namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 接口名称：PickUpSupplierCouponProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：餐厅自提折扣功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/6/2013 5:33 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PickUpSupplierCouponProvider : ISupplierCouponProvider
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/7/2013 2:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierCouponEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCouponEntity> supplierCouponEntityRepository;

        /// <summary>
        /// 字段supplierCouponTimeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCouponTimeEntity> supplierCouponTimeEntityRepository;

        /// <summary>
        /// 字段supplierCouponCustomerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/7/2013 2:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCouponCustomerEntity> supplierCouponCustomerEntityRepository;

        /// <summary>
        /// 取餐方式
        /// </summary>
        /// <value>
        /// 取餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DeliveryMethodType DeliveryMethodType
        {
            get
            {
                return DeliveryMethodType.PickUp;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PickUpSupplierCouponProvider" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierCouponEntityRepository">The supplierCouponEntityRepository</param>
        /// <param name="supplierCouponTimeEntityRepository">The supplierCouponTimeEntityRepository</param>
        /// <param name="supplierCouponCustomerEntityRepository">The supplierCouponCustomerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PickUpSupplierCouponProvider(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierCouponEntity> supplierCouponEntityRepository,
            INHibernateRepository<SupplierCouponTimeEntity> supplierCouponTimeEntityRepository,
            INHibernateRepository<SupplierCouponCustomerEntity> supplierCouponCustomerEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.supplierCouponEntityRepository = supplierCouponEntityRepository;
            this.supplierCouponTimeEntityRepository = supplierCouponTimeEntityRepository;
            this.supplierCouponCustomerEntityRepository = supplierCouponCustomerEntityRepository;
        }

        /// <summary>
        /// 取得折扣
        /// </summary>
        /// <param name="total">消费总额</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="now">下单时间</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 折扣
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierCouponModel> CalculateCoupon(decimal total, int supplierId, DateTime now, int? userId)
        {
            var day = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            var list = (from couponEntity in this.supplierCouponEntityRepository.EntityQueryable
                        from couponTimeEntity in this.supplierCouponTimeEntityRepository.EntityQueryable
                        where couponEntity.Id == couponTimeEntity.SupplierCoupon.Id &&
                        couponEntity.Supplier.SupplierId == supplierId &&
                        couponTimeEntity.DayWeek == day
                        select new
                            {
                                SupplierCouponId = couponEntity.Id,
                                Discount = couponEntity.TakeoutDiscount,
                                Description = couponEntity.TakeoutDescription,
                                TypeId = couponEntity.TakeoutCouponTypeId,
                                Min = couponEntity.TakeoutRateLower,
                                Max = couponEntity.TakeoutRateHigh,
                                couponEntity.OneUserMax,
                                couponEntity.NumberMaxUse,
                                couponEntity.BeginDate,
                                couponEntity.EndDate,
                                couponTimeEntity.OpenTime,
                                couponTimeEntity.CloseTime
                            }).ToList();

            var listDiscount = new List<SupplierCouponModel>();
            foreach (var item in list)
            {
                var beginDate = item.BeginDate ?? now;
                var endDate = item.EndDate ?? now;
                if (beginDate > now || endDate < now)
                {
                    continue;
                }

                var openTime = DateTime.Parse(string.Format("{0} {1}", now.ToString("yyyy-MM-dd"), item.OpenTime));
                var closeTime = DateTime.Parse(string.Format("{0} {1}", now.ToString("yyyy-MM-dd"), item.CloseTime));
                if (openTime > now || closeTime < now)
                {
                    continue;
                }

                var discount = item.Discount ?? 1;
                var min = item.Min ?? total;
                var max = item.Max ?? total;
                if (min > total || max < total)
                {
                    continue;
                }

                listDiscount.Add(new SupplierCouponModel
                {
                    SupplierCouponId = item.SupplierCouponId,
                    Description = item.Description,
                    Discount = discount,
                    CouponTypeId = item.TypeId ?? 0
                });
            }

            if (userId == null)
            {
                return listDiscount;
            }

            var tempSupplierCouponIdList = listDiscount.Select(p => p.SupplierCouponId).ToList();
            if (list.Where(p => tempSupplierCouponIdList.Contains(p.SupplierCouponId)).All(p => (p.OneUserMax ?? -1) <= 0 && (p.NumberMaxUse ?? -1) <= 0))
            {
                return listDiscount;
            }

            var customerEntity = this.customerEntityRepository.EntityQueryable.FirstOrDefault(p => p.LoginId == userId);
            var result = new List<SupplierCouponModel>();
            var supplierCouponIdList = listDiscount.Select(p => (int?)p.SupplierCouponId).ToList();
            var couponList = this.supplierCouponCustomerEntityRepository.EntityQueryable.Where(
                                p => supplierCouponIdList.Contains(p.SupplierCouponId))
                                .Select(p => new { p.SupplierCouponId, p.CustomerId })
                                .ToList();

            foreach (var item in listDiscount)
            {
                var supplierCoupon = list.FirstOrDefault(p => p.SupplierCouponId == item.SupplierCouponId);
                if (supplierCoupon == null)
                {
                    continue;
                }

                var numberMaxUseCount = couponList.Count(p => p.SupplierCouponId == item.SupplierCouponId);
                var numberMaxUse = supplierCoupon.NumberMaxUse ?? numberMaxUseCount - 1;
                if (numberMaxUse <= numberMaxUseCount)
                {
                    continue;
                }

                if ((supplierCoupon.OneUserMax ?? -1) <= 0)
                {
                    result.Add(item);
                    continue;
                }

                if (customerEntity == null)
                {
                    continue;
                }

                var oneUserMaxCount = couponList.Count(p => p.SupplierCouponId == item.SupplierCouponId && p.CustomerId == customerEntity.CustomerId);
                var oneUserMax = supplierCoupon.OneUserMax ?? oneUserMaxCount - 1;
                if (oneUserMax <= oneUserMaxCount)
                {
                    continue;
                }

                result.Add(item);
            }

            return result;
        }
    }
}
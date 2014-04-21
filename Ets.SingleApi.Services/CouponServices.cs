using System;

namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：CouponServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：优惠信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 11:29 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CouponServices : ICouponServices
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierCouponProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISupplierCouponProvider> supplierCouponProviderList;

        /// <summary>
        /// 字段supplierCouponProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:29 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISupplierCouponCodeProvider> supplierCouponCodeProviderList;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/7/2013 2:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CouponEntity> couponEntityRepository;

        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段tableReservationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TableReservationEntity> tableReservationEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="couponEntityRepository">The couponEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// <param name="supplierCouponCodeProviderList">The supplierCouponCodeProviderList</param>
        /// 创建者：周超
        /// 创建日期：12/9/2013 11:28 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CouponServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<CouponEntity> couponEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            List<ISupplierCouponProvider> supplierCouponProviderList,
            List<ISupplierCouponCodeProvider> supplierCouponCodeProviderList)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.couponEntityRepository = couponEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.supplierCouponProviderList = supplierCouponProviderList;
            this.supplierCouponCodeProviderList = supplierCouponCodeProviderList;
        }

        /// <summary>
        /// 取得优惠列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierCouponModel> GetSupplierCouponList(string source, SupplierCouponParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest,
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (parameter.Total <= 0)
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResultList<SupplierCouponModel>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                        Result = new List<SupplierCouponModel>()
                    };
            }

            if (parameter.UserId != null && !this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResultList<SupplierCouponModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new List<SupplierCouponModel>()
                };
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == (DeliveryMethodType)parameter.DeliveryMethodId);
            if (supplierCouponProvider == null)
            {
                return new ServicesResultList<SupplierCouponModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryMethodId,
                    Result = new List<SupplierCouponModel>()
                };
            }

            var supplierCouponList = supplierCouponProvider.CalculateCoupon(parameter.Total, parameter.SupplierId, parameter.DeliveryDate, parameter.UserId) ?? new List<SupplierCouponModel>();
            return new ServicesResultList<SupplierCouponModel>
            {
                StatusCode = supplierCouponList.Count == 0 ? (int)StatusCode.Succeed.Empty : (int)StatusCode.Succeed.Ok,
                Result = supplierCouponList
            };
        }

        /// <summary>
        /// 取得优惠信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<decimal> GetSupplierCoupon(string source, SupplierCouponParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (parameter.Total <= 0)
            {
                return new ServicesResult<decimal>();
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                };
            }

            if (parameter.UserId != null && !this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode
                };
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == (DeliveryMethodType)parameter.DeliveryMethodId);
            if (supplierCouponProvider == null)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryMethodId
                };
            }

            var supplierCouponList = supplierCouponProvider.CalculateCoupon(parameter.Total, parameter.SupplierId, parameter.DeliveryDate, parameter.UserId) ?? new List<SupplierCouponModel>();
            var result = ServicesCommon.CalculateCoupon(parameter.Total, ServicesCommon.CalculateCouponWay, supplierCouponList);
            return new ServicesResult<decimal>
                {
                    Result = result
                };
        }


        /// <summary>
        /// 验证优惠码是否可用
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：4/21/2014 10:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// <exception cref="System.NotImplementedException"></exception>
        public ServicesResult<bool> CheckIsEffective(string source, SupplierCouponCodeParameter parameter)
        {
            var coupon = (from couponEntity in this.couponEntityRepository.EntityQueryable
                          where couponEntity.CouponCode == parameter.CouponCode
                          && couponEntity.Supplier.SupplierId == parameter.SupplierId
                          select couponEntity).FirstOrDefault();
            //判断是否存在该优惠码
            if (coupon == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false
                };
            }
            //判断该优惠码是否在有效期内
            if (DateTime.Now < coupon.StartDate || DateTime.Now > coupon.ExpirationDate)
            {
                return new ServicesResult<bool>
                {
                    Result = false
                };
            }
            //按试用规则判断是否可以使用该优惠码
            if (coupon.UseRules == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false
                };
            }

            var deliverylist = (from deliveryEntity in this.deliveryEntityRepository.EntityQueryable
                            where deliveryEntity.CouponId == coupon.CouponId
                            select deliveryEntity).ToList();

            var tableReservationlist = (from tableReservationEntity in this.tableReservationEntityRepository.EntityQueryable
                                        where tableReservationEntity.CouponCode == coupon.CouponCode
                                        select tableReservationEntity).ToList();

            if (coupon.UseRules == 2)
            {
                if ((deliverylist.Count + tableReservationlist.Count) >= 1)
                {
                    return new ServicesResult<bool>
                    {
                        Result = false
                    };
                }
            }

            if (coupon.UseRules == 3)
            {
                var deliveryCount = deliverylist.Count(p => p.CustomerId == parameter.UserId);
                var tableReservationCount = tableReservationlist.Count(p => p.CustomerId == parameter.UserId);

                if ((deliveryCount + tableReservationCount) >= 1)
                {
                    return new ServicesResult<bool>
                    {
                        Result = false
                    };
                }
            }

            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得优惠码优惠计算结果
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回优惠码优惠计算结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierCouponCodeModel> GetSupplierCouponCode(string source, SupplierCouponCodeParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new SupplierCouponCodeModel()
                };
            }

            if (parameter.Total <= 0)
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    Result = new SupplierCouponCodeModel()
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierCouponCodeModel()
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new SupplierCouponCodeModel()
                };
            }

            var coupon = (from couponEntity in this.couponEntityRepository.EntityQueryable
                          where couponEntity.CouponCode == parameter.CouponCode
                          && couponEntity.Supplier.SupplierId == parameter.SupplierId
                          select couponEntity).FirstOrDefault();

            if (coupon == null)
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCouponCode,
                    Result = new SupplierCouponCodeModel()
                };
            }

            var supplierCouponCodeProvider = this.supplierCouponCodeProviderList.FirstOrDefault(p => p.CouponType == (CouponCodeType)coupon.CouponTypeId);
            if (supplierCouponCodeProvider == null)
            {
                return new ServicesResult<SupplierCouponCodeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryMethodId,
                    Result = new SupplierCouponCodeModel()
                };
            }

            var supplierCouponCode = supplierCouponCodeProvider.CalculateCoupon(parameter.CouponCode,parameter.Total) ?? new SupplierCouponCodeModel();
            return new ServicesResult<SupplierCouponCodeModel>
            {
                StatusCode = supplierCouponCode.CouponCode.IsEmptyOrNull() ? (int)StatusCode.Succeed.Empty : (int)StatusCode.Succeed.Ok,
                Result = supplierCouponCode
            };
        }
    }
}

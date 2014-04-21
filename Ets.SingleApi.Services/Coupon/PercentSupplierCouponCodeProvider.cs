using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.IRepository;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：PercentSupplierCouponCodeProvider
    /// 命名空间：Ets.SingleApi.Services.Coupon
    /// 类功能：百分比折扣优惠
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：4/21/2014 11:48 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PercentSupplierCouponCodeProvider : ISupplierCouponCodeProvider
    {
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
        /// 优惠码优惠类型
        /// </summary>
        /// <value>
        /// 优惠码优惠类型
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：21/4/2014 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CouponCodeType CouponType
        {
            get { return CouponCodeType.Percent; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentSupplierCouponCodeProvider" /> class.
        /// </summary>
        /// <param name="couponEntityRepository">The couponEntityRepository</param>
        /// 创建者：单琪彬
        /// 创建日期：4/21/2014 11:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PercentSupplierCouponCodeProvider(INHibernateRepository<CouponEntity> couponEntityRepository)
        {
            this.couponEntityRepository = couponEntityRepository;
        }

        /// <summary>
        /// 计算优惠
        /// </summary>
        /// <param name="couponCode">The couponCode</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// SupplierCouponModel
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：4/21/2014 10:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// <exception cref="System.NotImplementedException"></exception>
        public SupplierCouponCodeModel CalculateCoupon(string couponCode, decimal total)
        {
            var coupon = (from couponEntity in this.couponEntityRepository.EntityQueryable
                          where couponEntity.CouponCode == couponCode
                          select couponEntity).FirstOrDefault();

            var suppliercoupon = new SupplierCouponCodeModel();
            if (coupon != null)
            {
                if (coupon.Discount != null)
                {
                    suppliercoupon.Discount = (decimal)coupon.Discount;
                    var discountAmount = total * (coupon.Discount / 100);
                    suppliercoupon.DiscountAmount = (decimal)discountAmount;
                }
                else
                {
                    suppliercoupon.Discount = 0;
                    suppliercoupon.DiscountAmount = 0;
                }
                suppliercoupon.CouponTypeId = coupon.CouponTypeId;
                suppliercoupon.CouponId = coupon.CouponId;
                suppliercoupon.CouponCode = coupon.CouponCode;
                suppliercoupon.AmountPayable = total - suppliercoupon.DiscountAmount;
            }


            return suppliercoupon;
        }
    }
}

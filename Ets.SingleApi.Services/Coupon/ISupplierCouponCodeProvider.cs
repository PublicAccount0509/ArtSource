using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Services.Coupon
{
    /// <summary>
    /// 接口名称：ISupplierCouponCodeProvider
    /// 命名空间：Ets.SingleApi.Services.Coupon
    /// 接口功能：优惠码优惠功能
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：4/21/2014 9:15 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISupplierCouponCodeProvider
    {
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
        CouponCodeType CouponType { get; }

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
        SupplierCouponCodeModel CalculateCoupon(string couponCode, decimal total);
    }
}

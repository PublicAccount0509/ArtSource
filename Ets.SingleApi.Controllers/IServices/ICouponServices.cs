namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ICouponServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：折扣信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 9:53 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ICouponServices
    {
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
        ServicesResultList<SupplierCouponModel> GetSupplierCouponList(string source, SupplierCouponParameter parameter);

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
        ServicesResult<decimal> GetSupplierCoupon(string source, SupplierCouponParameter parameter);

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
        ServicesResult<bool> CheckIsEffective(string source, SupplierCouponCodeParameter parameter);

        /// <summary>
        /// 取得优惠码优惠计算结果
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 取得优惠码优惠计算结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：4/21/2014 5:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierCouponCodeModel> GetSupplierCouponCode(string source,
                                                                      SupplierCouponCodeParameter parameter);
    }
}
namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：ICouponService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Coupon服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface ICouponService
    {
        /// <summary>
        /// 取得优惠列表
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得优惠列表")]
        ListResponse<SupplierCoupon> SupplierCouponList(SupplierCouponRequst requst);

        /// <summary>
        /// 计算优惠信息
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：计算优惠信息")]
        Response<decimal> SupplierCoupon(SupplierCouponRequst requst);

        /// <summary>
        /// 检查优惠码是否可用
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：检查优惠码是否可用")]
        Response<bool> CheckIsEffective(SupplierCouponCodeRequst requst);

        /// <summary>
        /// 根据优惠码取得优惠计算结果
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回优惠计算结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 10:20 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：根据优惠码取得优惠计算结果")]
        Response<SupplierCouponCode> SupplierCouponCode(SupplierCouponCodeRequst requst);
    }
}
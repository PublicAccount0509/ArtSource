namespace Ets.SingleApi.Services.IDetailServices
{
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrderDetailServices
    /// 命名空间：Ets.SingleApi.Services.IDetailServices
    /// 接口功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:28 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOrderDetailServices
    {
        /// <summary>
        /// 添加外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<AddWaiMaiOrderModel> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter);
    }
}
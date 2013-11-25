namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrderServicesTemp
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOrderServicesTemp
    {
        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<WaiMaiOrderDetailModel> GetWaiMaiOrder(int orderId, int userId);

        /// <summary>
        /// 添加一个外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 6:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<AddWaiMaiOrderModel> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter);

        /// <summary>
        /// 确认外卖订单
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ConfirmWaiMaiOrderModel> ConfirmWaiMaiOrder(ConfirmWaiMaiOrderParameter parameter);

        /// <summary>
        /// 订单外卖支付
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<PaymentWaiMaiOrderModel> PaymentWaiMaiOrder(PaymentWaiMaiOrderParameter parameter);

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> GetOrderNumber(int orderType);
    }
}
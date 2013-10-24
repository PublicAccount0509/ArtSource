namespace Ets.SingleApi.Services.IDetailServices
{
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IWaiMaiOrderDetailServices
    /// 命名空间：Ets.SingleApi.Services.IDetailServices
    /// 接口功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 8:14 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IWaiMaiOrderDetailServices
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
        ServicesResult<WaiMaiOrderDetailModel> GetOrder(int orderId, int userId);

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
        DetailServicesResult<AddWaiMaiOrderModel> AddOrder(AddWaiMaiOrderParameter parameter);

        /// <summary>
        /// 确认订单
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
        DetailServicesResult<ConfirmWaiMaiOrderModel> ConfirmOrder(ConfirmWaiMaiOrderParameter parameter);

        /// <summary>
        /// 订单支付
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
        DetailServicesResult<PaymentWaiMaiOrderModel> PaymentOrder(PaymentWaiMaiOrderParameter parameter);
    }
}
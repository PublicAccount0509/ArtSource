namespace Ets.SingleApi.Services.IExternalServices
{
    using Ets.SingleApi.Model.ExternalServices;

    /// <summary>
    /// 接口名称：ISmsExternalServices
    /// 命名空间：Ets.SingleApi.Services.IExternalServices
    /// 接口功能：短信发送
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 20:59
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISynchronousOrderExternalServices
    {
        /// <summary>
        /// 同步金百万外卖订单
        /// </summary>
        /// <param name="deliveryRequest">The deliveryRequestDefault documentation</param>
        /// <returns>
        /// SynchronousOrderExternalServiceResult
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 4:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        SynchronousOrderExternalServiceResult SynchronousWaiMaiOrderToJinBaiWan(DeliveryRequest deliveryRequest, SingleApiExternalServiceAuthenParameter authenParameter);

        /// <summary>
        /// 同步金百万外卖订单支付状态
        /// </summary>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="isPaid">The  isPaid indicates whether</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <returns>
        /// SynchronousOrderExternalServiceResult
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 4:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        SynchronousOrderExternalServiceResult SynchronousWaiMaiOrderPaymentStatusToJinBaiWan(int orderId, bool isPaid, int paymentMethodId);
    }
}
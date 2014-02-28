namespace Ets.SingleApi.Services.Payment
{
    /// <summary>
    /// 接口名称：IOnlinePayment
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 接口功能：在线支付接口
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/28/2014 4:04 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOnlinePayment
    {
        /// <summary>
        /// 获取支付Url地址
        /// </summary>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 支付Url地址
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/28/2014 4:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaymentResult<string> GetPaymentUrl(IPaymentData parameter);

        /// <summary>
        /// 查询订单支付状态
        /// </summary>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 是否已支付
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/28/2014 4:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaymentResult<bool> QueryState(IPaymentData parameter);
    }
}

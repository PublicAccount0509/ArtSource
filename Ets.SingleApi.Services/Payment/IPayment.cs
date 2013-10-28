namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：IPayment
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：支付功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 1:33 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IPayment
    {
        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaymentType PaymentType { get; }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        OrderType OrderType { get; }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaymentResult Payment(IPaymentData parameter);

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaymentResult QueryState(IPaymentData parameter);
    }
}
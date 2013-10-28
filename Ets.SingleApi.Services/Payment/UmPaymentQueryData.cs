namespace Ets.SingleApi.Services
{
    using System;

    /// <summary>
    /// 类名称：UmPaymentQueryData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：支付
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 2:27 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentQueryData : IPaymentData
    {
        /// <summary>
        /// 设置或取得订单号
        /// </summary>
        /// <value>
        /// 订单号
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// 设置或取得支付时间
        /// </summary>
        /// <value>
        /// 支付时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime PayDate { get; set; }
    }
}
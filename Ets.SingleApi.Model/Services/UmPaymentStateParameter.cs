namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：UmPaymentStateParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：支付参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 3:07 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentStateParameter
    {
        /// <summary>
        /// Gets or sets the OrderId of UmPaymentParameter
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:07 PM
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

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }
    }
}
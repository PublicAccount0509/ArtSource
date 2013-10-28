namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：UmPaymentParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：支付参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 3:07 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentParameter
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
        /// Gets or sets the Amount of UmPaymentParameter
        /// </summary>
        /// <value>
        /// The Amount
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Amount { get; set; }

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

        /// <summary>
        /// Gets or sets the MerPriv of UmPaymentParameter
        /// </summary>
        /// <value>
        /// The MerPriv
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string MerPriv { get; set; }

        /// <summary>
        /// Gets or sets the ReturnUrl of PaymentParameter
        /// </summary>
        /// <value>
        /// The ReturnUrl
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ReturnUrl { get; set; }
    }
}
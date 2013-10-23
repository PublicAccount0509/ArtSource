namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：ConfirmWaiMaiOrderData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PaymentWaiMaiOrderData : IOrderData
    {
        /// <summary>
        /// Gets or sets the OrderId of ConfirmWaiMaiOrderData
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the UserId of ConfirmWaiMaiOrderData
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }
    }
}
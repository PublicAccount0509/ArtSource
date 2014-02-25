namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：OrderIsCompleteIsPaidModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：订单是否完成，订单是否已支付
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/24/2014 8:02 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderShoppingCartStatusModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsComplete
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 8:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsPaid
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 8:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaid { get; set; }

        /// <summary>
        /// 订单状态 1 订单生成中
        /// </summary>
        /// <value>
        /// The OrderStatus
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/25/2014 4:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderStatusId { get; set; }
    }
}
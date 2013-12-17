namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：OrderProviderType
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：订单类别属性
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/17/2013 3:32 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderProviderType
    {
        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/17/2013 3:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Gets or sets the type of the order source.
        /// </summary>
        /// <value>
        /// The type of the order source.
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/17/2013 3:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderSourceType OrderSourceType { get; set; }
    }
}
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：UmPaymentStateRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：百付宝支付状态查询
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：3/2/2014 3:30 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoPaymentStateRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the UserId of BaiFuBaoPaymentStateRequst
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/2/2014 3:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 设置或取得订单号
        /// </summary>
        /// <value>
        /// 订单号
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/2/2014 3:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：10/28/2013 3:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }

    }
}
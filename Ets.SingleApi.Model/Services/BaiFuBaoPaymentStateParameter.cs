namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：BaiFuBaoPaymentStateParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：百付宝查询订单支付状态
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/14/2014 2:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoPaymentStateParameter
    {
        /// <summary>
        /// 设置或取得 订单Id
        /// </summary>
        /// <value>
        /// 订单Id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 2:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }
        /// <summary>
        /// 设置或取得 订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 2:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }
    }
}

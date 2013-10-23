namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：AddWaiMaiOrderModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：添加外卖订单结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 3:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderModel
    {
        /// <summary>
        /// Gets or sets the OrderId of AddWaiMaiOrderModel
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
        /// Gets or sets the CustomerTotal of AddWaiMaiOrderModel
        /// </summary>
        /// <value>
        /// The CustomerTotal
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 3:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CustomerTotal { get; set; }
    }
}
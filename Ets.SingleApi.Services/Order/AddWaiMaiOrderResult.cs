namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：AddWaiMaiOrderResult
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderResult : IOrderResult
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
        /// Gets or sets the CustomerTotal of AddWaiMaiOrderResult
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

        /// <summary>
        /// Gets or sets the SupplierId of AddWaiMaiOrderResult
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 4:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 4:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishCount of AddWaiMaiOrderResult
        /// </summary>
        /// <value>
        /// The SupplierDishCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 4:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishCount { get; set; }
    }
}

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AddWaiMaiOrderResult
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：注册用户返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:23
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderResult
    {
        /// <summary>
        /// Gets or sets the OrderId of AddWaiMaiOrderResult
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:23
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
        /// 创建日期：10/23/2013 3:52 PM
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
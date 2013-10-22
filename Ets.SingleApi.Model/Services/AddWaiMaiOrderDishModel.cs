namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：AddWaiMaiOrderDishModel
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：添加外卖订单菜品
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:48 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderDishModel
    {
        /// <summary>
        /// Gets or sets the SupplierId of AddWaiMaiOrderDishModel
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishId of AddWaiMaiOrderDishModel
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of AddWaiMaiOrderDishModel
        /// </summary>
        /// <value>
        /// The Quantity
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Quantity { get; set; }
    }
}
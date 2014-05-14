namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierDishItem
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：传入菜品Id、数量列表
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：5/14/2014 9:56 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDishItem
    {
        /// <summary>
        /// 菜品ID
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:57 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// 菜品数量
        /// </summary>
        /// <value>
        /// 菜品数量
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:58 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DishCount { get; set; }
    }
}

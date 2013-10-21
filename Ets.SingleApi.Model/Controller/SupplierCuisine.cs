namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SimpleSupplierCuisine
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierCuisine
    {
        /// <summary>
        /// Gets or sets the Id of SimpleSupplierCuisine
        /// </summary>
        /// <value>
        /// The CuisineId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Name of SimpleSupplierCuisine
        /// </summary>
        /// <value>
        /// The Name
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishList of SimpleSupplierCuisine
        /// </summary>
        /// <value>
        /// The SupplierDishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierDish> SupplierDishList { get; set; }
    }
}
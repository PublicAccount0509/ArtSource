namespace Ets.SingleApi.Model.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SupplierCuisineModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierCuisineModel
    {
        /// <summary>
        /// Gets or sets the Id of SupplierCuisineModel
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
        /// Gets or sets the Name of SupplierCuisineModel
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
        /// Gets or sets the SupplierDishList of SupplierCuisineModel
        /// </summary>
        /// <value>
        /// The SupplierDishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierDishModel> SupplierDishList { get; set; }
    }
}
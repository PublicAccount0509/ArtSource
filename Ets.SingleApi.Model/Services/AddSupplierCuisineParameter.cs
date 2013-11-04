namespace Ets.SingleApi.Model.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：AddSupplierCuisineParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：添加外卖订单实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:46 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddSupplierCuisineParameter
    {
        /// <summary>
        /// Gets or sets the SupplierId of AddSupplierCuisineParameter
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:44 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierMenuCategoryTypeId of AddSupplierCuisineParameter
        /// </summary>
        /// <value>
        /// The SupplierMenuCategoryTypeId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierMenuCategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the CuisineList of AddSupplierCuisineParameter
        /// </summary>
        /// <value>
        /// The CuisineList
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SaveSupplierCuisineModel> CuisineList { get; set; }
    }
}
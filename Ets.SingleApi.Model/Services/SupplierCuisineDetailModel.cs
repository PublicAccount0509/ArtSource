namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：SupplierCuisineDetailModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierCuisineDetailModel
    {
        /// <summary>
        /// Gets or sets the Id of SupplierCuisineDetailModel
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
        /// Gets or sets the SupplierCategoryId of SupplierCuisineDetailModel
        /// </summary>
        /// <value>
        /// The SupplierCategoryId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 15:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Name of SupplierCuisineDetailModel
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
        /// Gets or sets the CategoryDescription of SupplierCuisineDetailModel
        /// </summary>
        /// <value>
        /// The CategoryDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 15:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CategoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the CuisineNo of SupplierCuisineDetailModel
        /// </summary>
        /// <value>
        /// The CuisineNo
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 11:22
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CategoryNo { get; set; }
    }
}
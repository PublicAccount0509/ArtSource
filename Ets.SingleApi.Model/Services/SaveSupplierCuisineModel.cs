namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：SaveSupplierCuisineModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：添加餐厅菜品
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/1/2013 4:22 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveSupplierCuisineModel
    {
        /// <summary>
        /// Gets or sets the CategoryId of SaveSupplierCuisineModel
        /// </summary>
        /// <value>
        /// The CategoryId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:18 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the cuisine.
        /// </summary>
        /// <value>
        /// The name of the cuisine.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineName { get; set; }

        /// <summary>
        /// Gets or sets the CuisineNo of SaveSupplierCuisineModel
        /// </summary>
        /// <value>
        /// The CuisineNo
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CuisineNo { get; set; }

        /// <summary>
        /// Gets or sets the CuisineDescription of SaveSupplierCuisineModel
        /// </summary>
        /// <value>
        /// The CuisineDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineDescription { get; set; }

        /// <summary>
        /// Gets or sets the CuisineImage of SaveSupplierCuisineModel
        /// </summary>
        /// <value>
        /// The CuisineImage
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineImage { get; set; }

        /// <summary>
        /// Gets or sets the type of the cuisine.
        /// </summary>
        /// <value>
        /// The type of the cuisine.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineType { get; set; }
    }
}
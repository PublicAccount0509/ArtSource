namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：CuisineCategoryModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CuisineModel
    {
        /// <summary>
        /// Gets or sets the Id of CuisineModel
        /// </summary>
        /// <value>
        /// The Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CuisineId { get; set; }

        /// <summary>
        /// Gets or sets the CuisineName of CuisineModel
        /// </summary>
        /// <value>
        /// The CuisineName
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineName { get; set; }

        /// <summary>
        /// Gets or sets the No of CuisineModel
        /// </summary>
        /// <value>
        /// The No
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CuisineNo { get; set; }

        /// <summary>
        /// Gets or sets the SupplierCount of CuisineModel
        /// </summary>
        /// <value>
        /// The SupplierCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 11:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierCount { get; set; }
    }
}
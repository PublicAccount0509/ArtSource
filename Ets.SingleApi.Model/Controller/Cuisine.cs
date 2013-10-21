namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：Cuisine
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：菜系信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 16:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class Cuisine
    {
        /// <summary>
        /// Gets or sets the Id of Cuisine
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
        /// Gets or sets the CuisineName of Cuisine
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
        /// Gets or sets the No of Cuisine
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
        /// Gets or sets the SupplierCount of Cuisine
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
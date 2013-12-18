namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：PackageCuisine
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：套餐类目信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PackageCuisine
    {
        /// <summary>
        /// Gets or sets the Id of PackageCuisine
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
        /// Gets or sets the Name of PackageCuisine
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
        /// Gets or sets the CanSelectCount of PackageCuisine
        /// </summary>
        /// <value>
        /// The CanSelectCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CanSelectCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsChoose
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsChoose { get; set; }

        /// <summary>
        /// Gets or sets the PackageDishList of PackageCuisine
        /// </summary>
        /// <value>
        /// The PackageDishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<PackageDish> PackageDishList { get; set; }
    }
}
namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetSupplierListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetSupplierList传入的参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetSupplierListParameter
    {
        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the FeatureId of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/22 10:26
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the CuisineId of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The CuisineId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/21 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CuisineId { get; set; }

        /// <summary>
        /// Gets or sets the BusinessAreaId of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The BusinessAreaId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BusinessAreaId { get; set; }

        /// <summary>
        /// Gets or sets the RegionId of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The RegionId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RegionId { get; set; }

        /// <summary>
        /// Gets or sets the UserLat of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The UserLat
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double UserLat { get; set; }

        /// <summary>
        /// Gets or sets the UserLong of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The UserLong
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double UserLong { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the Distance of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The Distance
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the OrderByType of GetSupplierListParameter
        /// </summary>
        /// <value>
        /// The OrderBy
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderByType { get; set; }
    }
}
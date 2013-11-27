namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetSearchSupplierListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetSearchSupplierList传入的参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetSearchSupplierListParameter
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
        /// Gets or sets the RegionId of GetSearchSupplierListParameter
        /// </summary>
        /// <value>
        /// The RegionId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the UserLat of GetSearchSupplierListParameter
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
        /// Gets or sets the UserLong of GetSearchSupplierListParameter
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
        /// Gets or sets the Distance of GetSearchSupplierListParameter
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
        /// Gets or sets the BuildingLat of GetSearchSupplierListParameter
        /// </summary>
        /// <value>
        /// The UserLat
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double BuildingLat { get; set; }

        /// <summary>
        /// Gets or sets the BuildingLong of GetSearchSupplierListParameter
        /// </summary>
        /// <value>
        /// The UserLong
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double BuildingLong { get; set; }
    }
}
namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetSearchActivitiesSupplierListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetSearchActivitiesSupplierList传入的参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetSearchActivitiesSupplierListParameter
    {
        /// <summary>
        /// Gets or sets the FeatureId of GetSearchActivitiesSupplierListParameter
        /// </summary>
        /// <value>
        /// The FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:41 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the ActivitiesId of GetSearchActivitiesSupplierListParameter
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:41 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ActivitiesId { get; set; }

        /// <summary>
        /// Gets or sets the CityId of GetGroupSupplierListParameter
        /// </summary>
        /// <value>
        /// The CityId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:41 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CityId { get; set; }

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
    }
}
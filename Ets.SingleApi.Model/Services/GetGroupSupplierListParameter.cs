namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetGroupSupplierListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetSupplierList传入的参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetGroupSupplierListParameter
    {
        /// <summary>
        /// Gets or sets the FeatureId of GetGroupSupplierListParameter
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
        /// Gets or sets the SupplierGroupId of GetGroupSupplierListParameter
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:41 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierGroupId { get; set; }

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
    }
}
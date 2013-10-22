namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：DingTaiSupplierListResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiSupplierListResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the SupplierList of DingTaiSupplierListResponse
        /// </summary>
        /// <value>
        /// The SupplierList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<Supplier> Result { get; set; }
    }
}
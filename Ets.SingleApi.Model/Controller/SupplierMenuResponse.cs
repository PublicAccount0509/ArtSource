namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SupplierMenuResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierMenuResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of SupplierMenuResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierCuisine> Result { get; set; }
    }
}
namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：GetGroupSupplierResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅分店列表返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:22
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetGroupSupplierResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of GetGroupSupplierResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<GroupSupplier> Result { get; set; }
    }
}
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：GetSupplierResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：注册用户API返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:22
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetRoughSupplierResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of GetSupplierResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public RoughSupplier Result { get; set; }
    }
}
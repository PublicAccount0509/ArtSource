namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：IsFollowerSupplierResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：判定是否收藏餐厅返回结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class IsFollowerSupplierResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/8/2013 5:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IsFollowerSupplierResult Result { get; set; }
    }
}
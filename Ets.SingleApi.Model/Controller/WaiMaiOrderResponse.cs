namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：WaiMaiOrderResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiOrderResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of WaiMaiOrderResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 9:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderDetail Result { get; set; }
    }
}
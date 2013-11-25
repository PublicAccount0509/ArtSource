namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：GetOrderResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：返回订单详情
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetOrderResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of GetOrderResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 8:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IOrderDetailModel Result { get; set; }
    }
}
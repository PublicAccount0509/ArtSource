namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：UmPaymentStateResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentStateResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of UmPaymentStateResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentStateResult Result { get; set; }
    }
}
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：CancelQueueRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：3/25/2014 9:52 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CancelQueueRequst : ApiRequst
    {
        /// <summary>
        /// 排队订单Id
        /// </summary>
        /// <value>
        /// The TableReservationId
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 9:28 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int QueueId { get; set; }
    }
}

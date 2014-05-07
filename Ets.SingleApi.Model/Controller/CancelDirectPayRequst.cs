namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：CancelDirectPayRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：5/6/2014 8:52 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CancelDirectPayRequst : ApiRequst
    {
        /// <summary>
        /// 当面付订单Id
        /// </summary>
        /// <value>
        /// The DirectPayId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/6/2014 8:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DirectPayId { get; set; }
    }
}

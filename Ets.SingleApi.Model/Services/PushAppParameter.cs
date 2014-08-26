
namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：PushAppParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：推送APP消息体
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/11 17:25
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PushAppParameter
    {
        /// <summary>
        /// Gets or sets the OrderId of PushAppParameter
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/11 17:27
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OrderId { get; set; }

        /// <summary>
        /// 设备号或者 MAC
        /// </summary>
        /// <value>
        /// The DeviceNumber
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/14 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeviceNumber { get; set; }
    }
}

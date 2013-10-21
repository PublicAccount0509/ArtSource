namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SendAuthCodeResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：短信发送结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 21:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SendAuthCodeResponse : ApiResponse
    {
        /// <summary>
        /// 设置或获取发送结果
        /// </summary>
        /// <value>
        /// 发送结果
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SendAuthCodeResult Result { get; set; }
    }
}

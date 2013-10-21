namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：SmsResult
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：短信发送结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 20:59
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SmsResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/18 9:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
            this.Result = string.Empty;
        }

        /// <summary>
        /// 设置或获取状态码
        /// </summary>
        /// <value>
        /// 状态码
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// 设置或获取发送短信的结果
        /// </summary>
        /// <value>
        /// 发送结果
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Result { get; set; }
    }
}
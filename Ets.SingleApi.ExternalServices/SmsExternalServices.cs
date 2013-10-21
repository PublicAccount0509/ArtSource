namespace Ets.SingleApi.ExternalServices
{
    using Ets.SingleApi.ExternalServices.SmsSoap;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.ExternalServices;
    using Ets.SingleApi.Services.IExternalServices;

    /// <summary>
    /// 类名称：SmsExternalServices
    /// 命名空间：Ets.SingleApi.ExternalServices
    /// 类功能：短信发送
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 21:14
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SmsExternalServices : ISmsExternalServices
    {
        /// <summary>
        /// 无频率限制的发送短信
        /// </summary>
        /// <param name="mobile">手机号使用逗号分隔</param>
        /// <param name="message">短信内容</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsResult SendSms(string mobile, string message)
        {
            var smsSoapClient = new SmsSoapClient();
            var result = smsSoapClient.SendSms(mobile, message);
            return new SmsResult
                {
                    Result = result
                };
        }

        /// <summary>
        /// 随机选择通道发送,用于营销使用(不使用主通道)
        /// </summary>
        /// <param name="mobile">手机号使用逗号分隔</param>
        /// <param name="message">短信内容</param>
        /// <param name="smsSendsType">短信发送类型</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsResult SendSmsBase(string mobile, string message, SmsSendsType smsSendsType)
        {
            var smsSoapClient = new SmsSoapClient();
            var result = smsSoapClient.SendSmsBase(mobile, message, (SmsSendType)smsSendsType);
            return new SmsResult
            {
                Result = result
            };
        }
    }
}
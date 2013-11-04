namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：TelephoneSendPassword
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：短信发送密码
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 11:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TelephoneSendPassword : ISendPassword
    {
        /// <summary>
        /// 发送方式
        /// </summary>
        /// <value>
        /// 发送方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:14
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PasswordType SendType
        {
            get
            {
                return PasswordType.Telephone;
            }
        }

        /// <summary>
        /// 字段smsDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsDetailServices smsDetailServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneSendPassword"/> class.
        /// </summary>
        /// <param name="smsDetailServices">The smsDetailServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public TelephoneSendPassword(ISmsDetailServices smsDetailServices)
        {
            this.smsDetailServices = smsDetailServices;
        }

        /// <summary>
        /// 向用户发送密码
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="content">内容</param>
        /// <returns>
        /// 发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:14
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SendPasswordData Send(string account, string content)
        {
            var message = string.Format(ServicesCommon.SmsFindPasswordMessage, content);
            var result = this.smsDetailServices.SendSms(account, message);
            if (result == null)
            {
                return new SendPasswordData
                {
                    Result = false,
                    StatusCode = (int)StatusCode.General.SmsSendError
                };
            }

            return new SendPasswordData
            {
                Result = result.StatusCode == (int)StatusCode.Succeed.Ok,
                StatusCode = result.StatusCode
            };
        }
    }
}

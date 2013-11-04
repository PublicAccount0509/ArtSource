namespace Ets.SingleApi.Services
{
    using System.Net.Mail;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EmailSendPassword
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：邮件发送密码
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 11:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EmailSendPassword : ISendPassword
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
                return PasswordType.Email;
            }
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
            var mailContent = string.Format(ServicesCommon.EmailFindPasswordMessage, content);
            var mailSubject = ServicesCommon.EmailSubject;
            var emailAddress = ServicesCommon.EmailAddress;
            var emailPassword = ServicesCommon.EmailPassword;
            var emailServer = ServicesCommon.EmailServer;

            using (var onemail = new MailMessage())
            {
                onemail.BodyEncoding = System.Text.Encoding.UTF8;
                onemail.IsBodyHtml = true;
                onemail.From = new MailAddress(emailAddress, emailPassword);
                onemail.To.Add(new MailAddress(account, mailSubject));
                onemail.Subject = mailSubject;
                onemail.Body = mailContent;
                onemail.BodyEncoding = System.Text.Encoding.UTF8;

                using (var client = new SmtpClient(emailServer))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(emailAddress, emailPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(onemail);
                }
            }

            return new SendPasswordData
            {
                Result = true,
                StatusCode = (int)StatusCode.Succeed.Ok
            };
        }
    }
}
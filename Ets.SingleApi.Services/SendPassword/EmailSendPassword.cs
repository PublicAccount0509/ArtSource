namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

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
            return new SendPasswordData();
        }
    }
}
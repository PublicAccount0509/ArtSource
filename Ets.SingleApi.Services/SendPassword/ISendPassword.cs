namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：ISendPassword
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：向用户发送密码
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 11:14
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISendPassword
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
        PasswordType SendType { get; }

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
        SendPasswordData Send(string account, string content);
    }
}
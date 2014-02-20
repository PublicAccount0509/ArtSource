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
        /// <param name="smsSource">客户端应用名称 +业务场景。 如用户在眉州东坡找回密码时，可传值：眉州东坡web找回密码</param>
        /// <param name="supplierId">如果客户端调用时业务场景无餐厅概念（如用户注册），传入null即可</param>
        /// <param name="isVoiceSms">是否要语音短信</param>
        /// <returns>
        /// 发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:14
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        SendPasswordData Send(string account, string content, string smsSource, int? supplierId, bool isVoiceSms);
    }
}
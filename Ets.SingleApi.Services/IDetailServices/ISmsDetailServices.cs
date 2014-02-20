namespace Ets.SingleApi.Services.IDetailServices
{
    using System;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.DetailServices;

    /// <summary>
    /// 接口名称：ISmsDetailServices
    /// 命名空间：Ets.SingleApi.IDetailServices
    /// 接口功能：短信发送功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 21:19
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISmsDetailServices
    {
        /// <summary>
        /// 无频率限制的发送短信
        /// </summary>
        /// <param name="mobile">手机号使用逗号分隔</param>
        /// <param name="message">短信内容</param>
        /// <param name="smsSource">客户端应用名称 +业务场景。 如用户在眉州东坡找回密码时，可传值：眉州东坡web找回密码</param>
        /// <param name="supplierId">如果客户端调用时业务场景无餐厅概念（如用户注册），传入null即可</param>
        /// <param name="isVoiceSms">是否要语音短信</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<string> SendSms(string mobile, string message, string smsSource, int? supplierId, bool isVoiceSms);

        /// <summary>
        /// 发送短信，如果失败，ErrorMessage会附带错误信息
        /// 自动检测发送频率，如果间隔过短会发送失败
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="message">短信内容</param>
        /// <param name="lastSendTime">上次支付时间</param>
        /// <param name="smsSource">客户端应用名称 +业务场景。 如用户在眉州东坡找回密码时，可传值：眉州东坡web找回密码</param>
        /// <param name="supplierId">如果客户端调用时业务场景无餐厅概念（如用户注册），传入null即可</param>
        /// <param name="isVoiceSms">是否要语音短信</param>
        /// <returns>
        /// 返回发送结果，True成功，False失败
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> Send(string mobile, string message, DateTime? lastSendTime, string smsSource, int? supplierId, bool isVoiceSms);

        /// <summary>
        /// 随机选择通道发送,用于营销使用(不使用主通道)
        /// </summary>
        /// <param name="mobile">手机号使用逗号分隔</param>
        /// <param name="message">短信内容</param>
        /// <param name="smsSendsType">短信发送类型</param>
        /// <param name="smsSource">客户端应用名称 +业务场景。 如用户在眉州东坡找回密码时，可传值：眉州东坡web找回密码</param>
        /// <param name="supplierId">如果客户端调用时业务场景无餐厅概念（如用户注册），传入null即可</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<string> SendSmsBase(string mobile, string message, SmsSendsType smsSendsType, string smsSource, int? supplierId);
    }
}
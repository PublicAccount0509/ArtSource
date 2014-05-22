﻿namespace Ets.SingleApi.ExternalServices
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
        /// <param name="smsSource">客户端应用名称 +业务场景。 如用户在眉州东坡找回密码时，可传值：眉州东坡web找回密码</param>
        /// <param name="supplierId">如果客户端调用时业务场景无餐厅概念（如用户注册），传入null即可</param>
        /// <param name="isVoiceSms">是否要语音短信</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsResult SendSms(string mobile, string message,string smsSource,int? supplierId,bool isVoiceSms)
        {
            var smsSoapClient = new SmsSoapClient();
            //var result = smsSoapClient.SendSms(mobile, message);
            var result = smsSoapClient.SendSmsSaveLog(mobile, message, smsSource, supplierId, isVoiceSms);
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
        public SmsResult SendSmsBase(string mobile, string message, SmsSendsType smsSendsType,string smsSource,int? supplierId)
        {
            var smsSoapClient = new SmsSoapClient();
            //var result = smsSoapClient.SendSmsBase(mobile, message, (SmsSendType)smsSendsType);
            var result = smsSoapClient.SendSmsBaseSaveLog(mobile, message, (SmsSendType)smsSendsType,smsSource,supplierId);
            return new SmsResult
            {
                Result = result
            };
        }
    }
}
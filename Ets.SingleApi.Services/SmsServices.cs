namespace Ets.SingleApi.Services
{
    using System;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SmsServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：短信发送服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 22:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SmsServices : ISmsServices
    {
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
        /// Initializes a new instance of the <see cref="SmsServices"/> class.
        /// </summary>
        /// <param name="smsDetailServices">The smsDetailServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsServices(ISmsDetailServices smsDetailServices)
        {
            this.smsDetailServices = smsDetailServices;
        }

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SendAuthCodeModel> SendAuthCode(SendAuthCodeParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<SendAuthCodeModel>
                {
                    Result = new SendAuthCodeModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var message = this.GetAuthCodeMessage(parameter.Type);
            if (message.IsEmptyOrNull())
            {
                return new ServicesResult<SendAuthCodeModel>
                    {
                        Result = new SendAuthCodeModel(),
                        StatusCode = (int)StatusCode.Validate.InvalidAuthCodeType
                    };
            }

            var code = CommonUtility.RandNum(6);
            CacheUtility.GetInstance().Set(string.Format("{0}{1}", ServicesCommon.AuthCodeCacheKey, parameter.Telephone), code, DateTime.Now.AddMinutes(5));

            if (parameter.Second.HasValue)
            {
                var second = DateTime.Now.AddSeconds(parameter.Second.Value).ToString("yyyy-MM-dd HH:mm:ss");
                CacheUtility.GetInstance().Set(string.Format("{0}{1}", ServicesCommon.AuthSecondCacheKey, parameter.Second), second, DateTime.Now.AddMinutes(5));
            }

            var result = this.smsDetailServices.SendSms(parameter.Telephone, string.Format(message, code));
            if (result == null)
            {
                return new ServicesResult<SendAuthCodeModel>
                {
                    Result = new SendAuthCodeModel(),
                    StatusCode = (int)StatusCode.General.SmsSendError
                };
            }

            return new ServicesResult<SendAuthCodeModel>
                {
                    Result = new SendAuthCodeModel { Result = result.StatusCode == (int)StatusCode.Succeed.Ok },
                    StatusCode = result.StatusCode
                };
        }

        /// <summary>
        /// 获取发送信息
        /// </summary>
        /// <param name="type">短信发送类型</param>
        /// <returns>
        /// 发送信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetAuthCodeMessage(string type)
        {
            if (type == ServicesCommon.EtkAuthCodeType)
            {
                return "短信验证码：{0}[易淘食]";
            }

            if (type == ServicesCommon.WaiMaiAuthCodeType)
            {
                return "短信验证码：{0}[叫外卖]";
            }

            return string.Empty;
        }
    }
}
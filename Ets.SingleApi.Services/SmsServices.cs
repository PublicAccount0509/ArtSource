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
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SendAuthCodeModel> SendAuthCode(string source, SendAuthCodeParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<SendAuthCodeModel>
                {
                    Result = new SendAuthCodeModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var code = CommonUtility.RandNum(6);
            CacheUtility.GetInstance().Set(string.Format("{0}_{1}{2}", source, ServicesCommon.AuthCodeCacheKey, parameter.Telephone), code, DateTime.Now.AddMinutes(ServicesCommon.AuthCodeExpiredTime));

            if (parameter.Second.HasValue)
            {
                var second = DateTime.Now.AddSeconds(parameter.Second.Value).ToString("yyyy-MM-dd HH:mm:ss");
                CacheUtility.GetInstance().Set(string.Format("{0}_{1}{2}", source, ServicesCommon.AuthSecondCacheKey, parameter.Second), second, DateTime.Now.AddMinutes(ServicesCommon.AuthCodeExpiredTime));
            }

            var result = this.smsDetailServices.SendSms(parameter.Telephone, string.Format(ServicesCommon.AuthCodeMessage, code), parameter.SmsSource, parameter.SupplierId, parameter.IsVoiceSms);
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
    }
}
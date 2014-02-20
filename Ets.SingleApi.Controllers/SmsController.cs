namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SmsController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：短信发送API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 21:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SmsController : SingleApiController
    {
        /// <summary>
        /// 字段smsServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsServices smsServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsController"/> class.
        /// </summary>
        /// <param name="smsServices">The smsServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SmsController(ISmsServices smsServices)
        {
            this.smsServices = smsServices;
        }

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="requst">发送信息</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<SendAuthCodeModel> SendAuthCode(SendAuthCodeRequst requst)
        {
            if (requst == null)
            {
                return new Response<SendAuthCodeModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new SendAuthCodeModel()
                };
            }

            var result = this.smsServices.SendAuthCode(this.Source, new SendAuthCodeParameter
            {
                Telephone = (requst.Telephone ?? string.Empty).Trim(),
                Second = requst.Second,
                SmsSource = requst.SmsSource,
                SupplierId = requst.SupplierId,
                IsVoiceSms = requst.IsVoiceSms
            });

            return new Response<SendAuthCodeModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }
    }
}
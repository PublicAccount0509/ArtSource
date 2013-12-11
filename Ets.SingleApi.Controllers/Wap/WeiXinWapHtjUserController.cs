namespace Ets.SingleApi.Controllers.Wap
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WeiXinWapHtjUserController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：微信对接控制器
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/11/2013 10:45 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WeiXinWapHtjUserController : SingleApiController
    {
        /// <summary>
        /// 字段htjExtendServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHtjExtendServices htjExtendServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeiXinWapHtjUserController"/> class.
        /// </summary>
        /// <param name="htjExtendServices">The htjExtendServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WeiXinWapHtjUserController(IHtjExtendServices htjExtendServices)
        {
            this.htjExtendServices = htjExtendServices;
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<HtjUserExtendResult> Register(HtjRegisterUserRequest requst)
        {
            if (requst == null)
            {
                return new Response<HtjUserExtendResult>
                {
                    Result = new HtjUserExtendResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var registerResult = this.htjExtendServices.Register(this.Source, new HtjRegisterUserParameter
                {
                    WeChatId = (requst.WeChatId ?? string.Empty).Trim(),
                    UserId = requst.UserId,
                    InsBy = (requst.InsBy ?? string.Empty).Trim(),
                    UpdBy = (requst.UpdBy ?? string.Empty).Trim(),
                    Recsts = (requst.Recsts ?? string.Empty).Trim(),
                    SourceCd = (requst.SourceCd ?? string.Empty).Trim()
                });

            if (registerResult.Result == null)
            {
                return new Response<HtjUserExtendResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = registerResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : registerResult.StatusCode
                    },
                    Result = new HtjUserExtendResult()
                };
            }

            var result = new HtjUserExtendResult
            {
                WeChatId = (registerResult.Result.WeChatId ?? string.Empty).Trim(),
                UserId = registerResult.Result.UserId,
                InsBy = (registerResult.Result.InsBy ?? string.Empty).Trim(),
                UpdBy = (registerResult.Result.UpdBy ?? string.Empty).Trim(),
                Recsts = (registerResult.Result.Recsts ?? string.Empty).Trim(),
                SourceCd = (registerResult.Result.SourceCd ?? string.Empty).Trim(),
                InsDt = registerResult.Result.InsDt,
                UpdDt = registerResult.Result.UpdDt
            };

            return new Response<HtjUserExtendResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = registerResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="weChatId">The weChatId</param>
        /// <param name="sourceCd">The sourceCd</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<HtjUserExtendResult> GetUser(string weChatId, string sourceCd)
        {
            var getUserResult = this.htjExtendServices.GetUser(this.Source, weChatId, sourceCd);
            if (getUserResult.Result == null)
            {
                return new Response<HtjUserExtendResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getUserResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getUserResult.StatusCode
                    },
                    Result = new HtjUserExtendResult()
                };
            }

            var result = new HtjUserExtendResult
            {
                WeChatId = (getUserResult.Result.WeChatId ?? string.Empty).Trim(),
                UserId = getUserResult.Result.UserId,
                InsBy = (getUserResult.Result.InsBy ?? string.Empty).Trim(),
                UpdBy = (getUserResult.Result.UpdBy ?? string.Empty).Trim(),
                Recsts = (getUserResult.Result.Recsts ?? string.Empty).Trim(),
                SourceCd = (getUserResult.Result.SourceCd ?? string.Empty).Trim(),
                InsDt = getUserResult.Result.InsDt,
                UpdDt = getUserResult.Result.UpdDt
            };

            return new Response<HtjUserExtendResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = getUserResult.StatusCode
                },
                Result = result
            };
        }
    }
}
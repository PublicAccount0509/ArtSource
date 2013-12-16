namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：WeiXinWapHtjUserService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：黄太吉用户服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/14/2013 6:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WeiXinWapHtjUserService : IWeiXinWapHtjUserService
    {
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
        [WebInvoke(UriTemplate = "/Register", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<HtjUser> Register(HtjRegisterUserRequest requst)
        {
            return new Response<HtjUser>();
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
        [WebGet(UriTemplate = "/GetUser?weChatId={weChatId}&sourceCd={sourceCd}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<HtjUserExtendResult> GetUser(string weChatId, string sourceCd)
        {
            return new Response<HtjUserExtendResult>();
        }
    }
}
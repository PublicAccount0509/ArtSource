namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：AuthenService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：Authen服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AuthenService : IAuthenService
    {
        /// <summary>
        /// 用户账户或邮箱登陆方法
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Login", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<LoginResult> Login(LoginRequst requst)
        {
            return new Response<LoginResult>();
        }
    }
}
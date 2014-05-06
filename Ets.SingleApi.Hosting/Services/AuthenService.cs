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

        /// <summary>
        /// 手机验证登陆方法
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
        [WebInvoke(UriTemplate = "/AuthLogin", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<AuthLoginResult> AuthLogin(AuthLoginRequst requst)
        {
            return new Response<AuthLoginResult>();
        }

        /// <summary>
        /// 第三方登录
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 11:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/OAuthLogin", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<OAuthLoginResult> OAuthLogin(OAuthLoginRequst requst)
        {
            return new Response<OAuthLoginResult>();
        }

        /// <summary>
        /// 仅通过手机号登录（自动登录）
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：4/30/2014 4:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/TelephoneNumLogin", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<TelephoneNumLoginResult> TelephoneNumLogin(TelephoneNumLoginRequst requst)
        {
            return new Response<TelephoneNumLoginResult>();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Password/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> Password(string id, PasswordRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SetPassword", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SetPassword(SetPasswordRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/FindPassword", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> FindPassword(FindPasswordRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AuthCode", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> AuthCode(AuthCodeRequst requst)
        {
            return new Response<bool>();
        }
    }
}
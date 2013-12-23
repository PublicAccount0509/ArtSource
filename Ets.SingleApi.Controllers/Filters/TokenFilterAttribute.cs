namespace Ets.SingleApi.Controllers.Filters
{
    using System;
    using System.Configuration;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：TokenFilterAttribute.Filters
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：使用token方式验证，验证通过后更新AccessToken和AppInfo
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/29/2013 5:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TokenFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在调用操作方法之前发生。
        /// </summary>
        /// <param name="actionContext">操作上下文。</param>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!ControllersCommon.ApplicationValidationEnabled)
            {
                return;
            }

            var controller = ((SingleApiController)actionContext.ControllerContext.Controller);
            var token = actionContext.Request.Headers.Read("Token");
            if (token.IsEmptyOrNull())
            {
                var exception = new Exception("Token无效");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            var filterServices = CastleUtility.GetInstance().Container.Resolve<IFilterServices>();
            if (filterServices == null)
            {
                return;
            }

            var result = filterServices.GetToken(token.Trim());
            if (result.Result == null)
            {
                var exception = new Exception("Token无效");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            if (result.Result.AccessToken.IsEmptyOrNull() || result.Result.UserId == null)
            {
                var exception = new Exception("Token无效");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            controller.UserId = result.Result.UserId.Value;
            int tokenExpiresIn;
            if (!int.TryParse(ConfigurationManager.AppSettings["TokenExpiresIn"], out tokenExpiresIn))
            {
                return;
            }

            if (result.Result.TokenDateTime == null)
            {
                return;
            }

            if (result.Result.TokenDateTime.Value.AddSeconds(tokenExpiresIn) < DateTime.Now)
            {
                var exception = new Exception("Token已过期");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }
        }
    }
}
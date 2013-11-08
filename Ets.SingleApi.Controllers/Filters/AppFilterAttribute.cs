namespace Ets.SingleApi.Controllers.Filters
{
    using System;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：AppFilterAttribute
    /// 命名空间：Ets.SingleApi.Controllers.Filters
    /// 类功能：App验证
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/30/2013 2:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AppFilterAttribute : ActionFilterAttribute
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
            var controller = ((SingleApiController)actionContext.ControllerContext.Controller);
            if (!ControllersCommon.ApplicationValidationEnabled)
            {
                controller.AppKey = ControllersCommon.DefaultAppKey;
                return;
            }

            var appKey = actionContext.Request.Headers.Read("AppKey");
            if (appKey.IsEmptyOrNull())
            {
                var exception = new Exception("未认证的客户端AppKey无效");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            var appPassword = actionContext.Request.Headers.Read("AppPassword");
            if (appPassword.IsEmptyOrNull())
            {
                var exception = new Exception("未认证的客户端AppPassword无效");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            var filterServices = CastleUtility.GetInstance().Container.Resolve<IFilterServices>();
            if (filterServices == null)
            {
                return;
            }

            var result = filterServices.ValidateApp(appKey.Trim(), appPassword.Trim());
            if (!result.Result)
            {
                var exception = new Exception("未认证的客户端");
                exception.WriteLog("Ets.SingleApi.Filter");
                throw exception;
            }

            controller.AppKey = appKey;
        }
    }
}
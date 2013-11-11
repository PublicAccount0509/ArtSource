namespace Ets.SingleApi.Interceptors
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    using Castle.DynamicProxy;

    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ControllerInterceptor
    /// 命名空间：Ets.SingleApi.Interceptors
    /// 类功能：Controller的拦截
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 16:38
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ControllerInterceptor : IInterceptor
    {
        /// <summary>
        /// 拦截方法
        /// </summary>
        /// <param name="invocation">The invocation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 16:38
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Intercept(IInvocation invocation)
        {
            var statusCode = (int)StatusCode.Succeed.Ok;
            this.WriteLog(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (HttpResponseException exception)
            {
                statusCode = (int)StatusCode.System.InvalidRequestUrl;
                exception.WriteLog("Ets.SingleApi.Controllers");
            }
            catch (Exception exception)
            {
                statusCode = (int)StatusCode.System.InternalServerError;
                exception.WriteLog("Ets.SingleApi.Controllers");
            }

            if (string.Equals(invocation.Method.ReturnType.Name, "void", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (invocation.ReturnValue == null)
            {
                var result = (InterceptorCommon.GetConstructor(invocation.Method.ReturnType) as ApiResponse) ?? new ApiResponse();
                result.Message = new ApiMessage { StatusCode = statusCode };
                invocation.ReturnValue = result;
            }

            InterceptorCommon.GetChildrenConstructor(invocation.ReturnValue);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="invocation">The invocation</param>
        /// 创建者：周超
        /// 创建日期：11/1/2013 1:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void WriteLog(IInvocation invocation)
        {
            if (invocation == null)
            {
                return;
            }

            if (!invocation.Method.Name.Contains("Initialize"))
            {
                return;
            }

            var httpContext = (invocation.Arguments[0] as HttpControllerContext);
            if (httpContext == null || httpContext.Request == null)
            {
                return;
            }

            var message = string.Format("Method:{0}---Url:{1}", httpContext.Request.Method, httpContext.Request.RequestUri);
            message.WriteLog("Ets.SingleApi.Controllers", Log4NetType.Info);
        }
    }
}
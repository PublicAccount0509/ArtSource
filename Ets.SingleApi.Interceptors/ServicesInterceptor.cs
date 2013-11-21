namespace Ets.SingleApi.Interceptors
{
    using System;
    using System.Linq;

    using Castle.DynamicProxy;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ServicesInterceptor
    /// 命名空间：Ets.SingleApi.Interceptors
    /// 类功能：Services的拦截
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 16:38
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ServicesInterceptor : IInterceptor
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
            this.WriteLog(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                exception.WriteLog("Ets.SingleApi.Services");
            }

            if (invocation.ReturnValue == null)
            {
                var result = (InterceptorCommon.GetConstructor(invocation.Method.ReturnType) as DefaultServicesResult) ?? new DefaultServicesResult();
                result.StatusCode = (int)StatusCode.System.InternalServerError;
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

            if (!InterceptorCommon.WriteLogParamsEnabled)
            {
                invocation.Method.Name.WriteLog("Ets.SingleApi.Services", Log4NetType.Info);
                return;
            }

            var method = invocation.Method;
            var arguments = invocation.Arguments;
            var message = string.Format("{0}({1})", method.Name, string.Join(",", arguments.Select(p => p.Serialize()).ToList()));
            message.WriteLog("Ets.SingleApi.Services", Log4NetType.Info);

        }
    }
}
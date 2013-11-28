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
        /// 记录日志的名称
        /// </summary>
        /// <value>
        /// 记录日志的名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/28/2013 3:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string LogName
        {
            get
            {
                return "Ets.SingleApi.Services";
            }
        }

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
            this.WriteRequestLog(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                exception.WriteLog(this.LogName);
            }

            if (invocation.ReturnValue == null)
            {
                var result = (InterceptorCommon.GetConstructor(invocation.Method.ReturnType) as DefaultServicesResult) ?? new DefaultServicesResult();
                result.StatusCode = (int)StatusCode.System.InternalServerError;
                invocation.ReturnValue = result;
            }

            InterceptorCommon.GetChildrenConstructor(invocation.ReturnValue);
            this.WriteResponseLog(invocation);
        }

        /// <summary>
        /// 记录请求参数日志
        /// </summary>
        /// <param name="invocation">The invocation</param>
        /// 创建者：周超
        /// 创建日期：11/1/2013 1:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void WriteRequestLog(IInvocation invocation)
        {
            if (invocation == null)
            {
                return;
            }

            if (!InterceptorCommon.WriteLogParamsEnabled)
            {
                invocation.Method.Name.WriteLog(this.LogName, Log4NetType.Info);
                return;
            }

            var method = invocation.Method;
            var arguments = invocation.Arguments;
            var message = string.Format("Request--{0}({1})", method.Name, string.Join(",", arguments.Select(p => p.Serialize()).ToList()));
            message.WriteLog(this.LogName, Log4NetType.Info);
        }

        /// <summary>
        /// 记录返回结果日志
        /// </summary>
        /// <param name="invocation">The invocation</param>
        /// 创建者：周超
        /// 创建日期：11/1/2013 1:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void WriteResponseLog(IInvocation invocation)
        {
            if (invocation == null)
            {
                return;
            }

            if (!InterceptorCommon.WriteLogReturnEnabled)
            {
                return;
            }

            var method = invocation.Method;
            var message = string.Format("Response--{0}({1})", method.Name, invocation.ReturnValue == null ? string.Empty : invocation.ReturnValue.Serialize());
            message.WriteLog(this.LogName, Log4NetType.Info);
        }
    }
}
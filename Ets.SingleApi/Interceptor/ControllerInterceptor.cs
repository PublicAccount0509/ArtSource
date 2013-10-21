namespace Ets.SingleApi.Interceptor
{
    using System;

    using Castle.DynamicProxy;

    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ControllerInterceptor
    /// 命名空间：Ets.SingleApi.Interceptor
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
            invocation.Method.Name.WriteLog("Ets.SingleApi.WapControllers", Log4NetType.Info);
            invocation.Proceed();
        }
    }
}
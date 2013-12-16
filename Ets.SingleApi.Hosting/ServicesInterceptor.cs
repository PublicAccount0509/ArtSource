namespace Ets.SingleApi.Hosting
{
    using System;
    using System.Linq;

    using Castle.DynamicProxy;

    /// <summary>
    /// 类名称：ServicesInterceptor
    /// 命名空间：Ets.SingleApi.Hosting
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
            invocation.Proceed();
            this.GetChildrenConstructor(invocation.ReturnValue);
        }

        /// <summary>
        /// Formats the return value.
        /// </summary>
        /// <param name="source">The source</param>
        /// Creator:zhouchao
        /// Creation Date:3/15/2012 7:11 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private void GetChildrenConstructor(object source)
        {
            if (source == null)
            {
                return;
            }

            var type = source.GetType();
            foreach (var property in type.GetProperties().Where(info => info.CanRead && info.CanWrite))
            {
                var value = property.GetValue(source, null);
                if (value != null)
                {
                    continue;
                }

                var childType = property.PropertyType;
                var childConstructor = childType.GetConstructor(new Type[] { });
                if (childConstructor == null)
                {
                    continue;
                }

                var child = childConstructor.Invoke(new object[] { });
                property.SetValue(source, child, null);
            }
        }
    }
}
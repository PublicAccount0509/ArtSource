namespace Ets.SingleApi.Interceptors
{
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// 类名称：InterceptorCommon
    /// 命名空间：Ets.SingleApi.Interceptors
    /// 类功能：拦截公用方法
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 3:14 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    internal class InterceptorCommon
    {
        /// <summary>
        /// 是否开启记录请求参数的详细日志
        /// </summary>
        /// <value>
        /// 是否开启记录请求参数的详细日志
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool WriteLogParamsEnabled
        {
            get
            {
                return string.Equals(ConfigurationManager.AppSettings["WriteLogParamsEnabled"], "true", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// 是否开启记录返回值的详细日志
        /// </summary>
        /// <value>
        /// 是否开启记录返回值的详细日志
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool WriteLogReturnEnabled
        {
            get
            {
                return string.Equals(ConfigurationManager.AppSettings["WriteLogReturnEnabled"], "true", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Contructs the return value.
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>
        /// The Object
        /// </returns>
        /// Creator:zhangzhigang
        /// Creation Date:3/22/2012 1:51 PM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public static object GetConstructor(Type type)
        {
            var constructor = type.GetConstructor(new Type[] { });
            if (constructor == null)
            {
                return null;
            }

            var returnValue = constructor.Invoke(new object[] { });
            return returnValue;
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
        public static void GetChildrenConstructor(object source)
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
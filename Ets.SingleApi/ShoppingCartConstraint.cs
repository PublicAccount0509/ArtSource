namespace Ets.SingleApi
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Routing;

    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartConstraint
    /// 命名空间：Ets.SingleApi
    /// 类功能：ShoppingCart匹配关键字
    /// </summary>
    /// 创建者：周超
    /// 创建日期：3/3/2014 11:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartConstraint : IHttpRouteConstraint
    {
        /// <summary>
        /// 确定此实例是否等于指定的路由。
        /// </summary>
        /// <param name="request">请求。</param>
        /// <param name="route">要比较的路由。</param>
        /// <param name="parameterName">参数名。</param>
        /// <param name="values">参数值的列表。</param>
        /// <param name="routeDirection">路由方向。</param>
        /// <returns>
        /// 如果此实例等于指定的路由，则为 True；否则为 false。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/3/2014 11:28 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (values == null)
            {
                return true;
            }

            if (!string.Equals(parameterName, "shoppingcart", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            var parameterValueTemp = values[parameterName];
            if (parameterValueTemp == null)
            {
                return true;
            }

            var parameterValue = parameterValueTemp.ToString();
            if (parameterValue.IsEmptyOrNull())
            {
                return true;
            }

            var shoppingCartList = (ConfigurationManager.AppSettings["ShoppingCartList"] ?? string.Empty).Split(',').ToList();
            if (!shoppingCartList.Any(p => string.Equals(p, parameterValue, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            var controller = values["controller"];
            values["controller"] = string.Concat(parameterValue, controller);
            return true;
        }
    }
}
namespace Ets.SingleApi
{
    using System.Web.Http;
    using System.Web.Routing;

    /// <summary>
    /// 类名称：WebApiConfig
    /// 命名空间：Ets.SingleApi
    /// 类功能：WebApi路由设置
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/12 10:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public static class WebApiConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="config">The config</param>
        /// 创建者：周超
        /// 创建日期：2013/10/12 10:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void Register(HttpConfiguration config)
        {
            //搜索、修改、删除、创建资源
            config.Routes.MapHttpRoute(
                 "GET/PUT/DELETE",
                 "api/{controller}/{action}/{id}",
                 new { id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint("GET", "PUT", "DELETE", "POST") });
        }
    }
}
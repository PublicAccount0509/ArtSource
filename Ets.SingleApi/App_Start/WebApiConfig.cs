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
            //微信支付
            config.Routes.MapHttpRoute(
                "WechatPaymentRoute",
                "api/payment/WechatPaymentNotify/{orderType}",
                new { controller = "Payment", action = "WechatPaymentNotify", httpMethod = new HttpMethodConstraint("POST") });

            //首页
            config.Routes.MapHttpRoute(
                 "Home",
                 "",
                 new { controller = "Test", action = "Test", httpMethod = new HttpMethodConstraint("GET") });

            //搜索、修改、删除、创建资源
            config.Routes.MapHttpRoute(
                 "DefaultRoute",
                 "api/{controller}/{action}/{id}",
                 new { id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint("GET", "PUT", "DELETE", "POST") },
                 new { controller = new ControllerConstraint() });

            //搜索、修改、删除、创建资源
            config.Routes.MapHttpRoute(
                 "ShoppingCartRoute",
                 "api/{shoppingcart}/{controller}/{action}/{id}",
                 new { id = RouteParameter.Optional, httpMethod = new HttpMethodConstraint("GET", "PUT", "DELETE", "POST") },
                 new { shoppingcart = new ShoppingCartConstraint() });


        }
    }
}
namespace Ets.SingleApi
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;

    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WebApiApplication
    /// 命名空间：Ets.SingleApi
    /// 类功能：项目入口
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/12 10:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application_s the start.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/12 10:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected void Application_Start()
        {
            try
            {
                AreaRegistration.RegisterAllAreas();

                //注册路由
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                WapWebApiConfig.Register(GlobalConfiguration.Configuration);

                //注册Filters
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

                //注册log4net组件
                Log4NetUtility.Register();

                //注册log4net组件
                StatusUtility.Register();

                //注册缓存
                CacheUtility.Register();

                //注册castle组件
                CastleUtility.Register(GlobalConfiguration.Configuration);

                GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

                //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
            }
            catch (Exception exception)
            {
                exception.WriteLog("Ets.SingleApi.System");
            }
        }
    }
}
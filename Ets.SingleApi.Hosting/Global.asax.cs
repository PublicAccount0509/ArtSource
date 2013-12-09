namespace Ets.SingleApi.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel.Activation;
    using System.Web;
    using System.Web.Routing;

    using Castle.Facilities.WcfIntegration;
    using Castle.Windsor;

    using Ets.SingleApi.Hosting.Contracts;

    /// <summary>
    /// 类名称：Global
    /// 命名空间：Ets.SingleApi.Hosting
    /// 类功能：启动程序
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:27 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class Global : HttpApplication, IContainerAccessor
    {
        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The Object</param>
        /// <param name="e">The EventArgs</param>
        /// 创建者：周超
        /// 创建日期：12/9/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected void Application_Start(object sender, EventArgs e)
        {
            CastleUtility.Register();
            RegisterRoutes();
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/9/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IWindsorContainer Container
        {
            get
            {
                return CastleUtility.GetInstance().Container;
            }
        }

        /// <summary>
        /// 设置路由
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/9/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static void RegisterRoutes()
        {
            var routes = new Dictionary<string, Type>
                {
                    { "Authen", typeof(IAuthenService) }
                };

            foreach (var key in routes.Keys)
            {
                RouteTable.Routes.Add(new ServiceRoute(string.Format("Api/{0}", key), new DefaultServiceHostFactory(), routes[key]));
            }

            RouteTable.Routes.MapPageRoute("Help", string.Empty, "~/Help.aspx");
        }
    }
}
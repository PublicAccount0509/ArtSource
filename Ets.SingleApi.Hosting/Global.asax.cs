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
    using Ets.SingleApi.Utility;

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
            //注册log4net组件
            StatusUtility.Register();
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
                    { "Test", typeof(ITestService) },
                    { "Authen", typeof(IAuthenService) },
                    { "BusinessArea", typeof(IBusinessAreaService) },
                    { "Coupon", typeof(ICouponService) },
                    { "Cuisine", typeof(ICuisineService) },
                    { "Function", typeof(IFunctionService) },
                    { "Orders", typeof(IOrdersService) },
                    { "Payment", typeof(IPaymentService) },
                    { "ShoppingCart", typeof(IShoppingCartService) },
                    { "Sms", typeof(ISmsService) },
                    { "User", typeof(IUserService) },
                    { "Supplier", typeof(ISupplierService) },
                    { "DirectPay", typeof(IDirectPayService) },
                    { "Queue", typeof(IQueueService) },
                    { "EtsWapDingTaiShoppingCart", typeof(IEtsWapDingTaiShoppingCartService) },
                    { "EtsWapShoppingCart", typeof(IEtsWapShoppingCartService) },
                    { "EtsWapTangShiShoppingCart", typeof(IEtsWapTangShiShoppingCartService) }
                };

            foreach (var key in routes.Keys)
            {
                RouteTable.Routes.Add(new ServiceRoute(string.Format("Api/{0}", key), new DefaultServiceHostFactory(), routes[key]));
            }

            RouteTable.Routes.MapPageRoute(string.Empty, string.Empty, "~/Help.aspx");
        }
    }
}
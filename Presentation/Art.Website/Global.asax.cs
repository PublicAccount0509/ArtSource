using Art.BussinessLogic;
using Art.Data.Domain.Access;
using Art.Data.Domain.Access.Initializers;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.Linq;
using WebExpress.Core;

namespace Art.Website
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801 
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            var dependencyRegistar = new DependencyRegistrar();
            dependencyRegistar.Register(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
              
            InitDatabase(); 
        }

        private void InitDatabase()
        {
            IDataProvider dataProvider = new SqlServerDataProvider();
            var sqlCommandFile = HostingEnvironment.MapPath("~/App_Data/SqlServer.Indexes.sql");
            dataProvider.InitDatabase(sqlCommandFile);
        }
    }
}
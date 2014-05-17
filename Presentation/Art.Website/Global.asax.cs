using Art.Data.Domain.Access;
using Art.Data.Domain.Access.Initializers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml.Linq;
using WebExpress.Core.TypeExtensions;

namespace Art.Website
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        protected void Application_Start()
        {
            _container = Bootstrapper.Initialise();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            InitDatabase();

            LoadDynamicJs();
        }

        private void InitDatabase()
        {
            IDataProvider dataProvider = new SqlServerDataProvider();
            var sqlCommandFile = HostingEnvironment.MapPath("~/App_Data/SqlServer.Indexes.sql");
            dataProvider.InitDatabase(sqlCommandFile);
        }

        private void LoadDynamicJs()
        {
            var enumConfigFile = HostingEnvironment.MapPath("~/Config/EnumSettings.config");
            var xDoc = XDocument.Load(enumConfigFile);
            var sbJS = new StringBuilder();
            foreach (var item in xDoc.Descendants("enum"))
            {
                var enumName = item.Attribute("name").Value;
                var enumType = item.Attribute("type").Value;
                sbJS.AppendFormat("art.config.enums.{0} = {{", enumName);
                var enumItems = EnumExtenstion.GetEnumItems(Type.GetType(enumType));
                foreach (var enumItem in enumItems)
                {
                    sbJS.AppendFormat("{0}:new EnumItem('{1}','{2}'),", enumItem.Name, enumItem.Value, enumItem.Text);
                }
                sbJS.AppendLine("};");
            }
            var jsFile = HostingEnvironment.MapPath("~/Scripts/dynamicScript.js");
            File.WriteAllText(jsFile, sbJS.ToString());
        }

        //IUnityContainer IContainerAccessor.Container
        //{
        //    get { return Container; }
        //}
    }
}
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Art.WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            IDataProvider dataProvider = new SqlServerDataProvider();
            dataProvider.InitDatabase(string.Empty);
        }
    }
}

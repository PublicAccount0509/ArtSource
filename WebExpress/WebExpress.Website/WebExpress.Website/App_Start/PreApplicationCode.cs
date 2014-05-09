using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebExpress.Website.Filters;

[assembly: PreApplicationStartMethod(typeof(WebExpress.Website.PreApplicationCode), "Start")]

namespace WebExpress.Website
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PreApplicationCode
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Start()
        {
            RegisterHttpModules();

            RegisterGlobalFilters();
        }

        private static void RegisterHttpModules()
        { 
        
        }

        private static void RegisterGlobalFilters()
        {
            //GlobalFilters.Filters.Add(new VoidActionFilter());
            //GlobalFilters.Filters.Add(new AdvancedJsonResultActionFilter());
            //GlobalFilters.Filters.Add(new CompressionResponseFilter());
            GlobalFilters.Filters.Add(new ExceptionResolverFilter());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
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
            WriteDynamicScript();

            RegisterHttpModules();

            RegisterGlobalFilters();
        }

        public static void WriteDynamicScript()
        { 
            var sbJS = new StringBuilder();
            IDynamicScriptWriter ds = new EnumTypeScriptWriter();
            ds.WriteDynamicScripts(sbJS);
            var jsFile = HostingEnvironment.MapPath("~/Scripts/dynamicScript.js");
            File.WriteAllText(jsFile, sbJS.ToString());
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

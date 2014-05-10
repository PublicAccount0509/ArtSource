using Art.BussinessLogic;
using Art.Website.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Art.Website.Filters
{

    public class LoggingFilterAttribute :  System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;
            filterContext.HttpContext.Trace.Write("(Logging Filter)Action Executing: " + actionName);

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;

            string friendlyName = null;

            var attributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(ActAttribute), false);
            if (attributes.Length > 0)
            {
                friendlyName = (attributes[0] as ActAttribute).Feature;
            }
            var user = HttpContext.Current.User;
            OperationLogBussinessLogic.Instance.LogOperation(100, user.Identity.Name, actionName, friendlyName, filterContext.Exception, filterContext.ExceptionHandled);

            if (filterContext.Exception != null)
                filterContext.HttpContext.Trace.Write("(Logging Filter)Exception thrown");

            base.OnActionExecuted(filterContext);
        }
    }
}
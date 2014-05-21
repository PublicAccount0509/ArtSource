using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Art.Website.Common
{
    public class ImageRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string filename = requestContext.RouteData.Values["filename"] as string;
            string category = requestContext.RouteData.Values["category"] as string;

            var handler = new ImageHttpHandler(category, filename);
            return handler;
        }
    }

    public class ImageHttpHandler : IHttpHandler
    {
        private string _fileName;
        private string _category;
        public ImageHttpHandler(string category, string filename)
        {
            _category = category;
            _fileName = filename;
        }

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            var path = string.Format("~/Content/i/{0}", _fileName);
            string filepath = context.Server.MapPath(path);

            if (!File.Exists(filepath))
            {
                context.Response.Clear();
                context.Response.StatusCode = 404;
                context.Response.End();
            }

            context.Response.Clear();
            context.Response.ContentType = GetContentType(context.Request.Url.ToString());
            context.Response.WriteFile(filepath);
            context.Response.End();
        }

        private static string GetContentType(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }

        #endregion
    }
}

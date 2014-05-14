using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Art.Common
{
    public class CommonHelper
    {
        public static string GetUploadFileRelativePath_SlantStyle(string fileName)
        {
            var path = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, fileName);
            return path.Replace("\\", "/");
        }

        public static string GetUploadFileRelativePath(string fileName)
        {
            return Path.Combine(ConfigSettings.Instance.UploadedFileFolder, fileName);
        }

        public static string GetUploadFileAbsolutePath(string fileName)
        {
            var relativePath = GetUploadFileRelativePath(fileName);
            var absolutePath = HttpContext.Current.Server.MapPath("~/" + relativePath);
            return absolutePath;
        }
    }
}

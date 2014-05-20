using Art.Common;
using Art.Website.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Art.Website.Handlers
{
    public class FileUploadHandler : IHttpHandler
    {
        private int _minWidth;
        private int _minHeight;
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile file;
            try
            {
                file = context.Request.Files.Get(0);
            }
            catch (Exception ex)
            {
                var model = new FileUploadModel(false, "上传失败！");
                var jsonString = WebExpress.Website.Serialization.JavaScriptJsonSerializer.Instance.Serialize(model);
                context.Response.Write(ex.Message);
                return;
            }

            if (Path.GetExtension(file.FileName).ToLower() != ".jpg" && Path.GetExtension(file.FileName).ToLower() != ".png" && Path.GetExtension(file.FileName).ToLower() != ".gif" && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
            {
                var model = new FileUploadModel(false, "上传失败！请选择jpg,jpeg,png,gif类型的文件");
                var jsonString = WebExpress.Website.Serialization.JavaScriptJsonSerializer.Instance.Serialize(model);
                context.Response.Write(jsonString);
                return;
            }

            var imageObject = context.Request.QueryString["object"];
            if (imageObject == "artwork")
            {
                _minHeight = ConfigSettings.MINHEIGHT_UPLOADEDARTWORKIMAGE;
                _minWidth = ConfigSettings.MINWIDTH_UPLOADEDARTWORKIMAGE;
            }
            else
            {
                _minHeight = 88;
                _minWidth = 88;
            }

            using (Image image = Image.FromStream(file.InputStream))
            {
                if (image.Width < _minWidth)
                {

                    var model = new FileUploadModel(false, string.Format("上传失败！图片宽度不能小于{0}", _minWidth));
                    var jsonString = WebExpress.Website.Serialization.JavaScriptJsonSerializer.Instance.Serialize(model);
                    context.Response.Write(jsonString);
                    return;
                }

                if (image.Height < _minHeight)
                {
                    var model = new FileUploadModel(false, string.Format("上传失败！图片高度不能小于{0}", _minHeight));
                    var jsonString = WebExpress.Website.Serialization.JavaScriptJsonSerializer.Instance.Serialize(model);
                    context.Response.Write(jsonString);
                    return;
                }
            }

            var folderName = ConfigSettings.Instance.FileUploadPath;
            var path = context.Server.MapPath(folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = string.Format("{0}_{1}.jpg", "avatart", DateTime.Now.ToString("yyyyMMddhhmmss"));
            var fullFileName = Path.Combine(path, fileName);
            file.SaveAs(fullFileName);

            var uploadFileName = folderName + "\\" + fileName;
            var result = new FileUploadModel(true, string.Empty, uploadFileName);
            var json = WebExpress.Website.Serialization.JavaScriptJsonSerializer.Instance.Serialize(result);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}
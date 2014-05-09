using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models.CommonModel
{
    public class FileUploadModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string UploadedFileName { get; set; }
    }
}
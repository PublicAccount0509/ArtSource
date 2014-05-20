using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models.CommonModel
{
    public class FileUploadModel
    {
        public FileUploadModel(bool isSuccess, string message)
            : this(isSuccess, message, string.Empty)
        {
        }

        public FileUploadModel(bool isSuccess, string message, string fileName)
        {
            IsSuccess = isSuccess;
            Message = message;
            UploadedFileName = fileName;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string UploadedFileName { get; set; }
    }
}
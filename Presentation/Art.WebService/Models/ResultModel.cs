using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class ResultModel
    {
        public ResultModel(bool isSuccess)
            : this(isSuccess, string.Empty, 0)
        {

        }

        public ResultModel(bool isSuccess, string message)
            : this(isSuccess, message, 0)
        {

        }
        public ResultModel(bool isSuccess, int resultId)
            : this(isSuccess, string.Empty, resultId)
        {
        }

        public ResultModel(bool isSuccess, string message, int resultId)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.ResultId = resultId;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ResultId { get; set; }
    }
}
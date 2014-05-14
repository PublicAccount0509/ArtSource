using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class SimpleResultModel
    {
        public SimpleResultModel(int status)
            : this(status, string.Empty)
        {

        }

        public SimpleResultModel(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public static SimpleResultModel Success()
        {
            return new SimpleResultModel(0);
        }

        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class IntResultModel : ResultModel<int>
    {
        public IntResultModel(int status)
            : base(status, string.Empty)
        {

        }

        public IntResultModel(int status, string message)
            : base(status, message)
        {

        }

        public IntResultModel(int status, int id)
            : base(status, string.Empty, id)
        {

        }

        public IntResultModel(int status, string message, int id)
            : base(status, message, id)
        {

        }
    }

    public class ResultModel<TResult>
    {
        public ResultModel(int status)
            : this(status, string.Empty)
        {

        }

        public ResultModel(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public ResultModel(int status, string message, TResult result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
        }

        public static ResultModel<TResult> Success()
        {
            return new ResultModel<TResult>(0);
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public TResult Result { get; set; }
    }


}
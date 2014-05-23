using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ExceptionLog:BaseEntity
    {
        [MaxLength(303)]
        public string AppName { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }

        public string FAUserName { get; set; }
        public DateTime FADateTime { get; set; }

        public string Test { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }
    }
}

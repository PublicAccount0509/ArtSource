using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class OperationLog : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public string FriendlyActionName { get; set; }

        public string ExceptionInfo { get; set; }
        public bool ExceptionHandled { get; set; }

        public DateTime FADateTime { get; set; }

        public string Test2 { get; set; }
    }
}

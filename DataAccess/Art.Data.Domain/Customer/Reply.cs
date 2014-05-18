using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Reply : BaseEntity
    {
        public string Text { get; set; }
        public Comment Comment { get; set; }
        public AdminUser User { get; set; }

        public DateTime FADateTime { get; set; }
    }
}

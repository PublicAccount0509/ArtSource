using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class OrderPayInfo:BaseEntity
    {
        public PayType Mode { get; set; }

        public PayStatus Status { get; set; }
    }
}

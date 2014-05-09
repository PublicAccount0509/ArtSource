using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class OrderInvoiceInfo:BaseEntity
    {
        public InvoiceType InvoiceType { get; set; }
        public string CustomerName { get; set; }
    }
}

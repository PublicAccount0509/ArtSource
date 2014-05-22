using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic.Entities
{
    public class OrderSearchCriteria
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public OrderStatus? Status { get; set; }

        public PayStatus? PayResult { get; set; }

        public bool? IsPaid { get; set; }

        public string OrderNumber { get; set; }
         
        public PagingRequest PagingRequest { get; set; }
    }
}

using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models.MvcModels
{
    public class OrderSearchCriteria
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool? IsPaid { get; set; }
        public OrderStatus Status { get; set; }
        public string OrderNumber { get; set; }
    }
}
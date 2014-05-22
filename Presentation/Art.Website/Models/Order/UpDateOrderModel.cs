using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class UpDateOrderModel
    {
        public int Id { get; set; }
        public string RefuseMessage { get; set; }
        public string RefundMessage { get; set; }
        public string DeliveryCompany { get; set; }
        public string DeliveryNumber { get; set; }
    }
}
using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class OrderDeliveryInfo:BaseEntity
    { 
        public DeliveryMode Mode { get; set; }

        public Address CustomerAddress { get; set; }

        public DeliveryStatus Status { get; set; }

        public string DeliveryCompany { get; set; }
        public string DeliveryNumber { get; set; }
    }
}

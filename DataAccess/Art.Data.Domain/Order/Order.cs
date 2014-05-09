using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Art.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art.Data.Domain
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public PayMode PayMode { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public string CustumerMessage { get; set; }
        public string RefuseMessage { get; set; }
        public string RefundMessage { get; set; }
        public int CustomerId { get; set; }
        public DateTime FADateTime { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual OrderDeliveryInfo DeliveryInfo { get; set; }
        public virtual PayStatus PayStatus { get; set; }
        public virtual OrderInvoiceInfo InvoiceInfo { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }

    public class OrderItem : BaseEntity
    {
        public int ArtworkId { get; set; }

        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }
        public decimal Price { get; set; }
    }
}

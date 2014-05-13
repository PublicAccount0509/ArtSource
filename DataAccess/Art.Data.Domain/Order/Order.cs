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
        public OrderStatus Status { get; set; }

        public string OrderNumber { get; set; }


        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }

        public AuctionType AuctionType { get; set; }
        public PayType PayType { get; set; } 
        public PackingType PackingType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }

        public int ReceiptAddressId { get; set; }


        public decimal Price { get; set; }
        public decimal FeePackage { get; set; }
        public decimal FeeDelivery { get; set; }

        public string Note { get; set; }


        public DateTime FADateTime { get; set; }
          
        public string RefuseMessage { get; set; }
        public string RefundMessage { get; set; }
        public string DeliveryCompany { get; set; }
        public string DeliveryNumber { get; set; }
         
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; } 
        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }

          

        public virtual PayStatus PayStatus { get; set; } 
         
    }
     
}

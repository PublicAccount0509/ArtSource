using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;

namespace Art.WebService.Models
{
    public class AddOrderModel
    {
        public AuctionType AuctionType { get; set; }
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public PackingType PackingType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }
        public int ReceiptAddressId { get; set; }
    }
}
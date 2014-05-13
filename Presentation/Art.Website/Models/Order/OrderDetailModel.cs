using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;

namespace Art.Website.Models
{
    public class OrderDetailModel
    {
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ArtworkName { get; set; }
        public string ArtworkTypeName { get; set; }

        //delivery info 
        public AddressModel ReceiptAddress { get; set; }

        public DeliveryType DeliveryType { get; set; }
        public decimal FeeDelivery { get; set; }

        public string DeliveryCompany { get; set; }
        public string DeliveryNumber { get; set; }

        public PackingType PackingType { get; set; }
        public decimal FeePackage { get; set; }


        //invoice info
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }

        //pay info
        public PayType PayType { get; set; }
        public PayStatus PayStatus { get; set; }


        public decimal Price { get; set; }


        public string Note { get; set; }
        public string OtherMessage { get; set; }
    }
}
using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class AddOrderModel
    {
        public decimal Price { get; set; }
        public AuctionType AuctionType { get; set; }
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public PackingType PackingType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }
        public int ReceiptAddressId { get; set; }

        public string Note { get; set; }
    }

    public class AddOrderModelTranslator : TranslatorBase<Order, AddOrderModel>
    {
        public static readonly AddOrderModelTranslator Instance = new AddOrderModelTranslator();

        public override AddOrderModel Translate(Order from)
        {
            throw new NotImplementedException();
        }

        public override Order Translate(AddOrderModel from)
        {
            var to = new Order();
            to.AuctionType = from.AuctionType;
            to.CustomerId = from.CustomerId;
            to.ArtworkId = from.ArtworkId;
            to.PackingType = from.PackingType;
            to.DeliveryType = from.DeliveryType;
            to.InvoiceType = from.InvoiceType;
            to.InvoiceCompanyName = from.InvoiceCompanyName;
            to.ReceiptAddressId = from.ReceiptAddressId;
            to.Note = from.Note;
             
            return to;
        }
    }

}
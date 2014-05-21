using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using WebExpress.Core;
using Art.Data.Domain;

namespace Art.WebService.Models
{
    public class AddOrderModel
    {
        public int UserId { get; set; }
        public int ArtworkId { get; set; }
        public int ReceiptAddressId { get; set; }
        public decimal Price { get; set; }

        public AuctionType AuctionType { get; set; }
        public PackingType PackingType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }

        public string Note { get; set; }
    }

    public enum AddOrderStatus
    {
        InvalidAuctionType,

        InvoiceType,

        InvalidInvoiceType,

        InvalidPackingType,

        InvalidUserId,

        InvalidAddressId,

        InvalidArtworkId,

        NotSupportedDeliveryType,

        NotSupportedPackageType,

        [DisplayText("aaaaaaa")]
        PriceChanged,

        [DisplayText("该商品未发布")]
        ArtworkUnPublished,

        [DisplayText("该商品已被出售")]
        ArtworkPurchased,

        Success
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
            to.ArtworkId = from.ArtworkId;
            to.CustomerId = from.UserId;
            to.ReceiptAddressId = from.ReceiptAddressId;
            to.Price = from.Price;

            to.AuctionType = from.AuctionType;
            to.DeliveryType = from.DeliveryType;
            to.PackingType = from.PackingType;

            to.InvoiceType = from.InvoiceType;
            to.InvoiceCompanyName = from.InvoiceCompanyName;

            to.Note = from.Note;

            return to;
        }
    }
}
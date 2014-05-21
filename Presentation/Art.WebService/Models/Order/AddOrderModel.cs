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
        public decimal FeePacking { get; set; }
        public decimal FeeDelivery { get; set; }

        public AuctionType AuctionType { get; set; }
        public PackingType PackingType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }

        public string Note { get; set; }
    }

    public enum AddOrderStatus
    {
        [DisplayText("参数无效")]
        ArgumentNull,

        [DisplayText("无效的拍卖方式")]
        InvalidAuctionType, 

        [DisplayText("无效的发票类型")]
        InvalidInvoiceType,

        [DisplayText("无效的包装方式")]
        InvalidPackingType,

        [DisplayText("无效的用户")]
        InvalidUserId,

        [DisplayText("无效的地址")]
        InvalidAddressId,

        [DisplayText("无效的作品")]
        InvalidArtworkId,

        [DisplayText("不支持该物流方式")]
        NotSupportedDeliveryType,

        [DisplayText("不支持该包装方式")]
        NotSupportedPackageType,

        [DisplayText("订单的价格，运费，或包装费与当前商品不一致")]
        IncorrectPrice,

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

            to.FeeDelivery = from.FeeDelivery;
            to.FeePackage = from.FeePacking;

            to.Note = from.Note;

            return to;
        }
    }
}
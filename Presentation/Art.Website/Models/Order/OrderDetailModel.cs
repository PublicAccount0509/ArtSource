using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;

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
        public virtual AddressModel ReceiptAddress { get; set; }

        public DeliveryType DeliveryType { get; set; }
        public decimal FeeDelivery { get; set; }

        public string DeliveryCompany { get; set; }
        public string DeliveryNumber { get; set; }

        public PackingType PackingType { get; set; }
        public decimal FeePackage { get; set; }


        //invoice info
        public virtual InvoiceType InvoiceType { get; set; }
        public string InvoiceCompanyName { get; set; }

        //pay info
        public PayType PayType { get; set; }
        public virtual PayStatus PayStatus { get; set; }


        public decimal Price { get; set; }



        public string Note { get; set; }
        public string OtherMessage { get; set; }
    }

    public class OrderDetailModelTranslator : TranslatorBase<Order, OrderDetailModel>
    {
        public static readonly OrderDetailModelTranslator Instance = new OrderDetailModelTranslator();

        public override OrderDetailModel Translate(Order from)
        {
            var to = new OrderDetailModel();
            to.ArtworkName = from.Artwork.Name;
            to.ArtworkTypeName = from.Artwork.ArtworkType.Name;
            to.CreateDateTime = from.FADateTime;
            to.DeliveryCompany = from.DeliveryCompany;
            to.DeliveryNumber = from.DeliveryNumber;
            to.DeliveryType = from.DeliveryType;
            to.FeeDelivery = from.FeeDelivery;
            to.FeePackage = from.FeePackage;
            to.InvoiceCompanyName = from.InvoiceCompanyName;
            to.InvoiceType = from.InvoiceType;
            to.Note = from.Note;
            to.OrderNumber = from.OrderNumber;
            //TODO 其他信息
            to.OtherMessage = (string.IsNullOrEmpty(from.RefundMessage) ? "" : "拒绝订单理由：" + from.RefuseMessage)
                + (string.IsNullOrEmpty(from.RefundMessage) ? "" : " 退款信息：" + from.RefundMessage);
            to.PackingType = from.PackingType;
            to.PayStatus = from.PayStatus;
            to.PayType = from.PayType;
            to.Price = from.Price;
            //TODO 送货信息
            //to.ReceiptAddress = AddressModelTranslator.Instance.Translate(from.Customer.Addresses);
            to.Status = from.Status;
            return to;
        }

        public override Order Translate(OrderDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
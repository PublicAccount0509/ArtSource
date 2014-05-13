using Art.Common;
using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class OrderManageModel
    {
        public List<string> Status { get; set; }
        public PagedOrderModel PagedOrders { get; set; }
    }

    public class PagedOrderModel
    {
        public PagedOrderModel(List<OrderSimpleModel> orders, PagingResult pagingResult)
        {
            this.Orders = orders;
            this.PagingResult = pagingResult;
        }
        public List<OrderSimpleModel> Orders { get; set; }
        public PagingResult PagingResult { get; set; }
    }

    public class OrderSimpleModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string ArtworkName { get; set; }
        public string ArtworkImagePath { get; set; }
        public string ArtworkType { get; set; }
        public OrderStatus Status { get; set; }
        public PayType PayType { get; set; }
        public PayStatus PayStatus { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string Note { get; set; }

    }

    public class OrderSimpleModelTranslator : TranslatorBase<Order, OrderSimpleModel>
    {
        public static readonly OrderSimpleModelTranslator Instance = new OrderSimpleModelTranslator();

        public override OrderSimpleModel Translate(Order from)
        {
            var to = new OrderSimpleModel();
            to.Id = from.Id;
            to.OrderNumber = from.OrderNumber;
            to.TransactionDateTime = from.FADateTime;
            to.ArtworkName = from.Artwork.Name;
            to.ArtworkType = from.Artwork.ArtworkType.Name;
            if (!string.IsNullOrEmpty(from.Artwork.ImageFileName))
            {
                to.ArtworkImagePath = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.Artwork.ImageFileName);
            }            
            to.Status = from.Status;
            to.PayType = from.PayType;
            to.PayStatus = from.PayStatus;
            to.DeliveryType = from.DeliveryType;
            to.Note = from.Note;
            return to;
        }

        public override Order Translate(OrderSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }

}
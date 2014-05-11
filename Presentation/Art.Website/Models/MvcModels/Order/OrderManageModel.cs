using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Common.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class OrderManageModel
    {
        public List<string> Status { get; set; }
        public PagedOrderSimpleModel PagedOrders { get; set; }
    }

    public class PagedOrderSimpleModel
    {
        public PagedOrderSimpleModel(List<OrderSimpleModel> orders, PagingResult pagingResult)
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
        public string ImageFileName { get; set; }
        public OrderStatus Status { get; set; }
        public PayMode PayMode { get; set; }
        public PayStatus PayStatus { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public string CustumerMessage { get; set; }

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
            to.ImageFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.OrderItem.Artwork.ImageFileName);
            to.Status = from.Status;
            to.PayMode = from.PayMode;
            to.PayStatus = from.PayStatus;
            to.DeliveryMode = from.DeliveryMode;
            to.CustumerMessage = from.CustumerMessage;
            return to;
        }

        public override Order Translate(OrderSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }

}
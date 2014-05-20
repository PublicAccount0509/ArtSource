using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 订单详情数据
    /// </summary>
    public class OrderListModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// 作品名
        /// </summary>
        public string ArtworkName { get; set; }
        /// <summary>
        /// 作家
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 作品尺寸
        /// </summary>
        public string ArtworkSize { get; set; }
        /// <summary>
        /// 作品材质
        /// </summary>
        public string ArtworkMaterial { get; set; }
    }

    public class OrderListModelTranslator : TranslatorBase<Order, OrderListModel>
    {
        public static readonly OrderListModelTranslator Instance = new OrderListModelTranslator();

        public override OrderListModel Translate(Order from)
        {
            var to = new OrderListModel();
            to.ArtistName = from.Artwork.Artist.Name;
            to.ArtworkMaterial = from.Artwork.ArtMaterial.Name;
            to.ArtworkName = from.Artwork.Name;
            to.ArtworkSize = from.Artwork.Size;
            to.OrderNumber = from.OrderNumber;
            to.Status = from.Status;
            to.TotalPrice = from.Price + from.FeeDelivery + from.FeePackage;
            return to;
        }

        public override Order Translate(OrderListModel from)
        {
            throw new NotImplementedException();
        }
    }
}
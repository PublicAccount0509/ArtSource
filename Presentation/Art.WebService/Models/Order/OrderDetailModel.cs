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
    public class OrderDetailModel
    {
        /// <summary>
        /// 作品图
        /// </summary>
        public string ArtworkImagePath { get; set; }
        /// <summary>
        /// 作家名
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string ArtworkSize { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string ArtworkMaterial { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string ReceiptName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string ReceiptPhoneNumber { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ReceiptDetailAddress { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public PayStatus PayWay { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        public DeliveryType DeleveriyWay { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        public PackingType PackingWay { get; set; }
        /// <summary>
        /// 发票
        /// </summary>
        public string InvoiceInfo { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
    }

    public class OrderDetailModelTranslator : TranslatorBase<Order, OrderDetailModel>
    {
        public static readonly OrderDetailModelTranslator Instance = new OrderDetailModelTranslator();

        public override OrderDetailModel Translate(Order from)
        {
            var to = new OrderDetailModel();
            to.ArtistName = from.Artwork.Artist.Name;
            to.ArtworkImagePath = from.Artwork.ImageFileName;
            to.ArtworkMaterial = from.Artwork.ArtMaterial.Name;
            to.ArtworkSize = from.Artwork.Size;
            to.DeleveriyWay = from.DeliveryType;
            to.InvoiceInfo = from.InvoiceCompanyName;
            to.Note = from.Note;
            to.PackingWay = from.PackingType;
            to.PayWay = from.PayStatus;
            //to.ReceiptDetailAddress = from.ReceiptAddress.Detail;
            //to.ReceiptName= from.ReceiptAddress.Name;
            //to.ReceiptPhoneNumber = from.ReceiptAddress.Telephone;
            return to;
        }

        public override Order Translate(OrderDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
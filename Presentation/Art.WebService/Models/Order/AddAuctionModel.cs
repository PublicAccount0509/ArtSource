using System;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class AddAuctionModel
    {
        /// <summary>
        /// 用户
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 作品
        /// </summary>
        public int ArtworkId { get; set; }

        /// <summary>
        /// 原始价
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// 拍卖方式
        /// </summary>
        public AuctionType AuctionType { get; set; }

        /// <summary>
        /// 出价
        /// </summary>
        public decimal BidPrice { get; set; }

        /// <summary>
        /// 留言
        /// </summary>
        public string Note { get; set; }
    }

    public enum AddAuctionStatus
    {
        Success,

        [DisplayText("参数无效")]
        ArgumentNull,

        [DisplayText("无效的用户")]
        InvalidUser,

        [DisplayText("无效的作品")]
        InvalidArtwork,

        [DisplayText("无效的拍卖方式")]
        InvalidAuctionType,

        [DisplayText("无效的原始价")]
        InvalidOriginalPrice,

        [DisplayText("无效的出价")]
        InvalidBidPrice
    }

    public class AddAuctionModelTranslator : TranslatorBase<AuctionBill, AddAuctionModel>
    {
        public static readonly AddAuctionModelTranslator Instance = new AddAuctionModelTranslator();

        public override AddAuctionModel Translate(AuctionBill from)
        {
            throw new NotImplementedException();
        }

        public override AuctionBill Translate(AddAuctionModel from)
        {
            var to = new AuctionBill();
            to.ArtworkId = from.ArtworkId;
            to.BidPrice = from.BidPrice;
            to.CustomerId = from.UserId;
            to.OriginalPrice = from.OriginalPrice;
            to.CustumerMessage = from.Note;
            to.AuctionType = from.AuctionType;
            return to;
        }
    }
}
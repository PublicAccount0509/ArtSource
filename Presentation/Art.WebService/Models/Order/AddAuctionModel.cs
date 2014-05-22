using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using WebExpress.Core;
using Art.Data.Domain;

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

        InvalidUser,

        InvalidArtwork,

        [DisplayText("无效的拍卖方式")]
        InvalidAuctionType,

        [DisplayText("无效的出价")]
        InvalidBidPrice
    }

}
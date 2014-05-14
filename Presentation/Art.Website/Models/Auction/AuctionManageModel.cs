using System;
using System.Collections.Generic;
using System.IO;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Common;
using WebExpress.Core.Paging;
using WebExpress.Core;

namespace Art.Website.Models
{
    /// <summary>
    /// 类名称：AuctionManageModel
    /// 命名空间：Art.Website.Models
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/12/2014 10:14 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuctionManageModel
    {
        public List<string> Status { get; set; }
        public PagedAuctionModel PagedAuctions { get; set; }
        public List<ArtistModel> Artists { get; set; }
        public List<ArtworkModel> Artworks { get; set; }
    }

    /// <summary>
    /// 类名称：PagedAuctionModel
    /// 命名空间：Art.Website.Models
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/12/2014 6:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PagedAuctionModel
    {
        public PagedAuctionModel(List<AuctionSimpleModel> auctions, PagingResult pagingResult)
        {
            this.Auctions = auctions;
            this.PagingResult = pagingResult;
        }
        public List<AuctionSimpleModel> Auctions { get; set; }
        public PagingResult PagingResult { get; set; }
    }

    /// <summary>
    /// 类名称：AuctionSimpleModel
    /// 命名空间：Art.Website.Models
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/12/2014 6:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuctionSimpleModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ArtworkName { get; set; }
        /// <summary>
        /// 作者名称
        /// </summary>
        /// <value>
        /// The name of the art.
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ArtName { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        /// <value>
        /// The name of the image file.
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ImageFileName { get; set; }
        /// <summary>
        /// 原始价
        /// </summary>
        /// <value>
        /// The AuctionPrice
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal AuctionPrice { get; set; }
        /// <summary>
        /// 拍卖出价
        /// </summary>
        /// <value>
        /// The BidPrice
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal BidPrice { get; set; }
        /// <summary>
        /// 拍卖时间
        /// </summary>
        /// <value>
        /// The TransactionDateTime
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime BidDateTime { get; set; }
        /// <summary>
        /// 操作结果
        /// </summary>
        /// <value>
        /// The AuctionResult
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuctionResult AuctionResult { get; set; }
        /// <summary>
        /// 拍卖方式
        /// </summary>
        /// <value>
        /// The type of the auction.
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuctionType AuctionType { get; set; }
        /// <summary>
        /// 出价人
        /// </summary>
        /// <value>
        /// The name of the custumer.
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustumerName { get; set; }
        /// <summary>
        /// 出价人留言
        /// </summary>
        /// <value>
        /// The CustumerMessage
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustumerMessage { get; set; }

    }

    /// <summary>
    /// 类名称：AuctionSimpleModelTranslator
    /// 命名空间：Art.Website.Models
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/12/2014 6:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuctionSimpleModelTranslator : TranslatorBase<AuctionBill, AuctionSimpleModel>
    {
        public static readonly AuctionSimpleModelTranslator Instance = new AuctionSimpleModelTranslator();

        public override AuctionSimpleModel Translate(AuctionBill from)
        {
            var to = new AuctionSimpleModel();
            to.Id = from.Id;
            to.ArtName = from.Artwork.Name;
            to.ArtworkName = from.Artwork.Artist.Name;
            if (!string.IsNullOrEmpty(from.Artwork.ImageFileName))
            {
                to.ImageFileName = Path.Combine(ConfigSettings.Instance.FileUploadPath, from.Artwork.ImageFileName);
            }
            to.AuctionPrice = from.Artwork.AuctionPrice;
            to.BidPrice = from.BidPrice;
            to.CustumerName = from.Customer.NickName;
            to.CustumerMessage = from.CustumerMessage;
            to.BidDateTime = from.BidDateTime;
            to.AuctionResult = from.AuctionResult;
            to.AuctionType = from.Artwork.AuctionType;
            return to;
        }

        public override AuctionBill Translate(AuctionSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
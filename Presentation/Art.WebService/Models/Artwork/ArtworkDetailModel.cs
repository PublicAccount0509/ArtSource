using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;
using Art.Common;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取作品详情
    /// </summary>
    public class ArtworkDetailModel
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 是否赞过
        /// </summary>
        public bool HasPraised { get; set; }
        /// <summary>
        /// 拍卖类型
        /// </summary>
        public int AuctionType { get; set; }
        /// <summary>
        /// 拍卖数量
        /// </summary>
        public int AuctionCount { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDateTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDateTime { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 创作年代
        /// </summary>
        public int CreationYear { get; set; }
        /// <summary>
        /// 作品分类
        /// </summary>
        public string ArtworkType { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 技术手法
        /// </summary>
        public string Technique { get; set; }
        /// <summary>
        /// 适用空间
        /// </summary>
        public string FitPlaces { get; set; }
        /// <summary>
        /// 创作灵感
        /// </summary>
        public string Inspiration { get; set; }
        /// <summary>
        /// 作家Id
        /// </summary>
        public int ArtistId { get; set; }
        /// <summary>
        /// 作家名称
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
    }

    public enum ArtworkDetailModelStatus
    {
        Success,
        
        [DisplayText("该商品已下架")]
        ArtworkNotPublished,
        ArtworkNotFound,
        UserNotFound
    }

    public class ArtworkDetailModelTranslator : TranslatorBase<Artwork, ArtworkDetailModel>
    {
        public static readonly ArtworkDetailModelTranslator Instance = new ArtworkDetailModelTranslator();

        public override ArtworkDetailModel Translate(Artwork from)
        {
            var to = new ArtworkDetailModel();
            var image = from.Images.FirstOrDefault(i => i.ImageType == ArtworkImageResizeType.Size_BigImage);
            if (image != null)
            {
                to.ImagePath = CommonHelper.GetUploadFileRelativePath_SlantStyle(image.ImagePath);
            }
            to.AuctionType = (int)from.AuctionType;
            to.StartDateTime = from.StartDateTime;
            to.EndDateTime = from.EndDateTime;
            to.Size = from.Size;
            to.CreationYear = from.ArtYear;
            to.ArtworkType = from.ArtworkType.Name;
            to.Material = from.ArtMaterial.Name;
            to.Technique = from.ArtTechnique == null ? string.Empty : from.ArtTechnique.Name;
            to.FitPlaces = string.Join(",", from.SuitableArtPlaces.Select(i => i.Name));
            to.Inspiration = from.CreationInspiration;
            to.ArtistId = from.Artist.Id;
            to.ArtistName = from.Artist.Name;
            to.Price = from.AuctionPrice;
            return to;
        }

        public override Artwork Translate(ArtworkDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
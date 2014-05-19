using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 作品数据
    /// </summary>
    public class ArtworkSimpleModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 图像宽度
        /// </summary>
        public int ImageWidth { get; set; }
        /// <summary>
        /// 图像高度
        /// </summary>
        public int ImageHeight { get; set; }
        /// <summary>
        /// 作家名称
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 分享总次数
        /// </summary>
        public int ShareCount { get; set; }
        /// <summary>
        /// 收藏总次数
        /// </summary>
        public int CollectAccount { get; set; }
        /// <summary>
        /// 点赞总次数
        /// </summary>
        public int PraiseCount { get; set; }
        /// <summary>
        /// 评论用户Id
        /// </summary>
        public int CommentUserId { get; set; }
        /// <summary>
        /// 评论用户头像地址
        /// </summary>
        public string CommentUserIconPath { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }

    }

    public class ArtworkSimpleModelTranslator : TranslatorBase<Artwork, ArtworkSimpleModel>
    {
        public static readonly ArtworkSimpleModelTranslator Instance = new ArtworkSimpleModelTranslator();

        public override ArtworkSimpleModel Translate(Artwork from)
        {
            var to = new ArtworkSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ArtistName = from.Artist.Name;

            var image = from.Images.FirstOrDefault(i => i.ImageType == Data.Common.ArtworkImageResizeType.Size_W290_MinH240);
            if (image != null)
            {
                to.ImagePath = CommonHelper.GetUploadFileRelativePath_SlantStyle(image.ImagePath);
                to.ImageWidth = image.Width;
                to.ImageHeight = image.Height;
            }

            if (from.DefaultComment != null)
            {
                to.CommentUserId = from.DefaultComment.Id;
                to.CommentUserIconPath = CommonHelper.GetUploadFileRelativePath(from.DefaultComment.Customer.AvatarPath);
                to.CommentContent = from.DefaultComment.Text;
            }

            return to;
        }

        public override Artwork Translate(ArtworkSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
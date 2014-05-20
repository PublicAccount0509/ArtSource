using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 我的评价信息数据
    /// </summary>
    public class MyCommentModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string ArtworkName { get; set; }
        /// <summary>
        /// 作家头像
        /// </summary>
        public string ArtistIconPath { get; set; }
        /// <summary>
        /// 作家名称
        /// </summary>
        public string ArtistName { get; set; }
        /// <summary>
        /// 回复信息
        /// </summary>
        public string ReplyText { get; set; }
    }

    public class MyCommentModelTranslator : TranslatorBase<Comment, MyCommentModel>
    {
        public static readonly MyCommentModelTranslator Instance = new MyCommentModelTranslator();

        public override MyCommentModel Translate(Comment from)
        {
            var to = new MyCommentModel();
            to.ArtistIconPath = from.Artwork.Artist.AvatarFileName;
            to.ArtistName = from.Artwork.Artist.Name;
            to.ArtworkId = from.ArtworkId;
            to.ArtworkName = from.Artwork.Name;
            to.ReplyText = from.Text;
            return to;
        }

        public override Comment Translate(MyCommentModel from)
        {
            throw new NotImplementedException();
        }
    }
}
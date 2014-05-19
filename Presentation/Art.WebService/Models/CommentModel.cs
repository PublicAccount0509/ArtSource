using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 评论作品数据
    /// </summary>
    public class CommentModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? CreativeIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? ArtisticIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float? ObjectiveIndex { get; set; }
    }

    public enum CustomerCommentStatus
    {
        Success,

        [DisplayText("作品不存在")]
        InvalidArtworkId,

        [DisplayText("用户不存在")]
        InvalidUserId,

        [DisplayText("评论内容不能为空")]
        ContentEmpty
    }

    public class CommentModelTranslator : TranslatorBase<Comment, CommentModel>
    {
        public static readonly CommentModelTranslator Instance = new CommentModelTranslator
            ();

        public override CommentModel Translate(Comment from)
        {
            throw new NotImplementedException();
        }

        public override Comment Translate(CommentModel from)
        {
            var to = new Comment();
            to.Text = from.Content;
            to.ArtworkId = from.ArtworkId;
            to.CustomerId = from.UserId;
            to.CreativeIndex = from.CreativeIndex;
            to.ArtisticIndex = from.ArtisticIndex;
            to.ObjectiveIndex = from.ObjectiveIndex;
            return to;
        }
    }
}


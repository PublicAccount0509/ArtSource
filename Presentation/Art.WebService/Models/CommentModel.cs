using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class CommentModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public float? CreativeIndex { get; set; }
        public float? ArtisticIndex { get; set; }
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


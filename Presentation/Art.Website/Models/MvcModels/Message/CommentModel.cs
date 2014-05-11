using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class PagedCommentModel
    {
        public PagedCommentModel(IList<CommentModel> comments, PagingResult pagingResult)
        {
            this.Comments = comments;
            this.PagingResult = pagingResult;
        }
        public IList<CommentModel> Comments { get; set; }
        public PagingResult PagingResult { get; set; }
    }

    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Artwork { get; set; }
        public DateTime Date { get; set; }
        public CommentState State { get; set; }
    }

    public class CommentModelTranslator : TranslatorBase<Comment, CommentModel>
    {
        public static readonly CommentModelTranslator Instance = new CommentModelTranslator();

        public override CommentModel Translate(Comment from)
        {
            var to = new CommentModel();
            to.Id = from.Id;
            to.Text = from.Text;
            to.Artwork = from.Artwork.Name;
            to.Date = from.FADateTime;
            to.State = from.State;
            return to;
        }

        public override Comment Translate(CommentModel from)
        {
            throw new NotImplementedException();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class MessageModel
    {
        public PagedSystemNoticeModel SystemNoticeModel { get; set; }
        public PagedCommentModel CommentModel { get; set; }
    }
}
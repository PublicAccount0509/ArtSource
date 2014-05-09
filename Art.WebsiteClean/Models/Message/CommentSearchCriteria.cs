using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;
using Art.Data.Common;
namespace Art.Website.Models
{
    public class CommentSearchCriteria
    {
        public CommentSearchCriteria()
            : this(20)
        {

        }
        public CommentSearchCriteria(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CommentState? State { get; set; }

        public PagingRequest PagingRequest { get; set; }
    }
}
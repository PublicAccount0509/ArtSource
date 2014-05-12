using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class SystemNoticeSearchCriteria
    {
        public SystemNoticeSearchCriteria()
            : this(20)
        {

        }
        public SystemNoticeSearchCriteria(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public PagingRequest PagingRequest { get; set; }
    } 
}
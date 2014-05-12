using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtistSearchCriteria
    {
        public ArtistSearchCriteria()
            : this(20)
        {

        }
        public ArtistSearchCriteria(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }
        public string NamePart { get; set; }
        public int? ArtistTypeId { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}
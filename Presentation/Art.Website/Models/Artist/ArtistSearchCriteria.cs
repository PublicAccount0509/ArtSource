using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtistSearchCriteriaModel
    {
        public ArtistSearchCriteriaModel()
            : this(20)
        {

        }
        public ArtistSearchCriteriaModel(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }
        public string NamePart { get; set; }
        public int? ArtistTypeId { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}
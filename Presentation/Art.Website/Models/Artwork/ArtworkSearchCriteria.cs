using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtworkSearchCriteriaModel
    {
        public ArtworkSearchCriteriaModel()
            : this(20)
        {

        }
        public ArtworkSearchCriteriaModel(int pageSize)
        {
            PagingRequest = new PagingRequest(0, pageSize);
        }

        public string NamePart { get; set; }

        public int? ArtworkTypeId { get; set; }

        public int? ArtistId { get; set; }

        public int? ArtMaterialId { get; set; }

        public PagingRequest PagingRequest { get; set; }
    }
}
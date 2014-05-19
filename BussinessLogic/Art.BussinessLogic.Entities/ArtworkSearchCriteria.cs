using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic.Entities
{
    public class ArtworkSearchCriteria
    {
        public ArtworkSearchCriteria(PagingRequest paging)
        {
            this.PagingRequest = paging;
        }

        public string NamePart { get; set; }
        public int? ArtworkTypeId { get; set; }
        public int? ArtMaterialId { get; set; }
        public int? ArtistId { get; set; }

        public int? CollectionCustomerId { get; set; }
        public int? PraiseCustomerId { get; set; }

        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ArtworkType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public PagingRequest PagingRequest { get; set; }
    }
}

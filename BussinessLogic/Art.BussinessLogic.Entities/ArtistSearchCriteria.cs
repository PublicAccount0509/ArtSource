using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic.Entities
{
    public class ArtistSearchCriteria
    {
        public ArtistSearchCriteria(PagingRequest paging)
        {
            this.PagingRequest = paging;
        }

        public string NamePart { get; set; }
        public int? ArtistTypeId { get; set; }

        public PagingRequest PagingRequest { get; set; }
    }
}

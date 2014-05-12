using System;
using WebExpress.Core;

namespace Art.BussinessLogic.Entities
{
    public class AuctionSearchCriteria
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? ArtworkId { get; set; }
        public int? ArtistsId { get; set; }
        public PagingRequest PagingRequest { get; set; }
    }
}

using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class AuctionBill : BaseEntity
    {
        public int ArtworkId { get; set; }

        public int CustomerId { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal BidPrice { get; set; }

        public string CustumerMessage { get; set; }

        public DateTime BidDateTime { get; set; }

        public AuctionResult AuctionResult { get; set; }

        public virtual Artwork Artwork { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

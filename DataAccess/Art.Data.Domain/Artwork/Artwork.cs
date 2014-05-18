using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Artwork : BaseEntity, ISoftDelete
    {
        public int IdentityNumber { get; set; }
        public string Name { get; set; }
        public virtual Artist Artist { get; set; }
        public string Institution { get; set; }
        public string Size { get; set; }

        public virtual AuctionType AuctionType { get; set; }
        public decimal AuctionPrice { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }


        //public virtual ArtPeriod ArtPeriod { get; set; }
        public virtual int ArtYear { get; set; }
        public virtual Genre Genre { get; set; }
        public string CreationInspiration { get; set; }
        public string ImageFileName { get; set; }

        public bool IsPublic { get; set; }


        public decimal? FeePackageGeneral { get; set; }

        public decimal? FeePackageFine { get; set; }

        public decimal? FeeDeliveryLocal { get; set; }

        public decimal? FeeDeliveryNonlocal { get; set; }


        public virtual ICollection<ArtPlace> SuitableArtPlaces { get; set; }

        public virtual ArtworkType ArtworkType { get; set; }
        public virtual ArtMaterial ArtMaterial { get; set; }
        public virtual ArtShape ArtShape { get; set; }
        public virtual ArtTechnique ArtTechnique { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public int? DefaultCommentId { get; set; }
        public virtual Comment DefaultComment { get; set; }

        public virtual List<ArtworkImage> Images { get; set; }
    }

}

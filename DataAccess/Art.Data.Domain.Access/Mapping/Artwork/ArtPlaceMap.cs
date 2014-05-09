using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ArtPlaceMap : ArtEntityTypeConfiguration<ArtPlace>
    {
        public ArtPlaceMap()
        {
            this.HasMany(t => t.Artworks)
                 .WithMany(t => t.SuitableArtPlaces)
                 .Map(t => t.MapLeftKey("ArtPlaceId").MapRightKey("ArtworkId"));
        }
    }
}

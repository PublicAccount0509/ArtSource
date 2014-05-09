using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ArtworkMap : ArtEntityTypeConfiguration<Artwork>
    {
        public ArtworkMap()
        {
            this.HasRequired(i => i.Artist);
            this.HasRequired(i => i.ArtworkType).WithMany().WillCascadeOnDelete(false);
            this.HasRequired(i => i.ArtMaterial);


            this.HasMany(t => t.SuitableArtPlaces)
                 .WithMany(t => t.Artworks)
                 .Map(t => t.MapLeftKey("ArtworkId").MapRightKey("ArtPlaceId"));


        }
    }
}

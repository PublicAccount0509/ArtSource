using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ArtistMap : ArtEntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            this.HasMany(t => t.Professions)
                 .WithMany(t => t.Artists)
                 .Map(t => t.MapLeftKey("ArtistId").MapRightKey("ProfessionId"));

            this.HasMany(t => t.SkilledGenres)
                .WithMany(t => t.Artists)
                .Map(t => t.MapLeftKey("GenreId").MapRightKey("ArtistId"));
        }
    }
}

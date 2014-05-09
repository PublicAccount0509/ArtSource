using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class GenreMap : ArtEntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            this.HasMany(t => t.Artists)
                 .WithMany(t => t.SkilledGenres)
                 .Map(t => t.MapLeftKey("ArtistId").MapRightKey("GenreId"));
        }
    }
}

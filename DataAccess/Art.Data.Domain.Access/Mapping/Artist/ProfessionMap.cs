using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ArtistTypeMap : ArtEntityTypeConfiguration<ArtistType>
    {
        public ArtistTypeMap()
        {
            this.HasMany(t => t.Artists)
                 .WithMany(t => t.ArtistTypes)
                 .Map(t => t.MapLeftKey("ArtistTypeId").MapRightKey("ArtistId"));
        }
    }
}

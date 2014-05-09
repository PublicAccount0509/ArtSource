using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class ProfessionMap : ArtEntityTypeConfiguration<Profession>
    {
        public ProfessionMap()
        {
            this.HasMany(t => t.Artists)
                 .WithMany(t => t.Professions)
                 .Map(t => t.MapLeftKey("ProfessionId").MapRightKey("ArtistId"));
        }
    }
}

using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access
{ 
    public class ArtEntityTypeConfiguration<TEntityType> : EntityTypeConfiguration<TEntityType> where TEntityType : class
    {
        public ArtEntityTypeConfiguration()
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntityType)))
            {
                this.Map(i => i.Requires("IsDeleted").HasValue(false));
            }
        }
    }
}

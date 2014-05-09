using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class CustomerMap : ArtEntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.HasMany(c => c.Addresses)
            .WithRequired(a => a.Customer)
            .Map(x => x.MapKey("CustomerId"));
        }
    }
}

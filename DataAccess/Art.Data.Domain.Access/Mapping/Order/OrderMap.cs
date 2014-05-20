using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Mapping
{
    public class OrderMap : ArtEntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasRequired(i => i.ReceiptAddress).WithMany().WillCascadeOnDelete(false);
        }
    }
}

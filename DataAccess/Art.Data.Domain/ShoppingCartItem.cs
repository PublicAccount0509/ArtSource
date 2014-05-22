using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ShoppingCartItem : BaseEntity
    {
        public int ArtworkId { get; set; }

        public int CustomerId { get; set; }

        public DateTime FADateTime { get; set; }

        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }
         
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}

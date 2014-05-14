using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ActivityCollect : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }

        public DateTime FADatetime { get; set; }
    }
}

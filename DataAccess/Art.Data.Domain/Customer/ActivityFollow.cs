using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ActivityFollow : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ArtistId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

        public DateTime FADatetime { get; set; }
    }
}

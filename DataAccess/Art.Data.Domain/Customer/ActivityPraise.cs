using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ActivityPraise : BaseEntity
    {
        public virtual Customer Customer { get; set; }
        public virtual Artwork Artwork { get; set; }

        public DateTime FADatetime { get; set; }
    }
}

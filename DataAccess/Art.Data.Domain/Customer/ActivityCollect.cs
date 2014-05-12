using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ActivityCollect : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }

        public DateTime FADatetime { get; set; }
    }
}

using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Domain
{
    public class Genre : BaseEntity, IIdNameEntry
    { 
        [StringLength(30)]
        public string Name { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}

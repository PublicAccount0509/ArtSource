using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Profession : BaseEntity, ISoftDelete
    {
        public Profession()
        {
            Artists = new HashSet<Artist>();
        } 
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}

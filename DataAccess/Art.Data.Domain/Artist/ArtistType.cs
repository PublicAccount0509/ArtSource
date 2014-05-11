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
    public class ArtistType : BaseEntity, ISoftDelete
    {
        public ArtistType()
        {
            Artists = new HashSet<Artist>();
        }

        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
    }
}

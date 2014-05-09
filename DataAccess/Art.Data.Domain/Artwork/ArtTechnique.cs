using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtTechnique : BaseEntity, ISoftDelete
    {
        public ArtTechnique()
        {
            Artworks = new List<Artwork>();
        }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public ArtworkType ArtworkType { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}

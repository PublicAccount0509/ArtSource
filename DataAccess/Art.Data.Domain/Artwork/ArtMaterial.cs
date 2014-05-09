using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtMaterial : BaseEntity,  ISoftDelete
    {
        public ArtMaterial()
        {
            Artworks = new List<Artwork>();
        }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }

        public ArtworkType ArtworkType { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}

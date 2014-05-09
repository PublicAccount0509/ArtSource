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
    public class ArtPlace : BaseEntity, IIdNameEntry, ISoftDelete
    {
        public ArtPlace()
        {
            Artworks = new List<Artwork>();
        }

        public string Name { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}

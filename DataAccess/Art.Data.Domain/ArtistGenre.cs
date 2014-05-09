using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtistGenre : BaseEntity
    {
        public Artist Artist { get; set; }

        public Genre Profession { get; set; }
    }
}

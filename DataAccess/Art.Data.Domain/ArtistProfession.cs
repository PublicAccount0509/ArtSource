using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtistProfession : BaseEntity
    {
        public Artist Artist { get; set; }

        public Profession Profession { get; set; }

        public bool IsPublic { get; set; }
    }
}

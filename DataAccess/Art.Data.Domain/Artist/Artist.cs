using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.Data.Domain
{
    public class Artist : BaseEntity, IIdNameEntry, ISoftDelete
    {
        public Artist()
        {
            ArtistTypes = new HashSet<ArtistType>();
            SkilledGenres = new List<Genre>();
        }

        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? Deathday { get; set; }

        [MaxLength(30)]
        public string School { get; set; }

        public bool IsPublic { get; set; }

        [MaxLength(50)]
        public string AvatarFileName { get; set; }

        [MaxLength(30)]
        public string Masterpiece { get; set; }

        public int MasterpieceTypeId { get; set; }

        [MaxLength(30)]
        public string PrizeItems { get; set; }

        public Genders Gender { get; set; }

        public Degree? Degree { get; set; }

        public virtual ICollection<ArtistType> ArtistTypes { get; set; }

        public virtual ICollection<Genre> SkilledGenres { get; set; }

        public virtual ArtworkType MasterpieceType { get; set; }
    }
     
}

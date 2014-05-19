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
    public class Comment : BaseEntity
    {
        public CommentState State { get; set; }

        [Required]
        public string Text { get; set; }
        public float? CreativeIndex { get; set; }
        public float? ArtisticIndex { get; set; }
        public float? ObjectiveIndex { get; set; }

        public int ArtworkId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("ArtworkId")]
        public virtual Artwork Artwork { get; set; }

        public DateTime FADateTime { get; set; }
    }
}

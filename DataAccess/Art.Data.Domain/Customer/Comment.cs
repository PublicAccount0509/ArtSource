using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public CommentState State { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Artwork Artwork { get; set; }

        public DateTime FADateTime { get; set; }
    }
}

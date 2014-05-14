using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtworkImage : BaseEntity
    {
        public Artwork Artwork { get; set; }
        public ArtworkImageResizeType ImageType { get; set; }
        public string ImagePath { get; set; }

        public int MyProperty { get; set; }
    }
}

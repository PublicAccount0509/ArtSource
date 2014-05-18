using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain
{
    public class ArtistImage:BaseEntity
    {
        public Artist Artist { get; set; }
        public ArtistImageType ImageType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImagePath { get; set; }
    }
}

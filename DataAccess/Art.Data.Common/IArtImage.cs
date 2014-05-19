using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Common
{
    public interface IArtImage
    {
        Enum ImageType { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string ImagePath { get; set; }
    }
}

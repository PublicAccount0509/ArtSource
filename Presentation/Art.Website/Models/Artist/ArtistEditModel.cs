using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Enums;
using WebExpress.Core.TypeExtensions;

namespace Art.Website.Models
{
    public class ArtistEditModel
    {
        public ArtistModel Artist { get; set; }

        public ArtistTypeModel[] SourceArtistTypes { get; set; }

        public GenreModel[] SourceGenres { get; set; }

        public IEnumItem[] Degrees { get; set; }

        public ValueTextEntry[] ArtworkTypes { get; set; }
    }

}
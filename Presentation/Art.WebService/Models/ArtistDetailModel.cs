using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class ArtistDetailModel
    {
        public bool HasFollowed { get; set; }
        public string IconPath { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Honur { get; set; }
        public ArtworkSimpleModel[] Artworks { get; set; }
    }
}
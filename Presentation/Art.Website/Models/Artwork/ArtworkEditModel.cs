using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core; 

namespace Art.Website.Models
{
    public class ArtworkEditModel
    {
        public ArtworkModel Artwork { get; set; }

        public IList<ValueTextEntry> SourceArtists { get; set; }

        public IList<ValueTextEntry> SourceArtPeriods { get; set; }

        public IList<ValueTextEntry> SourceArtPlaces { get; set; }

        public IList<ValueTextEntry> SourceGenres { get; set; }

        public IList<IEnumItem> SourceAuctionTypes { get; set; }

        public IList<ArtworkTypeModel> SourceArtworkTypes { get; set; }

        //public IList<IdNameModel> SourceArtMaterials { get; set; }
    }

}
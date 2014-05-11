using Art.Website.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class ArtistManageModel
    {
        public ArtistManageModel()
        {
            ArtistTypes = new List<ArtistTypeModel>();
        }

        public List<ArtistTypeModel> ArtistTypes { get; set; }

        public PagedArtistModel PagedArtists { get; set; }
    }


    public class PagedArtistModel
    {
        public PagedArtistModel(List<ArtistItem> artists,PagingResult pagingResult)
        {
            this.Artists = artists;
            this.PagingResult = pagingResult;
        }
        public List<ArtistItem> Artists { get; set; }
        public PagingResult PagingResult { get; set; }
    }
}
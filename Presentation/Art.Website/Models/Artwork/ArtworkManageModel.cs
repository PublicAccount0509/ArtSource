using Art.Website.Models.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class ArtworkManageModel
    {
        public ArtworkManageModel()
        {
        }

        public IList<ArtworkTypeModel> ArtworkTypes { get; set; }

        public IList<ValueTextEntry> Artists { get; set; }

        public PagedArtworkModel PagedArtworks { get; set; }
    }


    public class PagedArtworkModel
    {
        public PagedArtworkModel(List<ArtworkSimpleModel> artworks, PagingResult pagingResult)
        {
            this.Artworks = artworks;
            this.PagingResult = pagingResult;
        }
        public List<ArtworkSimpleModel> Artworks { get; set; }
        public PagingResult PagingResult { get; set; }
    }
}
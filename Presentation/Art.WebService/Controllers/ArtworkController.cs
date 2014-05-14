using Art.BussinessLogic;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebExpress.Core;

namespace Art.WebService.Controllers
{
    public class ArtworkController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ArtworkSimpleModel> Get()
        {
            var paging = new PagingRequest(0, 10);
            var aa = ArtworkBussinessLogic.Instance.SearchArtworks(paging);
            //var dd =  ArtworkSimpleModel.Instance.Translate(aa);
            return null;

        }

        [HttpGet]
        public ArtworkSimpleModel[] List(int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var artworks = ArtworkBussinessLogic.Instance.SearchArtworks(paging);
            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            return models.ToArray();
        }



    }
}
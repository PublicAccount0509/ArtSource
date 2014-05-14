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
            foreach (var model in models)
            {
                model.ShareCount = ArtworkBussinessLogic.Instance.GetShareCount(model.Id);
                model.CollectAccount = ArtworkBussinessLogic.Instance.GetCollectCount(model.Id);
                model.PraiseCount = ArtworkBussinessLogic.Instance.GetPraiseCount(model.Id);
            }
            return models.ToArray();
        }

        //public 

        public SimpleResultModel Share(ShareArtworkModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ShareArtworkStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ShareArtworkStatus.UserNotExist, "指定的用户Id不存在");
            }

            ArtworkBussinessLogic.Instance.Share(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }


    }
}
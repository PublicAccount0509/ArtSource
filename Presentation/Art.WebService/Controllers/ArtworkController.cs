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
        public ResultModel<ArtworkSimpleModel[]> List(int itemsCount, int pageIndex)
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
            var result = new ResultModel<ArtworkSimpleModel[]>(0);
            result.Result = models.ToArray();
            return result;
        }

        [HttpGet]
        public ResultModel<ArtworkDetailModel> Detail(int artworkId, int? userId)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(artworkId);
            var model = ArtworkDetailModelTranslator.Instance.Translate(artwork);
            if (userId.HasValue)
            {
                model.HasPraised = ArtworkBussinessLogic.Instance.HasPraised(artworkId, userId.Value);
            }            
            var result = new ResultModel<ArtworkDetailModel>((int)ArtworkDetailModelStatus.Success, string.Empty, model);
            return result;
        }

        //public  
        public SimpleResultModel Share(ActivityShareModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityShareStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityShareStatus.UserNotExist, "指定的用户Id不存在");
            }

            ArtworkBussinessLogic.Instance.Share(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }

        public SimpleResultModel Collect(ActivityCollectModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.UserNotExist, "指定的用户Id不存在");
            }

            if (ArtworkBussinessLogic.Instance.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.AlreadyCollected, "用户已经收藏过该作品");
            }

            ArtworkBussinessLogic.Instance.Collect(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }

        public SimpleResultModel CancelCollect(ActivityCancelCollectModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityCancelCollectStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityCancelCollectStatus.UserNotExist, "指定的用户Id不存在");
            }

            if (!ArtworkBussinessLogic.Instance.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityCancelCollectStatus.NotCollectYet, "用户还没有收藏过该作品");
            }

            ArtworkBussinessLogic.Instance.CancelCollect(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }

        public SimpleResultModel Praise(ActivityPraiseModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.UserNotExist, "指定的用户Id不存在");
            }

            if (ArtworkBussinessLogic.Instance.ExistPraise(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.AlreadyPraised, "用户已经收藏过该作品");
            }

            ArtworkBussinessLogic.Instance.Praise(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }


        public SimpleResultModel CancelPraise(ActivityCancelPraiseModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityCancelPraiseStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityCancelPraiseStatus.UserNotExist, "指定的用户Id不存在");
            }

            if (!ArtworkBussinessLogic.Instance.ExistPraise(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityCancelPraiseStatus.NotPraiseYet, "用户还没有赞过该作品");
            }

            ArtworkBussinessLogic.Instance.CancelCollect(model.ArtworkId, model.UserId);
            return SimpleResultModel.Success();
        }
    }
}
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

        public ArtworkDetailModel Detail(int artworkId,int userId)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(artworkId);

            return null;
        }

        public SimpleResultModel Share(ShareArtworkModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ShareArtworkStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ShareArtworkStatus.UserNotExist, "指定的用户不存在");
            }
            //if (ArtistBussinessLogic.Instance.ExistFollow(model.ArtworkId, model.UserId))
            //{
            //    return new SimpleResultModel((int)ShareArtworkStatus.ArtistAlreadyShared, "您已经分享过该作品");
            //}
            var entity = ShareArtworkModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.Share(entity);
            return SimpleResultModel.Success();
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// The SimpleResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SimpleResultModel Praise(PraiseArtworkModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)PraiseArtworkStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)PraiseArtworkStatus.UserNotExist, "指定的用户不存在");
            }
            if (ArtworkBussinessLogic.Instance.ExistPraise(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)PraiseArtworkStatus.ArtistAlreadyPraised, "您已经赞过该作品");
            }
            var praiseArtwork = PraiseArtworkModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.Praise(praiseArtwork);
            return SimpleResultModel.Success();
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// The SimpleResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 6:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public SimpleResultModel Collect(CollectArtworkModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.UserNotExist, "指定的用户不存在");
            }
            if (ArtworkBussinessLogic.Instance.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.ArtistAlreadyCollected, "您已经收藏过该作品");
            }
            var collectArtwork = CollectArtworkModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.Collect(collectArtwork);
            return SimpleResultModel.Success();
        }

        /// <summary>
        /// Cancels the collect.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// SimpleResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 7:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public SimpleResultModel CancelCollect(CollectArtworkModel model)
        {
            if (!ArtworkBussinessLogic.Instance.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.UserNotExist, "指定的用户不存在");
            }
            if (!ArtworkBussinessLogic.Instance.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)CollectArtworkStatus.ArtistNoCollected, "您还没有收藏该作品");
            }
            var collectArtwork = CollectArtworkModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.DeleteCollect(collectArtwork);
            return SimpleResultModel.Success();
        }
    }
}
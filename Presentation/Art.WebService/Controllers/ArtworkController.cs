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
        private IArtistBussinessLogic _artistBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        private ICustomerBussinessLogic _customerBussinessLogic;
        public ArtworkController(IArtistBussinessLogic artistBussinessLogic, 
            IArtworkBussinessLogic artworkBussinessLogic,
            ICustomerBussinessLogic customerBussinessLogic )
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _customerBussinessLogic = customerBussinessLogic;
        }

        // GET api/<controller>
        public IEnumerable<ArtworkSimpleModel> Get()
        {
            var paging = new PagingRequest(0, 10);
            var aa = _artworkBussinessLogic.SearchArtworks(paging);
            //var dd =  ArtworkSimpleModel.Instance.Translate(aa);
            return null;

        }

        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> List(int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var artworks = _artworkBussinessLogic.SearchArtworks(paging);
            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = _artworkBussinessLogic.GetShareCount(model.Id);
                model.CollectAccount = _artworkBussinessLogic.GetCollectCount(model.Id);
                model.PraiseCount = _artworkBussinessLogic.GetPraiseCount(model.Id);
            }
            var result = new ResultModel<ArtworkSimpleModel[]>(0);
            result.Result = models.ToArray();
            return result;
        }

        [HttpGet]
        public ResultModel<ArtworkDetailModel> Detail(int artworkId, int? userId)
        {
            var artwork = _artworkBussinessLogic.GetArtwork(artworkId);
            var model = ArtworkDetailModelTranslator.Instance.Translate(artwork);
            if (userId.HasValue)
            {
                model.HasPraised = _artworkBussinessLogic.ExistPraise(artworkId, userId.Value);
            }            
            var result = new ResultModel<ArtworkDetailModel>((int)ArtworkDetailModelStatus.Success, string.Empty, model);
            return result;
        }

        ////public  
        public SimpleResultModel Share(ActivityShareModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityShareStatus.ArtworkNotExist, "指定的作品Id不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityShareStatus.UserNotExist, "指定的用户Id不存在");
            }

            _artworkBussinessLogic.Share(model.ArtworkId, model.UserId);
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
        public SimpleResultModel Praise(ActivityPraiseModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.UserNotExist, "指定的用户不存在");
            }

            if (_artworkBussinessLogic.ExistPraise(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityPraiseStatus.AlreadyPraised, "您已经赞过该作品");
            }
            _artworkBussinessLogic.Praise(model.ArtworkId, model.UserId);
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
        public SimpleResultModel Collect(ActivityCollectModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.ArtworkNotExist, "指定的作品不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.UserNotExist, "指定的用户不存在");
            }
            if (_artworkBussinessLogic.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityCollectStatus.AlreadyCollected, "您已经收藏过该作品");
            }

            _artworkBussinessLogic.Collect(model.ArtworkId, model.UserId);
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
        public SimpleResultModel CancelCollect(ActivityCancelCollectModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return new SimpleResultModel((int)ActivityCancelCollectStatus.ArtworkNotExist, "指定的作品不存在");

            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {

                return new SimpleResultModel((int)ActivityCancelCollectStatus.UserNotExist, "指定的用户Id不存在");
            }

            if (!_artworkBussinessLogic.ExistCollect(model.ArtworkId, model.UserId))
            {
                return new SimpleResultModel((int)ActivityCancelCollectStatus.NotCollectYet, "用户还没有收藏过该作品");
            }

            _artworkBussinessLogic.CancelCollect(model.ArtworkId, model.UserId);
              
            return SimpleResultModel.Success();
        }

        /// <summary>
        /// Prices the information.
        /// </summary>
        /// <param name="artworkId">The artworkId</param>
        /// <returns>
        /// ResultModel{PriceInfoModel}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ResultModel<PriceInfoModel> PriceInfo(int artworkId)
        {
            var artwork = _artworkBussinessLogic.GetArtwork(artworkId);
            if (artwork == null)
            {
                return new ResultModel<PriceInfoModel>((int)PriceInfoStatus.ArtworkNotExist);
            }
            return new ResultModel<PriceInfoModel>
                {
                    Status = (int)PriceInfoStatus.Success,
                    Result = PriceInfoModelTranslator.Instance.Translate(artwork)
                };
        }

        /// <summary>
        /// Deveries the ways.
        /// </summary>
        /// <param name="artworkIds">The artworkIds</param>
        /// <returns>
        /// ResultModel{DeveryWaysModel[]}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 2:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ResultModel<DeveryWaysModel[]> DeveryWays(int[] artworkIds)
        {
            if (artworkIds == null)
            {
                return new ResultModel<DeveryWaysModel[]>((int) DeveryWaysStatus.NoData);
            }
            var artworks = _artworkBussinessLogic.DeveryWays(artworkIds);
            return
                new ResultModel<DeveryWaysModel[]>
                    {
                        Status = (int) DeveryWaysStatus.Success,
                        Result = artworks.Select(p => DeveryWaysModelTranslator.Instance.Translate(p)).ToArray()
                    };
        }
    }
}
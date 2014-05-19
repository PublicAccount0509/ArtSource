﻿using Art.BussinessLogic;
using Art.BussinessLogic.Entities;
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
            ICustomerBussinessLogic customerBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _customerBussinessLogic = customerBussinessLogic;
        }

        // GET api/<controller>
        public IEnumerable<ArtworkSimpleModel> Get()
        {
            var paging = new PagingRequest(0, 10);
            var aa = _artworkBussinessLogic.SearchArtworks(new ArtworkSearchCriteria(paging));
            //var dd =  ArtworkSimpleModel.Instance.Translate(aa);
            return null;

        }

        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> List(int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging);
            var result = SearchArtwork(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
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
            var result = ResultModel<ArtworkDetailModel>.Conclude(ArtworkDetailModelStatus.Success, model);
            return result;
        }

        ////public  
        public SimpleResultModel Share(ActivityShareModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return SimpleResultModel.Conclude(ActivityShareStatus.ArtworkNotExist);//, "指定的作品Id不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityShareStatus.UserNotExist);//, "指定的用户Id不存在");
            }

            _artworkBussinessLogic.Share(model.ArtworkId, model.UserId);
            return SimpleResultModel.Conclude(ActivityShareStatus.Success);
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
                return SimpleResultModel.Conclude(ActivityPraiseStatus.ArtworkNotExist);//, "指定的作品不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityPraiseStatus.UserNotExist);//, "指定的用户不存在");
            }

            if (_artworkBussinessLogic.ExistPraise(model.ArtworkId, model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityPraiseStatus.AlreadyPraised);//, "您已经赞过该作品");
            }
            _artworkBussinessLogic.Praise(model.ArtworkId, model.UserId);
            return SimpleResultModel.Conclude(ActivityPraiseStatus.Success);
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
                return SimpleResultModel.Conclude(ActivityCollectStatus.ArtworkNotExist);//, "指定的作品不存在");
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityCollectStatus.UserNotExist);//, "指定的用户不存在");
            }
            if (_artworkBussinessLogic.ExistCollect(model.ArtworkId, model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityCollectStatus.AlreadyCollected);//, "您已经收藏过该作品");
            }

            _artworkBussinessLogic.Collect(model.ArtworkId, model.UserId);

            return SimpleResultModel.Conclude(ActivityCollectStatus.Success);
        }



        /// <summary>
        /// 获取所有收藏的作品
        /// </summary> 
        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> Collected(int userId, int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging) { CollectionCustomerId = userId };

            var result = SearchArtwork(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
        }

        [HttpPost]
        public SimpleResultModel Comment(CommentModel model)
        {
            if (string.IsNullOrEmpty(model.Content))
            {
                return SimpleResultModel.Conclude(CustomerCommentStatus.ContentEmpty);
            }

            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return SimpleResultModel.Conclude(CustomerCommentStatus.InvalidArtworkId);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(CustomerCommentStatus.InvalidUserId);
            }

            var comment = CommentModelTranslator.Instance.Translate(model);
            _customerBussinessLogic.AddComment(comment);

            return SimpleResultModel.Conclude(CustomerCommentStatus.Success);
        }

        [HttpGet]
        //获取所有评价过的作品
        public ResultModel<CommentedArtworkModel[]> Commented(int userId)
        {
            var comments = _customerBussinessLogic.GetComments(userId);
            var models = CommentedArtworkModelTranslator.Instance.Translate(comments);
            return ResultModel<CommentedArtworkModel[]>.Conclude(StandaloneStatus.Success, models.ToArray());
        }


        /// <summary>
        /// 获取所有赞过的作品
        /// </summary> 
        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> Praised(int userId, int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging) { PraiseCustomerId = userId };

            var result = SearchArtwork(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
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
                return SimpleResultModel.Conclude(ActivityCancelCollectStatus.ArtworkNotExist);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {

                return SimpleResultModel.Conclude(ActivityCancelCollectStatus.UserNotExist);
            }

            if (!_artworkBussinessLogic.ExistCollect(model.ArtworkId, model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityCancelCollectStatus.NotCollectYet);
            }

            _artworkBussinessLogic.CancelCollect(model.ArtworkId, model.UserId);

            return SimpleResultModel.Conclude(ActivityCancelCollectStatus.Success);
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
                return ResultModel<PriceInfoModel>.Conclude(PriceInfoStatus.ArtworkNotExist);
            }

            var result = PriceInfoModelTranslator.Instance.Translate(artwork);
            return ResultModel<PriceInfoModel>.Conclude(PriceInfoStatus.Success, result);
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
        [HttpPost]
        public ResultModel<DeveryWaysModel[]> DeliveryWays(int[] artworkIds)
        {
            var artworks = _artworkBussinessLogic.GetArtworks(artworkIds);

            var result = DeveryWaysModelTranslator.Instance.Translate(artworks).ToArray();

            return ResultModel<DeveryWaysModel[]>.Conclude(StandaloneStatus.Success, result);
        }   

        [HttpGet]
        //获取包装方式
        public ResultModel<ArtworkPackingWayModel> PackingWays(int artworkId)
        {
            var artwork = _artworkBussinessLogic.GetArtwork(artworkId);

            var result = ArtworkPackingWayModelTranslator.Instance.Translate(artwork);

            return ResultModel<ArtworkPackingWayModel>.Conclude(StandaloneStatus.Success, result);
        }

        private ArtworkSimpleModel[] SearchArtwork(ArtworkSearchCriteria criteria)
        {
            var artworks = _artworkBussinessLogic.SearchArtworks(criteria);

            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = _artworkBussinessLogic.GetShareCount(model.Id);
                model.CollectAccount = _artworkBussinessLogic.GetCollectCount(model.Id);
                model.PraiseCount = _artworkBussinessLogic.GetPraiseCount(model.Id);
            }

            return models.ToArray();
        }
    }
}
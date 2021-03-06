﻿using Art.BussinessLogic;
using Art.BussinessLogic.Entities;
using Art.Data.Domain;
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

        /// <summary>
        /// 获取首页艺术品列表
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> List(int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging)
            {
                IsPublic = true
            };

            criteria.OrderByItems.Add(new OrderByItem<Artwork>(i => i.AtTopDatetime.Value, System.Data.SqlClient.SortOrder.Descending));
            criteria.OrderByItems.Add(new OrderByItem<Artwork>(i => i.Id, System.Data.SqlClient.SortOrder.Descending));
            var result = SearchArtworkAndAttachCount(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
        }

        /// <summary>
        /// 获取艺术品列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpPost]
        public ResultModel<ArtworkSimpleModel[]> Search(ArtworkSearchCriteriaModel model)
        {
            var paging = new PagingRequest(model.PageIndex, model.ItemsCount);
            var criteria = new ArtworkSearchCriteria(paging)
            {
                NamePart = model.ArtworkNamePart,
                ArtworkTypeId = model.ArtworkTypeId,
                BeginYear = model.BeginYear,
                EndYear = model.EndYear,
                MinPrice = model.MinPrice,
                MaxPrice = model.MaxPrice,
            };
            if (model.OrderByField.HasValue)
            {
                switch (model.OrderByField.Value)
                {
                    case OrderByField.Hot:
                        criteria.OrderByItems.Add(new OrderByItem<Artwork>(i => i.Praises.Count, System.Data.SqlClient.SortOrder.Descending));
                        break;
                    case OrderByField.New:
                        criteria.FromDate = DateTime.Now.AddMonths(-1);
                        break;
                    case OrderByField.Price:
                        criteria.OrderByItems.Add(new OrderByItem<Artwork>(i => i.AuctionPrice, System.Data.SqlClient.SortOrder.Descending));
                        break;
                    default:
                        break;
                }
            }
            var result = SearchArtworkAndAttachCount(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
        }

        /// <summary>
        /// 获取作品分类列表
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<ArtworkTypeSimpleModel[]> ArtworkTypeList()
        {
            var artworkTypes = _artworkBussinessLogic.GetArtworkTypes();
            var result = ArtworkTypeSimpleModelTranslator.Instance.Translate(artworkTypes);
            return ResultModel<ArtworkTypeSimpleModel[]>.Conclude(StandaloneStatus.Success, result.ToArray());
        }

        /// <summary>
        /// 获取作品详情
        /// </summary>
        [ActionStatus(typeof(ArtworkDetailModelStatus))]
        [HttpGet]
        public ResultModel<ArtworkDetailModel> Detail(int artworkId, int? userId)
        {
            var artwork = _artworkBussinessLogic.GetArtwork(artworkId);
            if (artwork == null)
            {
                return ResultModel<ArtworkDetailModel>.Conclude(ArtworkDetailModelStatus.ArtworkNotFound);
            }
            var model = ArtworkDetailModelTranslator.Instance.Translate(artwork);
            if (userId.HasValue)
            {
                model.HasPraised = _artworkBussinessLogic.ExistPraise(artworkId, userId.Value);
            }

            model.ShareCount = _artworkBussinessLogic.GetSharedCount(artworkId);
            model.CollectAccount = _artworkBussinessLogic.GetCollectedCount(artworkId);
            model.PraiseCount = _artworkBussinessLogic.GetPraisedCount(artworkId);

            var result = ResultModel<ArtworkDetailModel>.Conclude(ArtworkDetailModelStatus.Success, model);
            return result;
        }

        /// <summary>
        /// 分享作品
        /// </summary>
        [ActionStatus(typeof(ActivityShareStatus))]
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
        /// 赞作品
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(ActivityPraiseStatus))]
        [HttpPost]
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
        /// 取消赞
        /// </summary>
        [ActionStatus(typeof(ActivityCancelPraiseStatus))]
        [HttpPost]
        public SimpleResultModel CancelPraise(ActivityPraiseModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return SimpleResultModel.Conclude(ActivityCancelPraiseStatus.ArtworkNotExist);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {

                return SimpleResultModel.Conclude(ActivityCancelPraiseStatus.UserNotExist);
            }

            if (!_artworkBussinessLogic.ExistPraise(model.ArtworkId, model.UserId))
            {
                return SimpleResultModel.Conclude(ActivityCancelPraiseStatus.NotPraised);
            }

            _artworkBussinessLogic.CancelPraise(model.ArtworkId, model.UserId);

            return SimpleResultModel.Conclude(ActivityCancelPraiseStatus.Success);
        }

        /// <summary>
        /// 收藏作品
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 6:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(ActivityCollectStatus))]
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
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> Collected(int userId, int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging) { CollectionCustomerId = userId };

            var result = SearchArtworkAndAttachCount(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
        }

        /// <summary>
        /// 评论作品
        /// </summary>
        [ActionStatus(typeof(CustomerCommentStatus))]
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
            _artworkBussinessLogic.AddComment(comment);

            return SimpleResultModel.Conclude(CustomerCommentStatus.Success);
        }

        /// <summary>
        /// 获取所有评价过的作品
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<CommentedArtworkModel[]> Commented(int userId)
        {
            var comments = _artworkBussinessLogic.GetComments(userId);
            var models = CommentedArtworkModelTranslator.Instance.Translate(comments);
            return ResultModel<CommentedArtworkModel[]>.Conclude(StandaloneStatus.Success, models.ToArray());
        }

        /// <summary>
        /// 获取所有赞过的作品
        /// </summary>
        [ActionStatus(typeof(StandaloneStatus))]
        [HttpGet]
        public ResultModel<ArtworkSimpleModel[]> Praised(int userId, int itemsCount, int pageIndex)
        {
            var paging = new PagingRequest(pageIndex, itemsCount);
            var criteria = new ArtworkSearchCriteria(paging) { PraiseCustomerId = userId };

            var result = SearchArtworkAndAttachCount(criteria);
            return ResultModel<ArtworkSimpleModel[]>.Conclude(StandaloneStatus.Success, result);
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 7:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(ActivityCancelCollectStatus))]
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
        /// 获取艺术品价格
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [ActionStatus(typeof(PriceInfoStatus))]
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
        /// 获取配送方式
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 2:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [ActionStatus(typeof(GetDeveryWaysStatus))]
        public ResultModel<DeveryWaysModel[]> DeliveryWays(string artworkIds)
        {
            if (artworkIds == null)
            {
                return ResultModel<DeveryWaysModel[]>.Conclude(GetDeveryWaysStatus.InvalidArgument);
            }

            var strIds = artworkIds.Split(',');
            var intIds = new List<int>();
            for (int i = 0; i < strIds.Length; i++)
            {
                int id;
                if (int.TryParse(strIds[i], out id))
                {
                    intIds.Add(id);
                }
                else
                {
                    return ResultModel<DeveryWaysModel[]>.Conclude(GetDeveryWaysStatus.InvalidArgument);
                }
            }

            var artworks = _artworkBussinessLogic.GetArtworks(intIds.ToArray());

            var result = DeveryWaysModelTranslator.Instance.Translate(artworks).ToArray();

            return ResultModel<DeveryWaysModel[]>.Conclude(GetDeveryWaysStatus.Success, result);
        }

        /// <summary>
        /// 获取包装方式
        /// </summary>
        [ActionStatus(typeof(GetArtworkPackingWayStatus))]
        [HttpGet]
        public ResultModel<ArtworkPackingWayModel[]> PackingWays(string artworkIds)
        {
            if (artworkIds == null)
            {
                return ResultModel<ArtworkPackingWayModel[]>.Conclude(GetArtworkPackingWayStatus.InvalidArgument);
            }

            var strIds = artworkIds.Split(',');
            var intIds = new List<int>();
            for (int i = 0; i < strIds.Length; i++)
            {
                int id;
                if (int.TryParse(strIds[i], out id))
                {
                    intIds.Add(id);
                }
                else
                {
                    return ResultModel<ArtworkPackingWayModel[]>.Conclude(GetArtworkPackingWayStatus.InvalidArgument);
                }
            }

            var artworks = _artworkBussinessLogic.GetArtworks(intIds.ToArray());

            var result = ArtworkPackingWayModelTranslator.Instance.Translate(artworks);

            return ResultModel<ArtworkPackingWayModel[]>.Conclude(GetArtworkPackingWayStatus.Success, result.ToArray());
        }

        private ArtworkSimpleModel[] SearchArtworkAndAttachCount(ArtworkSearchCriteria criteria)
        {
            var artworks = _artworkBussinessLogic.SearchArtworks(criteria);

            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = _artworkBussinessLogic.GetSharedCount(model.Id);
                model.CollectAccount = _artworkBussinessLogic.GetCollectedCount(model.Id);
                model.PraiseCount = _artworkBussinessLogic.GetPraisedCount(model.Id);
            }

            return models.ToArray();
        }
    }
}
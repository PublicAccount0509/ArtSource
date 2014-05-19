using System;
using System.Linq;
using System.Web.Http;
using Art.BussinessLogic;
using Art.WebService.Models;
using WebExpress.Core;
using Art.BussinessLogic.Entities;

namespace Art.WebService.Controllers
{
    public class ArtistController : ApiController
    {
        private IArtistBussinessLogic _artistBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        private ICustomerBussinessLogic _customerBussinessLogic;
        public ArtistController(IArtistBussinessLogic artistBussinessLogic,
            IArtworkBussinessLogic artworkBussinessLogic,
            ICustomerBussinessLogic customerBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _customerBussinessLogic = customerBussinessLogic;
        }


        [HttpGet]
        public ResultModel<ArtistSimpleModel[]> List()
        {
            var pageIndex = 0;
            var itemsCount = int.MaxValue;
            var paging = new PagingRequest(pageIndex, itemsCount);

            var criteria = new ArtistSearchCriteria(paging);
            var artworks = _artistBussinessLogic.SearchArtists(criteria);
            var result = ArtistSimpleModelTranslator.Instance.Translate(artworks);
            return ResultModel<ArtistSimpleModel[]>.Conclude(StandaloneStatus.Success, result.ToArray());
        }


        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="artistId">The artistId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// The ArtistDetailModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ResultModel<ArtistDetailModel> Detail(int artistId, int? userId)
        {
            var artist = _artistBussinessLogic.GetArtist(artistId);
            if (artist == null)
            {
                return ResultModel<ArtistDetailModel>.Conclude(ArtistDetailModelStatus.ArtistNotExist); ;//, "艺术家不存在");
            }
            var artworks = _artworkBussinessLogic.GetArtworksByArtistId(artistId);
            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = _artworkBussinessLogic.GetShareCount(model.Id);
                model.CollectAccount = _artworkBussinessLogic.GetCollectCount(model.Id);
                model.PraiseCount = _artworkBussinessLogic.GetPraiseCount(model.Id);
            }
            var artistDetailModel = ArtistDetailModelTranslator.Instance.Translate(artist);
            artistDetailModel.HasFollowed =
                userId != null &&
                _artistBussinessLogic.ExistFollow(artistId, Convert.ToInt32(userId));
            artistDetailModel.Artworks = models.ToArray();
            return ResultModel<ArtistDetailModel>.Conclude(ArtistDetailModelStatus.Success, artistDetailModel);
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// The ResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public SimpleResultModel Follow(FollowModel model)
        {
            if (!_artistBussinessLogic.Exist(model.ArtistId))
            {
                return SimpleResultModel.Conclude(FollowModelStatus.ArtistNotExist);//, "要关注的艺术家不存在");
            }
            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(FollowModelStatus.UserNotExist);//, "无效的用户");
            }
            if (_artistBussinessLogic.ExistFollow(model.ArtistId, model.UserId))
            {
                return SimpleResultModel.Conclude(FollowModelStatus.ArtistAlreadyFollowed);//, "您已经关注了该艺术家");
            }
            var entity = FollowModelTranslator.Instance.Translate(model);
            _artistBussinessLogic.AddFollow(entity);

            return SimpleResultModel.Conclude(FollowModelStatus.Success);
        }

        /// <summary>
        /// Cancels the follow.
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// SimpleResultModel
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 5:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public SimpleResultModel CancelFollow(FollowModel model)
        {
            if (!_artistBussinessLogic.Exist(model.ArtistId))
            {
                return SimpleResultModel.Conclude(CancelFollowStatus.ArtistNotExist);//, "要取消关注的艺术家不存在");
            }
            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return SimpleResultModel.Conclude(CancelFollowStatus.UserNotExist);//, "无效的用户");
            }
            if (!_artistBussinessLogic.ExistFollow(model.ArtistId, model.UserId))
            {
                return SimpleResultModel.Conclude(CancelFollowStatus.NotFollowYet);//, "您还没有关注该艺术家");
            }

            var entity = FollowModelTranslator.Instance.Translate(model);
            _artistBussinessLogic.DeleteFollow(entity);

            return SimpleResultModel.Conclude(CancelFollowStatus.Success);
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="userid">The userid</param>
        /// <returns>
        /// The FollowedModel[][]
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ResultModel<FollowedModel[]> Followed(int userid)
        {
            if (!_customerBussinessLogic.Exist(userid))
            {
                return ResultModel<FollowedModel[]>.Conclude(GetFollowedArtistsStatus.InvalidUserId);
            }

            var follows = _artistBussinessLogic.GetFollowsByCustomerId(userid);
            var result = follows.Select(p => FollowedModelTranslator.Instance.Translate(p)).ToArray();
            return ResultModel<FollowedModel[]>.Conclude(GetFollowedArtistsStatus.Success, result);
        }
    }
}
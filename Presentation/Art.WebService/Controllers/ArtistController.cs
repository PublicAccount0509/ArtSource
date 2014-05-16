using System;
using System.Linq;
using System.Web.Http;
using Art.BussinessLogic;
using Art.WebService.Models;

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
            if (artistId == 0)
            {
                return new ResultModel<ArtistDetailModel>((int)ArtistDetailModelStatus.ArtistNotExist, "艺术家不存在");
            }
            var artist = _artistBussinessLogic.GetArtist(artistId);
            if (artist == null)
            {
                return new ResultModel<ArtistDetailModel>((int)ArtistDetailModelStatus.ArtistNotExist, "艺术家不存在");
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
            return new ResultModel<ArtistDetailModel>
                {
                    Status = (int)ArtistDetailModelStatus.Success,
                    Result = artistDetailModel
                };
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
                return new SimpleResultModel((int)FollowModelStatus.ArtistNotExist, "要关注的艺术家不存在");
            }
            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.UserNotExist, "无效的用户");
            }
            if (_artistBussinessLogic.ExistFollow(model.ArtistId, model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.ArtistAlreadyFollowed, "您已经关注了该艺术家");
            }
            var entity = FollowModelTranslator.Instance.Translate(model);
            _artistBussinessLogic.AddFollow(entity);
            return SimpleResultModel.Success();
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
                return new SimpleResultModel((int)FollowModelStatus.ArtistNotExist, "要取消关注的艺术家不存在");
            }
            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.UserNotExist, "无效的用户");
            }
            if (!_artistBussinessLogic.ExistFollow(model.ArtistId, model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.NotFollowYet, "您还没有关注该艺术家");
            }
            var entity = FollowModelTranslator.Instance.Translate(model);
            _artistBussinessLogic.DeleteFollow(entity);
            return SimpleResultModel.Success();
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
            var follows = _artistBussinessLogic.GetFollowsByCustomerId(userid);
            return new ResultModel<FollowedModel[]>
            {
                Status = (int)FollowedModelStatus.Success,
                Result = follows.Select(p => FollowedModelTranslator.Instance.Translate(p)).ToArray()
            };
        }
    }
}
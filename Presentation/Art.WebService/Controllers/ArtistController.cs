using System;
using System.Linq;
using System.Web.Http;
using Art.BussinessLogic;
using Art.WebService.Models;

namespace Art.WebService.Controllers
{
    public class ArtistController : ApiController
    {
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
                return new ResultModel<ArtistDetailModel>((int) ArtistDetailModelStatus.ArtistNotExist, "艺术家不存在");
            }
            var artist = ArtistBussinessLogic.Instance.GetArtist(artistId);
            if (artist == null)
            {
                return new ResultModel<ArtistDetailModel>((int) ArtistDetailModelStatus.ArtistNotExist, "艺术家不存在");
            }
            var artworks = ArtworkBussinessLogic.Instance.GetArtworksByArtistId(artistId);
            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks);
            foreach (var model in models)
            {
                model.ShareCount = ArtworkBussinessLogic.Instance.GetShareCount(model.Id);
                model.CollectAccount = ArtworkBussinessLogic.Instance.GetCollectCount(model.Id);
                model.PraiseCount = ArtworkBussinessLogic.Instance.GetPraiseCount(model.Id);
            }
            var artistDetailModel = ArtistDetailModelTranslator.Instance.Translate(artist);
            artistDetailModel.HasFollowed =
                userId != null &&
                ArtistBussinessLogic.Instance.ExistFollow(artistId, Convert.ToInt32(userId));
            artistDetailModel.Artworks = models.ToArray();
            return new ResultModel<ArtistDetailModel>
                {
                    Status = (int) ArtistDetailModelStatus.Success,
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
            if (!ArtistBussinessLogic.Instance.Exist(model.ArtistId))
            {
                return new SimpleResultModel((int) FollowModelStatus.ArtistNotExist, "要关注的艺术家不存在");
            }
            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int) FollowModelStatus.UserNotExist, "无效的用户");
            }
            if (ArtistBussinessLogic.Instance.ExistFollow(model.ArtistId, model.UserId))
            {
                return new SimpleResultModel((int) FollowModelStatus.ArtistAlreadyFollowed, "您已经关注了该艺术家");
            }
            var entity = FollowModelTranslator.Instance.Translate(model);
            ArtistBussinessLogic.Instance.AddFollow(entity);
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
            if (!ArtistBussinessLogic.Instance.Exist(model.ArtistId))
            {
                return new SimpleResultModel((int)FollowModelStatus.ArtistNotExist, "要取消关注的艺术家不存在");
            }
            if (!CustomerBussinessLogic.Instance.Exist(model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.UserNotExist, "无效的用户");
            }
            if (!ArtistBussinessLogic.Instance.ExistFollow(model.ArtistId, model.UserId))
            {
                return new SimpleResultModel((int)FollowModelStatus.ArtistNoFollowed, "您还没有关注该艺术家");
            }
            var entity = FollowModelTranslator.Instance.Translate(model);
            ArtistBussinessLogic.Instance.DeleteFollow(entity);
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
            var follows = ArtistBussinessLogic.Instance.GetFollowsByCustomerId(userid);
            return new ResultModel<FollowedModel[]>
                {
                    Status = (int) FollowedModelStatus.Success,
                    Result = follows.Select(p => FollowedModelTranslator.Instance.Translate(p)).ToArray()
                };
        }
    }
}
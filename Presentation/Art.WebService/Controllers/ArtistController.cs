using System;
using System.Linq;
using System.Web.Http;
using Art.BussinessLogic;
using Art.Data.Domain;
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
        public ArtistDetailModel Detail(int artistId, int? userId)
        {
            if (artistId == 0)
            {
                return null;
            }
            var artist = ArtistBussinessLogic.Instance.GetArtist(artistId);
            if (artist == null)
            {
                return null;
            }
            var artworks = ArtworkBussinessLogic.Instance.GetArtworksByArtistId(artistId);
            var models = ArtworkSimpleModelTranslator.Instance.Translate(artworks).ToArray();
            return new ArtistDetailModel
                {
                    HasFollowed =
                        userId != null && ArtistBussinessLogic.Instance.ExistFollow(artistId, Convert.ToInt32(userId)),
                    Honur = artist.PrizeItems,
                    Experience = artist.School,
                    IconPath = artist.AvatarFileName,
                    Name = artist.Name,
                    Artworks = models
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
        public ResultModel Follow(FollowModel model)
        {
            var entity = new ActivityFollow
                {
                    ArtistId = model.ArtistId,
                    CustomerId = model.UserId,
                    FADatetime = DateTime.Now
                };
            var artist = ArtistBussinessLogic.Instance.GetArtist(model.ArtistId);
            if (artist == null)
            {
                return new ResultModel(false, "要关注的艺术家不存在");
            }
            var customer = CustomerBussinessLogic.Instance.Get(model.UserId);
            if (customer == null)
            {
                return new ResultModel(false, "无效的用户");
            }
            if (ArtistBussinessLogic.Instance.ExistFollow(model.ArtistId, model.UserId))
            {
                return new ResultModel(false, "您已经关注了该艺术家");
            }

            entity.Artist = artist;
            entity.Customer = customer;
            ArtistBussinessLogic.Instance.AddFollow(entity);
            return new ResultModel(true);
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
        public FollowedModel[] Followed(int userid)
        {
            var follows = ArtistBussinessLogic.Instance.GetFollowsByCustomerId(userid);
            return
                follows.Select(
                    p => new FollowedModel {Id = p.ArtistId, AvatarPath = p.Artist.AvatarFileName, Name = p.Artist.Name})
                       .ToArray();
        }
    }
}
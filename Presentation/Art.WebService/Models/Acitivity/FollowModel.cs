
using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 取消关注数据
    /// </summary>
    public class FollowModel
    {
        /// <summary>
        /// 艺术家Id
        /// </summary>
        public int ArtistId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }

    public enum FollowModelStatus
    {
        Success,

        [DisplayText("艺术家不存在")]
        ArtistNotExist,

        [DisplayText("无效的用户")]
        UserNotExist,

        [DisplayText("您已经关注了该艺术家")]
        ArtistAlreadyFollowed,
    }

    public enum CancelFollowStatus
    {
        Success,

        [DisplayText("艺术家不存在")]
        ArtistNotExist,

        [DisplayText("无效的用户")]
        UserNotExist,

        [DisplayText("您还没有关注该艺术家")]
        NotFollowYet
    }


    public class FollowModelTranslator : TranslatorBase<ActivityFollow, FollowModel>
    {
        public static readonly FollowModelTranslator Instance = new FollowModelTranslator();

        public override FollowModel Translate(ActivityFollow from)
        {
            throw new NotImplementedException();
        }

        public override ActivityFollow Translate(FollowModel from)
        {
            var to = new ActivityFollow
            {
                ArtistId = from.ArtistId,
                CustomerId = from.UserId,
                FADatetime = DateTime.Now
            };
            return to;
        }
    }
}
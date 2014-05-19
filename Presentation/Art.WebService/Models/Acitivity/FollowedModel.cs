using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取所有关注的艺术家数据
    /// </summary>
    public class FollowedModel
    {
        /// <summary>
        /// 作家id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 作家头像路径
        /// </summary>
        public string AvatarPath { get; set; }
        /// <summary>
        /// 作家名字
        /// </summary>
        public string Name { get; set; }
    }

    public enum GetFollowedArtistsStatus
    {
        Success,
        [DisplayText("指定的用户不存在")]
        InvalidUserId
    }

    public class FollowedModelTranslator : TranslatorBase<ActivityFollow, FollowedModel>
    {
        public static readonly FollowedModelTranslator Instance = new FollowedModelTranslator();

        public override FollowedModel Translate(ActivityFollow from)
        {
            var to = new FollowedModel
                {
                    Id = from.ArtistId,
                    AvatarPath = from.Artist.AvatarFileName,
                    Name = from.Artist.Name
                };
            return to;
        }

        public override ActivityFollow Translate(FollowedModel from)
        {
            throw new NotImplementedException();
        }
    }
}
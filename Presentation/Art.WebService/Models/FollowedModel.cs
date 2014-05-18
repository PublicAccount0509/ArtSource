using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class FollowedModel
    {
        public int Id { get; set; } // 作家id
        public string AvatarPath { get; set; } //  作家头像路径
        public string Name { get; set; } // 作家名字
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
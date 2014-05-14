
using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class FollowModel
    {
        public int ArtistId { get; set; }
        public int UserId { get; set; }
    }

    public enum FollowModelStatus
    {
        Success,
        ArtistNotExist,
        UserNotExist,
        ArtistAlreadyFollowed
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
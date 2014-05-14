using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class CollectArtworkModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum CollectArtworkStatus
    { 
        Success,
        ArtworkNotExist,
        UserNotExist,
        ArtistAlreadyCollected,
        ArtistNoCollected
    }
    public class CollectArtworkModelTranslator : TranslatorBase<ActivityCollect, CollectArtworkModel>
    {
        public static readonly CollectArtworkModelTranslator Instance = new CollectArtworkModelTranslator();

        public override CollectArtworkModel Translate(ActivityCollect from)
        {
            throw new NotImplementedException();
        }

        public override ActivityCollect Translate(CollectArtworkModel from)
        {
            var to = new ActivityCollect();
            to.ArtworkId = from.ArtworkId;
            to.CustomerId = from.UserId;
            to.FADatetime = DateTime.Now;
            return to;
        }
    }
}
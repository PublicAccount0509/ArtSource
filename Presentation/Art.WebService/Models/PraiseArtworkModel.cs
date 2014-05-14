using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class PraiseArtworkModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum PraiseArtworkStatus
    { 
        Success,
        ArtworkNotExist,
        UserNotExist,
        ArtistAlreadyPraised
    }
    public class PraiseArtworkModelTranslator : TranslatorBase<ActivityPraise, PraiseArtworkModel>
    {
        public static readonly PraiseArtworkModelTranslator Instance = new PraiseArtworkModelTranslator();

        public override PraiseArtworkModel Translate(ActivityPraise from)
        {
            throw new NotImplementedException();
        }

        public override ActivityPraise Translate(PraiseArtworkModel from)
        {
            var to = new ActivityPraise();
            to.ArtworkId = from.ArtworkId;
            to.CustomerId = from.UserId;
            to.FADatetime = DateTime.Now;
            return to;
        }
    }
}
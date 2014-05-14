using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ActivityShareModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum ActivityShareStatus
    { 
        Success,
        ArtworkNotExist,
        UserNotExist,
        ArtistAlreadyShared
    }
    //public class ShareArtworkModelTranslator : TranslatorBase<ActivityShare, ShareArtworkModel>
    //{
    //    public static readonly ShareArtworkModelTranslator Instance = new ShareArtworkModelTranslator();

    //    public override ShareArtworkModel Translate(ActivityShare from)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override ActivityShare Translate(ShareArtworkModel from)
    //    {
    //        var to = new ActivityShare();
    //        to.ArtworkId = from.ArtworkId;
    //        to.CustomerId = from.UserId;
    //        to.FADatetime = DateTime.Now;
    //        return to;
    //    }
    //}
}
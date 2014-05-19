using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 分享作品数据
    /// </summary>
    public class ActivityShareModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }

    public enum ActivityShareStatus
    { 
        Success,

        [DisplayText("指定的作品Id不存在")]
        ArtworkNotExist,

        [DisplayText("指定的用户Id不存在")]
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
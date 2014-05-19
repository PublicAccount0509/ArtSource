using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 赞作品数据
    /// </summary>
    public class ActivityPraiseModel
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

    public enum ActivityPraiseStatus
    { 
        Success,

        [DisplayText("指定的作品不存在")]
        ArtworkNotExist,

        [DisplayText("指定的用户不存在")]
        UserNotExist,

        [DisplayText("您已经赞过该作品")]
        AlreadyPraised
    }
    public enum ActivityCancelPraiseStatus
    {
        Success,

        [DisplayText("指定的作品不存在")]
        ArtworkNotExist,

        [DisplayText("指定的用户不存在")]
        UserNotExist,

        [DisplayText("您还没有赞过该作品")]
        NotPraised
    }
}
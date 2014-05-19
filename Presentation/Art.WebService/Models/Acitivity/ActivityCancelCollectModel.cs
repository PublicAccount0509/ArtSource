using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ActivityCollectModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum ActivityCollectStatus
    { 
        Success,

        [DisplayText("指定的作品不存在")]
        ArtworkNotExist,

        [DisplayText("指定的用户不存在")]
        UserNotExist,
         
        [DisplayText("您已经收藏过该作品")]
        AlreadyCollected
    }
}
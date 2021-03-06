﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 取消收藏数据
    /// </summary>
    public class ActivityCancelCollectModel
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

    public enum ActivityCancelCollectStatus
    { 
        Success,

        [DisplayText("指定的作品不存在")]
        ArtworkNotExist,

        [DisplayText("指定的用户Id不存在")]
        UserNotExist,

        [DisplayText("用户还没有收藏过该作品")]
        NotCollectYet
    }
}
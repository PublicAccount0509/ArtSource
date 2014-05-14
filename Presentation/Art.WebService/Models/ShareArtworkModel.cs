﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class ShareArtworkModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum ShareArtworkStatus
    { 
        Success,
        ArtworkNotExist,
        UserNotExist
    }
}
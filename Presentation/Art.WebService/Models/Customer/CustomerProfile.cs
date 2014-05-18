using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class CustomerProfile
    {
        public string IconPath { get; set; }
        public string UserName { get; set; }
        public float ArtIndex { get; set; }
        public int CollectCount { get; set; }
        public int CommentCount { get; set; }
        public int PraiseCount { get; set; }
        public int FollowCount { get; set; }

        public ArtworkSimpleModel[] LatestCollectArtworks { get; set; }
    }
}
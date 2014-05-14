using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class FollowModel
    {
        public int ArtistId { get; set; }
        public int UserId { get; set; }
    }
}
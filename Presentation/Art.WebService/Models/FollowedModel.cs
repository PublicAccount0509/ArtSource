using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class FollowedModel
    {
        public int Id { get; set; } // 作家id
        public string AvatarPath { get; set; } //  作家头像路径
        public string Name { get; set; } // 作家名字
    }
}
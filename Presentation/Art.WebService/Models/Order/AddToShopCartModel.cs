using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class AddToShopCartModel
    {
        public int ArtworkId { get; set; }
        public int UserId { get; set; }
    }

    public enum AddToShopCartStatus
    { 
        Success,

        [DisplayText("商品不存在")]
        InvalidArtworkId,

        [DisplayText("用户不存在")]
        InvalidUserId, 

        [DisplayText("该商品已经在购物车中了")]
        AlreadyAdded
    }
}
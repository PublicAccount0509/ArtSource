using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 放到购物车数据
    /// </summary>
    public class AddToShopCartModel
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
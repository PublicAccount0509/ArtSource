using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取购物车商品参数
    /// </summary>
    public class GetToShopCartModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }
}
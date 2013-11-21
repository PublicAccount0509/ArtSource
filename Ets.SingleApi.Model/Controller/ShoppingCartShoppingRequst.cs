namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：ShoppingCartShoppingRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：保存商品信息参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartShoppingRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the ShoppingCartItemList of ShoppingCartShoppingRequst
        /// </summary>
        /// <value>
        /// The ShoppingCartItemList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<ShoppingCartItem> ShoppingCartItemList { get; set; }
    }
}
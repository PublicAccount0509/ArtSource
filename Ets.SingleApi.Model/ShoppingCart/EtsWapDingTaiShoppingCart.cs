namespace Ets.SingleApi.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：EtsWapTangShiShoppingCart
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：易淘食堂食购物车
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 10:35 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCart
    {
        /// <summary>
        /// 设置或取得购物车Id
        /// </summary>
        /// <value>
        /// 购物车Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ShoppingCartId { get; set; }

        /// <summary>
        /// 设置或取得购物车是否失效
        /// </summary>
        /// <value>
        /// 购物车是否失效
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsActive { get; set; }

        /// <summary>
        /// 设置或取得购物车商品信息
        /// </summary>
        /// <value>
        /// 购物车商品信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<ShoppingCartItem> ShoppingList { get; set; }
    }
}
namespace Ets.SingleApi.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：ShoppingCart
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：购物车
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 10:35 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCart
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
        public Guid Id { get; set; }

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
        /// 设置或取得购物车种类
        /// </summary>
        /// <value>
        /// 购物车种类
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Type { get; set; }

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

        /// <summary>
        /// 设置或取得购物车对应的顾客信息
        /// </summary>
        /// <value>
        /// 购物车对应的顾客信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartCustomer Customer { get; set; }

        /// <summary>
        /// 设置或取得购物车对应的订单信息
        /// </summary>
        /// <value>
        /// 购物车对应的订单信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartOrder Order { get; set; }

        /// <summary>
        /// 设置或取得当前餐厅信息
        /// </summary>
        /// <value>
        /// 当前餐厅信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IShoppingCartBusiness Supplier { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCart()
        {
            this.ShoppingList = new List<ShoppingCartItem>();
            this.Customer = new ShoppingCartCustomer();
            this.Order = new ShoppingCartOrder();
            this.Supplier = new ShoppingCartSupplier();
        }
    }
}
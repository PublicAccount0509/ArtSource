namespace Ets.SingleApi.Model
{
using Ets.SingleApi.Model.Controller;
using System.Collections.Generic;

    /// <summary>
    /// 类名称：HuangTaiJiShoppingCartItem
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：黄太极购物车商品信息
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 10:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiShoppingCartItem
    {
        /// <summary>
        /// 设置或取得类目Id
        /// </summary>
        /// <value>
        /// 类目Id
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<int> CategoryIdList { get; set; }

        /// <summary>
        /// 设置或取得父Id
        /// </summary>
        /// <value>
        /// 父Id
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ParentId { get; set; }

        /// <summary>
        /// 设置或取得商品Id
        /// </summary>
        /// <value>
        /// 商品Id
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ItemId { get; set; }

        /// <summary>
        /// 设置或取得商品名称
        /// </summary>
        /// <value>
        /// 商品名称
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ItemName { get; set; }

        /// <summary>
        /// 设置或取得商品说明
        /// </summary>
        /// <value>
        /// 商品说明
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Instruction { get; set; }

        /// <summary>
        /// 设置或取得商品单价
        /// </summary>
        /// <value>
        /// 商品单价
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Price { get; set; }

        /// <summary>
        /// 设置或取得商品打包费
        /// </summary>
        /// <value>
        /// 商品打包费
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// 设置或取得商品数量
        /// </summary>
        /// <value>
        /// 商品数量
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Quantity { get; set; }

        /// <summary>
        /// 设置或取得商品类型
        /// </summary>
        /// <value>
        /// 商品类型 0 菜 1 小料 2 锅底 3 套餐 4 专人服务
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Type { get; set; }

        /// <summary>
        /// 设置或取得是否为赠品
        /// </summary>
        /// <value>
        /// 是否为赠品
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPresent { get; set; }

        /// <summary>
        /// 设置或取得商品群组Id
        /// </summary>
        /// <value>
        /// 商品群组Id
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string GroupId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartItem"/> class.
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：11/29/2013 6:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCartItem()
        {
            this.CategoryIdList = new List<int>();
            this.Instruction = string.Empty;
        }

        /// 增加辅菜
        /// <summary>
        /// Gets or sets the SupplierDishOptionGroup of SupplierDishDetail
        /// </summary>
        /// <value>
        /// The SupplierDishOptionGroup
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiSupplierDishOptionGroup> SupplierDishOptionGroups { get; set; }

        /// 增加子菜单
        /// <summary>
        /// Gets or sets the SubSupplierDishDetail of SupplierDishDetail
        /// </summary>
        /// <value>
        /// The SubSupplierDishDetail
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiShoppingCartItem> SubSupplierDishDetail { get; set; }
    }
}
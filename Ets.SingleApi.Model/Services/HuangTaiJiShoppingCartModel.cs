namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：HuangTaiJiShoppingCartModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：黄太极购物车
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 10:35 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiShoppingCartModel
    {
        /// <summary>
        /// 设置或取得唯一标识符
        /// </summary>
        /// <value>
        /// 唯一标识符
        /// </value>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Id { get; set; }

        /// <summary>
        /// 设置或取得购物车信息
        /// </summary>
        /// <value>
        /// 购物车信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// 设置或取得购物车对应的顾客信息
        /// </summary>
        /// <value>
        /// 购物车对应的顾客信息
        /// </value>
        /// 创建者：殷超
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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCartOrder Order { get; set; }

        /// <summary>
        /// 设置或取得当前餐厅信息
        /// </summary>
        /// <value>
        /// 当前餐厅信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartSupplier Supplier { get; set; }

        /// <summary>
        /// 设置或取得当前订单配送信息
        /// </summary>
        /// <value>
        /// 当前订单配送信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartDelivery Delivery { get; set; }

        /// <summary>
        /// 设置或取得当前订单额外信息
        /// </summary>
        /// <value>
        /// 当前订单额外信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartExtra Extra { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HaiDiLaoShoppingCartModel"/> class.
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 10:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCartModel()
        {
            this.ShoppingCart = new HuangTaiJiShoppingCart();
            this.Customer = new ShoppingCartCustomer();
            this.Order = new HuangTaiJiShoppingCartOrder();
            this.Supplier = new ShoppingCartSupplier();
            this.Delivery = new ShoppingCartDelivery();
            this.Extra = new ShoppingCartExtra();
        }
    }
}
namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：ShoppingCartModel
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：购物车
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 10:35 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapTangShiShoppingCartModel
    {
        /// <summary>
        /// 设置或取得唯一标识符
        /// </summary>
        /// <value>
        /// 唯一标识符
        /// </value>
        /// 创建者：周超
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
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapTangShiShoppingCart ShoppingCart { get; set; }

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
        public EtsWapTangShiShoppingCartOrder Order { get; set; }

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
        public ShoppingCartSupplier Supplier { get; set; }

        /// <summary>
        /// 设置或取得当前订单配送信息
        /// </summary>
        /// <value>
        /// 当前订单配送信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartDelivery Delivery { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapTangShiShoppingCartModel"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapTangShiShoppingCartModel()
        {
            this.ShoppingCart = new EtsWapTangShiShoppingCart();
            this.Customer = new ShoppingCartCustomer();
            this.Order = new EtsWapTangShiShoppingCartOrder();
            this.Supplier = new ShoppingCartSupplier();
            this.Delivery = new ShoppingCartDelivery();
        }
    }
}
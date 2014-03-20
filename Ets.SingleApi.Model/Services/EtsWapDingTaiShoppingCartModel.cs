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
    public class EtsWapDingTaiShoppingCartModel
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
        public EtsWapDingTaiShoppingCart ShoppingCart { get; set; }

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
        public EtsWapDingTaiShoppingCartOrder Order { get; set; }

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
        /// 设置或取得购物车对应的台位信息
        /// </summary>
        /// <value>
        /// 购物车对应的台位信息
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartDesk Desk { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapDingTaiShoppingCartModel"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapDingTaiShoppingCartModel()
        {
            this.ShoppingCart = new EtsWapDingTaiShoppingCart();
            this.Customer = new ShoppingCartCustomer();
            this.Order = new EtsWapDingTaiShoppingCartOrder();
            this.Supplier = new ShoppingCartSupplier();
            this.Delivery = new ShoppingCartDelivery();
            this.Desk = new ShoppingCartDesk();
        }
    }
}
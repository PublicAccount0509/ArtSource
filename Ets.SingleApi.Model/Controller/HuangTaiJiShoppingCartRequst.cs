namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HuangTaiJiShoppingCartRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：黄太极保存商品信息参数
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiShoppingCartRequst : ApiRequst
    {
        /// <summary>
        /// 设置或取得购物车信息
        /// </summary>
        /// <value>
        /// 购物车信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 10:35 PM
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
        /// 创建日期：12/25/2013 11:32 PM
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
        /// 创建日期：12/25/2013 10:37 PM
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
        /// 创建日期：12/25/2013 10:38 PM
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
        /// 创建日期：12/25/2013 10:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartDelivery Delivery { get; set; }
    }
}
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：ShoppingCartResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：购物车返回信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of ShoppingCartResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCart Result { get; set; }
    }
}
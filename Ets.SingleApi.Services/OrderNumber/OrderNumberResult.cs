namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：OrderNumberResult
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订单号
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 2:17 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderNumberResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderNumberResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderNumberResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of UserOrdersResult
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the OrderNumber of OrderNumberResult
        /// </summary>
        /// <value>
        /// The OrderNumber
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderNumber { get; set; }
    }
}
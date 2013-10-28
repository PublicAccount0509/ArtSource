namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：PaymentResult
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：支付结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 19:53
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PaymentResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of PaymentResult
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
        /// Gets or sets the Result of PaymentResult
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Result { get; set; }
    }
}

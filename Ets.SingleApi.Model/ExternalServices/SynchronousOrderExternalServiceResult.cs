namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：SynchronousExternalServiceResult
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：同步订单给其他系统
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：5/22/2014 1:55 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SynchronousOrderExternalServiceResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SynchronousOrderExternalServiceResult"/> class.
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 1:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SynchronousOrderExternalServiceResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
            this.Result = string.Empty;
        }

        /// <summary>
        /// Gets or sets the StatusCode of SynchronousOrderExternalServiceResult
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 1:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Result of SynchronousOrderExternalServiceResult
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 1:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Result { get; set; }
    }
}

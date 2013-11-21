namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：DefaultServicesResult
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：Service返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DefaultServicesResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServicesResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 22:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DefaultServicesResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of ServicesResult
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 19:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Count of DefaultServicesResult
        /// </summary>
        /// <value>
        /// The Count
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:01 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Count { get; set; }
    }
}
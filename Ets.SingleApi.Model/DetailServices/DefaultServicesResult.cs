namespace Ets.SingleApi.Model.DetailServices
{
    /// <summary>
    /// 类名称：DefaultServicesResult
    /// 命名空间：Ets.SingleApi.Model.DetailServices
    /// 类功能：Service返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DefaultDetailServicesResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDetailServicesResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 22:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DefaultDetailServicesResult()
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
    }
}
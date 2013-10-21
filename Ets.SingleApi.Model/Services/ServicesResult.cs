namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：ServicesResult
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：Service返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ServicesResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesResult{T}"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 22:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult()
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
        /// Gets or sets the Result of ServicesResult{T}
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 19:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public T Result { get; set; }
    }
}
namespace Ets.SingleApi.Model.DetailServices
{
    /// <summary>
    /// 类名称：DetailServicesResult
    /// 命名空间：Ets.SingleApi.Model.DetailServices
    /// 类功能：DetailServices返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DetailServicesResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetailServicesResult{T}"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 22:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DetailServicesResult()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of DetailServicesResult
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
        /// Gets or sets the Result of DetailServicesResult{T}
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
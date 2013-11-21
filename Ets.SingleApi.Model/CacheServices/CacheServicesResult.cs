namespace Ets.SingleApi.Model.CacheServices
{
    /// <summary>
    /// 类名称：DefaultServicesResult
    /// 命名空间：Ets.SingleApi.Model.CacheServices
    /// 类功能：CacheServices返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CacheServicesResult<T> : DefaultServicesResult
    {
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
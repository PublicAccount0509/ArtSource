namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：ShoppingCartResult{T}
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：ShoppingCart返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartResult<T> : DefaultServicesResult
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
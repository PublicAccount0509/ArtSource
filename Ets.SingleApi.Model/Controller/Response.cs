namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：Response{T}
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：API返回值基类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:22
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class Response<T> : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of Response{T}
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/23/2013 7:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public T Result { get; set; }
    }
}
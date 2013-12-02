namespace Ets.SingleApi.Model.DetailServices
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：DetailServicesResultList
    /// 命名空间：Ets.SingleApi.Model.DetailServices
    /// 类功能：DetailServices返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DetailServicesResultList<T> : DefaultServicesResult
    {
        /// <summary>
        /// Gets or sets the Result of DetailServicesResultList{T}
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 19:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<T> Result { get; set; }
    }
}
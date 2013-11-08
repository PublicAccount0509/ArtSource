namespace Ets.SingleApi.Model.Services
{
    using System.Collections.Generic;

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
    public class ServicesResultList<T> : DefaultServicesResult
    {
        /// <summary>
        /// Gets or sets the ResultTotalCount of ServicesResultList{T}
        /// </summary>
        /// <value>
        /// The ResultTotalCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/8/2013 12:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ResultTotalCount { get; set; }

        /// <summary>
        /// Gets or sets the Result of ServicesResultList{T}
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 19:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<T> Result { get; set; }
    }
}
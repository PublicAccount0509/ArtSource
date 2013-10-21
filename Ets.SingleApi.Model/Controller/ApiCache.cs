namespace Ets.SingleApi.Model.Controller
{
    using System;

    /// <summary>
    /// 类名称：ApiCache
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：缓存信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:32
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ApiCache
    {
        /// <summary>
        /// Gets or sets the ServerTime of ApiCache
        /// </summary>
        /// <value>
        /// The ServerTime
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime ServerTime { get; set; }

        /// <summary>
        /// Gets or sets the ExpiresIn of ApiCache
        /// </summary>
        /// <value>
        /// The ExpiresIn
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCache"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/13 13:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ApiCache()
        {
            this.ServerTime = DateTime.Now;
            this.ExpiresIn = 0;
        }
    }
}
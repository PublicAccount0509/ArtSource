namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：TokenModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：Token实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/29/2013 5:32 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TokenModel
    {
        /// <summary>
        /// Gets or sets the AccessToken of TokenModel
        /// </summary>
        /// <value>
        /// The AccessToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the UserId of TokenModel
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the TokenDateTime of TokenModel
        /// </summary>
        /// <value>
        /// The TokenDateTime
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? TokenDateTime { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HtjUserExtendResult
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：黄太吉注册用户参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 10:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HtjUserExtendResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtjUserExtendResult"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/12/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HtjUserExtendResult()
        {
            this.User = new HtjUser();
            this.UserToken = new UserToken();
        }

        /// <summary>
        /// Gets or sets the User of HtjUserExtendResult
        /// </summary>
        /// <value>
        /// The User
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HtjUser User { get; set; }

        /// <summary>
        /// Gets or sets the UserToken of HtjUserExtendResult
        /// </summary>
        /// <value>
        /// The UserToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserToken UserToken { get; set; }
    }
}
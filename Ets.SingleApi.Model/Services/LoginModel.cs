﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：Login
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：登陆返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the AccessToken of Login
        /// </summary>
        /// <value>
        /// The AccessToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the RefreshToken of Login
        /// </summary>
        /// <value>
        /// The RefreshToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the UserId of Login
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }

        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：8/1/2014 10:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierId { get; set; }
    }
}
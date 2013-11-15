﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AuthCodeResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：验证验证码返回结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthCodeResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of AuthCodeResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Result { get; set; }
    }
}
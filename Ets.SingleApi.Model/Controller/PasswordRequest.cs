﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：PasswordRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：修改密码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PasswordRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the OldPassword of Password
        /// </summary>
        /// <value>
        /// The OldPassword
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the NewPasswrod of Password
        /// </summary>
        /// <value>
        /// The NewPasswrod
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string NewPasswrod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsSendSms
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 12:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsSendSms { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model.Controller
{
    using System;

    /// <summary>
    /// 类名称：UmPaymentRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the UserId of ConfirmWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 设置或取得订单号
        /// </summary>
        /// <value>
        /// 订单号
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }

        /// <summary>
        /// 设置或取得支付金额
        /// </summary>
        /// <value>
        /// 支付金额
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Amount { get; set; }

        /// <summary>
        /// 设置或取得支付时间
        /// </summary>
        /// <value>
        /// 支付时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime PayDate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnUrl of UmPaymentParameter
        /// </summary>
        /// <value>
        /// The ReturnUrl
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/27/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ReturnUrl { get; set; }
        public string NotifyUrl { get; set; }
    }
}
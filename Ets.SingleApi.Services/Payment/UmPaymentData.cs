﻿namespace Ets.SingleApi.Services
{
    using System;

    /// <summary>
    /// 类名称：UmPaymentData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：支付
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 2:27 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPaymentData : IPaymentData
    {
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
        /// 设置或取得回调地址
        /// </summary>
        /// <value>
        /// 回调地址
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
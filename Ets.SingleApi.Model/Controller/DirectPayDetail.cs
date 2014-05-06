﻿using System;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：DirectPayDetail
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：当面付订单详情
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 5:34 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DirectPayDetail
    {
        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 餐厅名称
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// 应付金额
        /// </summary>
        /// <value>
        /// 应付金额
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:10 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PayableAmount { get; set; }

        /// <summary>
        /// 实付金额
        /// </summary>
        /// <value>
        /// 实付金额
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:13 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal ActualPaidAmount { get; set; }

        /// <summary>
        /// 支付方式Id
        /// </summary>
        /// <value>
        /// 支付方式Id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        /// <value>
        /// 是否取消
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Cancelled { get; set; }

        /// <summary>
        /// 是否支付
        /// </summary>
        /// <value>
        /// 是否支付
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaid { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        /// <value>
        /// 创建日期
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime CeateDate { get; set; }

        /// <summary>
        /// 订单付款时间
        /// </summary>
        /// <value>
        /// The payment date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：5/6/2014 10:21 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// 订单状态Id
        /// </summary>
        /// <value>
        /// 订单状态Id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 12:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderStatusId { get; set; }
    }
}
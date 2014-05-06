﻿using System;

namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：DirectPayModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：当面付信息
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 10:18 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DirectPayModel
    {
        /// <summary>
        /// 当面付序号
        /// </summary>
        /// <value>
        /// The DirectPayId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DirectPayId { get; set; }

        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:38 AM
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
        /// 创建日期：4/30/2014 10:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:45 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public long OrderId { get; set; }

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

        /// <summary>
        /// 支付方式id
        /// </summary>
        /// <value>
        /// The PaymentMethodId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// 是否支付
        /// </summary>
        /// <value>
        /// The IsPaid
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaid { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>
        /// 手机号
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// 订单下单时间
        /// </summary>
        /// <value>
        /// 订单下单时间
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? CreateDate { get; set; }

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
        /// 客户优惠金额
        /// </summary>
        /// <value>
        /// 客户优惠金额
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:13 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CustomerCouponTotal { get; set; }

        /// <summary>
        /// 商户优惠金额
        /// </summary>
        /// <value>
        /// 商户优惠金额
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 11:13 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal SupplierCouponTotal { get; set; }

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
        public bool? Cancelled { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model
{
    using System;

    /// <summary>
    /// 类名称：ShoppingCartOrder
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：订单信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:10 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartOrder
    {
        /// <summary>
        /// 设置或取得取餐方式
        /// </summary>
        /// <value>
        /// 取餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeliveryMethodId { get; set; }

        /// <summary>
        /// 设置或取得订单备注信息
        /// </summary>
        /// <value>
        /// 订单备注信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 10:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryInstruction { get; set; }

        /// <summary>
        /// 设置或取得订单模板信息
        /// </summary>
        /// <value>
        /// 订单模板信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 10:05 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Template { get; set; }

        /// <summary>
        /// 设置或取得订单路径信息
        /// </summary>
        /// <value>
        /// 订单路径信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Path { get; set; }

        /// <summary>
        /// 设置或取得是否开发票
        /// </summary>
        /// <value>
        /// 是否开发票
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool InvoiceRequired { get; set; }

        /// <summary>
        /// 设置或取得发票标题
        /// </summary>
        /// <value>
        /// 发票标题
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string InvoiceTitle { get; set; }

        /// <summary>
        /// 设置或取得订单说明
        /// </summary>
        /// <value>
        /// 订单说明
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OrderNotes { get; set; }

        /// <summary>
        /// 设置或取得订单所属区域Id
        /// </summary>
        /// <value>
        /// 订单所属区域Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? AreaId { get; set; }

        /// <summary>
        /// 设置或取得是否开发票
        /// </summary>
        /// <value>
        /// 是否开发票
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsTakeInvoice { get; set; }

        /// <summary>
        /// 设置或取得是送餐日期
        /// </summary>
        /// <value>
        /// 送餐日期
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// 设置或取得是送餐时间
        /// </summary>
        /// <value>
        /// 送餐时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 设置或取得是送餐时间类型
        /// </summary>
        /// <value>
        /// 送餐时间类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeliveryType { get; set; }

        /// <summary>
        /// 设置或取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// 设置或取得商品总数量
        /// </summary>
        /// <value>
        /// 商品总数量
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int TotalQuantity { get; set; }

        /// <summary>
        /// 设置或取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// 设置或取得订单总金额
        /// </summary>
        /// <value>
        /// 订单总金额
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 设置或取得应付金额
        /// </summary>
        /// <value>
        /// 应付金额
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CustomerTotalFee { get; set; }

        /// <summary>
        /// 设置或取得订单优惠金额
        /// </summary>
        /// <value>
        /// 订单优惠金额
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CouponFee { get; set; }

        /// <summary>
        /// 设置或取得订单是否完成
        /// </summary>
        /// <value>
        /// 订单是否完成
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsComplete { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：WaiMaiOrderDetail
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiOrderDetail
    {
        /// <summary>
        /// 设置或取得订单号
        /// </summary>
        /// <value>
        /// 订单号
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// 设置或取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? OrderTypeId { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatus of WaiMaiOrderModel
        /// </summary>
        /// <value>
        /// The OrderStatus
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 22:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? OrderStatusId { get; set; }

        /// <summary>
        /// 设置或取得下单时间
        /// </summary>
        /// <value>
        /// 下单时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DateReserved { get; set; }

        /// <summary>
        /// 设置或取得订单备注
        /// </summary>
        /// <value>
        /// 订单备注
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryInstruction { get; set; }

        /// <summary>
        /// 设置或取得餐厅Id
        /// </summary>
        /// <value>
        /// 餐厅Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 设置或取得餐厅名称
        /// </summary>
        /// <value>
        /// 餐厅名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// 设置或取得餐厅电话
        /// </summary>
        /// <value>
        /// 餐厅电话
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierTelephone { get; set; }

        /// <summary>
        /// 设置或取得餐厅地址
        /// </summary>
        /// <value>
        /// 餐厅地址
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierAddress { get; set; }

        /// <summary>
        /// 设置或取得餐厅经度
        /// </summary>
        /// <value>
        /// 餐厅经度
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal SupplierBaIduLat { get; set; }

        /// <summary>
        /// 设置或取得餐厅纬度
        /// </summary>
        /// <value>
        /// 餐厅纬度
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal SupplierBaIduLong { get; set; }

        /// <summary>
        /// 设置或取得客户总消费
        /// </summary>
        /// <value>
        /// 客户总消费
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerTotal { get; set; }

        /// <summary>
        /// 设置或取得折扣
        /// </summary>
        /// <value>
        /// 折扣
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Commission { get; set; }

        /// <summary>
        /// 设置或取得优惠
        /// </summary>
        /// <value>
        /// 优惠
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Coupon { get; set; }

        /// <summary>
        /// 设置或取得总计
        /// </summary>
        /// <value>
        /// 总计
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Total { get; set; }

        /// <summary>
        /// 设置或取得付款方式
        /// </summary>
        /// <value>
        /// 付款方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/6/2013 11:15 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? RealSupplierType { get; set; }

        /// <summary>
        /// 设置或取得取餐方式
        /// </summary>
        /// <value>
        /// 取餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? DeliveryMethodId { get; set; }

        /// <summary>
        /// 设置或取得是否支付
        /// </summary>
        /// <value>
        /// 是否支付
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaid { get; set; }

        /// <summary>
        /// 设置或取得是否确认订单
        /// </summary>
        /// <value>
        /// 是否确认订单
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsConfirm { get; set; }

        /// <summary>
        /// 设置或取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/13/2013 5:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PaymentMethodId { get; set; }

        /// <summary>
        /// 设置或取得菜信息
        /// </summary>
        /// <value>
        /// 菜信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<WaiMaiOrderDish> DishList { get; set; }
    }
}
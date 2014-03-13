﻿namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：WaiMaiOrderModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiOrderModel : IOrderModel
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
        public int? SupplierId { get; set; }

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
        public DateTime? DateReserved { get; set; }

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
        public int OrderType { get; set; }

        /// <summary>
        /// 设置或取得订单状态
        /// </summary>
        /// <value>
        /// 订单状态
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderStatusId { get; set; }

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
        public string OrderStatus { get; set; }

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
        public decimal? CustomerTotal { get; set; }

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
        public bool? IsPaid { get; set; }

        /// <summary>
        /// 菜品名称（菜品1,菜品2,菜品3)
        /// </summary>
        /// <value>
        /// 菜品名称（菜品1,菜品2,菜品3)
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/12/2014 6:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DishNames { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：DingTaiOrderModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiOrderModel : IOrderModel
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
        /// 设置或取得订单状态Id
        /// </summary>
        /// <value>
        /// 订单状态Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderStatusId { get; set; }

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
        public decimal CustomerTotal { get; set; }

        /// <summary>
        /// 设置或取得就餐人数
        /// </summary>
        /// <value>
        /// 就餐人数
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DineNumber { get; set; }

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

        /// <summary>
        /// 支付方式id
        /// </summary>
        /// <value>
        /// 支付方式id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/13/2014 1:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// 餐桌号
        /// </summary>
        /// <value>
        /// The TableNo
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeskNo { get; set; }

        /// <summary>
        /// 实景大图Url地址
        /// </summary>
        /// <value>
        /// The DeskImgUrl
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeskImgUrl { get; set; }

        /// <summary>
        /// 房间类型 0 散座，1 包房
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int RoomType { get; set; }

        /// <summary>
        /// 房间类型 0 散座，1 包房
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RoomTypeName { get; set; }

        /// <summary>
        /// 最小就餐人数
        /// </summary>
        /// <value>
        /// The MinNumber
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int MinNumber { get; set; }

        /// <summary>
        /// 最大就餐人数
        /// </summary>
        /// <value>
        /// The MaxNumber
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int MaxNumber { get; set; }

        /// <summary>
        /// 预订日期
        /// </summary>
        /// <value>
        /// The BookDate
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? BookDate { get; set; }

        /// <summary>
        /// 预订时间
        /// </summary>
        /// <value>
        /// The BookTime
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BookTime { get; set; }

        /// <summary>
        /// 位子类型（大中小桌）
        /// </summary>
        /// <value>
        /// The name of the table type.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 6:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TblTypeName { get; set; }
    }
}
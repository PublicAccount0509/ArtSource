﻿using System;

namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 台位信息
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/20/2014 9:39 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartDesk
    {
        /// <summary>
        /// 设置或取得订单台位唯一标识符
        /// </summary>
        /// <value>
        /// 订单台位唯一标识符
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Id { get; set; }

        /// <summary>
        /// 台位类型Id
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeskTypeId { get; set; }

        /// <summary>
        /// 房间类型（0:散座、1:包房）
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? RoomType { get; set; }

        /// <summary>
        /// 桌位类型Id
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int TblTypeId { get; set; }

        /// <summary>
        /// 桌位类型名称（大中小桌）
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TblTypeName { get; set; }

        /// <summary>
        /// 最多人数
        /// </summary>
        /// <value>
        /// The maximum number.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:13 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int MaxNumber { get; set; }

        /// <summary>
        /// 最少人数
        /// </summary>
        /// <value>
        /// The minimum number.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:12 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int MinNumber { get; set; }

        /// <summary>
        /// 最低消费金额
        /// </summary>
        /// <value>
        /// The low cost.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:11 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? LowCost { get; set; }

        /// <summary>
        /// 位子押金
        /// </summary>
        /// <value>
        /// The deposit.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:10 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? DepositAmount { get; set; }

        /// <summary>
        /// 预定日期
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? BookingDate { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BookingTime { get; set; }

        /// <summary>
        /// 预定人数
        /// </summary>
        /// <value>
        /// The people count.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PeopleCount { get; set; }
    }
}
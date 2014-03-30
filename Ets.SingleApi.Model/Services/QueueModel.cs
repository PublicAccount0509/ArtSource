﻿namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：QueueModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：排队订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：3/22/2014 1:34 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class QueueModel
    {
        /// <summary>
        /// 排队Id
        /// </summary>
        /// <value>
        /// 排队Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/22/2014 1:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int QueueId { get; set; }

        /// <summary>
        /// 排队号
        /// </summary>
        /// <value>
        /// 排队号
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/22/2014 1:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Number { get; set; }

        /// <summary>
        /// 排队状态Id
        /// </summary>
        /// <value>
        /// 排队状态Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/22/2014 1:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int QueueStateId { get; set; }

        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// 餐厅Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 餐厅名称
        /// </summary>
        /// <value>
        /// 餐厅名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

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
        /// 包厢名称
        /// </summary>
        /// <value>
        /// The name of the box.
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BoxName { get; set; }

        /// <summary>
        /// 台位类型Id
        /// </summary>
        /// <value>
        /// The name of the desk type.
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeskTypeId { get; set; }

        /// <summary>
        /// 台位类型名称
        /// </summary>
        /// <value>
        /// The name of the desk type.
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeskTypeName { get; set; }

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
        /// 排队人数
        /// </summary>
        /// <value>
        /// The QueueNumber
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 1:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int QueueNumber { get; set; }

        /// <summary>
        /// 排队日期
        /// </summary>
        /// <value>
        /// The CeateDate
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/21/2014 3:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime CeateDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The Cancelled
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/15/2014 4:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Cancelled { get; set; }
    }
}
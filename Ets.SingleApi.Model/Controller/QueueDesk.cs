﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：QueueDesk
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：排队台位信息
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 6:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class QueueDesk
    {
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
        public int Id { get; set; }

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
        public int RoomType { get; set; }

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
        /// 台位类型描述
        /// </summary>
        /// <value>
        /// The Description
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 1:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Description { get; set; }

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
    }
}
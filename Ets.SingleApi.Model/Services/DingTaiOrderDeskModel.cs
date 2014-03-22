﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：WaiMaiOrderDishModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：订台订单台位信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiOrderDeskModel
    {
        /// <summary>
        /// 房间类型
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 8:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeskNo { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 8:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RoomType { get; set; }

        /// <summary>
        /// 桌子类型
        /// </summary>
        /// <value>
        /// The name of the table type.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 8:09 PM
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
    }
}
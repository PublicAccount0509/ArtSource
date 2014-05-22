﻿namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 订单类型
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public enum OrderType
    {
        /// <summary>
        /// 所有订单
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        All = -1,

        /// <summary>
        /// 外卖
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        WaiMai = 0,

        /// <summary>
        /// 堂食
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        TangShi = 1,

        /// <summary>
        /// 订台
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DingTai = 2,

        /// <summary>
        /// 排队
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 15:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        PaiDui = 3,

        /// <summary>
        /// 当面付
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/29/2014 5:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DirectPay = 4
    }
}
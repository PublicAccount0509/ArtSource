﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HaiDiLaoShoppingCartExtraRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：外卖订单额外信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HaiDiLaoShoppingCartExtraRequst : ApiRequst
    {
        /// <summary>
        /// 设置或取得订单炉灶数
        /// </summary>
        /// <value>
        /// 订单炉灶数
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/14/2013 3:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CookingCount { get; set; }

        /// <summary>
        /// 设置或取得订单锅数
        /// </summary>
        /// <value>
        /// 订单锅数
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/14/2013 3:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PanCount { get; set; }

        /// <summary>
        /// 设置或取得订单就餐人数
        /// </summary>
        /// <value>
        /// 订单就餐人数
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/14/2013 3:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DiningCount { get; set; }
    }
}
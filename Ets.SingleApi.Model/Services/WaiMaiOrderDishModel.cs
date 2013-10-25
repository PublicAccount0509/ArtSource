﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：WaiMaiOrderDishModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 15:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiOrderDishModel
    {
        /// <summary>
        /// 设置或取得菜Id
        /// </summary>
        /// <value>
        /// 菜Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// 设置或取得菜名
        /// </summary>
        /// <value>
        /// 菜名
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishName { get; set; }

        /// <summary>
        /// 设置或取得菜数量
        /// </summary>
        /// <value>
        /// 菜数量
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Quantity { get; set; }

        /// <summary>
        /// 设置或取得菜价格
        /// </summary>
        /// <value>
        /// 菜价格
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? Price { get; set; }
    }
}
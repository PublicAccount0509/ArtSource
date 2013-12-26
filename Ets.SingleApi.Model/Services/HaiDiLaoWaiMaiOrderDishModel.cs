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
    public class HaiDiLaoWaiMaiOrderDishModel
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
        /// 设置或取得菜父级Id
        /// </summary>
        /// <value>
        /// 菜父级Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/19/2013 11:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ParentId { get; set; }

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
        /// 设置或取得菜备注
        /// </summary>
        /// <value>
        /// 菜备注
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Instruction { get; set; }

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

        /// <summary>
        /// 设置或取得商品类型
        /// </summary>
        /// <value>
        /// 商品类型 0 菜 3 套餐
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Type { get; set; }
    }
}
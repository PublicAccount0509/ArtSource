﻿namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：ShoppingCartLink
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：购物车关联信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 3:11 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartLink
    {
        /// <summary>
        /// 设置或取得购物车唯一标识
        /// </summary>
        /// <value>
        /// 购物车唯一标识
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ShoppingCartLinkId { get; set; }

        /// <summary>
        /// 设置或取得购物车Id
        /// </summary>
        /// <value>
        /// 购物车Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ShoppingCartId { get; set; }

        /// <summary>
        /// 设置或取得供应商Id
        /// </summary>
        /// <value>
        /// 供应商Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int BusinessId { get; set; }

        /// <summary>
        /// 设置或取得供应商类型
        /// </summary>
        /// <value>
        /// 供应商类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int BusinessType { get; set; }

        /// <summary>
        /// 设置或取得用户Id
        /// </summary>
        /// <value>
        /// 用户Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 设置或取得订单唯一标识符
        /// </summary>
        /// <value>
        /// 订单唯一标识符
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OrderId { get; set; }
    }
}

﻿namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 接口名称：IShoppingCartBusiness
    /// 命名空间：Ets.SingleApi.Model
    /// 接口功能：购物车所属厂家
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:05 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartBusiness
    {
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
        int BusinessType { get; set; }

        /// <summary>
        /// 设置或取得餐厅Id
        /// </summary>
        /// <value>
        /// 餐厅Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        int BusinessId { get; set; }
    }
}
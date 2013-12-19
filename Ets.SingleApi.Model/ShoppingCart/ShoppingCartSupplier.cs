﻿namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：ShoppingCartSupplier
    /// 命名空间：Ets.SingleApi.Model
    /// 类功能：餐厅信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 10:57 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartSupplier
    {
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
        public int SupplierId { get; set; }

        /// <summary>
        /// 设置或取得餐厅名称
        /// </summary>
        /// <value>
        /// 餐厅名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// 设置或取得餐厅电话
        /// </summary>
        /// <value>
        /// 餐厅电话
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// 设置或取得餐厅营业时间
        /// </summary>
        /// <value>
        /// 营业时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ServiceTime { get; set; }

        /// <summary>
        /// 设置或取得餐厅送餐时间
        /// </summary>
        /// <value>
        /// 送餐时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 10:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 设置或取得餐厅阶梯打包费
        /// </summary>
        /// <value>
        /// 餐厅阶梯打包费
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackLadder { get; set; }

        /// <summary>
        /// 设置或取得餐厅打包费
        /// </summary>
        /// <value>
        /// 餐厅打包费
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// 设置或取得餐厅免送餐费价格
        /// </summary>
        /// <value>
        /// 餐厅免送餐费价格
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal FreeDeliveryLine { get; set; }

        /// <summary>
        /// 设置或取得餐厅服务费百分率
        /// </summary>
        /// <value>
        /// 餐厅服务费百分率
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal ConsumerAmount { get; set; }

        /// <summary>
        /// 设置或取得餐厅送餐费
        /// </summary>
        /// <value>
        /// 餐厅送餐费
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int FixedDeliveryCharge { get; set; }

        /// <summary>
        /// 设置或取得餐厅送餐起送价格
        /// </summary>
        /// <value>
        /// 餐厅送餐起送价格
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DelMinOrderAmount { get; set; }

        /// <summary>
        /// 设置或取得餐厅是否支持阶梯打包
        /// </summary>
        /// <value>
        /// 餐厅是否支持阶梯打包
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPackLadder { get; set; }
    }
}
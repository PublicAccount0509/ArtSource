﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：BaiFuBaoPaymentQueryData
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：百付宝支付请求参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/14/2014 9:08 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoPaymentParameter 
    {
        /// <summary>
        /// 设置或取得 订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:56 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }
        /// <summary>
        /// 设置或获取 订单号
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:10 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }
        /// <summary>
        /// 设置或获取 商品名称
        /// </summary>
        /// <value>
        /// 商品名称
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:10 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string GoodsName { get; set; }
        /// <summary>
        /// 设置或获取 金额
        /// </summary>
        /// <value>
        /// 金额
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Amount { get; set; }
        /// <summary>
        /// 设置或获取 百付宝前台通知Url地址
        /// </summary>
        /// <value>
        /// 百付宝后前通知Url地址
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:11 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string PageUrl { get; set; }
        /// <summary>
        /// 百度支付后台回调地址
        /// </summary>
        /// <value>
        /// The BackgroundNoticeUrl
        /// </value>
        /// 创建者：王巍
        /// 创建日期：6/4/2014 4:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BackgroundNoticeUrl { get; set; }
    }
}

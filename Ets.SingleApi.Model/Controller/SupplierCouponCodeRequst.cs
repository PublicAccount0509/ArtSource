﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierCouponRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：优惠参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 11:37 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierCouponCodeRequst : ApiRequst
    {
        /// <summary>
        /// 设置或取得总消费
        /// </summary>
        /// <value>
        /// 总消费
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Total { get; set; }

        /// <summary>
        /// 设置或取得用户Id
        /// </summary>
        /// <value>
        /// 用户Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 优惠码
        /// </summary>
        /// <value>
        /// 优惠码
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：4/21/2014 2:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CouponCode { get; set; }
    }
}
﻿namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 支付方式
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 1:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public enum PaymentType
    {
        /// <summary>
        /// 默认支付，向服务器下单
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:40
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Default = 1,

        /// <summary>
        /// 字段UmPayment
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        UmPayment = 2,

        /// <summary>
        /// 百付宝支付
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 1:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        BaiFuBaoPayment =3
    }
}
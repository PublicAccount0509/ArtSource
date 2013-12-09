namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ISupplierCouponProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：餐厅折扣功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/6/2013 5:33 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISupplierCouponProvider
    {
        /// <summary>
        /// 取餐方式
        /// </summary>
        /// <value>
        /// 取餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DeliveryMethodType DeliveryMethodType { get; }

        /// <summary>
        /// 取得折扣
        /// </summary>
        /// <param name="total">消费总额</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="now">下单时间</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 折扣
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        List<SupplierCouponModel> CalculateCoupon(decimal total, int supplierId, DateTime now, int? userId);
    }
}
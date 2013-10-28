﻿namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IPaymentServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：支付功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 3:23 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IPaymentServices
    {
        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> UmPayment(UmPaymentParameter parameter);
    }
}
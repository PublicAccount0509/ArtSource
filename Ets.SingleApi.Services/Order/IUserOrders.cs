﻿namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IUserOrders
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：用户订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 16:01
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IUserOrders
    {
        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        OrderType OrderType { get; }

        /// <summary>
        /// 取得订单列表
        /// </summary>
        /// <param name="parameter">查询用户订单参数</param>
        /// <returns>
        /// 返回订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<IOrderModel> GetUserOrderList(UserOrdersParameter parameter);
    }
}
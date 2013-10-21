﻿namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：UserOrdersData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：用户订单结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/20 19:53
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserOrdersData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserOrdersData"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserOrdersData()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of UserOrdersData
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the OrderList of UserOrdersData
        /// </summary>
        /// <value>
        /// The OrderList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 19:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<IOrderModel> OrderList { get; set; }
    }
}

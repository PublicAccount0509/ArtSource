﻿namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：GetDirectPayOrderListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：当面付查询参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 9:14 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetDirectPayOrderListParameter
    {
        /// <summary>
        /// Gets or sets the QueueStartDate of GetQueuesParameter
        /// </summary>
        /// <value>
        /// The QueueStartDate
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/22/2014 4:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? DirectPayStartDate { get; set; }

        /// <summary>
        /// Gets or sets the QueueEndDate of GetQueuesParameter
        /// </summary>
        /// <value>
        /// The QueueEndDate
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/22/2014 4:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? DirectPayEndDate { get; set; }

        /// <summary>
        /// 订单状态Id
        /// </summary>
        /// <value>
        /// 订单状态Id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/5/2014 12:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of GetQueuesParameter
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierGroupId of GetQueuesParameter
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierGroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsEtaoshi
        /// </value>
        /// 创建者：周超
        /// 创建日期：1/16/2014 9:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsEtaoshi { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PageIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The Cancelled
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/15/2014 4:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Cancelled { get; set; }

        /// <summary>
        /// 当前用户UserId
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：3/24/2014 6:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        /// <value>
        /// The PlatformId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 11:57 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PlatformId { get; set; }
    }
}
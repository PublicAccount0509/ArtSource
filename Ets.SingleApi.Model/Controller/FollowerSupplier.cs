﻿namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：FollowerSupplier
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：收藏餐厅列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:51
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FollowerSupplier
    {
        /// <summary>
        /// Gets or sets the SupplierId of FollowerSupplier
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the FollowerSupplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Address of FollowerSupplier
        /// </summary>
        /// <value>
        /// The Address
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of FollowerSupplier
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDescription of FollowerSupplier
        /// </summary>
        /// <value>
        /// The SupplierDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDescription { get; set; }

        /// <summary>
        /// Gets or sets the Averageprice of FollowerSupplier
        /// </summary>
        /// <value>
        /// The Averageprice
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double? Averageprice { get; set; }

        /// <summary>
        /// Gets or sets the AverageRating of FollowerSupplier
        /// </summary>
        /// <value>
        /// The AverageRating
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 17:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the name of the cuisine.
        /// </summary>
        /// <value>
        /// The name of the cuisine.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineName { get; set; }

        /// <summary>
        /// Gets or sets the LogoUrl of FollowerSupplier
        /// </summary>
        /// <value>
        /// The LogoUrl
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the SupplierFeatureList of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The SupplierFeatureList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierFeature> SupplierFeatureList { get; set; }
    }
}
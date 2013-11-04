﻿namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SaveSupplierCuisineRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：添加外卖订单实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:46 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveSupplierCuisineRequst
    {
        /// <summary>
        /// Gets or sets the SupplierMenuCategoryTypeId of SaveSupplierCuisineRequst
        /// </summary>
        /// <value>
        /// The SupplierMenuCategoryTypeId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierMenuCategoryTypeId { get; set; }

        /// <summary>
        /// Gets or sets the CuisineList of SaveSupplierCuisineRequst
        /// </summary>
        /// <value>
        /// The CuisineList
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SaveSupplierCuisine> CuisineList { get; set; }
    }
}
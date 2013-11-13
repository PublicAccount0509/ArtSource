﻿namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SupplierDishListResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅菜列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDishListResponse : ApiResponse
    {
        /// <summary>
        /// 餐厅菜列表
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierDishDetail> Result { get; set; }
    }
}
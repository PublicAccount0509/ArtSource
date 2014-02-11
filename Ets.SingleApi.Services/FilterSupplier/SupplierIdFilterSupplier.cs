﻿using System.Collections.Generic;
using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 过虑餐厅Id
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：2014-2-10 17:16
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierIdFilterSupplier : IFilterSupplier
    {
        /// <summary>
        /// 过滤餐厅Id
        /// </summary>
        /// <value>
        /// 过滤餐厅Id
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FilteredSupplierWay FilteredSupplierWay
        {
            get { return FilteredSupplierWay.FilteredSupplierId; }
        }

        /// <summary>
        /// 过滤餐厅列表
        /// </summary>
        /// <param name="supplierList">餐厅列表</param>
        /// <returns>
        /// 要过滤掉的餐厅Id
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 17:15
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<int> Filter(List<SupplierModel> supplierList)
        {
            if (supplierList == null || supplierList.Count == 0)
            {
                return new List<int>();
            }

            return supplierList.Where(p => ServicesCommon.FilteredSupplierIdList.Contains(p.SupplierId))
                                    .Select(p => p.SupplierId)
                                    .ToList();
        }
    }
}

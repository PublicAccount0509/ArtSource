using System.Collections.Generic;
using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 过虑餐厅名称关键字
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：2014-2-10 17:16
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class KeyWordFilterSupplier : IFilterSupplier
    {
        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <value>
        /// 过滤关键字
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：2014-2-11 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FilteredSupplierWay FilteredSupplierWay
        {
            get { return FilteredSupplierWay.FilteredKeyWord; }
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
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 17:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<int> Filter(List<SupplierModel> supplierList)
        {
            return
                supplierList.Where(
                    p =>
                    ServicesCommon.FilteredKeyWordList.Any(
                        t => p.SupplierName.IndexOf(t, System.StringComparison.Ordinal) != -1))
                            .Select(p => p.SupplierId)
                            .ToList();
        }
    }
}

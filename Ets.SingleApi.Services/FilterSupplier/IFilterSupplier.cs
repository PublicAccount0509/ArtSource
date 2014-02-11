using System.Collections.Generic;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 过滤餐厅列表
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：2014-2-10 16:46
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IFilterSupplier
    {
        /// <summary>
        /// Gets the filtered supplier way.
        /// </summary>
        /// <value>
        /// The filtered supplier way.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        FilteredSupplierWay FilteredSupplierWay { get; }

        /// <summary>
        /// 过滤餐厅列表
        /// </summary>
        /// <param name="supplierList">餐厅列表</param>
        /// <returns>要过滤掉的餐厅Id</returns>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-10 17:15
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        List<int> Filter(List<SupplierModel> supplierList);
    }
}

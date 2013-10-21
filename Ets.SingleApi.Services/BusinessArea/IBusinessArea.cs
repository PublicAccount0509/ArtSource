namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IBusinessArea
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：获取商圈信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 15:07
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IBusinessArea
    {
        /// <summary>
        /// Gets the type of the area.
        /// </summary>
        /// <value>
        /// The type of the area.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        AreaType AreaType { get; }

        /// <summary>
        /// 根据id查询商圈信息列表
        /// </summary>
        /// <param name="parentId">The parentId</param>
        /// <returns>
        /// 返回数据列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        List<BusinessAreaModel> GetBusinessAreaData(int? parentId);

        /// <summary>
        /// 根据code查询商圈信息列表
        /// </summary>
        /// <param name="parentCode">The parentCode</param>
        /// <returns>
        /// 返回数据列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        List<BusinessAreaModel> GetBusinessAreaData(string parentCode);
    }
}
﻿namespace Ets.SingleApi.Controllers.IServices
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IBusinessAreaServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：提供一些关于商圈的数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 0:24
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IBusinessAreaServices
    {


        /// <summary>
        /// 根据regioncode获取城市名称
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="regionCode">The regionCode</param>
        /// <returns>
        /// The ServicesResult{BusinessAreaModel}
        /// </returns>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/7/28 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<BusinessAreaModel> BusinessCityName(string source, int regionCode);


        /// <summary>
        /// 根据supplierGroupId获取RegionCode
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="provinceCode">The provinceCode</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <returns>
        /// Int32}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/7/25 15:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetCityListBySupplierGroupId(string source, string provinceCode, int supplierGroupId);

        /// <summary>
        /// 获取国家列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 返回国家列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetCountryList(string source);

        /// <summary>
        /// 获取省份列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="countryCode">国家code</param>
        /// <returns>
        /// 返回省份列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetProvinceList(string source, string countryCode);

        /// <summary>
        /// 获取城市列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="provinceCode">省份code</param>
        /// <returns>
        /// 返回城市列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetCityList(string source, string provinceCode);

        /// <summary>
        /// 获取区域列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="cityCode">城市code</param>
        /// <returns>
        /// 返回区域列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetRegionList(string source, string cityCode);

        /// <summary>
        /// 获取商圈列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="regionCode">区域code</param>
        /// <returns>
        /// 返回商圈列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetBusinessAreaList(string source, string regionCode);

        /// <summary>
        /// 获取地区和商圈信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回地区和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 18:26
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetAllBusinessAreaList(string source, string parentCode);

        /// <summary>
        /// 获取地区和商圈信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回地区和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<BusinessAreaModel> GetRegionBusinessAreaList(string source, string parentCode);

        /// <summary>
        /// 获取商圈信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">商圈Id</param>
        /// <param name="businessAreaName">商圈名称</param>
        /// <returns>
        /// 返回商圈信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<BusinessAreaModel> GetBusinessArea(string source, string id, string businessAreaName);

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">区域Id</param>
        /// <param name="regionName">区域名称</param>
        /// <param name="parentCode">父节点编码</param>
        /// <returns>
        /// 返回区域信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<BusinessAreaModel> GetRegion(string source, int id, string regionName, string parentCode);
    }
}
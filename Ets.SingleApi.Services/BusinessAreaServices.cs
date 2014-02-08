namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：BusinessAreaServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：提供业务商圈基本数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/12 18:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BusinessAreaServices : IBusinessAreaServices
    {
        /// <summary>
        /// 字段businessAreaList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/14 17:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IBusinessArea> businessAreaList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessAreaServices" /> class.
        /// </summary>
        /// <param name="businessAreaList">The businessAreaList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/12 18:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BusinessAreaServices(List<IBusinessArea> businessAreaList)
        {
            this.businessAreaList = businessAreaList;
        }

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
        public ServicesResultList<BusinessAreaModel> GetCountryList(string source)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Country);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(string.Empty);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

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
        public ServicesResultList<BusinessAreaModel> GetProvinceList(string source, string countryCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Province);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(countryCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

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
        public ServicesResultList<BusinessAreaModel> GetCityList(string source, string provinceCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.City);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(provinceCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

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
        public ServicesResultList<BusinessAreaModel> GetRegionList(string source, string cityCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Region);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(cityCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

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
        public ServicesResultList<BusinessAreaModel> GetBusinessAreaList(string source, string regionCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.BusinessArea);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(regionCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取商圈列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回商圈列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetAllBusinessAreaList(string source, string parentCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.AllArea);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(parentCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

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
        public ServicesResultList<BusinessAreaModel> GetRegionBusinessAreaList(string source, string parentCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.RegionBusinessArea);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(parentCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }
    }
}
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
        /// <returns>
        /// 返回国家列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetCountryList()
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Country);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(string.Empty);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取省份列表信息
        /// </summary>
        /// <param name="countryCode">国家code</param>
        /// <returns>
        /// 返回省份列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetProvinceList(string countryCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Province);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(countryCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取城市列表信息
        /// </summary>
        /// <param name="provinceCode">省份code</param>
        /// <returns>
        /// 返回城市列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetCityList(string provinceCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.City);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(provinceCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取区域列表信息
        /// </summary>
        /// <param name="cityCode">城市code</param>
        /// <returns>
        /// 返回区域列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetRegionList(string cityCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.Region);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(cityCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取商圈列表信息
        /// </summary>
        /// <param name="regionCode">区域code</param>
        /// <returns>
        /// 返回商圈列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetBusinessAreaList(string regionCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.BusinessArea);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(regionCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }

        /// <summary>
        /// 获取商圈列表信息
        /// </summary>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回商圈列表信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<BusinessAreaModel> GetAllBusinessAreaList(string parentCode)
        {
            var businessArea = this.businessAreaList.FirstOrDefault(p => p.AreaType == AreaType.AllArea);
            var list = businessArea == null ? new List<BusinessAreaModel>() : businessArea.GetBusinessAreaData(parentCode);
            return new ServicesResultList<BusinessAreaModel> { ResultTotalCount = list.Count, Result = list };
        }
    }
}
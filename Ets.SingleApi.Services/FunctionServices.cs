namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：FunctionServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：公用功能信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FunctionServices : IFunctionServices
    {
        /// <summary>
        /// 字段distanceList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IDistance> distanceList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionServices"/> class.
        /// </summary>
        /// <param name="distanceList">The distanceList</param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FunctionServices(List<IDistance> distanceList)
        {
            this.distanceList = distanceList;
        }

        /// <summary>
        /// 根据地址取得对应坐标
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="address">楼宇地址</param>
        /// <param name="city">当前城市</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<Location> GetLocation(string source, string address, string city, int type)
        {
            if (address.IsEmptyOrNull())
            {
                return new ServicesResult<Location>
                {
                    StatusCode = (int)StatusCode.Location.InvalidAddressCode,
                    Result = new Location()
                };
            }

            var distance = this.distanceList.FirstOrDefault(p => p.LocationType == (LocationType)type);
            if (distance == null)
            {
                return new ServicesResult<Location>
                    {
                        StatusCode = (int)StatusCode.Location.InvalidLocationTypeCode,
                        Result = new Location()
                    };
            }

            var location = distance.GetLocation(address, city);
            return new ServicesResult<Location>
            {
                StatusCode = location == null ? (int)StatusCode.Location.LocationErrorCode : (int)StatusCode.Location.Ok,
                Result = location ?? new Location()
            };
        }
    }
}
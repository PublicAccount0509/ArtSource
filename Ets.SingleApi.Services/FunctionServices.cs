using System;

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

        /// <summary>
        /// 根据坐标取得对应地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<LocationCityModel> GetLocationCity(string source, double userLat, double userLong, int type)
        {
            var distance = this.distanceList.FirstOrDefault(p => p.LocationType == (LocationType)type);
            if (distance == null)
            {
                return new ServicesResult<LocationCityModel>
                {
                    StatusCode = (int)StatusCode.Location.InvalidLocationTypeCode,
                    Result = new LocationCityModel()
                };
            }

            var locationCity = distance.GetLocationCity(new Location { Lat = userLat, Lng = userLong });
            if (locationCity == null)
            {
                return new ServicesResult<LocationCityModel>
                    {
                        StatusCode = (int)StatusCode.Location.LocationErrorCode,
                        Result = new LocationCityModel()
                    };
            }

            var result = new LocationCityModel
                {
                    Address = locationCity.Address,
                    CityCode = string.Empty,
                    CityName = locationCity.City
                };
            return new ServicesResult<LocationCityModel>
            {
                StatusCode = (int)StatusCode.Location.Ok,
                Result = result
            };
        }
        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<DistanceModel> GetDistance(string source, DistanceParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<DistanceModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new DistanceModel()
                };
            }
            var distance = CalDistance(parameter.LocationA, parameter.LocationB, parameter.Gs);
            var distanceModel = new DistanceModel { Distance = distance };
            return new ServicesResult<DistanceModel>
            {
                Result = distanceModel
            };
        }
        /// <summary>
        /// 计算距离方法
        /// </summary>
        /// <param name="locationA">The locationA</param>
        /// <param name="locationB">The locationB</param>
        /// <param name="gs">The gs</param>
        /// <returns>
        /// Double
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private double CalDistance(Location locationA, Location locationB, GaussSphere gs)
        {
            var radLat1 = Rad(locationA.Lat);
            var radLat2 = Rad(locationB.Lat);
            var a = radLat1 - radLat2;
            var b = Rad(locationA.Lng) - Rad(locationB.Lng);
            var s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * (gs == GaussSphere.WGS84 ? 6378137.0 : (gs == GaussSphere.Xian80 ? 6378140.0 : 6378245.0));
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="d">The d</param>
        /// <returns>
        /// The Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 4:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }
    }
}
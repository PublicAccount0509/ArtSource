using System;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：FunctionController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：提供一些公用方法控制器
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FunctionController : SingleApiController
    {
        /// <summary>
        /// 字段functionServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IFunctionServices functionServices;

        /// <summary>
        /// 字段businessAreaServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：1/8/2014 3:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IBusinessAreaServices businessAreaServices;
        /// <summary>
        /// 字段supplierServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISupplierServices supplierServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionController" /> class.
        /// </summary>
        /// <param name="functionServices">The functionServices</param>
        /// <param name="businessAreaServices">The businessAreaServices</param>
        /// <param name="supplierServices"></param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FunctionController(
            IFunctionServices functionServices,
            IBusinessAreaServices businessAreaServices,
            ISupplierServices supplierServices)
        {
            this.functionServices = functionServices;
            this.businessAreaServices = businessAreaServices;
            this.supplierServices = supplierServices;
        }

        /// <summary>
        /// 根据地址取得对应坐标
        /// </summary>
        /// <param name="address">楼宇地址</param>
        /// <param name="city">当前城市</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<Location> Location(string address, string city = null, int? type = 0)
        {
            var getLocationResult = this.functionServices.GetLocation(this.Source, address, city ?? string.Empty, type ?? 0);
            if (getLocationResult.Result == null)
            {
                return new Response<Location>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLocationResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLocationResult.StatusCode
                    },
                    Result = new Location()
                };
            }

            return new Response<Location>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLocationResult.StatusCode
                },
                Result = getLocationResult.Result
            };
        }

        /// <summary>
        /// 根据坐标取得对应地址
        /// </summary>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<LocationCity> LocationCity(double userLat, double userLong, int? type = 0)
        {
            var getLocationResult = this.functionServices.GetLocationCity(this.Source, userLat, userLong, type ?? 0);
            if (getLocationResult.Result == null)
            {
                return new Response<LocationCity>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLocationResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLocationResult.StatusCode
                    },
                    Result = new LocationCity()
                };
            }

            var result = new LocationCity
                {
                    Address = getLocationResult.Result.Address ?? string.Empty,
                    CityCode = getLocationResult.Result.CityCode ?? string.Empty,
                    CityName = getLocationResult.Result.CityName ?? string.Empty
                };

            var list = this.businessAreaServices.GetCityList(this.Source, string.Empty);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new Response<LocationCity>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLocationResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLocationResult.StatusCode
                    },
                    Result = result
                };
            }

            var businessArea = list.Result.FirstOrDefault(p => p.Name == result.CityName);
            result.CityCode = businessArea == null ? string.Empty : businessArea.Code;
            result.CityId = businessArea == null ? string.Empty : businessArea.Id;
            return new Response<LocationCity>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLocationResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="userLat"></param>
        /// <param name="userLong"></param>
        /// <param name="supplierId"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<DistanceResult> GetDistance(double userLat, double userLong, int supplierId)
        {
            var supplier = this.supplierServices.GetSupplier(this.Source, supplierId, null);
            if (supplier == null)
            {
                return new Response<DistanceResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Succeed.Empty
                    },
                    Result = new DistanceResult()
                };
            }
            var locationA = new Location
                {
                    Lat = userLat,
                    Lng = userLong
                };
            var locationB = new Location
                {
                    Lat = Convert.ToDouble(supplier.Result.BaIduLat),
                    Lng = Convert.ToDouble(supplier.Result.BaIduLong)
                };
            var distanceParameter = new DistanceParameter
                {
                    LocationA = locationA,
                    LocationB = locationB,
                    Gs = GaussSphere.Beijing54
                };
            var distanceResult = this.functionServices.GetDistance(this.Source, distanceParameter);
            if (distanceResult == null)
            {
                return new Response<DistanceResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Succeed.Empty
                    },
                    Result = new DistanceResult()
                };
            }

            return new Response<DistanceResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = (int)StatusCode.Succeed.Ok
                },
                Result = new DistanceResult
                    {
                        Distance = distanceResult.Result.Distance
                    }
            };
        }
    }
}
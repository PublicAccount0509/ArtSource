namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：BusinessAreaController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：业务商圈API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BusinessAreaController : SingleApiController
    {
        /// <summary>
        /// 字段businessAreaServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IBusinessAreaServices businessAreaServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessAreaController" /> class.
        /// </summary>
        /// <param name="businessAreaServices">The businessAreaServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BusinessAreaController(IBusinessAreaServices businessAreaServices)
        {
            this.businessAreaServices = businessAreaServices;
        }

        /// <summary>
        /// Businesses the name of the city.
        /// </summary>
        /// <param name="regionCode">The regionCode</param>
        /// <returns>
        /// The Response{BusinessArea}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/7/28 18:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<BusinessArea> BusinessCityName(int regionCode)
        {
            var result = this.businessAreaServices.BusinessCityName(this.Source, regionCode);
            if (result.Result == null)
            {
                return new Response<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = result.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : result.StatusCode
                    },
                    Result = new BusinessArea()
                };
            }

            var model = new BusinessArea
            {
                Id = (result.Result.Id ?? string.Empty),
                Name = (result.Result.Name ?? string.Empty),
                Code = (result.Result.Code ?? string.Empty),
                Depth = result.Result.Depth,
                ParentCode = (result.Result.ParentCode ?? string.Empty)
            };

            return new Response<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                ResultTotalCount = result.ResultTotalCount,
                Result = model
            };
        }


        /// <summary>
        /// 获取区域和商圈信息列表
        /// </summary>
        /// <returns>
        /// 返回区域和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<BusinessArea> BusinessAreaList(string parentCode = null)
        {
            var list = this.businessAreaServices.GetAllBusinessAreaList(this.Source, (parentCode ?? string.Empty).Trim());
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<BusinessArea>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = list.StatusCode
                            },
                        Result = new List<BusinessArea>()
                    };
            }

            var result = list.Result.Select(p => new BusinessArea
                    {
                        Id = (p.Id ?? string.Empty),
                        Name = (p.Name ?? string.Empty),
                        Code = (p.Code ?? string.Empty),
                        Depth = p.Depth,
                        ParentCode = (p.ParentCode ?? string.Empty)
                    }).ToList();

            return new ListResponse<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode
                    },
                    ResultTotalCount = result.Count,
                    Result = result
                };
        }

        /// <summary>
        /// Opens the city list by supplier group identifier.
        /// </summary>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <returns>
        /// ListResponse{BusinessArea}
        /// </returns>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/7/25 14:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<BusinessArea> OpenCityListBySupplierGroupId(int supplierGroupId)
        {

            var list = this.businessAreaServices.GetCityListBySupplierGroupId(this.Source, string.Empty, supplierGroupId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode
                    },
                    Result = new List<BusinessArea>()
                };
            }
            var result = list.Result.Select(p => new BusinessArea
            {
                Id = (p.Id ?? string.Empty),
                Name = (p.Name ?? string.Empty),
                Code = (p.Code ?? string.Empty),
                Depth = p.Depth,
                ParentCode = (p.ParentCode ?? string.Empty)
            }).OrderBy(p => p.Code).ToList();

            return new ListResponse<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = result.Count,
                Result = result
            };
        }

        /// <summary>
        /// 获取已开通城市列表
        /// </summary>
        /// <returns>
        /// 获取已开通城市列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<BusinessArea> OpenCityList(string parentCode = null)
        {
            var list = this.businessAreaServices.GetCityList(this.Source, (parentCode ?? string.Empty).Trim());
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode
                    },
                    Result = new List<BusinessArea>()
                };
            }

            var result = list.Result.Where(p => ControllersCommon.OpenCityList.Any(q => p.Name.Contains(q))).Select(p => new BusinessArea
            {
                Id = (p.Id ?? string.Empty),
                Name = (p.Name ?? string.Empty),
                Code = (p.Code ?? string.Empty),
                Depth = p.Depth,
                ParentCode = (p.ParentCode ?? string.Empty)
            }).OrderBy(p => p.Code).ToList();

            return new ListResponse<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = result.Count,
                Result = result
            };
        }

        /// <summary>
        /// 获取地区和商圈信息列表
        /// </summary>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回地区和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<BusinessArea> RegionBusinessAreaList(string parentCode = null)
        {
            var list = this.businessAreaServices.GetRegionBusinessAreaList(this.Source, (parentCode ?? string.Empty).Trim());
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode
                    },
                    Result = new List<BusinessArea>()
                };
            }

            var result = list.Result.Select(p => new BusinessArea
            {
                Id = (p.Id ?? string.Empty),
                Name = (p.Name ?? string.Empty),
                Code = (p.Code ?? string.Empty),
                Depth = p.Depth,
                ParentCode = (p.ParentCode ?? string.Empty),
                ParentId = (p.ParentId == null ? string.Empty : p.ParentId.Value.ToString())
            }).ToList();

            return new ListResponse<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = result.Count,
                Result = result
            };
        }

        /// <summary>
        /// 获取商圈信息
        /// </summary>
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
        [HttpGet]
        public Response<BusinessArea> BusinessArea(string id, string businessAreaName)
        {
            var result = this.businessAreaServices.GetBusinessArea(this.Source, id ?? string.Empty, businessAreaName ?? string.Empty);
            if (result.Result == null)
            {
                return new Response<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = result.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : result.StatusCode
                    },
                    Result = new BusinessArea()
                };
            }

            var model = new BusinessArea
                {
                    Id = (result.Result.Id ?? string.Empty),
                    Name = (result.Result.Name ?? string.Empty),
                    Code = (result.Result.Code ?? string.Empty),
                    Depth = result.Result.Depth,
                    ParentCode = (result.Result.ParentCode ?? string.Empty)
                };

            return new Response<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                ResultTotalCount = result.ResultTotalCount,
                Result = model
            };
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="id">区域Id</param>
        /// <param name="regionName">区域名称</param>
        /// <param name="parentCode">The parentCode</param>
        /// <returns>
        /// 返回区域信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<BusinessArea> Region(int id = 0, string regionName = null, string parentCode = null)
        {
            var result = this.businessAreaServices.GetRegion(this.Source, id, regionName ?? string.Empty, parentCode ?? string.Empty);
            if (result.Result == null)
            {
                return new Response<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = result.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : result.StatusCode
                    },
                    Result = new BusinessArea()
                };
            }

            var model = new BusinessArea
            {
                Id = (result.Result.Id ?? string.Empty),
                Name = (result.Result.Name ?? string.Empty),
                Code = (result.Result.Code ?? string.Empty),
                Depth = result.Result.Depth,
                ParentCode = (result.Result.ParentCode ?? string.Empty)
            };

            return new Response<BusinessArea>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                ResultTotalCount = result.ResultTotalCount,
                Result = model
            };
        }
    }
}
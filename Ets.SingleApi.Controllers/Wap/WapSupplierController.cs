namespace Ets.SingleApi.Controllers.Wap
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WapSupplierController
    /// 命名空间：Ets.SingleApi.Controllers.Wap
    /// 类功能：餐厅信息API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 16:34
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WapSupplierController : SingleApiController
    {
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
        /// Initializes a new instance of the <see cref="WapSupplierController"/> class.
        /// </summary>
        /// <param name="supplierServices">The supplierServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WapSupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public GetSupplierResponse Supplier(int id)
        {
            var getSupplierResult = this.supplierServices.GetSupplier(id);
            if (getSupplierResult.Result == null)
            {
                return new GetSupplierResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getSupplierResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getSupplierResult.StatusCode
                    },
                    Result = new SupplierDetail()
                };
            }

            var supplier = new SupplierDetail
                {
                    SupplierId = getSupplierResult.Result.SupplierId,
                    SupplierName = getSupplierResult.Result.SupplierName ?? string.Empty,
                    SupplierDescription = getSupplierResult.Result.SupplierDescription ?? string.Empty,
                    ServiceTime = getSupplierResult.Result.ServiceTime ?? string.Empty,
                    Address = getSupplierResult.Result.Address ?? string.Empty,
                    Averageprice = getSupplierResult.Result.Averageprice ?? 0,
                    ParkingInfo = getSupplierResult.Result.ParkingInfo ?? string.Empty,
                    Telephone = getSupplierResult.Result.Telephone ?? string.Empty,
                    SupplierGroupId = getSupplierResult.Result.SupplierGroupId,
                    ChainCount = getSupplierResult.Result.ChainCount,
                    CuisineName = getSupplierResult.Result.CuisineName ?? string.Empty,
                    DateJoined = getSupplierResult.Result.DateJoined,
                    IsOpenDoor = getSupplierResult.Result.IsOpenDoor,
                    LogoUrl = getSupplierResult.Result.LogoUrl ?? string.Empty,
                    PackagingFee = getSupplierResult.Result.PackagingFee ?? 0,
                    FixedDeliveryCharge = getSupplierResult.Result.FixedDeliveryCharge ?? 0,
                    DelMinOrderAmount = getSupplierResult.Result.DelMinOrderAmount ?? 0,
                    FreeDeliveryLine = getSupplierResult.Result.FreeDeliveryLine ?? 0
                };

            return new GetSupplierResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = getSupplierResult.StatusCode
                },
                Result = supplier
            };
        }

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public GetGroupSupplierResponse GroupSupplierList(int supplierGroupId, int pageSize, int? pageIndex)
        {
            var getGroupSupplierListResult = this.supplierServices.GetGroupSupplierList(new GetGroupSupplierListParameter
                {
                    SupplierGroupId = supplierGroupId,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                });

            if (getGroupSupplierListResult.Result == null || getGroupSupplierListResult.Result.Count == 0)
            {
                return new GetGroupSupplierResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getGroupSupplierListResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getGroupSupplierListResult.StatusCode
                    },
                    Result = new List<GroupSupplier>()
                };
            }

            var result = getGroupSupplierListResult.Result.Select(p => new GroupSupplier
                {
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName ?? string.Empty,
                    SupplierDescription = p.SupplierDescription ?? string.Empty,
                    Address = p.Address ?? string.Empty,
                    Averageprice = p.Averageprice ?? 0,
                    ParkingInfo = p.ParkingInfo ?? string.Empty,
                    Telephone = p.Telephone ?? string.Empty,
                    IsWaiMai = p.SupplierFeatureList != null && p.SupplierFeatureList.Count(q => q.FeatureId == ControllersCommon.WaiMaiFeatureId) > 0,
                    IsDingTai = p.SupplierFeatureList != null && p.SupplierFeatureList.Count(q => q.FeatureId == ControllersCommon.DingTaiFeatureId) > 0
                }).ToList();

            return new GetGroupSupplierResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = getGroupSupplierListResult.StatusCode
                },
                ResultTotalCount = getGroupSupplierListResult.ResultTotalCount,
                Result = result
            };
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="supplierName">餐厅名称</param>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public SearchSupplierListResponse SearchSupplierList(string supplierName, int? cuisineId, int? regionId, string businessAreaId, double? userLat, double? userLong, double? distance, int pageSize, int? pageIndex, int orderByType)
        {
            var list = this.supplierServices.GetSupplierList(new GetSupplierListParameter
                {
                    SupplierName = (supplierName ?? string.Empty).Trim(),
                    FeatureId = -1,
                    CuisineId = cuisineId ?? -1,
                    BusinessAreaId = (businessAreaId ?? string.Empty).Trim(),
                    RegionId = regionId ?? -1,
                    UserLat = userLat ?? 0,
                    UserLong = userLong ?? 0,
                    Distance = distance ?? 0,
                    PageSize = pageSize,
                    PageIndex = pageIndex,
                    OrderByType = orderByType
                });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new SearchSupplierListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<Supplier>()
                };
            }

            var result = list.Result.Select(p => new Supplier
                {
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName ?? string.Empty,
                    Address = p.Address ?? string.Empty,
                    Telephone = p.Telephone ?? string.Empty,
                    Averageprice = p.Averageprice ?? 0,
                    CuisineName = p.CuisineName ?? string.Empty,
                    Distance = p.Distance ?? 0,
                    LogoUrl = p.LogoUrl ?? string.Empty
                }).ToList();

            return new SearchSupplierListResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    ResultTotalCount = list.ResultTotalCount,
                    Result = result
                };
        }

        /// <summary>
        /// 获取外卖餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回外卖餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public WaiMaiSupplierListResponse WaiMaiSupplierList(int? cuisineId, int? regionId, string businessAreaId, double? userLat, double? userLong, double? distance, int pageSize, int? pageIndex, int orderByType)
        {
            var featureId = ControllersCommon.WaiMaiFeatureId;
            var list = this.supplierServices.GetSupplierList(new GetSupplierListParameter
            {
                SupplierName = string.Empty,
                FeatureId = featureId,
                CuisineId = cuisineId ?? -1,
                BusinessAreaId = (businessAreaId ?? string.Empty).Trim(),
                RegionId = regionId ?? -1,
                UserLat = userLat ?? 0,
                UserLong = userLong ?? 0,
                Distance = distance,
                PageSize = pageSize,
                PageIndex = pageIndex,
                OrderByType = orderByType
            });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new WaiMaiSupplierListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<Supplier>()
                };
            }

            var result = list.Result.Select(p => new Supplier
            {
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName ?? string.Empty,
                Address = p.Address ?? string.Empty,
                Telephone = p.Telephone ?? string.Empty,
                Averageprice = p.Averageprice ?? 0,
                CuisineName = p.CuisineName ?? string.Empty,
                Distance = p.Distance ?? 0,
                LogoUrl = p.LogoUrl ?? string.Empty
            }).ToList();

            return new WaiMaiSupplierListResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = list.ResultTotalCount,
                Result = result
            };
        }

        /// <summary>
        /// 获取订台餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回订台餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public DingTaiSupplierListResponse DingTaiSupplierList(int? cuisineId, int? regionId, string businessAreaId, double userLat, double userLong, double? distance, int pageSize, int? pageIndex, int orderByType)
        {
            var featureId = ControllersCommon.DingTaiFeatureId;
            var list = this.supplierServices.GetSupplierList(new GetSupplierListParameter
            {
                SupplierName = string.Empty,
                FeatureId = featureId,
                CuisineId = cuisineId ?? -1,
                BusinessAreaId = (businessAreaId ?? string.Empty).Trim(),
                RegionId = regionId ?? -1,
                UserLat = userLat,
                UserLong = userLong,
                Distance = distance,
                PageSize = pageSize,
                PageIndex = pageIndex,
                OrderByType = orderByType
            });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new DingTaiSupplierListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<Supplier>()
                };
            }

            var result = list.Result.Select(p => new Supplier
            {
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName ?? string.Empty,
                Address = p.Address ?? string.Empty,
                Telephone = p.Telephone ?? string.Empty,
                Averageprice = p.Averageprice ?? 0,
                CuisineName = p.CuisineName ?? string.Empty,
                Distance = p.Distance ?? 0,
                LogoUrl = p.LogoUrl ?? string.Empty
            }).ToList();

            return new DingTaiSupplierListResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = list.ResultTotalCount,
                Result = result
            };
        }

        /// <summary>
        /// 获取餐厅菜单
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜单
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public SupplierMenuResponse Menu(int id, int supplierMenuCategoryTypeId)
        {
            var list = this.supplierServices.GetMenu(id, supplierMenuCategoryTypeId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new SupplierMenuResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<SupplierCuisine>()
                };
            }

            var result = list.Result.Select(p => new SupplierCuisine
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                SupplierDishList = p.SupplierDishList.Select(q => new SupplierDish
                {
                    Price = q.Price,
                    ImagePath = q.ImagePath ?? string.Empty,
                    SupplierDishId = q.SupplierDishId,
                    SupplierDishName = q.SupplierDishName ?? string.Empty,
                    SuppllierDishDescription = q.SuppllierDishDescription ?? string.Empty,
                    AverageRating = q.AverageRating ?? 0,
                    IsCommission = q.IsCommission,
                    IsDiscount = q.IsDiscount,
                    Recipe = q.Recipe ?? string.Empty,
                    Recommended = q.Recommended
                }).ToList()
            }).ToList();

            return new SupplierMenuResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                ResultTotalCount = list.ResultTotalCount,
                Result = result
            };
        }
    }
}
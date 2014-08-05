using Ets.SingleApi.Model;

namespace Ets.SingleApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SupplierController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：餐厅信息功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/1/2013 3:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierController : SingleApiController
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
        /// Initializes a new instance of the <see cref="SupplierController"/> class.
        /// </summary>
        /// <param name="supplierServices">The supplierServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }

        /// <summary>
        /// 计算餐厅打包费
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">菜品信息</param>
        /// <returns>
        /// 返回打包费
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Response<decimal> PackagingFee(int id, PackagingFeeRequst requst)
        {
            if (requst == null || requst.DishList == null || requst.DishList.Count == 0)
            {
                return new Response<decimal>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var result = this.supplierServices.GetPackagingFee(this.Source, id, requst.DishList);
            return new Response<decimal>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="cityCode">城市Code</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<SupplierDetail> Supplier(int id, string cityCode = null)
        {
            var getSupplierResult = this.supplierServices.GetSupplier(this.Source, id, cityCode);
            if (getSupplierResult.Result == null || getSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new Response<SupplierDetail>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = getSupplierResult.StatusCode
                            },
                        Result = new SupplierDetail()
                    };
            }

            var supplierFeatureList = getSupplierResult.Result.SupplierFeatureList;

            //餐厅推荐菜品列表
            var recommendedDishList = getSupplierResult.Result.RecommendedDishList ??
                                      new List<SupplierRecommendedDishModel>();

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
                    FreeDeliveryLine = getSupplierResult.Result.FreeDeliveryLine ?? 0,
                    BaIduLat = getSupplierResult.Result.BaIduLat,
                    BaIduLong = getSupplierResult.Result.BaIduLong,
                    Fax = getSupplierResult.Result.Fax ?? string.Empty,
                    Email = getSupplierResult.Result.Email ?? string.Empty,
                    SupplierDiningPurpose = getSupplierResult.Result.SupplierDiningPurpose ?? string.Empty,
                    PackLadder = getSupplierResult.Result.PackLadder ?? 0,
                    TakeawaySpecialOffersSummary = getSupplierResult.Result.TakeawaySpecialOffersSummary ?? string.Empty,
                    PublicTransport = getSupplierResult.Result.PublicTransport ?? string.Empty,
                    SupplierFeatureList = supplierFeatureList.Select(q => new SupplierFeature
                        {
                            SupplierFeatureId = q.SupplierFeatureId,
                            FeatureId = q.FeatureId,
                            FeatureName = q.FeatureName ?? string.Empty
                        }).ToList(),
                    RecommendedDishList = recommendedDishList.Select(p => new SupplierDish
                        {
                            SupplierDishId = p.SupplierDishId,
                            SupplierDishName = p.SupplierDishName,
                            Price = p.Price,
                            ImagePath = p.ImagePath,
                            SupplierCatogryId = p.SupplierCatogryId,
                            SupplierMenuCategoryId = p.SupplierMenuCategoryId,
                            Type = p.Type,
                            Recipe = p.Recipe,
                            PackagingFee = p.PackagingFee
                        }).ToList()
                };

            return new Response<SupplierDetail>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getSupplierResult.StatusCode
                        },
                    Result = supplier
                };
        }

        /// <summary>
        /// 根据餐厅域名获取餐厅信息
        /// </summary>
        /// <param name="supplierDomain">餐厅域名</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<RoughSupplier> RoughSupplier(string supplierDomain)
        {
            var getRoughSupplierResult = this.supplierServices.GetRoughSupplier(this.Source, (supplierDomain ?? string.Empty).Trim());
            if (getRoughSupplierResult.Result == null)
            {
                return new Response<RoughSupplier>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getRoughSupplierResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getRoughSupplierResult.StatusCode
                    },
                    Result = new RoughSupplier()
                };
            }

            var supplierFeatureList = getRoughSupplierResult.Result.SupplierFeatureList;
            var supplier = new RoughSupplier
            {
                SupplierId = getRoughSupplierResult.Result.SupplierId,
                SupplierName = getRoughSupplierResult.Result.SupplierName ?? string.Empty,
                SupplierDescription = getRoughSupplierResult.Result.SupplierDescription ?? string.Empty,
                Address = getRoughSupplierResult.Result.Address ?? string.Empty,
                Telephone = getRoughSupplierResult.Result.Telephone ?? string.Empty,
                IsWaiMai = supplierFeatureList != null && supplierFeatureList.Exists(q => q.FeatureId == ControllersCommon.WaiMaiFeatureId),
                IsDingTai = supplierFeatureList != null && supplierFeatureList.Exists(q => q.FeatureId == ControllersCommon.DingTaiFeatureId),
                IsTangShi = supplierFeatureList != null && supplierFeatureList.Exists(q => q.FeatureId == ControllersCommon.TangShiFeatureId)
            };

            return new Response<RoughSupplier>
            {
                Message = new ApiMessage
                {
                    StatusCode = getRoughSupplierResult.StatusCode
                },
                Result = supplier
            };
        }

        /// <summary>
        /// 获取餐厅基本信息
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
        public Response<SupplierSimple> SupplierSimple(int id)
        {
            var getSupplierSimpleResult = this.supplierServices.GetSupplierSimple(this.Source, id);
            if (getSupplierSimpleResult.Result == null)
            {
                return new Response<SupplierSimple>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getSupplierSimpleResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getSupplierSimpleResult.StatusCode
                            },
                        Result = new SupplierSimple()
                    };
            }

            var supplier = new SupplierSimple
                {
                    SupplierId = getSupplierSimpleResult.Result.SupplierId,
                    SupplierName = getSupplierSimpleResult.Result.SupplierName ?? string.Empty,
                    SupplierDescription = getSupplierSimpleResult.Result.SupplierDescription ?? string.Empty,
                    Address = getSupplierSimpleResult.Result.Address ?? string.Empty,
                    Averageprice = getSupplierSimpleResult.Result.Averageprice ?? 0,
                    Telephone = getSupplierSimpleResult.Result.Telephone ?? string.Empty,
                    SupplierGroupId = getSupplierSimpleResult.Result.SupplierGroupId,
                    PackagingFee = getSupplierSimpleResult.Result.PackagingFee ?? 0,
                    FixedDeliveryCharge = getSupplierSimpleResult.Result.FixedDeliveryCharge ?? 0,
                    DelMinOrderAmount = getSupplierSimpleResult.Result.DelMinOrderAmount ?? 0,
                    FreeDeliveryLine = getSupplierSimpleResult.Result.FreeDeliveryLine ?? 0,
                    BaIduLat = getSupplierSimpleResult.Result.BaIduLat,
                    BaIduLong = getSupplierSimpleResult.Result.BaIduLong,
                    IsSelfSupport = getSupplierSimpleResult.Result.IsSelfSupport ?? 0
                };

            return new Response<SupplierSimple>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getSupplierSimpleResult.StatusCode
                        },
                    Result = supplier
                };
        }

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="cityId">The cityId</param>
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
        public ListResponse<GroupSupplier> GroupSupplierList(int supplierGroupId, int? featureId = -1,
                                                             int? cityId = null, int pageSize = 10,
                                                             int? pageIndex = null)
        {
            var getGroupSupplierListResult = this.supplierServices.GetGroupSupplierList(this.Source,
                                                                                        new GetGroupSupplierListParameter
                                                                                            {
                                                                                                FeatureId =
                                                                                                    featureId == -1
                                                                                                        ? null
                                                                                                        : featureId,
                                                                                                SupplierGroupId =
                                                                                                    supplierGroupId,
                                                                                                CityId = cityId,
                                                                                                PageIndex = pageIndex,
                                                                                                PageSize = pageSize
                                                                                            });

            if (getGroupSupplierListResult.Result == null || getGroupSupplierListResult.Result.Count == 0)
            {
                return new ListResponse<GroupSupplier>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getGroupSupplierListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getGroupSupplierListResult.StatusCode
                            },
                        Result = new List<GroupSupplier>()
                    };
            }

            var result = getGroupSupplierListResult.Result.Select(p => new GroupSupplier
                {
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName ?? string.Empty,
                    SupplierDescription = p.SupplierDescription ?? string.Empty,
                    BaIduLat = p.BaIduLat ?? string.Empty,
                    BaIduLong = p.BaIduLong ?? string.Empty,
                    Address = p.Address ?? string.Empty,
                    Averageprice = p.Averageprice ?? 0,
                    ParkingInfo = p.ParkingInfo ?? string.Empty,
                    Telephone = p.Telephone ?? string.Empty,
                    LogoUrl = p.LogoUrl ?? string.Empty,
                    SupplierFeatureList = p.SupplierFeatureList.Select(q => new SupplierFeature
                        {
                            SupplierFeatureId = q.SupplierFeatureId,
                            FeatureId = q.FeatureId,
                            FeatureName = q.FeatureName ?? string.Empty
                        }).ToList()
                }).ToList();

            return new ListResponse<GroupSupplier>
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
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="cityId">The cityId</param>
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
        public ListResponse<GroupSupplier> SearchGroupSupplierList(int supplierGroupId, double? userLat = null,
                                                                   double? userLong = null, int? featureId = -1,
                                                                   int? cityId = null, int pageSize = 10,
                                                                   int? pageIndex = null)
        {
            var getGroupSupplierListResult = this.supplierServices.GetSearchGroupSupplierList(this.Source,
                                                                                              new GetSearchGroupSupplierListParameter
                                                                                                  {
                                                                                                      FeatureId =
                                                                                                          featureId ==
                                                                                                          -1
                                                                                                              ? null
                                                                                                              : featureId,
                                                                                                      SupplierGroupId =
                                                                                                          supplierGroupId,
                                                                                                      CityId = cityId,
                                                                                                      UserLat =
                                                                                                          userLat ?? -1,
                                                                                                      UserLong =
                                                                                                          userLong ?? -1,
                                                                                                      PageIndex =
                                                                                                          pageIndex,
                                                                                                      PageSize =
                                                                                                          pageSize
                                                                                                  });

            if (getGroupSupplierListResult.Result == null || getGroupSupplierListResult.Result.Count == 0)
            {
                return new ListResponse<GroupSupplier>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getGroupSupplierListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getGroupSupplierListResult.StatusCode
                            },
                        Result = new List<GroupSupplier>()
                    };
            }

            var result = getGroupSupplierListResult.Result.Select(p => new GroupSupplier
                {
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName ?? string.Empty,
                    SupplierDescription = p.SupplierDescription ?? string.Empty,
                    BaIduLat = p.BaIduLat ?? string.Empty,
                    BaIduLong = p.BaIduLong ?? string.Empty,
                    Address = p.Address ?? string.Empty,
                    Averageprice = p.Averageprice ?? 0,
                    ParkingInfo = p.ParkingInfo ?? string.Empty,
                    Telephone = p.Telephone ?? string.Empty,
                    LogoUrl = p.LogoUrl ?? string.Empty,
                    Distance = p.Distance ?? -1,
                    SupplierFeatureList = p.SupplierFeatureList.Select(q => new SupplierFeature
                        {
                            SupplierFeatureId = q.SupplierFeatureId,
                            FeatureId = q.FeatureId,
                            FeatureName = q.FeatureName ?? string.Empty
                        }).ToList()
                }).ToList();

            return new ListResponse<GroupSupplier>
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
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="activitiesId">The activitiesId</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="cityId">The cityId</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="distance">The distance</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<GroupSupplier> SearchActivitiesSupplierList(int activitiesId, double? userLat = null,
                                                                   double? userLong = null, int? featureId = -1,
                                                                   int? cityId = null, int pageSize = 10,
                                                                   int? pageIndex = null, double? distance = null)
        {
            var getGroupSupplierListResult = this.supplierServices.GetSearchActivitiesSupplierList(this.Source,
                                                                                              new GetSearchActivitiesSupplierListParameter
                                                                                              {
                                                                                                  FeatureId = featureId == -1
                                                                                                          ? null
                                                                                                          : featureId,
                                                                                                  ActivitiesId =
                                                                                                      activitiesId,
                                                                                                  CityId = cityId,
                                                                                                  UserLat =
                                                                                                      userLat ?? -1,
                                                                                                  UserLong =
                                                                                                      userLong ?? -1,
                                                                                                  PageIndex =
                                                                                                      pageIndex,
                                                                                                  PageSize =
                                                                                                      pageSize,
                                                                                                  Distance = distance
                                                                                              });

            if (getGroupSupplierListResult.Result == null || getGroupSupplierListResult.Result.Count == 0)
            {
                return new ListResponse<GroupSupplier>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            getGroupSupplierListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : getGroupSupplierListResult.StatusCode
                    },
                    Result = new List<GroupSupplier>()
                };
            }

            var result = getGroupSupplierListResult.Result.Select(p => new GroupSupplier
            {
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName ?? string.Empty,
                SupplierDescription = p.SupplierDescription ?? string.Empty,
                BaIduLat = p.BaIduLat ?? string.Empty,
                BaIduLong = p.BaIduLong ?? string.Empty,
                Address = p.Address ?? string.Empty,
                Averageprice = p.Averageprice ?? 0,
                ParkingInfo = p.ParkingInfo ?? string.Empty,
                Telephone = p.Telephone ?? string.Empty,
                LogoUrl = p.LogoUrl ?? string.Empty,
                Distance = p.Distance ?? -1,
                SupplierFeatureList = p.SupplierFeatureList.Select(q => new SupplierFeature
                {
                    SupplierFeatureId = q.SupplierFeatureId,
                    FeatureId = q.FeatureId,
                    FeatureName = q.FeatureName ?? string.Empty
                }).ToList()
            }).ToList();

            return new ListResponse<GroupSupplier>
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
        /// 获取餐厅已经开通的功能列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回餐厅已经开通的功能列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierFeature> SupplierFeatureList(int id)
        {
            var getSupplierFeatureListResult = this.supplierServices.GetSupplierFeatureList(this.Source, id);
            if (getSupplierFeatureListResult.Result == null || getSupplierFeatureListResult.Result.Count == 0)
            {
                return new ListResponse<SupplierFeature>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getSupplierFeatureListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getSupplierFeatureListResult.StatusCode
                            },
                        Result = new List<SupplierFeature>()
                    };
            }

            var result = getSupplierFeatureListResult.Result.Select(p => new SupplierFeature
                {
                    SupplierFeatureId = p.SupplierFeatureId,
                    FeatureId = p.FeatureId,
                    FeatureName = p.FeatureName ?? string.Empty
                }).ToList();

            return new ListResponse<SupplierFeature>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getSupplierFeatureListResult.StatusCode
                        },
                    ResultTotalCount = getSupplierFeatureListResult.ResultTotalCount,
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
        public ListResponse<SupplierCuisine> Menu(int id, int supplierMenuCategoryTypeId)
        {
            var list = this.supplierServices.GetMenu(this.Source, id, supplierMenuCategoryTypeId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierCuisine>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
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
                            Recommended = q.Recommended,
                            PackagingFee = q.PackagingFee ?? 0
                        }).ToList()
                }).ToList();

            return new ListResponse<SupplierCuisine>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 获取赠品菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回赠品菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierDish> PresentDishList(int id)
        {
            var list = this.supplierServices.GetPresentDishList(this.Source, id);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierDish>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new List<SupplierDish>()
                    };
            }

            var result = list.Result.Select(q => new SupplierDish
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
                }).ToList();

            return new ListResponse<SupplierDish>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 获取餐厅菜系列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜系列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierCuisineDetail> SupplierCuisineList(int id, int supplierMenuCategoryTypeId)
        {
            var list = this.supplierServices.GetSupplierCuisineList(this.Source, id, supplierMenuCategoryTypeId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierCuisineDetail>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new List<SupplierCuisineDetail>()
                    };
            }

            var result = list.Result.Select(p => new SupplierCuisineDetail
                {
                    CategoryId = p.CategoryId,
                    CategoryName = p.CategoryName ?? string.Empty,
                    CategoryNo = p.CategoryNo ?? 0,
                    SupplierCategoryId = p.SupplierCategoryId,
                    CategoryDescription = p.CategoryDescription ?? string.Empty
                }).ToList();

            return new ListResponse<SupplierCuisineDetail>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 获取餐厅菜系
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierCategoryId">菜系Id</param>
        /// <returns>
        /// 返回餐厅菜系
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<SupplierCuisineDetail> SupplierCuisine(int id, int supplierCategoryId)
        {
            var list = this.supplierServices.GetSupplierCuisine(this.Source, id, supplierCategoryId);
            if (list.Result == null)
            {
                return new Response<SupplierCuisineDetail>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new SupplierCuisineDetail()
                    };
            }

            var result = new SupplierCuisineDetail
                {
                    CategoryId = list.Result.CategoryId,
                    CategoryName = list.Result.CategoryName ?? string.Empty,
                    CategoryNo = list.Result.CategoryNo ?? 0,
                    SupplierCategoryId = list.Result.SupplierCategoryId,
                    CategoryDescription = list.Result.CategoryDescription ?? string.Empty
                };

            return new Response<SupplierCuisineDetail>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 添加餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> AddSupplierCuisine(int id, SaveSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CuisineList == null || requst.CuisineList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var cuisineList = requst.CuisineList.Select(p => new SaveSupplierCuisineModel
                {
                    CuisineName = p.CuisineName,
                    CuisineNo = p.CuisineNo,
                    CuisineDescription = p.CuisineDescription,
                    CuisineImage = p.CuisineImage,
                    CuisineType = p.CuisineType
                }).ToList();

            var result = this.supplierServices.AddSupplierCuisine(this.Source, new SaveSupplierCuisineParameter
                {
                    SupplierId = id,
                    SupplierMenuCategoryTypeId = requst.SupplierMenuCategoryTypeId,
                    CuisineList = cuisineList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 修改餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> UpdateSupplierCuisine(int id, SaveSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CuisineList == null || requst.CuisineList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var cuisineList = requst.CuisineList.Select(p => new SaveSupplierCuisineModel
                {
                    CuisineName = p.CuisineName,
                    CuisineNo = p.CuisineNo,
                    CuisineDescription = p.CuisineDescription,
                    CuisineImage = p.CuisineImage,
                    CuisineType = p.CuisineType
                }).ToList();

            var result = this.supplierServices.UpdateSupplierCuisine(this.Source, new SaveSupplierCuisineParameter
                {
                    SupplierId = id,
                    SupplierMenuCategoryTypeId = requst.SupplierMenuCategoryTypeId,
                    CuisineList = cuisineList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 删除餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> DeleteSupplierCuisine(int id, DeleteSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CategoryIdList == null || requst.CategoryIdList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var result = this.supplierServices.DeleteSupplierCuisine(this.Source, new DeleteSupplierCuisineParameter
                {
                    SupplierId = id,
                    SupplierMenuCategoryTypeId = requst.SupplierMenuCategoryTypeId,
                    CategoryIdList = requst.CategoryIdList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 获取餐厅菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <param name="supplierCategoryId">餐厅菜系Id</param>
        /// <returns>
        /// 返回餐厅菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierDishDetail> SupplierDishList(int id, int supplierMenuCategoryTypeId,
                                                                 int? supplierCategoryId = null)
        {
            var list = this.supplierServices.GetSupplierDishList(this.Source, id, supplierMenuCategoryTypeId,
                                                                 supplierCategoryId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierDishDetail>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new List<SupplierDishDetail>()
                    };
            }

            var result = list.Result.Select(p => new SupplierDishDetail
                {
                    Price = p.Price,
                    ImagePath = p.ImagePath ?? string.Empty,
                    SupplierDishId = p.SupplierDishId,
                    DishName = p.DishName ?? string.Empty,
                    DishDescription = p.DishDescription ?? string.Empty,
                    AverageRating = p.AverageRating,
                    IsCommission = p.IsCommission,
                    IsDiscount = p.IsDiscount,
                    Recipe = p.Recipe ?? string.Empty,
                    Recommended = p.Recommended,
                    CategoryId = p.CategoryId,
                    CategoryName = p.CategoryName ?? string.Empty,
                    DishNo = p.DishNo ?? string.Empty,
                    HasNuts = p.HasNuts,
                    IsDel = p.IsDel,
                    IsSpecialOffer = p.IsSpecialOffer,
                    JianPin = p.JianPin ?? string.Empty,
                    Online = p.Online,
                    PackagingFee = p.PackagingFee,
                    QuanPin = p.QuanPin ?? string.Empty,
                    SpecialOfferNo = p.SpecialOfferNo,
                    SpicyLevel = p.SpicyLevel,
                    StockLevel = p.StockLevel,
                    SupplierCategoryId = p.SupplierCategoryId,
                    SupplierId = p.SupplierId,
                    Vegetarian = p.Vegetarian
                }).ToList();

            return new ListResponse<SupplierDishDetail>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 获取餐厅菜
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierDishId">餐厅菜Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id（1：外卖菜单、2：订台堂食菜单）</param>
        /// <returns>
        /// 返回餐厅菜
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<SupplierDishDetail> SupplierDish(int id, int supplierDishId, int supplierMenuCategoryTypeId)
        {
            var list = this.supplierServices.GetSupplierDish(this.Source, id, supplierDishId, supplierMenuCategoryTypeId);
            if (list.Result == null)
            {
                return new Response<SupplierDishDetail>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new SupplierDishDetail()
                    };
            }

            var result = new SupplierDishDetail
                {
                    Price = list.Result.Price,
                    ImagePath = list.Result.ImagePath ?? string.Empty,
                    SupplierDishId = list.Result.SupplierDishId,
                    DishName = list.Result.DishName ?? string.Empty,
                    DishDescription = list.Result.DishDescription ?? string.Empty,
                    AverageRating = list.Result.AverageRating,
                    IsCommission = list.Result.IsCommission,
                    IsDiscount = list.Result.IsDiscount,
                    Recipe = list.Result.Recipe ?? string.Empty,
                    Recommended = list.Result.Recommended,
                    CategoryId = list.Result.CategoryId,
                    CategoryName = list.Result.CategoryName ?? string.Empty,
                    DishNo = list.Result.DishNo ?? string.Empty,
                    HasNuts = list.Result.HasNuts,
                    IsDel = list.Result.IsDel,
                    IsSpecialOffer = list.Result.IsSpecialOffer,
                    JianPin = list.Result.JianPin ?? string.Empty,
                    Online = list.Result.Online,
                    PackagingFee = list.Result.PackagingFee,
                    QuanPin = list.Result.QuanPin ?? string.Empty,
                    SpecialOfferNo = list.Result.SpecialOfferNo,
                    SpicyLevel = list.Result.SpicyLevel,
                    StockLevel = list.Result.StockLevel,
                    SupplierCategoryId = list.Result.SupplierCategoryId,
                    SupplierId = list.Result.SupplierId,
                    Vegetarian = list.Result.Vegetarian
                };

            return new Response<SupplierDishDetail>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
                    Result = result
                };
        }

        /// <summary>
        /// 添加餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> AddSupplierDish(int id, SaveSupplierDishRequst requst)
        {
            if (requst == null || requst.DishList == null || requst.DishList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var dishList = requst.DishList.Select(p => new SaveSupplierDishModel
                {
                    SupplierDishName = p.SupplierDishName,
                    SupplierDishNo = p.SupplierDishNo,
                    SuppllierDishDescription = p.SuppllierDishDescription,
                    CategoryId = p.CategoryId,
                    ImagePath = p.ImagePath,
                    IsCommission = p.IsCommission,
                    IsDiscount = p.IsDiscount,
                    IsVegetarian = p.IsVegetarian,
                    PackagingFee = p.PackagingFee,
                    Price = p.Price,
                    Recipe = p.Recipe,
                    Recommended = p.Recommended,
                    SpicyLevel = p.SpicyLevel,
                    StockLevel = p.StockLevel,
                    SupplierDishId = p.SupplierDishId
                }).ToList();

            var result = this.supplierServices.AddSupplierDish(this.Source, new SaveSupplierDishParameter
                {
                    SupplierId = id,
                    SupplierMenuCategoryTypeId = requst.SupplierMenuCategoryTypeId,
                    DishList = dishList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 修改餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> UpdateSupplierDish(int id, SaveSupplierDishRequst requst)
        {
            if (requst == null || requst.DishList == null || requst.DishList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var dishList = requst.DishList.Select(p => new SaveSupplierDishModel
                {
                    SupplierDishName = p.SupplierDishName,
                    SupplierDishNo = p.SupplierDishNo,
                    SuppllierDishDescription = p.SuppllierDishDescription,
                    CategoryId = p.CategoryId,
                    ImagePath = p.ImagePath,
                    IsCommission = p.IsCommission,
                    IsDiscount = p.IsDiscount,
                    IsVegetarian = p.IsVegetarian,
                    PackagingFee = p.PackagingFee,
                    Price = p.Price,
                    Recipe = p.Recipe,
                    Recommended = p.Recommended,
                    SpicyLevel = p.SpicyLevel,
                    StockLevel = p.StockLevel,
                    SupplierDishId = p.SupplierDishId
                }).ToList();

            var result = this.supplierServices.AddSupplierDish(this.Source, new SaveSupplierDishParameter
                {
                    SupplierId = id,
                    SupplierMenuCategoryTypeId = requst.SupplierMenuCategoryTypeId,
                    DishList = dishList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 删除餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> DeleteSupplierDish(int id, DeleteSupplierDishRequst requst)
        {
            if (requst == null || requst.DishIdList == null || requst.DishIdList.Count == 0)
            {
                return new Response<bool>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.System.InvalidRequest
                            }
                    };
            }

            var result = this.supplierServices.DeleteSupplierDish(this.Source, new DeleteSupplierDishParameter
                {
                    SupplierId = id,
                    DishIdList = requst.DishIdList
                });

            return new Response<bool>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result
                };
        }

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierServiceTime> SupplierServiceTime(int id, int? deliveryMethodId = null,
                                                                     DateTime? startDate = null, int? days = null,
                                                                     bool? onlyActive = true)
        {
            var result = this.supplierServices.GetSupplierServiceTime(this.Source, id, deliveryMethodId ?? -1, startDate,
                                                                      days, onlyActive ?? true);
            if (result == null)
            {
                return new ListResponse<SupplierServiceTime>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.Succeed.Empty
                            },
                        Result = new List<SupplierServiceTime>()
                    };
            }

            if (result.Result == null || result.Result.Count == 0)
            {
                return new ListResponse<SupplierServiceTime>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = result.StatusCode
                            },
                        Result = new List<SupplierServiceTime>()
                    };
            }

            return new ListResponse<SupplierServiceTime>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result.Select(p => new SupplierServiceTime
                        {
                            SupplierId = p.SupplierId,
                            ServiceDate = p.ServiceDate,
                            ServiceTime = p.ServiceTime,
                            ServiceTimeList = p.ServiceTimeList
                        }).ToList()
                };
        }

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(int id, int? deliveryMethodId = null,
                                                                       DateTime? startDate = null, int? days = null,
                                                                       bool? onlyActive = true)
        {
            var result = this.supplierServices.GetSupplierDeliveryTime(this.Source, id, deliveryMethodId ?? -1,
                                                                       startDate, days, onlyActive ?? true);
            if (result == null)
            {
                return new ListResponse<SupplierDeliveryTime>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = (int)StatusCode.Succeed.Empty
                            },
                        Result = new List<SupplierDeliveryTime>()
                    };
            }

            if (result.Result == null || result.Result.Count == 0)
            {
                return new ListResponse<SupplierDeliveryTime>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = result.StatusCode
                            },
                        Result = new List<SupplierDeliveryTime>()
                    };
            }

            return new ListResponse<SupplierDeliveryTime>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        },
                    Result = result.Result.Select(p => new SupplierDeliveryTime
                        {
                            SupplierId = p.SupplierId,
                            DeliveryDate = p.DeliveryDate,
                            DeliveryTime = p.DeliveryTime,
                            DeliveryTimeList = p.DeliveryTimeList
                        }).ToList()
                };
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="userLat"></param>
        /// <param name="userLong"></param>
        /// <param name="id"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<DistanceResult> GetDistance(int id, double userLat, double userLong)
        {
            var supplier = this.supplierServices.GetSupplier(this.Source, id, null);
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
            var distanceResult = this.supplierServices.GetDistance(this.Source, distanceParameter);
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

        /// <summary>
        /// 获取订台台位列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订日期</param>
        /// <param name="bookingTime">预订时间</param>
        /// <param name="peopleCount">预定人数</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<DingTaiDesk> DeskList(int id, DateTime? bookingDate, string bookingTime, int peopleCount)
        {
            if (bookingDate == null)
            {
                return new ListResponse<DingTaiDesk>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    (int)StatusCode.System.InvalidRequest
                            },
                        Result = new List<DingTaiDesk>()
                    };
            }

            var dingTaiGetDeskListParameter = new DingTaiGetDeskListParameter
                {
                    SupplierId = id,
                    BookingDate = bookingDate.Value,
                    BookingTime = bookingTime,
                    PeopleCount = peopleCount
                };

            var getDeskListResult = this.supplierServices.GetDeskList(this.Source, dingTaiGetDeskListParameter);

            if (getDeskListResult.Result == null || getDeskListResult.Result.Count == 0)
            {
                return new ListResponse<DingTaiDesk>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getDeskListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getDeskListResult.StatusCode
                            },
                        Result = new List<DingTaiDesk>()
                    };
            }

            var result = getDeskListResult.Result.Select(p => new DingTaiDesk
                {
                    Id = p.Id,
                    RoomType = p.RoomType ?? 0,
                    TblTypeId = p.TblTypeId,
                    TblTypeName = p.TblTypeName,
                    MaxNumber = p.MaxNumber,
                    MinNumber = p.MinNumber,
                    DepositAmount = p.DepositAmount ?? 0,
                    LowCost = p.LowCost ?? 0
                }).ToList();

            return new ListResponse<DingTaiDesk>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getDeskListResult.StatusCode
                        },
                    ResultTotalCount = getDeskListResult.ResultTotalCount,
                    Result = result
                };
        }

        /// <summary>
        /// 获取餐厅订台开放时间列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订时间</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<string> DeskOpenTimeList(int id, DateTime? bookingDate)
        {
            if (bookingDate == null)
            {
                return new ListResponse<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            (int)StatusCode.System.InvalidRequest
                    },
                    Result = new List<string>()
                };
            }

            var getDeskOpenTimeListResult = this.supplierServices.GetDeskOpenTimeList(this.Source, id, bookingDate.Value);

            if (getDeskOpenTimeListResult.Result == null || getDeskOpenTimeListResult.Result.Count == 0)
            {
                return new ListResponse<string>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode =
                                    getDeskOpenTimeListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : getDeskOpenTimeListResult.StatusCode
                            },
                        Result = new List<string>()
                    };
            }

            return new ListResponse<string>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getDeskOpenTimeListResult.StatusCode
                        },
                    ResultTotalCount = getDeskOpenTimeListResult.ResultTotalCount,
                    Result = getDeskOpenTimeListResult.Result
                };
        }

        /// <summary>
        /// 获取餐厅订台开放日期列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="days">The days</param>
        /// <returns>
        /// ListResponse{DeskOpenDate}
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 7:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<DeskOpenDate> DeskOpenDateList(int id, int? days = null)
        {
            var getDeskOpenDateListResult = this.supplierServices.GetDeskOpenDateList(this.Source, id, days);

            if (getDeskOpenDateListResult.Result == null || getDeskOpenDateListResult.Result.Count == 0)
            {
                return new ListResponse<DeskOpenDate>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            getDeskOpenDateListResult.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : getDeskOpenDateListResult.StatusCode
                    },
                    Result = new List<DeskOpenDate>()
                };
            }

            return new ListResponse<DeskOpenDate>
            {
                Message = new ApiMessage
                {
                    StatusCode = getDeskOpenDateListResult.StatusCode
                },
                ResultTotalCount = getDeskOpenDateListResult.ResultTotalCount,
                Result = getDeskOpenDateListResult.Result.Select(p => new DeskOpenDate
                        {
                            Date = p.Date.Date,
                            IsLock = p.IsLock
                        }).ToList()
            };
        }

        /// <summary>
        /// 查检订台台位是否被锁
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">The requst.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:11 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> CheckDesk(int id, CheckDeskRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }
            var result = this.supplierServices.CheckDesk(this.Source, id, new CheckDeskParameter
            {
                DeskTypeId = requst.DeskTypeId,
                BookingDate = requst.BookingDate,
                BookingTime = requst.BookingTime
            });

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }
        /// <summary>
        /// Checks the table number is effective.
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="tableNo">The tableNo</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/24/2014 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> CheckTableNumIsEffective(int supplierId, string tableNo)
        {
            if (supplierId == 0)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                    }
                };
            }

            var result = this.supplierServices.CheckTableNumIsEffective(this.Source, supplierId, tableNo);

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }
        /// <summary>
        /// 根据桌子Id查询桌子编号
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="tableNo">The tableNo</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> GetDeskNoById(int supplierId, int? tableNo)
        {
            if (supplierId == 0)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            (int)StatusCode.System.InvalidRequest
                    },
                    Result = string.Empty
                };
            }

            var getDeskNoResult = this.supplierServices.GetDeskNoById(this.Source, tableNo, supplierId);

            if (getDeskNoResult.Result == null || getDeskNoResult.Result.IsEmptyOrNull())
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            getDeskNoResult.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : getDeskNoResult.StatusCode
                    },
                    Result = string.Empty
                };
            }

            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = getDeskNoResult.StatusCode
                },
                Result = getDeskNoResult.Result
            };
        }

        /// <summary>
        /// 查询推荐菜品列表
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// 推荐菜品列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/27/2014 3:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierRecommendedDish> GetRecommendedDishList(int id, int pageIndex, int pageSize)
        {
            var list = this.supplierServices.GetRecommendedDish(this.Source, id, pageIndex, pageSize);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierRecommendedDish>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            list.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : list.StatusCode
                    },
                    Result = new List<SupplierRecommendedDish>()
                };
            }

            var result = list.Result.Select(p => new SupplierRecommendedDish
            {
                SupplierDishId = p.SupplierDishId,
                SupplierDishName = p.SupplierDishName,
                Price = p.Price,
                ImagePath = p.ImagePath,
                SupplierCatogryId = p.SupplierCatogryId,
                SupplierMenuCategoryId = p.SupplierMenuCategoryId,
                Type = p.Type,
                Recipe = p.Recipe,
                PackagingFee = p.PackagingFee
            }).ToList();

            return new ListResponse<SupplierRecommendedDish>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 为百度轻应用提供统计结果
        /// </summary>
        /// <param name="date">The dateDefault documentation</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/9/2014 6:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public BaiDuLightStatisticsResult LightStatisticsForBaiDu(string date)
        {
            var lightStatisticsForBaiDuResult = this.supplierServices.LightStatisticsForBaiDu(date);
            if (lightStatisticsForBaiDuResult == null)
            {
                return new BaiDuLightStatisticsResult();
            }
            if (lightStatisticsForBaiDuResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new BaiDuLightStatisticsResult();
            }

            var baiDuLightStatisticsOrderResultList = new List<BaiDuLightStatisticsOrderResult>();
            foreach (var lightStatistics in lightStatisticsForBaiDuResult.Result)
            {
                var baiDuLightStatisticsCountsResult = new BaiDuLightStatisticsCountsResult
                    {
                        total_count = lightStatistics.total_count,
                        online_count = lightStatistics.online_count,
                        offline_count = lightStatistics.offline_count,
                        pay_suc_count = lightStatistics.pay_suc_count,
                        pay_discount_suc_count = 0,
                        pay_coupon_suc_count = 0,
                        pay_fail_count = lightStatistics.pay_fail_count,
                        pay_discount_fail_count = 0,
                        pay_coupon_fail_count = 0,
                        online_pay_suc_count = lightStatistics.online_pay_suc_count,
                        online_pay_discount_suc_count = 0,
                        online_pay_coupon_suc_count = 0,
                        online_pay_fail_count = lightStatistics.online_pay_fail_count,
                        online_pay_discount_fail_count = 0,
                        online_pay_coupon_fail_count = 0,
                        offline_pay_suc_count = lightStatistics.online_pay_suc_count,
                        offline_pay_discount_suc_count = 0,
                        offline_pay_coupon_suc_count = 0,
                        offline_pay_fail_count = lightStatistics.online_pay_fail_count,
                        offline_pay_discount_fail_count = 0,
                        offline_pay_coupon_fail_count = 0
                    };

                var baiDuLightStatisticsIncomesResult = new BaiDuLightStatisticsIncomesResult
                    {
                        pay_suc_incomes = lightStatistics.pay_suc_incomes,
                        pay_discount_suc_incomes = string.Empty,
                        pay_coupon_suc_incomes = string.Empty,
                        pay_fail_incomes = lightStatistics.pay_fail_incomes,
                        pay_discount_fail_incomes = string.Empty,
                        pay_coupon_fail_incomes = string.Empty,
                        online_pay_suc_incomes = lightStatistics.online_pay_suc_incomes,
                        online_pay_discount_suc_incomes = string.Empty,
                        online_pay_coupon_suc_incomes = string.Empty,
                        online_pay_fail_incomes = lightStatistics.online_pay_fail_incomes,
                        online_pay_discount_fail_incomes = string.Empty,
                        online_pay_coupon_fail_incomes = string.Empty,
                        offline_pay_suc_incomes = lightStatistics.offline_pay_suc_incomes,
                        offline_pay_discount_suc_incomes = string.Empty,
                        offline_pay_coupon_suc_incomes = string.Empty,
                        offline_pay_fail_incomes = lightStatistics.offline_pay_fail_incomes,
                        offline_pay_discount_fail_incomes = string.Empty,
                        offline_pay_coupon_fail_incomes = string.Empty
                    };

                var baiDuLightStatisticsOrderResult = new BaiDuLightStatisticsOrderResult
                    {
                        bd_ref_id = string.Empty,
                        bd_from_id = string.Empty,
                        bd_channel_id = string.Empty,
                        bd_subpage = string.Empty,
                        counts = baiDuLightStatisticsCountsResult,
                        incomes = baiDuLightStatisticsIncomesResult
                    };

                baiDuLightStatisticsOrderResultList.Add(baiDuLightStatisticsOrderResult);

            }
            var baiDuLightStatisticsResult = new BaiDuLightStatisticsResult
                {
                    appid = ControllersCommon.BaiDuStatisticsAppId,
                    date = date,
                    lostfields = "bd_ref_id|bd_from_id|bd_channel_id|bd_subpage|pay_discount_suc_count|pay_coupon_suc_count|pay_discount_fail_count|pay_coupon_fail_count|" +
                                 "online_pay_discount_suc_count|online_pay_coupon_suc_count|online_pay_discount_fail_count|online_pay_coupon_fail_count|offline_pay_discount_suc_count|" +
                                 "offline_pay_coupon_suc_count|offline_pay_discount_fail_count|offline_pay_coupon_fail_count|pay_discount_suc_incomes|pay_coupon_suc_incomes|" +
                                 "pay_discount_fail_incomes|pay_coupon_fail_incomes|online_pay_discount_suc_incomes|online_pay_coupon_suc_incomes|online_pay_discount_fail_incomes|online_pay_coupon_fail_incomes|" +
                                 "offline_pay_discount_suc_incomes|offline_pay_coupon_suc_incomes|offline_pay_discount_fail_incomes|offline_pay_coupon_fail_incomes",
                    orders = baiDuLightStatisticsOrderResultList
                };

            return baiDuLightStatisticsResult;
        }

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="platformId">平台Id</param>
        /// <returns>
        /// 支付方式列表
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/16/2014 11:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ListResponse<PaymentMethodResult> GetPaymentMethodList(int supplierId, int platformId)
        {
            var list = this.supplierServices.GetPaymentMethodList(this.Source, supplierId, platformId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<PaymentMethodResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode =
                            list.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : list.StatusCode
                    },
                    Result = new List<PaymentMethodResult>()
                };
            }

            var result = list.Result.Select(p => new PaymentMethodResult { PaymentMethodId = p.PaymentMethodId }).ToList();

            return new ListResponse<PaymentMethodResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                Result = result
            };
        }
    }
}
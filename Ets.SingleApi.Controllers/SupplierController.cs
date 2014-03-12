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
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<SupplierDetail> Supplier(int id)
        {
            var getSupplierResult = this.supplierServices.GetSupplier(this.Source, id);
            if (getSupplierResult.Result == null)
            {
                return new Response<SupplierDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getSupplierResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getSupplierResult.StatusCode
                    },
                    Result = new SupplierDetail()
                };
            }

            var supplierFeatureList = getSupplierResult.Result.SupplierFeatureList;

            //餐厅推荐菜品列表
            var recommendedDishList = getSupplierResult.Result.RecommendedDishList;

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
                RecommendedDishList = recommendedDishList.Select(p=>new SupplierDish
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
                        StatusCode = getSupplierSimpleResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getSupplierSimpleResult.StatusCode
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
                BaIduLong = getSupplierSimpleResult.Result.BaIduLong
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
        public ListResponse<GroupSupplier> GroupSupplierList(int supplierGroupId, int? featureId = -1, int? cityId = null, int pageSize = 10, int? pageIndex = null)
        {
            var getGroupSupplierListResult = this.supplierServices.GetGroupSupplierList(this.Source, new GetGroupSupplierListParameter
            {
                FeatureId = featureId == -1 ? null : featureId,
                SupplierGroupId = supplierGroupId,
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
        public ListResponse<GroupSupplier> SearchGroupSupplierList(int supplierGroupId, double? userLat = null, double? userLong = null, int? featureId = -1, int? cityId = null, int pageSize = 10, int? pageIndex = null)
        {
            var getGroupSupplierListResult = this.supplierServices.GetSearchGroupSupplierList(this.Source, new GetSearchGroupSupplierListParameter
            {
                FeatureId = featureId == -1 ? null : featureId,
                SupplierGroupId = supplierGroupId,
                CityId = cityId,
                UserLat = userLat ?? -1,
                UserLong = userLong ?? -1,
                PageIndex = pageIndex,
                PageSize = pageSize
            });

            if (getGroupSupplierListResult.Result == null || getGroupSupplierListResult.Result.Count == 0)
            {
                return new ListResponse<GroupSupplier>
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
                        StatusCode = getSupplierFeatureListResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getSupplierFeatureListResult.StatusCode
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
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
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
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
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
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
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
        public ListResponse<SupplierDishDetail> SupplierDishList(int id, int supplierMenuCategoryTypeId, int? supplierCategoryId = null)
        {
            var list = this.supplierServices.GetSupplierDishList(this.Source, id, supplierMenuCategoryTypeId, supplierCategoryId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<SupplierDishDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
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
        /// <returns>
        /// 返回餐厅菜
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<SupplierDishDetail> SupplierDish(int id, int supplierDishId)
        {
            var list = this.supplierServices.GetSupplierDish(this.Source, id, supplierDishId);
            if (list.Result == null)
            {
                return new Response<SupplierDishDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
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
        public ListResponse<SupplierServiceTime> SupplierServiceTime(int id, int? deliveryMethodId = null, DateTime? startDate = null, int? days = null, bool? onlyActive = true)
        {
            var result = this.supplierServices.GetSupplierServiceTime(this.Source, id, deliveryMethodId ?? -1, startDate, days, onlyActive ?? true);
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
        public ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(int id, int? deliveryMethodId = null, DateTime? startDate = null, int? days = null, bool? onlyActive = true)
        {
            var result = this.supplierServices.GetSupplierDeliveryTime(this.Source, id, deliveryMethodId ?? -1, startDate, days, onlyActive ?? true);
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
        public Response<DistanceResult> GetDistance(int id,double userLat, double userLong)
        {
            var supplier = this.supplierServices.GetSupplier(this.Source, id);
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
    }
}
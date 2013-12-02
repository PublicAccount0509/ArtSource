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

            var result = this.supplierServices.GetPackagingFee(id, requst.DishList);
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
            var list = this.supplierServices.GetMenu(id, supplierMenuCategoryTypeId);
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
            var list = this.supplierServices.GetSupplierCuisineList(id, supplierMenuCategoryTypeId);
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
                CategoryName = p.CategoryName,
                CategoryNo = p.CategoryNo ?? 0,
                SupplierCategoryId = p.SupplierCategoryId,
                CategoryDescription = p.CategoryDescription
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
            var list = this.supplierServices.GetSupplierCuisine(id, supplierCategoryId);
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
                CategoryName = list.Result.CategoryName,
                CategoryNo = list.Result.CategoryNo ?? 0,
                SupplierCategoryId = list.Result.SupplierCategoryId,
                CategoryDescription = list.Result.CategoryDescription
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

            var result = this.supplierServices.AddSupplierCuisine(new SaveSupplierCuisineParameter
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

            var result = this.supplierServices.UpdateSupplierCuisine(new SaveSupplierCuisineParameter
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

            var result = this.supplierServices.DeleteSupplierCuisine(new DeleteSupplierCuisineParameter
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
            var list = this.supplierServices.GetSupplierDishList(id, supplierMenuCategoryTypeId, supplierCategoryId);
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
                ImagePath = p.ImagePath,
                SupplierDishId = p.SupplierDishId,
                DishName = p.DishName,
                DishDescription = p.DishDescription,
                AverageRating = p.AverageRating,
                IsCommission = p.IsCommission,
                IsDiscount = p.IsDiscount,
                Recipe = p.Recipe,
                Recommended = p.Recommended,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                DishNo = p.DishNo,
                HasNuts = p.HasNuts,
                IsDel = p.IsDel,
                IsSpecialOffer = p.IsSpecialOffer,
                JianPin = p.JianPin,
                Online = p.Online,
                PackagingFee = p.PackagingFee,
                QuanPin = p.QuanPin,
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
            var list = this.supplierServices.GetSupplierDish(id, supplierDishId);
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
                ImagePath = list.Result.ImagePath,
                SupplierDishId = list.Result.SupplierDishId,
                DishName = list.Result.DishName,
                DishDescription = list.Result.DishDescription,
                AverageRating = list.Result.AverageRating,
                IsCommission = list.Result.IsCommission,
                IsDiscount = list.Result.IsDiscount,
                Recipe = list.Result.Recipe,
                Recommended = list.Result.Recommended,
                CategoryId = list.Result.CategoryId,
                CategoryName = list.Result.CategoryName,
                DishNo = list.Result.DishNo,
                HasNuts = list.Result.HasNuts,
                IsDel = list.Result.IsDel,
                IsSpecialOffer = list.Result.IsSpecialOffer,
                JianPin = list.Result.JianPin,
                Online = list.Result.Online,
                PackagingFee = list.Result.PackagingFee,
                QuanPin = list.Result.QuanPin,
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

            var result = this.supplierServices.AddSupplierDish(new SaveSupplierDishParameter
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

            var result = this.supplierServices.AddSupplierDish(new SaveSupplierDishParameter
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

            var result = this.supplierServices.DeleteSupplierDish(new DeleteSupplierDishParameter
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
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierServiceTime> SupplierServiceTime(int id, DateTime? startDate = null, int? days = null)
        {
            return new ListResponse<SupplierServiceTime>();
        }
    }
}
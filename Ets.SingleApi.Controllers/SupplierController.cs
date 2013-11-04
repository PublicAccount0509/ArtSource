namespace Ets.SingleApi.Controllers
{
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
        public SaveSupplierCuisineResponse AddSupplierCuisine(int id, SaveSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CuisineList == null || requst.CuisineList.Count == 0)
            {
                return new SaveSupplierCuisineResponse
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

            return new SaveSupplierCuisineResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = result.StatusCode
                        }
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
        public SaveSupplierCuisineResponse UpdateSupplierCuisine(int id, SaveSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CuisineList == null || requst.CuisineList.Count == 0)
            {
                return new SaveSupplierCuisineResponse
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

            return new SaveSupplierCuisineResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                }
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
        public DeleteSupplierCuisineResponse DeleteSupplierCuisine(int id, DeleteSupplierCuisineRequst requst)
        {
            if (requst == null || requst.CategoryIdList == null || requst.CategoryIdList.Count == 0)
            {
                return new DeleteSupplierCuisineResponse
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

            return new DeleteSupplierCuisineResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                }
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
        public SaveSupplierDishResponse AddSupplierDish(int id, SaveSupplierDishRequst requst)
        {
            if (requst == null || requst.DishList == null || requst.DishList.Count == 0)
            {
                return new SaveSupplierDishResponse
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

            return new SaveSupplierDishResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                }
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
        public SaveSupplierDishResponse UpdateSupplierDish(int id, SaveSupplierDishRequst requst)
        {
            if (requst == null || requst.DishList == null || requst.DishList.Count == 0)
            {
                return new SaveSupplierDishResponse
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

            return new SaveSupplierDishResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                }
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
        public DeleteSupplierDishResponse DeleteSupplierDish(int id, DeleteSupplierDishRequst requst)
        {
            if (requst == null || requst.DishIdList == null || requst.DishIdList.Count == 0)
            {
                return new DeleteSupplierDishResponse
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

            return new DeleteSupplierDishResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                }
            };
        }
    }
}
using System;

namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HaiDiLaoSupplierController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：海底捞餐厅API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 21:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HaiDiLaoSupplierController : SingleApiController
    {
        /// <summary>
        /// 字段haiDiLaoSupplierServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHaiDiLaoSupplierServices haiDiLaoSupplierServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsController"/> class.
        /// </summary>
        /// <param name="haiDiLaoSupplierServices">The haiDiLaoSupplierServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HaiDiLaoSupplierController(IHaiDiLaoSupplierServices haiDiLaoSupplierServices)
        {
            this.haiDiLaoSupplierServices = haiDiLaoSupplierServices;
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
            var list = this.haiDiLaoSupplierServices.GetMenu(this.Source, id, supplierMenuCategoryTypeId);
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
                    Recommended = q.Recommended,
                    Type = q.Type
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
        /// 获取套餐详细信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="packageId">套餐Id</param>
        /// <returns>
        /// 返回套餐详细信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<PackageCuisine> PackageDetail(int id, int packageId)
        {
            var list = this.haiDiLaoSupplierServices.GetPackageDetail(this.Source, id, packageId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<PackageCuisine>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<PackageCuisine>()
                };
            }

            var result = list.Result.Select(p => new PackageCuisine
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                CanSelectCount = p.CanSelectCount ?? 0,
                IsChoose = p.IsChoose != 0,
                PackageDishList = p.PackageDishList.Select(q => new PackageDish
                {
                    PackageContentId = q.PackageContentId,
                    CanSelectCount = q.CanSelectCount ?? 1,
                    DefaultNum = q.DefaultNum ?? 1,
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
                    Type = q.Type
                }).ToList()
            }).ToList();

            return new ListResponse<PackageCuisine>
            {
                Message = new ApiMessage
                {
                    StatusCode = list.StatusCode
                },
                Result = result
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
        /// 创建者：单琪彬
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierServiceTime> SupplierServiceTime(int id, int? deliveryMethodId = null, DateTime? startDate = null, int? days = null, bool? onlyActive = true)
        {
            var result = this.haiDiLaoSupplierServices.GetSupplierServiceTime(this.Source, id, deliveryMethodId ?? -1, startDate, days, onlyActive ?? true);
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
        /// 创建者：单琪彬
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(int id, int? deliveryMethodId = null, DateTime? startDate = null, int? days = null, bool? onlyActive = true)
        {
            var result = this.haiDiLaoSupplierServices.GetSupplierDeliveryTime(this.Source, id, deliveryMethodId ?? -1, startDate, days, onlyActive ?? true);
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
    }
}
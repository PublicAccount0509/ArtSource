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
    /// 类名称：HuangTaiJiSupplierController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：黄太吉餐厅信息功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/27/2013 3:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiSupplierController : SingleApiController
    {
        /// <summary>
        /// 字段huangTaiJiSupplierServices
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：2013/12/27 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHuangTaiJiSupplierServices huangTaiJiSupplierServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="HuangTaiJiSupplierController"/> class.
        /// </summary>
        /// <param name="huangTaiJiSupplierServices">The huangTaiJiSupplierServices</param>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiSupplierController(IHuangTaiJiSupplierServices huangTaiJiSupplierServices)
        {
            this.huangTaiJiSupplierServices = huangTaiJiSupplierServices;
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
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<HuangTaiJiSupplierCuisine> SupplierDishList(int id, int supplierMenuCategoryTypeId, int? supplierCategoryId = null)
        {
            var list = this.huangTaiJiSupplierServices.GetSupplierDishList(this.Source, id, supplierMenuCategoryTypeId, supplierCategoryId);
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<HuangTaiJiSupplierCuisine>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<HuangTaiJiSupplierCuisine>()
                };
            }

            var result =( from item in list.Result
                    group item by item.CategoryId into g
                    select new HuangTaiJiSupplierCuisine
                        {
                            CategoryId = g.Key,
                            CategoryName = g.First().CategoryName,
                            SupplierDishList = (from q in g select new HuangTaiJiSupplierDishDetail {
                                CategoryId = g.Key,
                                CategoryName = g.First().CategoryName,
                                Price = q.Price,
                                ImagePath = q.ImagePath ?? string.Empty,
                                SupplierDishId = q.SupplierDishId,
                                DishName = q.DishName ?? string.Empty,
                                DishDescription = q.DishDescription ?? string.Empty,
                                AverageRating = q.AverageRating ?? 0,
                                IsCommission = q.IsCommission,
                                IsDiscount = q.IsDiscount,
                                Recipe = q.Recipe ?? string.Empty,
                                Recommended = q.Recommended,
                                PackagingFee = q.PackagingFee,
                                SupplierDishOptionGroups = q.SupplierDishOptionGroups,
                                SubSupplierDishDetail = q.SubSupplierDishDetail
                            }).ToList()
                        }).ToList();

            return new ListResponse<HuangTaiJiSupplierCuisine>
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
        //[HttpGet]
        //public Response<HuangTaiJiSupplierDishDetail> SupplierDish(int id, int supplierDishId)
        //{
        //    var list = this.huangTaiJiSupplierServices.GetSupplierDish(this.Source, id, supplierDishId);
        //    if (list.Result == null)
        //    {
        //        return new Response<HuangTaiJiSupplierDishDetail>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
        //            },
        //            Result = new HuangTaiJiSupplierDishDetail()
        //        };
        //    }

        //    var result = new HuangTaiJiSupplierDishDetail
        //    {
        //        Price = list.Result.Price,
        //        ImagePath = list.Result.ImagePath ?? string.Empty,
        //        SupplierDishId = list.Result.SupplierDishId,
        //        DishName = list.Result.DishName ?? string.Empty,
        //        DishDescription = list.Result.DishDescription ?? string.Empty,
        //        AverageRating = list.Result.AverageRating,
        //        IsCommission = list.Result.IsCommission,
        //        IsDiscount = list.Result.IsDiscount,
        //        Recipe = list.Result.Recipe ?? string.Empty,
        //        Recommended = list.Result.Recommended,
        //        CategoryId = list.Result.CategoryId,
        //        CategoryName = list.Result.CategoryName ?? string.Empty,
        //        DishNo = list.Result.DishNo ?? string.Empty,
        //        HasNuts = list.Result.HasNuts,
        //        IsDel = list.Result.IsDel,
        //        IsSpecialOffer = list.Result.IsSpecialOffer,
        //        JianPin = list.Result.JianPin ?? string.Empty,
        //        Online = list.Result.Online,
        //        PackagingFee = list.Result.PackagingFee,
        //        QuanPin = list.Result.QuanPin ?? string.Empty,
        //        SpecialOfferNo = list.Result.SpecialOfferNo,
        //        SpicyLevel = list.Result.SpicyLevel,
        //        StockLevel = list.Result.StockLevel,
        //        SupplierCategoryId = list.Result.SupplierCategoryId,
        //        SupplierId = list.Result.SupplierId,
        //        Vegetarian = list.Result.Vegetarian,
        //        SupplierDishOptionGroups = list.Result.SupplierDishOptionGroups,
        //        SubSupplierDishDetail = list.Result.SubSupplierDishDetail
        //    };

        //    return new Response<HuangTaiJiSupplierDishDetail>
        //    {
        //        Message = new ApiMessage
        //        {
        //            StatusCode = list.StatusCode
        //        },
        //        Result = result
        //    };
        //}

        ///// <summary>
        ///// 获取餐厅菜单
        ///// </summary>
        ///// <param name="id">餐厅Id</param>
        ///// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        ///// <returns>
        ///// 返回餐厅菜单
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：2013/10/15 13:24
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //[HttpGet]
        //public ListResponse<HuangTaiJiSupplierCuisine> Menu(int id, int supplierMenuCategoryTypeId)
        //{
        //    var list = this.huangTaiJiSupplierServices.GetMenu(this.Source, id, supplierMenuCategoryTypeId);
        //    if (list.Result == null || list.Result.Count == 0)
        //    {
        //        return new ListResponse<HuangTaiJiSupplierCuisine>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
        //            },
        //            Result = new List<HuangTaiJiSupplierCuisine>()
        //        };
        //    }

        //    var result = list.Result.Select(p => new HuangTaiJiSupplierCuisine
        //    {
        //        CategoryId = p.CategoryId,
        //        CategoryName = p.CategoryName,
        //        SupplierDishList = p.SupplierDishList.Select(q => new HuangTaiJiSupplierDishDetail
        //        {
        //            Price = q.Price,
        //            ImagePath = q.ImagePath ?? string.Empty,
        //            SupplierDishId = q.SupplierDishId,
        //            SupplierDishName = q.SupplierDishName ?? string.Empty,
        //            SuppllierDishDescription = q.SuppllierDishDescription ?? string.Empty,
        //            AverageRating = q.AverageRating ?? 0,
        //            IsCommission = q.IsCommission,
        //            IsDiscount = q.IsDiscount,
        //            Recipe = q.Recipe ?? string.Empty,
        //            Recommended = q.Recommended
        //        }).ToList()
        //    }).ToList();

        //    return new ListResponse<HuangTaiJiSupplierCuisine>
        //    {
        //        Message = new ApiMessage
        //        {
        //            StatusCode = list.StatusCode
        //        },
        //        Result = result
        //    };
        //}
    }
}

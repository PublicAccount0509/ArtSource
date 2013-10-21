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
    public class WapSupplierController : ApiController
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
                    SupplierName = getSupplierResult.Result.SupplierName,
                    SupplierDescription = getSupplierResult.Result.SupplierDescription,
                    ServiceTime = getSupplierResult.Result.ServiceTime,
                    Address = getSupplierResult.Result.Address,
                    Averageprice = getSupplierResult.Result.Averageprice,
                    ParkingInfo = getSupplierResult.Result.ParkingInfo,
                    Telephone = getSupplierResult.Result.Telephone
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
        /// 获取餐厅列表
        /// </summary>
        /// <param name="supplierName">餐厅名称</param>
        /// <param name="dishName">菜名</param>
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
        public SearchSupplierListResponse SearchSupplierList(string supplierName, string dishName, int? cuisineId, string businessAreaId, string regionId, double userLat, double userLong, double? distance, int pageSize, int? pageIndex, int orderByType)
        {
            var list = this.supplierServices.GetSupplierList(new GetSupplierListParameter
                {
                    SupplierName = supplierName ?? string.Empty,
                    DishName = dishName ?? string.Empty,
                    CuisineId = cuisineId ?? -1,
                    BusinessAreaId = businessAreaId ?? string.Empty,
                    RegionId = regionId ?? string.Empty,
                    UserLat = userLat,
                    UserLong = userLong,
                    Distance = distance,
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
                    SupplierName = p.SupplierName,
                    Address = p.Address,
                    Telephone = p.Telephone,
                    Averageprice = p.Averageprice,
                    CuisineName = p.CuisineName,
                    Distance = p.Distance,
                    LogoUrl = p.LogoUrl
                }).ToList();

            return new SearchSupplierListResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = list.StatusCode
                        },
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
                    ImagePath = q.ImagePath,
                    SupplierDishId = q.SupplierDishId,
                    SupplierDishName = q.SupplierDishName,
                    SuppllierDishDescription = q.SuppllierDishDescription,
                    AverageRating = q.AverageRating,
                    IsCommission = q.IsCommission,
                    IsDiscount = q.IsDiscount,
                    Recipe = q.Recipe,
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
    }
}
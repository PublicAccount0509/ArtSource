namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
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
    }
}
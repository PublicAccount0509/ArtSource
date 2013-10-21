namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：CuisineController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：提供一些菜品信息的API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 15:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CuisineController : ApiController
    {
        /// <summary>
        /// 字段cuisineServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ICuisineServices cuisineServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuisineController"/> class.
        /// </summary>
        /// <param name="cuisineServices">The cuisineServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CuisineController(ICuisineServices cuisineServices)
        {
            this.cuisineServices = cuisineServices;
        }

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <returns>
        /// 返回菜品列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public CuisineListResponse CuisineList()
        {
            var list = this.cuisineServices.GetCuisineList();
            if (list.Result == null || list.Result.Count == 0)
            {
                return new CuisineListResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                    },
                    Result = new List<Cuisine>()
                };
            }

            var result = list.Result.Select(p => new Cuisine
            {
                CuisineId = p.CuisineId,
                CuisineNo = p.CuisineNo,
                CuisineName = p.CuisineName,
                SupplierCount = p.SupplierCount
            }).ToList();

            return new CuisineListResponse
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
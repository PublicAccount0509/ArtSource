namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartController : SingleApiController
    {
        /// <summary>
        /// 字段shoppingCartServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartServices shoppingCartServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartController"/> class.
        /// </summary>
        /// <param name="shoppingCartServices">The shoppingCartServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartController(IShoppingCartServices shoppingCartServices)
        {
            this.shoppingCartServices = shoppingCartServices;
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="type">购物车类型</param>
        /// <param name="businessId">商家Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ShoppingCartResponse Create(int type, int businessId, int? userId)
        {
            var createResult = this.shoppingCartServices.Create(type, businessId, userId);
            if (createResult.Result == null)
            {
                return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = createResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : createResult.StatusCode
                    },
                    Result = new ShoppingCart()
                };
            }

            return new ShoppingCartResponse
                {
                    Message = new ApiMessage
                        {
                            StatusCode = createResult.StatusCode
                        },
                    Result = createResult.Result
                };
        }
    }
}
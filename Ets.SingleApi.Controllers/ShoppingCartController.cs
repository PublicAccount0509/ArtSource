﻿using Ets.SingleApi.Model;

namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
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
        /// Initializes a new instance of the <see cref="ZhongCanShoppingCartController"/> class.
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
        /// 更改购物车状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> SaveShoppingCartComplete(string id, bool complete, int orderId = 0, int orderType = 0)
        {
            var shoppingCartId = id;
            if (shoppingCartId.IsEmptyOrNull())
            {
                var getShoppingCartIdResult = this.shoppingCartServices.GetShoppingCartId(this.GetSource(orderType), orderId);
                shoppingCartId = getShoppingCartIdResult.Result;
            }

            var getShoppingCartResult = this.shoppingCartServices.SaveShoppingCartComplete(this.GetSource(orderType), shoppingCartId, complete);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = getShoppingCartResult.StatusCode
                },
                Result = getShoppingCartResult.Result
            };
        }

        /// <summary>
        /// 取得购物车状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> GetShoppingCartComplete(string id, int orderId = 0, int orderType = 0)
        {
            var shoppingCartId = id;
            if (shoppingCartId.IsEmptyOrNull())
            {
                var getShoppingCartIdResult = this.shoppingCartServices.GetShoppingCartId(this.GetSource(orderType), orderId);
                shoppingCartId = getShoppingCartIdResult.Result;
            }

            var getShoppingCartBaseResult = this.shoppingCartServices.GetShoppingCartBase(this.GetSource(orderType), shoppingCartId);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = getShoppingCartBaseResult.StatusCode
                },
                Result = getShoppingCartBaseResult.Result.IsComplete
            };
        }

        /// <summary>
        /// 取得购物车Id
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车Id
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> GetShoppingCartId(int orderId, int orderType = 0)
        {
            var getShoppingCartIdResult = this.shoppingCartServices.GetShoppingCartId(this.GetSource(orderType), orderId);
            return new Response<string>
                {
                    Message = new ApiMessage
                        {
                            StatusCode = getShoppingCartIdResult.StatusCode
                        },
                    Result = getShoppingCartIdResult.Result
                };
        }
        /// <summary>
        /// 取得来源信息
        /// </summary>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回来源信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/16/2014 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetSource(int orderType)
        {
            var preFix = ((OrderType)orderType).ToString();
            return string.Format("{0}{1}", preFix, this.Source);
        }
    }
}
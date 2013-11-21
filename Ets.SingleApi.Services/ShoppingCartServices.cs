namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartServices : IShoppingCartServices
    {

        /// <summary>
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartProvider shoppingCartProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartServices" /> class.
        /// </summary>
        /// <param name="shoppingCartProvider">The shoppingCartProvider</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartServices(
            IShoppingCartProvider shoppingCartProvider)
        {
            this.shoppingCartProvider = shoppingCartProvider;
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
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
        public ServicesResult<ShoppingCartModel> Create(int businessId, int? userId)
        {
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(Guid.NewGuid().ToString());
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = new ShoppingCartModel()
                    };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(businessId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCartLinkId = Guid.NewGuid().ToString();
            this.shoppingCartProvider.SaveShoppingCartLink(
                new ShoppingCartLink
                    {
                        ShoppingCartLinkId = shoppingCartLinkId,
                        ShoppingCartId = getShoppingCartResult.Result.ShoppingCartId,
                        SupplierId = getShoppingCartSupplierResult.Result.SupplierId,
                        UserId = userId ?? 0
                    });

            if (userId == null)
            {
                return new ServicesResult<ShoppingCartModel>
                    {
                        Result = new ShoppingCartModel
                            {
                                Id = shoppingCartLinkId,
                                ShoppingCart = getShoppingCartResult.Result,
                                Supplier = getShoppingCartSupplierResult.Result
                            }
                    };
            }

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(userId.Value);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCartOrder = new ShoppingCartOrder { Id = Guid.NewGuid().ToString() };
            var saveShoppingCartOrderResult = this.shoppingCartProvider.SaveShoppingCartOrder(shoppingCartOrder);
            if (saveShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = saveShoppingCartOrderResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = shoppingCartLinkId,
                    ShoppingCart = getShoppingCartResult.Result,
                    Supplier = getShoppingCartSupplierResult.Result,
                    Customer = getShoppingCartCustomerResult.Result,
                    Order = shoppingCartOrder
                }
            };
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="shoppingCartItemList">The shoppingCartItemList</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartModel> LinkShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(getShoppingCartLinkResult.Result.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartBusinessResult = this.shoppingCartProvider.GetShoppingCartSupplier(getShoppingCartLinkResult.Result.SupplierId);
            if (getShoppingCartBusinessResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartBusinessResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(getShoppingCartLinkResult.Result.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(getShoppingCartLinkResult.Result.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var business = getShoppingCartBusinessResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = getShoppingCartResult.Result.ShoppingList ?? new List<ShoppingCartItem>();

            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);

            getShoppingCartOrderResult.Result.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            //var fixedDeliveryCharge = (business.FreeDeliveryLine ?? 0) <= dishTotal
            //                              ? 0
            //                              : supplierEntity.FixedDeliveryCharge ?? 0;

            //var total = parameter.DeliveryMethodId == 2
            //        ? dishTotal + packagingFee + fixedDeliveryCharge
            //        : dishTotal + packagingFee;
            //var customerTotal = parameter.DeliveryMethodId == 2
            //        ? dishTotal + packagingFee + fixedDeliveryCharge
            //        : dishTotal + packagingFee;

            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    ShoppingCart = getShoppingCartResult.Result,
                    Supplier = getShoppingCartBusinessResult.Result,
                    Customer = getShoppingCartCustomerResult.Result
                }
            };
        }
    }
}
using Ets.SingleApi.Services.ICacheServices;
using Ets.SingleApi.Services.IDetailServices;

namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EtsWapShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapShoppingCartServices : IEtsWapShoppingCartServices
    {
        /// <summary>
        /// 字段supplierDetailServices
        /// </summary>
        /// 创建者：单琪彬
        /// 创建日期：1/9/2014 6:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISupplierDetailServices supplierDetailServices;

        /// <summary>
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapShoppingCartProvider etsWapShoppingCartProvider;

        /// <summary>
        /// 字段supplierCouponProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/7/2013 4:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISupplierCouponProvider> supplierCouponProviderList;

        /// <summary>
        /// 字段shoppingCartBaseCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZhongCanShoppingCartServices" /> class.
        /// </summary>
        /// <param name="supplierDetailServices">The supplierDetailServices</param>
        /// <param name="etsWapShoppingCartProvider">The shoppingCartProvider</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapShoppingCartServices(
            ISupplierDetailServices supplierDetailServices,
            IEtsWapShoppingCartProvider etsWapShoppingCartProvider,
            List<ISupplierCouponProvider> supplierCouponProviderList,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices)
        {
            this.supplierDetailServices = supplierDetailServices;
            this.etsWapShoppingCartProvider = etsWapShoppingCartProvider;
            this.supplierCouponProviderList = supplierCouponProviderList;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
        }

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartModel> GetShoppingCart(string source, string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartCustomerResult = this.etsWapShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = shoppingCartId,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order,
                    Delivery = delivery
                }
            };
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> CreateShoppingCart(string source, int supplierId, string userId)
        {
            var bindShoppingCartResult = this.shoppingCartBaseCacheServices.BindShoppingCartId(source, supplierId.ToString(), userId);
            if (bindShoppingCartResult.StatusCode == (int)StatusCode.Succeed.Ok && !bindShoppingCartResult.Result.IsNew)
            {
                return new ServicesResult<string>
                {
                    Result = bindShoppingCartResult.Result.ShoppingCartId
                };
            }

            var shoppingCartLinkId = bindShoppingCartResult.Result.ShoppingCartId;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, Guid.NewGuid().ToString());
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, supplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartOrder = new ShoppingCartOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    DeliveryType = ServicesCommon.DefaultDeliveryType,
                    DeliveryMethodId = ServicesCommon.DefaultDeliveryMethodId,
                    PaymentMethodId = ServicesCommon.DefaultPaymentMethodId
                };
            var saveShoppingCartOrderResult = this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
            if (saveShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = saveShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartDelivery = new ShoppingCartDelivery
            {
                Id = Guid.NewGuid().ToString()
            };

            var shoppingCartDeliveryResult = this.etsWapShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);
            if (shoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = shoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = new ShoppingCartLink
                {
                    ShoppingCartLinkId = shoppingCartLinkId,
                    ShoppingCartId = getShoppingCartResult.Result.ShoppingCartId,
                    SupplierId = getShoppingCartSupplierResult.Result.SupplierId,
                    OrderId = shoppingCartOrder.Id,
                    DeliveryId = shoppingCartDelivery.Id,
                    AnonymityId = userId
                };

            int tempUserId;
            if (!int.TryParse(userId, out tempUserId))
            {
                this.etsWapShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
                return new ServicesResult<string>
                {
                    Result = shoppingCartLinkId
                };
            }

            shoppingCartLink.UserId = tempUserId;
            this.etsWapShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
            var getShoppingCartCustomerResult = this.etsWapShoppingCartProvider.GetShoppingCartCustomer(source, tempUserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            return new ServicesResult<string>
            {
                Result = shoppingCartLinkId
            };
        }

        /// <summary>
        /// 更改商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = shoppingCartItemList;
            shoppingCart.ShoppingList = shoppingList;
            this.etsWapShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, saveDeliveryMethodId);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            if (shoppingCartItemList.Count(p => p.Quantity > 0) == 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            foreach (var shoppingCartItem in shoppingCartItemList)
            {
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId && (p.Instruction ?? string.Empty).Trim() == (shoppingCartItem.Instruction ?? string.Empty).Trim());
                if (item == null)
                {
                    shoppingList.Add(shoppingCartItem);
                    continue;
                }

                item.Quantity += shoppingCartItem.Quantity;
                if (shoppingCartItem.CategoryIdList == null)
                {
                    continue;
                }

                foreach (var categoryId in shoppingCartItem.CategoryIdList.Where(categoryId => !item.CategoryIdList.Contains(categoryId)))
                {
                    item.CategoryIdList.Add(categoryId);
                }
            }

            foreach (var shoppingCartItem in shoppingList)
            {
                if (shoppingCartItem.CategoryIdList != null)
                {
                    continue;
                }

                shoppingCartItem.CategoryIdList = new List<int>();
            }

            shoppingCart.ShoppingList = shoppingList;
            this.etsWapShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, saveDeliveryMethodId);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            foreach (var shoppingCartItem in shoppingCartItemList)
            {
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId && (p.Instruction ?? string.Empty).Trim() == (shoppingCartItem.Instruction ?? string.Empty).Trim());
                if (item == null)
                {
                    continue;
                }

                item.Quantity -= shoppingCartItem.Quantity;
                if (item.Quantity <= 0)
                {
                    shoppingList.Remove(item);
                }
            }

            foreach (var shoppingCartItem in shoppingList)
            {
                if (shoppingCartItem.CategoryIdList != null)
                {
                    continue;
                }

                shoppingCartItem.CategoryIdList = new List<int>();
            }

            shoppingCart.ShoppingList = shoppingList;
            this.etsWapShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, saveDeliveryMethodId);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartCustomer(string source, string id, int userId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartCustomerResult = this.etsWapShoppingCartProvider.GetShoppingCartCustomer(source, userId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode
                };
            }

            var customer = getShoppingCartCustomerResult.Result;
            shoppingCartLink.UserId = customer.UserId;
            this.etsWapShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCart">The shoppingCart</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCart(string source, string id, ShoppingCartModel shoppingCart)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            shoppingCart.Delivery.Id = getShoppingCartDeliveryResult.Result.Id;
            shoppingCart.Order.Id = getShoppingCartOrderResult.Result.Id;
            shoppingCart.ShoppingCart.ShoppingCartId = getShoppingCartResult.Result.ShoppingCartId;
            this.etsWapShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCart.Delivery);
            this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCart.Order);
            this.etsWapShoppingCartProvider.SaveShoppingCart(source, shoppingCart.ShoppingCart);

            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartOrder">The shoppingCartOrder</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <param name="isValidateDeliveryTime">是否检测送餐时间</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(string source, string id, ShoppingCartOrder shoppingCartOrder, bool isCalculateCoupon, bool isValidateDeliveryTime)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var deliveryMethodId = shoppingCartOrder.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = ServicesCommon.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var totalfee = shoppingPrice + packagingFee;
            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= totalfee
                                          ? 0
                                         : supplier.FixedDeliveryCharge;
            var fixedDeliveryFee = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId ? fixedDeliveryCharge : 0;
            var total = totalfee + fixedDeliveryFee;
            var coupon = isCalculateCoupon ? this.CalculateCoupon(shoppingPrice, supplier.SupplierId, deliveryMethodId, shoppingCartLink.UserId) : order.CouponFee;
            var customerTotal = total - coupon;
            shoppingCartOrder.DeliveryDateTime = order.DeliveryDateTime;
            if (isValidateDeliveryTime)
            {
                int supplierDeliveryTime;
                if (!int.TryParse(supplier.DeliveryTime, out supplierDeliveryTime))
                {
                    supplierDeliveryTime = ServicesCommon.DeliveryMethodReadyTime;
                }

                int pickUpTime;
                if (!int.TryParse(supplier.PickUpTime, out pickUpTime))
                {
                    pickUpTime = ServicesCommon.PickUpMethodReadyTime;
                }

                var beginReadyTime = deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId ? pickUpTime : supplierDeliveryTime;
                var now = DateTime.Now;
                var deliveryDate = (shoppingCartOrder.DeliveryDate ?? now).ToString("yyyy-MM-dd");
                DateTime deliveryTimeTemp;
                if (!DateTime.TryParse(string.Format("{0} {1}", deliveryDate, shoppingCartOrder.DeliveryTime), out deliveryTimeTemp))
                {
                    deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now);
                }

                if (shoppingCartOrder.DeliveryType == ServicesCommon.QuickDeliveryType)
                {
                    deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now).AddMinutes(beginReadyTime);
                }

                var validateDeliveryTimeResult = this.ValidateDeliveryTime(source, supplier.SupplierId, deliveryMethodId, deliveryTimeTemp, beginReadyTime);
                if (validateDeliveryTimeResult.Result == null)
                {
                    return new ServicesResult<bool>
                    {
                        StatusCode = validateDeliveryTimeResult.StatusCode
                    };
                }
                var deliveryTime = validateDeliveryTimeResult.Result;
                shoppingCartOrder.DeliveryDateTime = deliveryTime;
            }

            shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.IsComplete = order.IsComplete;
            shoppingCartOrder.CanDelivery = order.CanDelivery;
            shoppingCartOrder.DeliveryMethodId = deliveryMethodId;
            shoppingCartOrder.TotalPrice = shoppingPrice;
            shoppingCartOrder.FixedDeliveryFee = fixedDeliveryFee;
            shoppingCartOrder.PackagingFee = packagingFee;
            shoppingCartOrder.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            shoppingCartOrder.TotalFee = total;
            shoppingCartOrder.CustomerTotalFee = customerTotal;
            shoppingCartOrder.CouponFee = coupon;
            this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// Saves the shopping cart delivery.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">The id</param>
        /// <param name="shoppingCartDelivery">The shoppingCartDelivery</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/27/2013 5:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartDelivery(string source, string id, ShoppingCartDelivery shoppingCartDelivery)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            shoppingCartDelivery.Id = getShoppingCartDeliveryResult.Result.Id;
            this.etsWapShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);

            return new ServicesResult<bool>
            {
                Result = true
            };

        }

        /// <summary>
        /// 更改购物车送餐方式
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrderDeliveryMethod(string source, string id, int deliveryMethodId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = ServicesCommon.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            order.CouponFee = 0;
            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;

            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? shoppingPrice + packagingFee + fixedDeliveryCharge
                        : shoppingPrice + packagingFee;
            var coupon = order.CouponFee;
            var customerTotal = total - coupon;

            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId ? fixedDeliveryCharge : 0;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;

            this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, order);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// Saves the shopping cart order.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingList">The shoppingList</param>
        /// <param name="supplier">The supplier</param>
        /// <param name="order">The order</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// 创建者：周超
        /// 创建日期：11/29/2013 11:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveShoppingCartOrder(string source, List<ShoppingCartItem> shoppingList, ShoppingCartSupplier supplier, ShoppingCartOrder order, bool saveDeliveryMethodId)
        {
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = ServicesCommon.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var totalfee = shoppingPrice + packagingFee;
            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= totalfee
                                          ? 0
                                         : supplier.FixedDeliveryCharge;
            var canDelivery = totalfee >= supplier.DelMinOrderAmount;
            var deliveryMethodId = !canDelivery ? ServicesCommon.PickUpDeliveryMethodId : order.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var fixedDeliveryFee = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId ? fixedDeliveryCharge : 0;
            var total = totalfee + fixedDeliveryFee;
            var coupon = order.CouponFee;
            var customerTotal = total - coupon;

            if (saveDeliveryMethodId)
            {
                order.DeliveryMethodId = deliveryMethodId;
            }
            else
            {
                order.DeliveryMethodId = canDelivery ? ServicesCommon.DefaultDeliveryMethodId : ServicesCommon.PickUpDeliveryMethodId;
            }

            order.CanDelivery = canDelivery;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = fixedDeliveryFee;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;
            this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, order);
        }

        /// <summary>
        /// 取得折扣信息
        /// </summary>
        /// <param name="total">总消费</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryMethodId">取餐方式</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回折扣
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private decimal CalculateCoupon(decimal total, int supplierId, int deliveryMethodId, int? userId)
        {
            if (userId == null)
            {
                return 0;
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == (DeliveryMethodType)deliveryMethodId);
            if (supplierCouponProvider == null)
            {
                return 0;
            }

            var supplierCouponList = supplierCouponProvider.CalculateCoupon(total, supplierId, DateTime.Now, userId.Value);
            if (supplierCouponList == null || supplierCouponList.Count == 0)
            {
                return 0;
            }

            return ServicesCommon.CalculateCoupon(total, ServicesCommon.CalculateCouponWay, supplierCouponList);
        }
        /// <summary>
        /// 验证送餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryMethodId">The deliveryMethodId</param>
        /// <param name="deliveryTime">送餐时间</param>
        /// <param name="beginReadyTime">备餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private ServicesResult<DateTime?> ValidateDeliveryTime(string source, int supplierId, int deliveryMethodId, DateTime deliveryTime, int beginReadyTime)
        {
            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                //return this.ValidateSupplierDeliveryTime(source, supplierId, deliveryTime, beginReadyTime);
                return this.ValidateSupplierServiceTime(source, supplierId, deliveryTime, beginReadyTime);
            }

            return this.ValidateSupplierDeliveryTime(source, supplierId, deliveryTime, beginReadyTime);
        }

        /// <summary>
        /// 验证送餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="pickUpTime">取餐时间</param>
        /// <param name="beginReadyTime">备餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<DateTime?> ValidateSupplierDeliveryTime(string source, int supplierId, DateTime pickUpTime, int beginReadyTime)
        {
            if (!ServicesCommon.ValidateDeliveryTimeEnabled)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = pickUpTime
                };
            }

            var getSupplierDeliveryTimeResult = this.supplierDetailServices.GetSupplierDeliveryTime(supplierId, pickUpTime, 1, beginReadyTime, true);
            if (getSupplierDeliveryTimeResult == null)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null
                };
            }

            if (getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Ok && getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Empty)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null,
                    StatusCode = getSupplierDeliveryTimeResult.StatusCode
                };
            }

            var supplierDeliveryTime = (getSupplierDeliveryTimeResult.Result ?? new List<SupplierDeliveryTimeModel>()).FirstOrDefault();
            if (supplierDeliveryTime == null)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null,
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode
                };
            }

            var tempDeliveryTime = DateTime.Parse(pickUpTime.ToString("yyyy-MM-dd HH:mm"));
            foreach (var item in supplierDeliveryTime.DeliveryTime.Split(' '))
            {
                var tempList = item.Split('-').ToList();
                if (tempList.Count != 2)
                {
                    continue;
                }

                var startDate = DateTime.Parse(string.Format("{0} {1}", supplierDeliveryTime.DeliveryDate, tempList.First()));
                var endDate = DateTime.Parse(string.Format("{0} {1}", supplierDeliveryTime.DeliveryDate, tempList.Last()));
                if (startDate > tempDeliveryTime)
                {
                    string.Format("送餐时间：{0}，餐厅可送餐时间段：{1}，是否为有效时间：{2}", startDate, supplierDeliveryTime.DeliveryTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<DateTime?>
                        {
                            Result = startDate
                        };
                }

                if (startDate <= tempDeliveryTime && endDate >= tempDeliveryTime)
                {
                    string.Format("送餐时间：{0}，餐厅可送餐时间段：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.DeliveryTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<DateTime?>
                    {
                        Result = tempDeliveryTime
                    };
                }
            }

            string.Format("送餐时间：{0}，餐厅可送餐时间段：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.DeliveryTime, "无效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
            return new ServicesResult<DateTime?>
            {
                Result = null,
                StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode
            };
        }

        /// <summary>
        /// 验证取餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="pickUpTime">取餐时间</param>
        /// <param name="beginReadyTime">备餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：1/22/2014 11:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<DateTime?> ValidateSupplierServiceTime(string source, int supplierId, DateTime pickUpTime, int beginReadyTime)
        {
            if (!ServicesCommon.ValidateDeliveryTimeEnabled)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = pickUpTime
                };
            }

            var getSupplierServiceTimeResult = this.supplierDetailServices.GetSupplierServiceTime(supplierId, pickUpTime, 1, beginReadyTime, true);
            if (getSupplierServiceTimeResult == null)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null
                };
            }

            if (getSupplierServiceTimeResult.StatusCode != (int)StatusCode.Succeed.Ok && getSupplierServiceTimeResult.StatusCode != (int)StatusCode.Succeed.Empty)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null,
                    StatusCode = getSupplierServiceTimeResult.StatusCode
                };
            }

            var supplierServiceTime = (getSupplierServiceTimeResult.Result ?? new List<SupplierServiceTimeModel>()).FirstOrDefault();
            if (supplierServiceTime == null)
            {
                return new ServicesResult<DateTime?>
                {
                    Result = null,
                    StatusCode = (int)StatusCode.Validate.InvalidPickUpTimeCode
                };
            }

            var tempServiceTime = DateTime.Parse(pickUpTime.ToString("yyyy-MM-dd HH:mm"));
            foreach (var item in supplierServiceTime.ServiceTime.Split(' '))
            {
                var tempList = item.Split('-').ToList();
                if (tempList.Count != 2)
                {
                    continue;
                }

                var startDate = DateTime.Parse(string.Format("{0} {1}", supplierServiceTime.ServiceDate, tempList.First()));
                var endDate = DateTime.Parse(string.Format("{0} {1}", supplierServiceTime.ServiceDate, tempList.Last()));
                if (startDate > tempServiceTime)
                {
                    string.Format("取餐时间：{0}，餐厅可取餐时间段：{1}，是否为有效时间：{2}", startDate, supplierServiceTime.ServiceTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<DateTime?>
                    {
                        Result = startDate
                    };
                }

                if (startDate <= tempServiceTime && endDate >= tempServiceTime)
                {
                    string.Format("取餐时间：{0}，餐厅可取餐时间段：{1}，是否为有效时间：{2}", tempServiceTime, supplierServiceTime.ServiceTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<DateTime?>
                    {
                        Result = tempServiceTime
                    };
                }
            }

            string.Format("取餐时间：{0}，餐厅可取餐时间段：{1}，是否为有效时间：{2}", tempServiceTime, supplierServiceTime.ServiceTime, "无效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
            return new ServicesResult<DateTime?>
            {
                Result = null,
                StatusCode = (int)StatusCode.Validate.InvalidPickUpTimeCode
            };
        }
    }
}
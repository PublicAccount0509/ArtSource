using Ets.SingleApi.Services.ICacheServices;

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
    /// 类名称：EtsWapDingTaiShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：易淘食堂食购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCartServices : IEtsWapDingTaiShoppingCartServices
    {
        /// <summary>
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapDingTaiShoppingCartProvider etsWapShoppingCartProvider;

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
        /// <param name="etsWapShoppingCartProvider">The shoppingCartProvider</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapDingTaiShoppingCartServices(
            IEtsWapDingTaiShoppingCartProvider etsWapShoppingCartProvider,
            List<ISupplierCouponProvider> supplierCouponProviderList,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices)
        {
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
        public ServicesResult<EtsWapDingTaiShoppingCartModel> GetShoppingCart(string source, string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartLinkResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source,
                                                                                        shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source,
                                                                                                        shoppingCartLink
                                                                                                            .SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartSupplierResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var getShoppingCartCustomerResult = this.etsWapShoppingCartProvider.GetShoppingCartCustomer(source,
                                                                                                        shoppingCartLink
                                                                                                            .UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartCustomerResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source,
                                                                                                  shoppingCartLink
                                                                                                      .OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartOrderResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source,
                                                                                                        shoppingCartLink
                                                                                                            .DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartDeliveryResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            /*订单台位信息*/
            var getShoppingCartDeskResult = this.etsWapShoppingCartProvider.GetShoppingCartDesk(source,
                                                                                                shoppingCartLink.DeskId);
            if (getShoppingCartDeskResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                    {
                        StatusCode = getShoppingCartDeliveryResult.StatusCode,
                        Result = new EtsWapDingTaiShoppingCartModel()
                    };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            var desk = getShoppingCartDeskResult.Result;
            return new ServicesResult<EtsWapDingTaiShoppingCartModel>
                {
                    Result = new EtsWapDingTaiShoppingCartModel
                        {
                            Id = shoppingCartId,
                            ShoppingCart = shoppingCart,
                            Supplier = supplier,
                            Customer = customer,
                            Order = order,
                            Delivery = delivery,
                            Desk = desk
                        }
                };
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> CreateShoppingCart(string source, int supplierId, string userId, int orderId)
        {
            var bindShoppingCartResult = this.shoppingCartBaseCacheServices.BindShoppingCartId(source, supplierId.ToString(), userId, orderId);
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

            var shoppingCartOrder = new EtsWapDingTaiShoppingCartOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    DingTaiMethodId = ServicesCommon.DefaultDingTaiMethodId,
                    PaymentMethodId = ServicesCommon.DefaultPaymentMethodId,
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

            /*保存订台台位信息*/
            var shoppingCartDesk = new ShoppingCartDesk
            {
                Id = Guid.NewGuid().ToString()
            };
            var saveShoppingCartDeskResult = this.etsWapShoppingCartProvider.SaveShoppingCartDesk(source, shoppingCartDesk);
            if (saveShoppingCartDeskResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = saveShoppingCartDeskResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = new EtsWapDingTaiShoppingCartLink
                {
                    ShoppingCartLinkId = shoppingCartLinkId,
                    ShoppingCartId = getShoppingCartResult.Result.ShoppingCartId,
                    SupplierId = getShoppingCartSupplierResult.Result.SupplierId,
                    OrderId = shoppingCartOrder.Id,
                    DeliveryId = shoppingCartDelivery.Id,
                    DeskId = shoppingCartDesk.Id,
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList)
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
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList)
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
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order);
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList)
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
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order);
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

            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            var shoppingCartDelivery = getShoppingCartDeliveryResult.Result;
            shoppingCartDelivery.Telephone = customer.Telephone;
            shoppingCartDelivery.Name = customer.Name;
            shoppingCartDelivery.Gender = customer.Gender;
            this.etsWapShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);

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
        public ServicesResult<bool> SaveShoppingCart(string source, string id, EtsWapDingTaiShoppingCartModel shoppingCart)
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
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(string source, string id, EtsWapDingTaiShoppingCartOrder shoppingCartOrder, bool isCalculateCoupon)
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
            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;
            var total = totalfee;
            var coupon = isCalculateCoupon ? this.CalculateCoupon(shoppingPrice, supplier.SupplierId, shoppingCartLink.UserId) : order.CouponFee;
            var customerTotal = total - coupon;

            shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.IsComplete = order.IsComplete;
            shoppingCartOrder.TotalPrice = shoppingPrice;
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
        /// 保存用户确认订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartOrderConfirm">The shopping cart order confirm.</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrderConfirm(string source, string id,
                                                           EtsWapDingTaiShoppingCartOrderConfirm shoppingCartOrderConfirm,
                                                           bool isCalculateCoupon)
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

            /*商户信息*/
            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            /**/
            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            /*订单信息*/
            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            /*订台信息*/
            var getShoppingCartDeskResult = this.etsWapShoppingCartProvider.GetShoppingCartDesk(source, shoppingCartLink.DeskId);
            if (getShoppingCartDeskResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeskResult.StatusCode
                };
            }

            var supplier = getShoppingCartSupplierResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var desk = getShoppingCartDeskResult.Result;

            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;
            /*菜品总金额+押金*/
            var total = totalfee + desk.DepositAmount ?? 0;
            var coupon = isCalculateCoupon ? this.CalculateCoupon(shoppingPrice, supplier.SupplierId, shoppingCartLink.UserId) : order.CouponFee;
            var customerTotal = total - coupon;

            /*订单确认用户信息*/
            delivery.Telephone = shoppingCartOrderConfirm.CustomerPhoneNumber;
            delivery.Name = shoppingCartOrderConfirm.CustomerName;
            delivery.Gender = shoppingCartOrderConfirm.CustomerGender;

            /*确认订单信息*/
            order.OrderInstruction = shoppingCartOrderConfirm.Remark;
            order.DingTaiMethodId = shoppingCartOrderConfirm.DingTaiMethodId;
            order.TotalFee = total;

            /*shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.IsComplete = order.IsComplete;
            shoppingCartOrder.TotalPrice = shoppingPrice;
            shoppingCartOrder.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            shoppingCartOrder.TotalFee = total;
            shoppingCartOrder.CustomerTotalFee = customerTotal;
            shoppingCartOrder.CouponFee = coupon;*/
            this.etsWapShoppingCartProvider.SaveShoppingCartDelivery(source, delivery);
            this.etsWapShoppingCartProvider.SaveShoppingCartOrder(source, order);
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
        /// 保存订单台位信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartDesk">台位信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartDesk(string source, string id, ShoppingCartDesk shoppingCartDesk)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = getShoppingCartLinkResult.StatusCode
                    };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartDeskResult = this.etsWapShoppingCartProvider.GetShoppingCartDesk(source,
                                                                                                shoppingCartLink.DeskId);
            if (getShoppingCartDeskResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = getShoppingCartDeskResult.StatusCode
                    };
            }

            shoppingCartDesk.Id = getShoppingCartDeskResult.Result.Id;
            this.etsWapShoppingCartProvider.SaveShoppingCartDesk(source, shoppingCartDesk);

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
        /// 创建者：周超
        /// 创建日期：11/29/2013 11:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveShoppingCartOrder(string source, List<ShoppingCartItem> shoppingList, ShoppingCartSupplier supplier, EtsWapDingTaiShoppingCartOrder order)
        {
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;
            var total = totalfee;
            var coupon = order.CouponFee;
            var customerTotal = total - coupon;

            order.TotalPrice = shoppingPrice;
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
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回折扣
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/6/2013 5:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private decimal CalculateCoupon(decimal total, int supplierId, int? userId)
        {
            if (userId == null)
            {
                return 0;
            }

            var supplierCouponProvider = this.supplierCouponProviderList.FirstOrDefault(p => p.DeliveryMethodType == DeliveryMethodType.TangShi);
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
    }
}
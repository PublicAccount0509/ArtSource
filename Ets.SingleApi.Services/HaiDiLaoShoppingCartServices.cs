namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HaiDiLaoShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HaiDiLaoShoppingCartServices : IHaiDiLaoShoppingCartServices
    {
        /// <summary>
        /// 字段supplierDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：1/3/2014 9:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISupplierDetailServices supplierDetailServices;

        /// <summary>
        /// 字段haiDiLaoShoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHaiDiLaoShoppingCartProvider haiDiLaoShoppingCartProvider;

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
        /// 创建日期：3/3/2014 4:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="HaiDiLaoShoppingCartServices" /> class.
        /// </summary>
        /// <param name="supplierDetailServices">The supplierDetailServices</param>
        /// <param name="haiDiLaoShoppingCartProvider">The haiDiLaoShoppingCartProvider</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HaiDiLaoShoppingCartServices(
            ISupplierDetailServices supplierDetailServices,
            IHaiDiLaoShoppingCartProvider haiDiLaoShoppingCartProvider,
            List<ISupplierCouponProvider> supplierCouponProviderList,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices)
        {
            this.supplierDetailServices = supplierDetailServices;
            this.haiDiLaoShoppingCartProvider = haiDiLaoShoppingCartProvider;
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
        public ServicesResult<HaiDiLaoShoppingCartModel> GetShoppingCart(string source, string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var getShoppingCartCustomerResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var getShoppingCartDeliveryResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HaiDiLaoShoppingCartModel>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode,
                    Result = new HaiDiLaoShoppingCartModel()
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            return new ServicesResult<HaiDiLaoShoppingCartModel>
            {
                Result = new HaiDiLaoShoppingCartModel
                {
                    Id = shoppingCartId,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order,
                    Delivery = delivery,
                    Extra = extra
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
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, Guid.NewGuid().ToString());
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, supplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartOrder = new HaiDiLaoShoppingCartOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    CanSelectCooking = true,
                    DeliveryType = ServicesCommon.DefaultDeliveryType,
                    DeliveryMethodId = ServicesCommon.DefaultDeliveryMethodId,
                    PaymentMethodId = ServicesCommon.DefaultPaymentMethodId
                };
            var saveShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
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
            var shoppingCartDeliveryResult = this.haiDiLaoShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);
            if (shoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = shoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartExtra = new ShoppingCartExtra
            {
                Id = Guid.NewGuid().ToString(),
                CookingCount = ServicesCommon.DefaultCookingCount,
                DiningCount = ServicesCommon.DefaultDiningCount,
                PanCount = ServicesCommon.DefaultPanCount
            };
            var shoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, shoppingCartExtra);
            if (shoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = shoppingCartExtraResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = new HaiDiLaoShoppingCartLink
                {
                    ShoppingCartLinkId = shoppingCartLinkId,
                    ShoppingCartId = getShoppingCartResult.Result.ShoppingCartId,
                    SupplierId = getShoppingCartSupplierResult.Result.SupplierId,
                    OrderId = shoppingCartOrder.Id,
                    DeliveryId = shoppingCartDelivery.Id,
                    ExtraId = shoppingCartExtra.Id,
                    AnonymityId = userId
                };

            int tempUserId;
            if (!int.TryParse(userId, out tempUserId))
            {
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
                return new ServicesResult<string>
                {
                    Result = shoppingCartLinkId
                };
            }

            shoppingCartLink.UserId = tempUserId;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
            var getShoppingCartCustomerResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartCustomer(source, tempUserId);
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var shoppingList = shoppingCartItemList;
            shoppingCart.ShoppingList = shoppingList;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, extra, saveDeliveryMethodId);
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

            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            foreach (var shoppingCartItem in shoppingCartItemList)
            {
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId && p.ParentId == shoppingCartItem.ParentId && (p.Instruction ?? string.Empty).Trim() == (shoppingCartItem.Instruction ?? string.Empty).Trim());
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

            if (shoppingList.Count == 0)
            {
                extra.CookingCount = 0;
                extra.PanCount = 0;
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, extra);
            }

            shoppingCart.ShoppingList = shoppingList;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCart(source, shoppingCart);

            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, extra, saveDeliveryMethodId);
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            foreach (var shoppingCartItem in shoppingCartItemList)
            {
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId && p.ParentId == shoppingCartItem.ParentId && (p.Instruction ?? string.Empty).Trim() == (shoppingCartItem.Instruction ?? string.Empty).Trim());
                if (item == null)
                {
                    continue;
                }

                item.Quantity -= shoppingCartItem.Quantity;
                if (item.Quantity <= 0)
                {
                    shoppingList.Remove(item);
                    shoppingList.RemoveAll(p => p.ParentId == item.ItemId);
                }
            }

            var shoppingPrice = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;
            if (totalfee < supplier.DelMinOrderAmount)
            {
                shoppingList.RemoveAll(p => p.IsPresent && p.Type == 0);
            }

            foreach (var shoppingCartItem in shoppingList)
            {
                if (shoppingCartItem.CategoryIdList != null)
                {
                    continue;
                }

                shoppingCartItem.CategoryIdList = new List<int>();
            }

            if (shoppingList.Count == 0)
            {
                extra.CookingCount = 0;
                extra.PanCount = 0;
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, extra);
            }

            shoppingCart.ShoppingList = shoppingList;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCart(source, shoppingCart);

            order.CouponFee = 0;
            this.SaveShoppingCartOrder(source, shoppingList, supplier, order, extra, saveDeliveryMethodId);
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartCustomerResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartCustomer(source, userId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode
                };
            }

            var customer = getShoppingCartCustomerResult.Result;
            shoppingCartLink.UserId = customer.UserId;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
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
        public ServicesResult<bool> SaveShoppingCart(string source, string id, HaiDiLaoShoppingCartModel shoppingCart)
        {
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartDeliveryResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCart.Delivery);
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCart.Order);
            this.haiDiLaoShoppingCartProvider.SaveShoppingCart(source, shoppingCart.ShoppingCart);

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
        public ServicesResult<bool> SaveShoppingCartOrder(string source, string id, HaiDiLaoShoppingCartOrder shoppingCartOrder, bool isCalculateCoupon, bool isValidateDeliveryTime)
        {
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var deliveryMethodId = shoppingCartOrder.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;

            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            if (shoppingList.Count(p => p.ParentId == 0) == 0)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode
                    };
            }

            var shoppingPrice = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;
            if (totalfee < supplier.DelMinOrderAmount)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidShoppingPrice
                };
            }

            // TODO:根据公里数计算送餐费
            //var fixedDeliveryCharge = supplier.FreeDeliveryLine <= totalfee
            //                            ? 0
            //                           : supplier.FixedDeliveryCharge;

            var fixedDeliveryFee = 0;
            var servicesFee = Math.Round(totalfee * supplier.ConsumerAmount / 100, 0);
            var cookingFee = extra.CookingCount * ServicesCommon.CookingDeposit
                 + extra.PanCount * ServicesCommon.PotDeposit;
            if (deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId)
            {
                cookingFee = 0;
            }

            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                servicesFee = 0;
                fixedDeliveryFee = 0;
            }

            var total = totalfee + servicesFee + cookingFee + fixedDeliveryFee;
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

                var beginReadyTime = deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId ? ServicesCommon.PickUpMethodReadyTime : supplierDeliveryTime;
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
                if (!validateDeliveryTimeResult.Result)
                {
                    return new ServicesResult<bool>
                    {
                        StatusCode = validateDeliveryTimeResult.StatusCode
                    };
                }
                var deliveryTime = deliveryTimeTemp;
                shoppingCartOrder.DeliveryDateTime = deliveryTime;
            }

            shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.IsComplete = order.IsComplete;
            shoppingCartOrder.CanDelivery = order.CanDelivery;
            shoppingCartOrder.DeliveryMethodId = deliveryMethodId;
            shoppingCartOrder.IsSelfPan = order.IsSelfPan;
            shoppingCartOrder.IsSelfDip = order.IsSelfDip;
            shoppingCartOrder.TotalPrice = shoppingPrice;
            shoppingCartOrder.FixedDeliveryFee = fixedDeliveryFee;
            shoppingCartOrder.PackagingFee = 0;
            shoppingCartOrder.TotalQuantity = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity);
            shoppingCartOrder.PanQuantity = shoppingList.Where(p => p.Type == 2 && p.ParentId == 0).Sum(p => p.Quantity);
            shoppingCartOrder.DipQuantity = shoppingList.Where(p => p.Type == 1 && p.ParentId == 0).Sum(p => p.Quantity);
            shoppingCartOrder.DishQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && !p.IsPresent).Sum(p => p.Quantity);
            shoppingCartOrder.PresentQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && p.IsPresent).Sum(p => p.Quantity);
            shoppingCartOrder.PackageQuantity = shoppingList.Where(p => p.Type == 3 && p.ParentId == 0).Sum(p => p.Quantity);
            shoppingCartOrder.IsSpecialServices = shoppingList.Any(p => p.Type == 4 && p.ParentId == 0);
            shoppingCartOrder.TotalFee = total;
            shoppingCartOrder.CustomerTotalFee = customerTotal;
            shoppingCartOrder.ServicesFee = servicesFee;
            shoppingCartOrder.CouponFee = coupon;
            shoppingCartOrder.CookingFee = cookingFee;
            shoppingCartOrder.CanSelectCooking = true;

            if (order.IsSelfPan)
            {
                shoppingCartOrder.CookingFee = 0;
                shoppingCartOrder.CanSelectCooking = false;
                extra.CookingCount = 0;
                extra.PanCount = 0;
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, extra);
            }

            this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartDeliveryResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            shoppingCartDelivery.Id = getShoppingCartDeliveryResult.Result.Id;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);

            return new ServicesResult<bool>
            {
                Result = true
            };

        }

        /// <summary>
        /// 保存订单额外信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartExtra">The shoppingCartExtra</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartExtra(string source, string id, ShoppingCartExtra shoppingCartExtra)
        {
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var extra = getShoppingCartExtraResult.Result;
            shoppingCartExtra.Id = extra.Id;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, shoppingCartExtra);

            var order = getShoppingCartOrderResult.Result;
            var oldCookingFee = order.CookingFee;
            var cookingFee = shoppingCartExtra.CookingCount * ServicesCommon.CookingDeposit
                + shoppingCartExtra.PanCount * ServicesCommon.PotDeposit;
            if (order.DeliveryMethodId != ServicesCommon.PickUpDeliveryMethodId)
            {
                cookingFee = 0;
            }
            order.CookingFee = cookingFee;
            order.TotalFee = order.TotalFee - oldCookingFee + cookingFee;
            order.CustomerTotalFee = order.CustomerTotalFee - oldCookingFee + cookingFee;
            this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, order);

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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity * p.Price);
            var totalfee = shoppingPrice;

            order.CouponFee = 0;
            var fixedDeliveryFee = 0;
            var servicesFee = Math.Round(totalfee * supplier.ConsumerAmount / 100, 0);
            var cookingFee = extra.CookingCount * ServicesCommon.CookingDeposit
                 + extra.PanCount * ServicesCommon.PotDeposit;
            if (deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId)
            {
                cookingFee = 0;
            }

            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                servicesFee = 0;
                fixedDeliveryFee = 0;
            }

            var total = totalfee + fixedDeliveryFee + servicesFee + cookingFee;
            var coupon = order.CouponFee;
            var customerTotal = total - coupon;

            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = totalfee;
            order.FixedDeliveryFee = fixedDeliveryFee;
            order.PackagingFee = 0;
            order.TotalQuantity = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity);
            order.PanQuantity = shoppingList.Where(p => p.Type == 2 && p.ParentId == 0).Sum(p => p.Quantity);
            order.DipQuantity = shoppingList.Where(p => p.Type == 1 && p.ParentId == 0).Sum(p => p.Quantity);
            order.DishQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && !p.IsPresent).Sum(p => p.Quantity);
            order.PresentQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && p.IsPresent).Sum(p => p.Quantity);
            order.PackageQuantity = shoppingList.Where(p => p.Type == 3 && p.ParentId == 0).Sum(p => p.Quantity);
            order.IsSpecialServices = shoppingList.Any(p => p.Type == 4 && p.ParentId == 0);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;
            order.ServicesFee = servicesFee;
            order.CookingFee = cookingFee;
            order.CanSelectCooking = true;

            if (order.IsSelfPan)
            {
                order.CookingFee = 0;
                order.CanSelectCooking = false;
                extra.CookingCount = 0;
                extra.PanCount = 0;
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, extra);
            }

            this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, order);
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
        /// <param name="extra">The extra</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// 创建者：周超
        /// 创建日期：11/29/2013 11:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveShoppingCartOrder(string source, List<ShoppingCartItem> shoppingList, ShoppingCartSupplier supplier, HaiDiLaoShoppingCartOrder order, ShoppingCartExtra extra, bool saveDeliveryMethodId)
        {
            var shoppingPrice = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity * p.Price);
            var panQuantity = shoppingList.Where(p => p.Type == 2 && p.ParentId == 0).Sum(p => p.Quantity);
            var totalfee = shoppingPrice;
            //var fixedDeliveryCharge = supplier.FreeDeliveryLine <= totalfee
            //                            ? 0
            //                           : supplier.FixedDeliveryCharge;

            //var canDelivery = totalfee >= (supplier.DelMinOrderAmount * panQuantity);
            var canDelivery = totalfee >= supplier.DelMinOrderAmount;
            var deliveryMethodId = !canDelivery ? ServicesCommon.PickUpDeliveryMethodId : (order.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId);
            var fixedDeliveryFee = 0;
            var servicesFee = Math.Round(totalfee * supplier.ConsumerAmount / 100, 0);
            var cookingFee = extra.CookingCount * ServicesCommon.CookingDeposit
                 + extra.PanCount * ServicesCommon.PotDeposit;
            if (deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId)
            {
                cookingFee = 0;
            }

            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                servicesFee = 0;
                fixedDeliveryFee = 0;
            }

            var total = totalfee + fixedDeliveryFee + servicesFee + cookingFee;
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

            order.IsSelfPan = shoppingList.Any(p => p.Type == 0) && shoppingList.All(p => p.Type != 2) && shoppingList.All(p => p.Type != 3);
            order.IsSelfDip = shoppingList.Any(p => p.Type == 0) && shoppingList.All(p => p.Type != 1) && shoppingList.All(p => p.Type != 3);
            order.CanDelivery = canDelivery;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = fixedDeliveryFee;
            order.PackagingFee = 0;
            order.TotalQuantity = shoppingList.Where(p => p.ParentId == 0).Sum(p => p.Quantity);
            order.PanQuantity = panQuantity;
            order.DipQuantity = shoppingList.Where(p => p.Type == 1 && p.ParentId == 0).Sum(p => p.Quantity);
            order.DishQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && !p.IsPresent).Sum(p => p.Quantity);
            order.PresentQuantity = shoppingList.Where(p => p.Type == 0 && p.ParentId == 0 && p.IsPresent).Sum(p => p.Quantity);
            order.PackageQuantity = shoppingList.Where(p => p.Type == 3 && p.ParentId == 0).Sum(p => p.Quantity);
            order.IsSpecialServices = shoppingList.Any(p => p.Type == 4 && p.ParentId == 0);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;
            order.ServicesFee = servicesFee;
            order.CookingFee = cookingFee;
            order.CanSelectCooking = true;

            if (order.IsSelfPan)
            {
                order.CookingFee = 0;
                order.CanSelectCooking = false;
                extra.CookingCount = 0;
                extra.PanCount = 0;
                this.haiDiLaoShoppingCartProvider.SaveShoppingCartExtra(source, extra);
            }

            this.haiDiLaoShoppingCartProvider.SaveShoppingCartOrder(source, order);
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
        private ServicesResult<bool> ValidateDeliveryTime(string source, int supplierId, int deliveryMethodId, DateTime deliveryTime, int beginReadyTime)
        {
            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                return this.ValidateSupplierServiceTime(source, supplierId, deliveryTime, beginReadyTime);
            }

            return this.ValidateSupplierServiceTime(source, supplierId, deliveryTime, beginReadyTime);
        }

        /// <summary>
        /// 验证取餐时间(营业时间)
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
        public ServicesResult<bool> ValidateSupplierServiceTime(string source, int supplierId, DateTime pickUpTime, int beginReadyTime)
        {
            if (!ServicesCommon.ValidateDeliveryTimeEnabled)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var getSupplierDeliveryTimeResult = this.supplierDetailServices.GetSupplierServiceTime(supplierId, pickUpTime, 1, beginReadyTime, true);
            if (getSupplierDeliveryTimeResult == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false
                };
            }

            if (getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Ok && getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Empty)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = getSupplierDeliveryTimeResult.StatusCode
                };
            }

            var supplierDeliveryTime = (getSupplierDeliveryTimeResult.Result ?? new List<SupplierServiceTimeModel>()).FirstOrDefault();
            if (supplierDeliveryTime == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode
                };
            }

            var tempDeliveryTime = DateTime.Parse(pickUpTime.ToString("yyyy-MM-dd HH:mm"));
            foreach (var item in supplierDeliveryTime.ServiceTime.Split(' '))
            {
                var tempList = item.Split('-').ToList();
                if (tempList.Count != 2)
                {
                    continue;
                }

                var startDate = DateTime.Parse(string.Format("{0} {1}", supplierDeliveryTime.ServiceDate, tempList.First()));
                var endDate = DateTime.Parse(string.Format("{0} {1}", supplierDeliveryTime.ServiceDate, tempList.Last()));
                if (startDate <= tempDeliveryTime && endDate >= tempDeliveryTime)
                {
                    string.Format("取餐时间：{0}，餐厅送餐时间：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.ServiceTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<bool>
                    {
                        Result = true
                    };
                }
            }

            string.Format("取餐时间：{0}，餐厅送餐时间：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.ServiceTime, "无效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode
            };
        }

        /// <summary>
        /// 验证送餐时间（送餐时间）
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
        public ServicesResult<bool> ValidateSupplierDeliveryTime(string source, int supplierId, DateTime pickUpTime, int beginReadyTime)
        {
            if (!ServicesCommon.ValidateDeliveryTimeEnabled)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var getSupplierDeliveryTimeResult = this.supplierDetailServices.GetSupplierDeliveryTime(supplierId, pickUpTime, 1, beginReadyTime, true);
            if (getSupplierDeliveryTimeResult == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false
                };
            }

            if (getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Ok && getSupplierDeliveryTimeResult.StatusCode != (int)StatusCode.Succeed.Empty)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = getSupplierDeliveryTimeResult.StatusCode
                };
            }

            var supplierDeliveryTime = (getSupplierDeliveryTimeResult.Result ?? new List<SupplierDeliveryTimeModel>()).FirstOrDefault();
            if (supplierDeliveryTime == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidPickUpTimeCode
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
                if (startDate <= tempDeliveryTime && endDate >= tempDeliveryTime)
                {
                    string.Format("取餐时间：{0}，餐厅送餐时间：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.DeliveryTime, "有效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new ServicesResult<bool>
                    {
                        Result = true
                    };
                }
            }

            string.Format("取餐时间：{0}，餐厅送餐时间：{1}，是否为有效时间：{2}", tempDeliveryTime, supplierDeliveryTime.DeliveryTime, "无效").WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Validate.InvalidPickUpTimeCode
            };
        }
    }
}
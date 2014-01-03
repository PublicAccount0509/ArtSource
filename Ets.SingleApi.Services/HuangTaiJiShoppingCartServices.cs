﻿namespace Ets.SingleApi.Services
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
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：HuangTaiJiShoppingCartServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：黄太极购物车功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 12:17 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiShoppingCartServices : IHuangTaiJiShoppingCartServices
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：12/20/2013 3:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHuangTaiJiShoppingCartProvider huangTaiJiShoppingCartProvider;

        /// <summary>
        /// 字段supplierCouponProviderList
        /// </summary>
        /// 创建者：殷超
        /// 创建日期：12/7/2013 4:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<ISupplierCouponProvider> supplierCouponProviderList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="shoppingCartProvider">The shoppingCartProvider</param>
        /// <param name="supplierCouponProviderList">The supplierCouponProviderList</param>
        /// 创建者：殷超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiShoppingCartServices(
             INHibernateRepository<SupplierEntity> supplierEntityRepository,
            IHuangTaiJiShoppingCartProvider huangTaiJiShoppingCartProvider,
            List<ISupplierCouponProvider> supplierCouponProviderList)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.huangTaiJiShoppingCartProvider = huangTaiJiShoppingCartProvider;
            this.supplierCouponProviderList = supplierCouponProviderList;
        }

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<HuangTaiJiShoppingCartModel> GetShoppingCart(string source, string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var getShoppingCartCustomerResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var getShoppingCartDeliveryResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<HuangTaiJiShoppingCartModel>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode,
                    Result = new HuangTaiJiShoppingCartModel()
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            return new ServicesResult<HuangTaiJiShoppingCartModel>
            {
                Result = new HuangTaiJiShoppingCartModel
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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> CreateShoppingCart(string source, int supplierId, string userId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, supplierId, userId);
            if (getShoppingCartLinkResult.StatusCode == (int)StatusCode.Succeed.Ok && getShoppingCartLinkResult.Result != null)
            {
                return new ServicesResult<string>
                {
                    Result = getShoppingCartLinkResult.Result.ShoppingCartLinkId
                };
            }

            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, Guid.NewGuid().ToString());
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, supplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartOrder = new HuangTaiJiShoppingCartOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    DeliveryType = ServicesCommon.DefaultDeliveryType,
                    DeliveryMethodId = ServicesCommon.DefaultDeliveryMethodId
                };
            var saveShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
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
            var shoppingCartDeliveryResult = this.huangTaiJiShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);
            if (shoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = shoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLinkId = Guid.NewGuid().ToString();
            var shoppingCartLink = new HuangTaiJiShoppingCartLink
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
                this.huangTaiJiShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
                return new ServicesResult<string>
                {
                    Result = shoppingCartLinkId
                };
            }

            shoppingCartLink.UserId = tempUserId;
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
            var getShoppingCartCustomerResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartCustomer(source, tempUserId);
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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingItem(string source, string id, List<HuangTaiJiShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            this.huangTaiJiShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddShoppingItem(string source, string id, List<HuangTaiJiShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            if (shoppingCartItemList.Count(p => p.Quantity > 0) == 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            var shoppingList = shoppingCart.ShoppingList ?? new List<HuangTaiJiShoppingCartItem>();

            // 遍历shoppingList中的shoppingCartItem，存在Quantity数量计算，这个时候可能忽略子shoopingList下的Quantity,可能存在改动 todo
            foreach (var shoppingCartItem in shoppingCartItemList)
            {
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId && (p.Instruction ?? string.Empty).Trim() == (shoppingCartItem.Instruction ?? string.Empty).Trim());
                if (item == null)
                {
                    shoppingList.Add(shoppingCartItem);
                    continue;
                }

                foreach (var categoryId in shoppingCartItem.CategoryIdList.Where(categoryId => !item.CategoryIdList.Contains(categoryId)))
                {
                    item.CategoryIdList.Add(categoryId);
                }

                item.Quantity += shoppingCartItem.Quantity;
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
            this.huangTaiJiShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteShoppingItem(string source, string id, List<HuangTaiJiShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            var shoppingList = shoppingCart.ShoppingList ?? new List<HuangTaiJiShoppingCartItem>();

            // 遍历shoppingList中的shoppingCartItem，存在Quantity数量计算，这个时候可能忽略子shoopingList下的Quantity,可能存在改动 todo
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
            this.huangTaiJiShoppingCartProvider.SaveShoppingCart(source, shoppingCart);
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
        /// 创建者：殷超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartCustomer(string source, string id, int userId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartCustomerResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartCustomer(source, userId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode
                };
            }

            var customer = getShoppingCartCustomerResult.Result;
            shoppingCartLink.UserId = customer.UserId;
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartLink(source, shoppingCartLink);
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
        /// 创建者：殷超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCart(string source, string id, HuangTaiJiShoppingCartModel shoppingCart)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartDeliveryResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCart.Delivery);
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCart.Order);
            this.huangTaiJiShoppingCartProvider.SaveShoppingCart(source, shoppingCart.ShoppingCart);

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
        /// 创建者：殷超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(string source, string id, HuangTaiJiShoppingCartOrder shoppingCartOrder, bool isCalculateCoupon)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            var now = DateTime.Now;
            var deliveryDate = (shoppingCartOrder.DeliveryDate ?? now).ToString("yyyy-MM-dd");
            DateTime deliveryTimeTemp;
            if (!DateTime.TryParse(string.Format("{0} {1}", deliveryDate, shoppingCartOrder.DeliveryTime), out deliveryTimeTemp))
            {
                deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now);
            }

            if (shoppingCartOrder.DeliveryType == ServicesCommon.QuickDeliveryType)
            {
                deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now);
            }

            var validateDeliveryTimeResult = this.huangTaiJiShoppingCartProvider.ValidateDeliveryTime(source, supplier.SupplierId, deliveryTimeTemp, now);
            if (!validateDeliveryTimeResult.Result)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = validateDeliveryTimeResult.StatusCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<HuangTaiJiShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var mainOtherPrice = 0m;
            var mainOtherQuantity = 0;
            // 计费标准 是否需要把子菜单中的相关费用也计算进去(如打包费等) todo
            if (shoppingList != null)
            {
                foreach (var shopping in shoppingList)
                {
                    Tuple<decimal, int> tuple = getOptionGroupMoneyAndAmountInfo(shopping);
                    mainOtherPrice = mainOtherPrice + tuple.Item1;
                    mainOtherQuantity = mainOtherQuantity + tuple.Item2;
                }
            }
            //shoppingPrice = shoppingPrice + mainOtherPrice;

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
            var deliveryTime = this.GetDeliveryDate(deliveryMethodId, shoppingCartOrder.DeliveryType, deliveryTimeTemp, supplier.DeliveryTime);

            shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.CanDelivery = order.CanDelivery;
            shoppingCartOrder.DeliveryDateTime = deliveryTime;
            shoppingCartOrder.DeliveryMethodId = deliveryMethodId;
            shoppingCartOrder.TotalPrice = shoppingPrice;
            shoppingCartOrder.FixedDeliveryFee = fixedDeliveryFee;
            shoppingCartOrder.PackagingFee = packagingFee;
            shoppingCartOrder.TotalQuantity = shoppingList.Sum(p => p.Quantity) + mainOtherQuantity;
            shoppingCartOrder.TotalFee = total;
            shoppingCartOrder.CustomerTotalFee = customerTotal;
            shoppingCartOrder.CouponFee = coupon;
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartOrder(source, shoppingCartOrder);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        // 计算某主菜下头的所有Price和Quantity信息
        private Tuple<decimal, int> getOptionGroupMoneyAndAmountInfo(HuangTaiJiShoppingCartItem carItem)
        {
            var sumOtherPrice = 0m;
            var sumOtherQuantity = 0;
            var otherPrice = 0m;
            var otherQuantity = 0;
            var subOtherPrice = 0m;
            var subOtherQuantity = 0;

            if (carItem.SupplierDishOptionGroups != null && carItem.SupplierDishOptionGroups.Count > 0)
            {
                foreach (var optionGroup in carItem.SupplierDishOptionGroups)
                {
                    foreach (var customizationOption in optionGroup.SupplierDishCustomizationOption)
                    {
                        if (customizationOption.SupplierDishPrice != 0 && customizationOption.SupplierDishQuantity != 0)
                        {
                            otherPrice = otherPrice + (customizationOption.SupplierDishPrice.HasValue ? customizationOption.SupplierDishPrice.Value : 0m) * customizationOption.SupplierDishQuantity;
                            //otherQuantity++;
                        }
                    }
                }
            }

            // 子菜
            if (carItem.SubSupplierDishDetail != null && carItem.SubSupplierDishDetail.Count > 0)
            {
                foreach (HuangTaiJiShoppingCartItem subCarItem in carItem.SubSupplierDishDetail)
                {
                    if (subCarItem != null)
                    {
                        Tuple<decimal, int> nums = getOptionGroupMoneyAndAmountInfo(subCarItem);
                        subOtherPrice = subOtherPrice + nums.Item1;
                        subOtherQuantity = subOtherQuantity + nums.Item2;
                    }
                }
            }
            sumOtherPrice = otherPrice + subOtherPrice;
            sumOtherQuantity = otherQuantity + subOtherQuantity;
            return Tuple.Create(sumOtherPrice, sumOtherQuantity);
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
        /// 创建者：殷超
        /// 创建日期：11/27/2013 5:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartDelivery(string source, string id, ShoppingCartDelivery shoppingCartDelivery)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartDeliveryResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            shoppingCartDelivery.Id = getShoppingCartDeliveryResult.Result.Id;
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartDelivery(source, shoppingCartDelivery);

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
        /// 创建者：殷超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrderDeliveryMethod(string source, string id, int deliveryMethodId)
        {
            var getShoppingCartLinkResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartLink(source, id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.huangTaiJiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.huangTaiJiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            var shoppingList = shoppingCart.ShoppingList ?? new List<HuangTaiJiShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var mainOtherPrice = 0m;
            var mainOtherQuantity = 0;
            // 计费标准 是否需要把子菜单中的相关费用也计算进去(如打包费等) todo
            if (shoppingList != null)
            {
                foreach (var shopping in shoppingList)
                {
                    Tuple<decimal, int> tuple = getOptionGroupMoneyAndAmountInfo(shopping);
                    mainOtherPrice = mainOtherPrice + tuple.Item1;
                    mainOtherQuantity = mainOtherQuantity + tuple.Item2;
                }
            }
            //shoppingPrice = shoppingPrice + mainOtherPrice;


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
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity) + mainOtherQuantity;
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;

            this.huangTaiJiShoppingCartProvider.SaveShoppingCartOrder(source, order);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得送餐时间
        /// </summary>
        /// <param name="deliveryMethodId">取餐方式</param>
        /// <param name="deliveryType">送餐类型</param>
        /// <param name="deliveryTime">送餐日期</param>
        /// <param name="supplierDeliveryTime">餐厅默认送餐时间</param>
        /// <returns>
        /// 返回送餐时间
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：11/18/2013 12:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private DateTime GetDeliveryDate(int deliveryMethodId, int deliveryType, DateTime deliveryTime, string supplierDeliveryTime)
        {
            if (deliveryType == ServicesCommon.AssignDeliveryType)
            {
                return deliveryTime;
            }

            if (deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                return deliveryTime.AddMinutes(ServicesCommon.DefaultPickUpTime);
            }

            int result;
            if (!int.TryParse(supplierDeliveryTime, out result))
            {
                result = ServicesCommon.DefaultDeliveryTime;
            }

            return deliveryTime.AddMinutes(result);
        }

        /// <summary>
        /// Saves the shopping cart order.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingList">The shoppingList</param>
        /// <param name="supplier">The supplier</param>
        /// <param name="order">The order</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// 创建者：殷超
        /// 创建日期：11/29/2013 11:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveShoppingCartOrder(string source, List<HuangTaiJiShoppingCartItem> shoppingList, ShoppingCartSupplier supplier, HuangTaiJiShoppingCartOrder order, bool saveDeliveryMethodId)
        {
            // 计算车价格计算改变
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var mainOtherPrice = 0m;
            var mainOtherQuantity = 0;
            // 计费标准 是否需要把子菜单中的相关费用也计算进去(如打包费等) todo
            if (shoppingList != null)
            {
                foreach (var shopping in shoppingList)
                {
                    Tuple<decimal, int> tuple = getOptionGroupMoneyAndAmountInfo(shopping);
                    mainOtherPrice = mainOtherPrice + tuple.Item1;
                    mainOtherQuantity = mainOtherQuantity + tuple.Item2;
                }
            }
            // shoppingPrice = shoppingPrice + mainOtherPrice;

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
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity) + mainOtherQuantity;
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;
            this.huangTaiJiShoppingCartProvider.SaveShoppingCartOrder(source, order);
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
        /// 创建者：殷超
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

            if (this.supplierEntityRepository.EntityQueryable.Any(
                    p =>
                    p.SupplierId == supplierId && ServicesCommon.NoCouponSupplierGroupList.Contains(p.SupplierGroupId)))
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
    }
}
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
        /// 取得购物车信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartModel> GetShoppingCart(string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new ShoppingCartModel()
                };
            }

            var getShoppingCartDeliveryResult = this.shoppingCartProvider.GetShoppingCartDelivery(shoppingCartLink.DeliveryId);
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
        public ServicesResult<string> CreateShoppingCart(int supplierId, string userId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(supplierId, userId);
            if (getShoppingCartLinkResult.StatusCode == (int)StatusCode.Succeed.Ok && getShoppingCartLinkResult.Result != null)
            {
                return new ServicesResult<string>
                {
                    Result = getShoppingCartLinkResult.Result.ShoppingCartLinkId
                };
            }

            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(Guid.NewGuid().ToString());
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(supplierId);
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
                    DeliveryType = ServicesCommon.DefaultDeliveryType
                };
            var saveShoppingCartOrderResult = this.shoppingCartProvider.SaveShoppingCartOrder(shoppingCartOrder);
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
            var shoppingCartDeliveryResult = this.shoppingCartProvider.SaveShoppingCartDelivery(shoppingCartDelivery);
            if (shoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = shoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLinkId = Guid.NewGuid().ToString();
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
                this.shoppingCartProvider.SaveShoppingCartLink(shoppingCartLink);
                return new ServicesResult<string>
                {
                    Result = shoppingCartLinkId
                };
            }

            shoppingCartLink.UserId = tempUserId;
            this.shoppingCartProvider.SaveShoppingCartLink(shoppingCartLink);
            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(tempUserId);
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
        public ServicesResult<bool> SaveShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
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
            this.shoppingCartProvider.SaveShoppingCart(shoppingCart);

            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = this.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
                                                    {
                                                        PackagingFee = p.PackagingFee,
                                                        Price = p.Price,
                                                        Quantity = p.Quantity
                                                    }).ToList());

            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;
            var totalfee = shoppingPrice + packagingFee;
            var canDelivery = totalfee >= supplier.DelMinOrderAmount;
            var deliveryMethodId = canDelivery ? ServicesCommon.PickUpDeliveryMethodId : order.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? totalfee + fixedDeliveryCharge
                        : totalfee;
            var coupon = 0;
            var customerTotal = total - coupon;

            order.CanDelivery = canDelivery;
            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = fixedDeliveryCharge;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;

            this.shoppingCartProvider.SaveShoppingCartOrder(order);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 添加商品信息
        /// </summary>
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
        public ServicesResult<bool> AddShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList)
        {
            if (shoppingCartItemList.Count(p => p.Quantity > 0) == 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
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
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId);
                if (item == null)
                {
                    shoppingList.Add(shoppingCartItem);
                    continue;
                }

                item.Quantity += shoppingCartItem.Quantity;
            }

            shoppingCart.ShoppingList = shoppingList;
            this.shoppingCartProvider.SaveShoppingCart(shoppingCart);
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = this.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;
            var totalfee = shoppingPrice + packagingFee;
            var canDelivery = totalfee >= supplier.DelMinOrderAmount;
            var deliveryMethodId = canDelivery ? ServicesCommon.PickUpDeliveryMethodId : order.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? totalfee + fixedDeliveryCharge
                        : totalfee;
            var coupon = 0;
            var customerTotal = total - coupon;

            order.CanDelivery = canDelivery;
            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = fixedDeliveryCharge;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;

            this.shoppingCartProvider.SaveShoppingCartOrder(order);


            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 删除商品信息
        /// </summary>
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
        public ServicesResult<bool> DeleteShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
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
                var item = shoppingList.FirstOrDefault(p => p.ItemId == shoppingCartItem.ItemId);
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

            shoppingCart.ShoppingList = shoppingList;
            this.shoppingCartProvider.SaveShoppingCart(shoppingCart);
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = this.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;
            var totalfee = shoppingPrice + packagingFee;
            var canDelivery = totalfee >= supplier.DelMinOrderAmount;
            var deliveryMethodId = canDelivery ? ServicesCommon.PickUpDeliveryMethodId : order.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? totalfee + fixedDeliveryCharge
                        : totalfee;
            var coupon = 0;
            var customerTotal = total - coupon;

            order.CanDelivery = canDelivery;
            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = fixedDeliveryCharge;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;

            this.shoppingCartProvider.SaveShoppingCartOrder(order);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
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
        public ServicesResult<bool> SaveShoppingCartCustomer(string id, int userId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(userId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode
                };
            }

            var customer = getShoppingCartCustomerResult.Result;
            shoppingCartLink.UserId = customer.UserId;
            this.shoppingCartProvider.SaveShoppingCartLink(shoppingCartLink);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
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
        public ServicesResult<bool> SaveShoppingCart(string id, ShoppingCartModel shoppingCart)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartDeliveryResult = this.shoppingCartProvider.GetShoppingCartDelivery(shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
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
            this.shoppingCartProvider.SaveShoppingCartDelivery(shoppingCart.Delivery);
            this.shoppingCartProvider.SaveShoppingCartOrder(shoppingCart.Order);
            this.shoppingCartProvider.SaveShoppingCart(shoppingCart.ShoppingCart);

            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartOrder">The shoppingCartOrder</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(string id, ShoppingCartOrder shoppingCartOrder)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var supplier = getShoppingCartSupplierResult.Result;
            var order = getShoppingCartOrderResult.Result;

            var now = DateTime.Now;
            var deliveryDate = (shoppingCartOrder.DeliveryDate ?? now).ToString("yyyy-MM-dd");
            DateTime deliveryTimeTemp;
            if (!DateTime.TryParse(string.Format("{0} {1}", deliveryDate, shoppingCartOrder.DeliveryTime), out deliveryTimeTemp))
            {
                deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now);
            }

            if (order.DeliveryType == ServicesCommon.QuickDeliveryType)
            {
                deliveryTimeTemp = (shoppingCartOrder.DeliveryDate ?? now);
            }

            var deliveryMethodId = shoppingCartOrder.DeliveryMethodId ?? ServicesCommon.DefaultDeliveryMethodId;
            var deliveryTime = this.GetDeliveryDate(deliveryMethodId, shoppingCartOrder.DeliveryType, deliveryTimeTemp, supplier.DeliveryTime);
            if (deliveryTime < now.AddMinutes(ServicesCommon.MinDeliveryHours))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            var shoppingPrice = shoppingList.Sum(p => p.Quantity * p.Price);
            var packagingFee = this.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;

            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? shoppingPrice + packagingFee + fixedDeliveryCharge
                        : shoppingPrice + packagingFee;
            var coupon = 0;
            var customerTotal = total - coupon;

            shoppingCartOrder.Id = order.Id;
            shoppingCartOrder.OrderId = order.OrderId;
            shoppingCartOrder.CanDelivery = order.CanDelivery;
            shoppingCartOrder.DeliveryDateTime = deliveryTime;
            shoppingCartOrder.DeliveryMethodId = deliveryMethodId;
            shoppingCartOrder.TotalPrice = shoppingPrice;
            shoppingCartOrder.FixedDeliveryFee = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId ? fixedDeliveryCharge : 0;
            shoppingCartOrder.PackagingFee = packagingFee;
            shoppingCartOrder.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            shoppingCartOrder.TotalFee = total;
            shoppingCartOrder.CustomerTotalFee = customerTotal;
            shoppingCartOrder.CouponFee = coupon;

            this.shoppingCartProvider.SaveShoppingCartOrder(shoppingCartOrder);

            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// Saves the shopping cart delivery.
        /// </summary>
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
        public ServicesResult<bool> SaveShoppingCartDelivery(string id, ShoppingCartDelivery shoppingCartDelivery)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartDeliveryResult = this.shoppingCartProvider.GetShoppingCartDelivery(shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode
                };
            }

            shoppingCartDelivery.Id = getShoppingCartDeliveryResult.Result.Id;
            this.shoppingCartProvider.SaveShoppingCartDelivery(shoppingCartDelivery);

            return new ServicesResult<bool>
            {
                Result = true
            };

        }

        /// <summary>
        /// 更改购物车送餐方式
        /// </summary>
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
        public ServicesResult<bool> SaveShoppingCartOrderDeliveryMethod(string id, int deliveryMethodId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(id);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartResult.StatusCode
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
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
            var packagingFee = this.GetPackagingFee(supplier.IsPackLadder, supplier.PackagingFee, supplier.PackLadder, shoppingList.Select(p => new PackagingFeeItem
            {
                PackagingFee = p.PackagingFee,
                Price = p.Price,
                Quantity = p.Quantity
            }).ToList());

            var fixedDeliveryCharge = supplier.FreeDeliveryLine <= shoppingPrice
                                          ? 0
                                         : supplier.FixedDeliveryCharge;

            var total = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                        ? shoppingPrice + packagingFee + fixedDeliveryCharge
                        : shoppingPrice + packagingFee;
            var coupon = 0;
            var customerTotal = total - coupon;

            order.DeliveryMethodId = deliveryMethodId;
            order.TotalPrice = shoppingPrice;
            order.FixedDeliveryFee = deliveryMethodId != ServicesCommon.PickUpDeliveryMethodId ? fixedDeliveryCharge : 0;
            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;
            order.CouponFee = coupon;

            this.shoppingCartProvider.SaveShoppingCartOrder(order);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 计算打包费
        /// </summary>
        /// <param name="packageWay">是否阶梯打包</param>
        /// <param name="supplierPack">餐厅打包费</param>
        /// <param name="packLadder">阶梯打包费</param>
        /// <param name="dishList">菜品信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private decimal GetPackagingFee(bool packageWay, decimal supplierPack, decimal packLadder, List<PackagingFeeItem> dishList)
        {
            var totalPrice = dishList.Sum(item => item.Price * item.Quantity);
            if (totalPrice <= 0)
            {
                return 0;
            }

            if (!packageWay)
            {
                var fee = dishList.Sum(item => item.PackagingFee * item.Quantity);
                return fee;
            }

            if (packLadder == 0)
            {
                return supplierPack;
            }

            long x;
            var y = Math.DivRem((long)totalPrice, (long)packLadder, out x);
            return (y + 1) * supplierPack;
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
        /// 创建者：周超
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
    }
}
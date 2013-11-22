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

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = shoppingCartId,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order
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
        public ServicesResult<ShoppingCartModel> CreateShoppingCart(int supplierId, int? userId)
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

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(supplierId);
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

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = shoppingCartOrder;
            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = shoppingCartLinkId,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order
                }
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
        public ServicesResult<ShoppingCartModel> SaveShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList)
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

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var shoppingList = getShoppingCartResult.Result.ShoppingList ?? new List<ShoppingCartItem>();
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

            var total = order.DeliveryMethodId != null && order.DeliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                    ? shoppingPrice + packagingFee + fixedDeliveryCharge
                    : shoppingPrice + packagingFee;
            var customerTotal = order.DeliveryMethodId != null && order.DeliveryMethodId != ServicesCommon.PickUpDeliveryMethodId
                    ? shoppingPrice + packagingFee + fixedDeliveryCharge
                    : shoppingPrice + packagingFee;

            order.PackagingFee = packagingFee;
            order.TotalQuantity = shoppingList.Sum(p => p.Quantity);
            order.TotalFee = total;
            order.CustomerTotalFee = customerTotal;

            this.shoppingCartProvider.SaveShoppingCartOrder(order);
            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = id,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order
                }
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
        public ServicesResult<ShoppingCartModel> SaveShoppingCartCustomer(string id, int userId)
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

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(userId);
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

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;

            this.shoppingCartProvider.SaveShoppingCartLink(shoppingCartLink);
            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = id,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = order
                }
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
        public ServicesResult<ShoppingCartModel> SaveShoppingCartOrder(string id, ShoppingCartOrder shoppingCartOrder)
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

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;

            shoppingCartOrder.PackagingFee = order.PackagingFee;
            shoppingCartOrder.TotalQuantity = order.TotalQuantity;
            shoppingCartOrder.TotalFee = order.TotalFee;
            shoppingCartOrder.CustomerTotalFee = order.CustomerTotalFee;
            this.shoppingCartProvider.SaveShoppingCartOrder(shoppingCartOrder);

            return new ServicesResult<ShoppingCartModel>
            {
                Result = new ShoppingCartModel
                {
                    Id = id,
                    ShoppingCart = shoppingCart,
                    Supplier = supplier,
                    Customer = customer,
                    Order = shoppingCartOrder
                }
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
    }
}
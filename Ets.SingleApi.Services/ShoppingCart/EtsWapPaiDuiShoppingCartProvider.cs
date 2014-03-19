namespace Ets.SingleApi.Services
{
    using System;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：EtsWapPaiDuiShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapPaiDuiShoppingCartProvider : IEtsWapPaiDuiShoppingCartProvider
    {
        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 12:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 6:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段shoppingCartCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapPaiDuiShoppingCartCacheServices etsWapPaiDuiShoppingCartCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapPaiDuiShoppingCartProvider" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="etsWapPaiDuiShoppingCartCacheServices">The ets wap tang shi shopping cart cache services.</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapPaiDuiShoppingCartProvider(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            IEtsWapPaiDuiShoppingCartCacheServices etsWapPaiDuiShoppingCartCacheServices)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.etsWapPaiDuiShoppingCartCacheServices = etsWapPaiDuiShoppingCartCacheServices;
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(string source, int supplierId)
        {
            var shoppingCartCacheResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartSupplier(source, supplierId);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartSupplier>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCartSupplier = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                        where supplierEntity.SupplierId == supplierId
                                        select new ShoppingCartSupplier
                                        {
                                            SupplierId = supplierEntity.SupplierId,
                                            SupplierName = supplierEntity.SupplierName,
                                            Telephone = supplierEntity.Telephone,
                                            PackagingFee = supplierEntity.PackagingFee ?? 0,
                                            FixedDeliveryCharge = supplierEntity.FixedDeliveryCharge ?? 0,
                                            FreeDeliveryLine = supplierEntity.FreeDeliveryLine ?? 0,
                                            DelMinOrderAmount = supplierEntity.DelMinOrderAmount ?? 0,
                                            PackLadder = supplierEntity.PackLadder ?? 0
                                        }).FirstOrDefault();

            if (shoppingCartSupplier == null)
            {
                return new ServicesResult<ShoppingCartSupplier>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new ShoppingCartSupplier()
                };
            }

            this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartSupplier(source, shoppingCartSupplier);
            return new ServicesResult<ShoppingCartSupplier>
            {
                Result = shoppingCartSupplier
            };
        }

        /// <summary>
        /// 获取购物车顾客信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(string source, int? userId)
        {
            if (userId == null || userId.Value <= 0)
            {
                return new ServicesResult<ShoppingCartCustomer>
                    {
                        Result = new ShoppingCartCustomer()
                    };
            }

            var shoppingCartCacheResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartCustomer(source, userId.Value);
            if (shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var tempLogin = this.loginEntityRepository.EntityQueryable.Where(p => p.LoginId == userId && p.IsEnabled)
                .Select(p => new
                {
                    UserId = p.LoginId,
                    p.Username
                }).FirstOrDefault();

            if (tempLogin == null)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ShoppingCartCustomer()
                };
            }

            var tempCustomer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == userId)
                  .Select(p => new
                  {
                      UserId = p.LoginId,
                      p.CustomerId,
                      Telephone = p.Mobile,
                      p.Email,
                      p.Gender,
                      p.Forename,
                      p.Surname
                  }).FirstOrDefault();

            if (tempCustomer == null)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ShoppingCartCustomer()
                };
            }

            var customer = new ShoppingCartCustomer
            {
                UserId = tempCustomer.UserId ?? 0,
                Telephone = tempCustomer.Telephone,
                Email = tempCustomer.Email,
                CustomerId = tempCustomer.CustomerId,
                Gender = string.Equals(tempCustomer.Gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase) ? "1" : "0",
                Name = string.Format("{0}{1}", tempCustomer.Forename, tempCustomer.Surname),
                Username = tempLogin.Username
            };

            this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartCustomer(source, customer);
            return new ServicesResult<ShoppingCartCustomer>
            {
                Result = customer
            };
        }

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<EtsWapPaiDuiShoppingCart> GetShoppingCart(string source, string id)
        {
            var shoppingCartCacheResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCart(source, id);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapPaiDuiShoppingCart>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCart = new EtsWapPaiDuiShoppingCart
            {
                ShoppingCartId = id,
                IsActive = true
            };

            this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
            return new ServicesResult<EtsWapPaiDuiShoppingCart>
            {
                Result = shoppingCart
            };
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<EtsWapPaiDuiShoppingCartOrder> GetShoppingCartOrder(string source, string id)
        {
            var getShoppingCartOrderResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartOrder(source, id);
            return new ServicesResult<EtsWapPaiDuiShoppingCartOrder>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = getShoppingCartOrderResult.Result ?? new EtsWapPaiDuiShoppingCartOrder()
            };
        }

        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单配送信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartDelivery> GetShoppingCartDelivery(string source, string id)
        {
            var shoppingCartDeliveryResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartDelivery(source, id);
            return new ServicesResult<ShoppingCartDelivery>
            {
                StatusCode = shoppingCartDeliveryResult.StatusCode,
                Result = shoppingCartDeliveryResult.Result ?? new ShoppingCartDelivery()
            };
        }

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCart(string source, EtsWapPaiDuiShoppingCart shoppingCart)
        {
            var saveShoppingCartResult = this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartResult.StatusCode,
                Result = saveShoppingCartResult.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartOrder">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(string source, EtsWapPaiDuiShoppingCartOrder shoppingCartOrder)
        {
            var saveShoppingCartOrderResult = this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartOrder(source, shoppingCartOrder);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
            };
        }

        /// <summary>
        /// 保存订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartDelivery">订单配送信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartDelivery(string source, ShoppingCartDelivery shoppingCartDelivery)
        {
            var saveShoppingCartDeliveryResult = this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartDelivery(source, shoppingCartDelivery);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartDeliveryResult.StatusCode,
                Result = saveShoppingCartDeliveryResult.Result
            };
        }

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<EtsWapPaiDuiShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId)
        {
            var getShoppingCartLinkResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartLink(source, shoppingCartLinkId);
            return new ServicesResult<EtsWapPaiDuiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapPaiDuiShoppingCartLink()
            };
        }

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="anonymityId">匿名用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<EtsWapPaiDuiShoppingCartLink> GetShoppingCartLink(string source, int supplierId, string anonymityId)
        {
            var getShoppingCartLinkResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartLink(source, string.Format("{0}_{1}", anonymityId, supplierId));
            var shoppingCartLink = getShoppingCartLinkResult.Result ?? new EtsWapPaiDuiShoppingCartLink();
            var getShoppingCartOrderResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapPaiDuiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            if (getShoppingCartOrderResult.Result.IsComplete)
            {
                return new ServicesResult<EtsWapPaiDuiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            return new ServicesResult<EtsWapPaiDuiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapPaiDuiShoppingCartLink()
            };
        }

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartLink(string source, EtsWapPaiDuiShoppingCartLink shoppingCartLink)
        {
            var saveShoppingCartLinkResult = this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartLink(source, shoppingCartLink);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartLinkResult.StatusCode,
                Result = saveShoppingCartLinkResult.Result
            };
        }

        /// <summary>
        /// 更改支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank"></param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> ModifyOrderPaymentMethod(string source, string orderId, int paymentMethodId, string payBank)
        {
            var getShoppingCartOrderResult = this.etsWapPaiDuiShoppingCartCacheServices.GetShoppingCartOrder(source, orderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var order = getShoppingCartOrderResult.Result;
            order.PaymentMethodId = paymentMethodId;
            order.PayBank = payBank;

            var saveShoppingCartOrderResult = this.etsWapPaiDuiShoppingCartCacheServices.SaveShoppingCartOrder(source, order);

            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
            };
        }
    }
}
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
    /// 类名称：EtsWapTangShiShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapTangShiShoppingCartProvider : IEtsWapTangShiShoppingCartProvider
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
        private readonly IEtsWapTangShiShoppingCartCacheServices etsWapShoppingCartCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapTangShiShoppingCartProvider" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="etsWapShoppingCartCacheServices">The shoppingCartCacheServices</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapTangShiShoppingCartProvider(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            IEtsWapTangShiShoppingCartCacheServices etsWapShoppingCartCacheServices)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.etsWapShoppingCartCacheServices = etsWapShoppingCartCacheServices;
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
            var shoppingCartCacheResult = this.etsWapShoppingCartCacheServices.GetShoppingCartSupplier(source, supplierId);
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

            this.etsWapShoppingCartCacheServices.SaveShoppingCartSupplier(source, shoppingCartSupplier);
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

            var shoppingCartCacheResult = this.etsWapShoppingCartCacheServices.GetShoppingCartCustomer(source, userId.Value);
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

            this.etsWapShoppingCartCacheServices.SaveShoppingCartCustomer(source, customer);
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
        public ServicesResult<EtsWapTangShiShoppingCart> GetShoppingCart(string source, string id)
        {
            var shoppingCartCacheResult = this.etsWapShoppingCartCacheServices.GetShoppingCart(source, id);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapTangShiShoppingCart>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCart = new EtsWapTangShiShoppingCart
            {
                ShoppingCartId = id,
                IsActive = true
            };

            this.etsWapShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
            return new ServicesResult<EtsWapTangShiShoppingCart>
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
        public ServicesResult<EtsWapTangShiShoppingCartOrder> GetShoppingCartOrder(string source, string id)
        {
            var getShoppingCartOrderResult = this.etsWapShoppingCartCacheServices.GetShoppingCartOrder(source, id);
            return new ServicesResult<EtsWapTangShiShoppingCartOrder>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = getShoppingCartOrderResult.Result ?? new EtsWapTangShiShoppingCartOrder()
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
            var shoppingCartDeliveryResult = this.etsWapShoppingCartCacheServices.GetShoppingCartDelivery(source, id);
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
        public ServicesResult<bool> SaveShoppingCart(string source, EtsWapTangShiShoppingCart shoppingCart)
        {
            var saveShoppingCartResult = this.etsWapShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
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
        public ServicesResult<bool> SaveShoppingCartOrder(string source, EtsWapTangShiShoppingCartOrder shoppingCartOrder)
        {
            var saveShoppingCartOrderResult = this.etsWapShoppingCartCacheServices.SaveShoppingCartOrder(source, shoppingCartOrder);
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
            var saveShoppingCartDeliveryResult = this.etsWapShoppingCartCacheServices.SaveShoppingCartDelivery(source, shoppingCartDelivery);
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
        public ServicesResult<EtsWapTangShiShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartCacheServices.GetShoppingCartLink(source, shoppingCartLinkId);
            return new ServicesResult<EtsWapTangShiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapTangShiShoppingCartLink()
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
        public ServicesResult<EtsWapTangShiShoppingCartLink> GetShoppingCartLink(string source, int supplierId, string anonymityId)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartCacheServices.GetShoppingCartLink(source, string.Format("{0}_{1}", anonymityId, supplierId));
            var shoppingCartLink = getShoppingCartLinkResult.Result ?? new EtsWapTangShiShoppingCartLink();
            var getShoppingCartOrderResult = this.etsWapShoppingCartCacheServices.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapTangShiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            if (getShoppingCartOrderResult.Result.IsComplete)
            {
                return new ServicesResult<EtsWapTangShiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            return new ServicesResult<EtsWapTangShiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapTangShiShoppingCartLink()
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
        public ServicesResult<bool> SaveShoppingCartLink(string source, EtsWapTangShiShoppingCartLink shoppingCartLink)
        {
            var saveShoppingCartLinkResult = this.etsWapShoppingCartCacheServices.SaveShoppingCartLink(source, shoppingCartLink);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartLinkResult.StatusCode,
                Result = saveShoppingCartLinkResult.Result
            };
        }
    }
}

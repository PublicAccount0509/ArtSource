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
    /// 类名称：ShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartProvider : IShoppingCartProvider
    {
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
        /// 字段supplierFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 6:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository;

        /// <summary>
        /// 字段shoppingCartCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartCacheServices shoppingCartCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartProvider" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierFeatureEntityRepository">The supplierFeatureEntityRepository</param>
        /// <param name="shoppingCartCacheServices">The shoppingCartCacheServices</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartProvider(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository,
            IShoppingCartCacheServices shoppingCartCacheServices)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierFeatureEntityRepository = supplierFeatureEntityRepository;
            this.shoppingCartCacheServices = shoppingCartCacheServices;
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(int supplierId)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCartSupplier(supplierId);
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

            shoppingCartSupplier.IsPackLadder = this.supplierFeatureEntityRepository.EntityQueryable.Any(p => p.Supplier.SupplierId == supplierId && p.IsEnabled == true && p.Feature.FeatureId == ServicesCommon.PackageFeatureId);
            this.shoppingCartCacheServices.SaveShoppingCartSupplier(shoppingCartSupplier);
            return new ServicesResult<ShoppingCartSupplier>
            {
                Result = shoppingCartSupplier
            };
        }

        /// <summary>
        /// 获取购物车顾客信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(int userId)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCartCustomer(userId);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCartCustomer>
                {
                    Result = shoppingCartCacheResult.Result
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
                Name = string.Format("{0}{1}", tempCustomer.Forename, tempCustomer.Surname)
            };

            this.shoppingCartCacheServices.SaveShoppingCartCustomer(customer);
            return new ServicesResult<ShoppingCartCustomer>
            {
                Result = customer
            };
        }

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCart> GetShoppingCart(string id)
        {
            var shoppingCartCacheResult = this.shoppingCartCacheServices.GetShoppingCart(id);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<ShoppingCart>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCart = new ShoppingCart
            {
                ShoppingCartId = id,
                IsActive = true
            };

            this.shoppingCartCacheServices.SaveShoppingCart(shoppingCart);
            return new ServicesResult<ShoppingCart>
            {
                Result = shoppingCart
            };
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartOrder> GetShoppingCartOrder(string id)
        {
            var getShoppingCartOrderResult = this.shoppingCartCacheServices.GetShoppingCartOrder(id);
            return new ServicesResult<ShoppingCartOrder>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = getShoppingCartOrderResult.Result ?? new ShoppingCartOrder()
            };
        }

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            var saveShoppingCartResult = this.shoppingCartCacheServices.SaveShoppingCart(shoppingCart);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartResult.StatusCode,
                Result = saveShoppingCartResult.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartOrder">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartOrder(ShoppingCartOrder shoppingCartOrder)
        {
            var saveShoppingCartOrderResult = this.shoppingCartCacheServices.SaveShoppingCartOrder(shoppingCartOrder);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
            };
        }

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartLink> GetShoppingCartLink(string shoppingCartLinkId)
        {
            var getShoppingCartLinkResult = this.shoppingCartCacheServices.GetShoppingCartLink(shoppingCartLinkId);
            return new ServicesResult<ShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new ShoppingCartLink()
            };
        }

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartLink(ShoppingCartLink shoppingCartLink)
        {
            var saveShoppingCartLinkResult = this.shoppingCartCacheServices.SaveShoppingCartLink(shoppingCartLink);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartLinkResult.StatusCode,
                Result = saveShoppingCartLinkResult.Result
            };
        }

        /// <summary>
        /// 将订单状态设置为完成状态
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CompleteShoppingCartOrder(string orderId)
        {
            var getShoppingCartOrderResult = this.shoppingCartCacheServices.GetShoppingCartOrder(orderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode
                };
            }

            var order = getShoppingCartOrderResult.Result;
            order.IsComplete = true;
            var saveShoppingCartOrderResult = this.shoppingCartCacheServices.SaveShoppingCartOrder(order);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
            };
        }
    }
}

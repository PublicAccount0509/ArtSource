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
    /// 类名称：EtsWapDingTaiShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCartProvider : IEtsWapDingTaiShoppingCartProvider
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
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 6:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository;

        /// <summary>
        /// 字段shoppingCartCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapDingTaiShoppingCartCacheServices etsWapDingTaiShoppingCartCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapDingTaiShoppingCartProvider" /> class.
        /// </summary>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="deskTypeEntityRepository">The deskTypeEntityRepositoryDefault documentation</param>
        /// <param name="etsWapDingTaiShoppingCartCacheServices">The ets wap tang shi shopping cart cache services.</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapDingTaiShoppingCartProvider(
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository,
            IEtsWapDingTaiShoppingCartCacheServices etsWapDingTaiShoppingCartCacheServices)
        {
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.deskTypeEntityRepository = deskTypeEntityRepository;
            this.etsWapDingTaiShoppingCartCacheServices = etsWapDingTaiShoppingCartCacheServices;
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
            var shoppingCartCacheResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartSupplier(source, supplierId);
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

            this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartSupplier(source, shoppingCartSupplier);
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

            var shoppingCartCacheResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartCustomer(source, userId.Value);
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

            this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartCustomer(source, customer);
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
        public ServicesResult<EtsWapDingTaiShoppingCart> GetShoppingCart(string source, string id)
        {
            var shoppingCartCacheResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCart(source, id);
            if (shoppingCartCacheResult != null && shoppingCartCacheResult.StatusCode == (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCart>
                {
                    Result = shoppingCartCacheResult.Result
                };
            }

            var shoppingCart = new EtsWapDingTaiShoppingCart
            {
                ShoppingCartId = id,
                IsActive = true
            };

            this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
            return new ServicesResult<EtsWapDingTaiShoppingCart>
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
        public ServicesResult<EtsWapDingTaiShoppingCartOrder> GetShoppingCartOrder(string source, string id)
        {
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartOrder(source, id);
            return new ServicesResult<EtsWapDingTaiShoppingCartOrder>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = getShoppingCartOrderResult.Result ?? new EtsWapDingTaiShoppingCartOrder()
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
            var shoppingCartDeliveryResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartDelivery(source, id);
            return new ServicesResult<ShoppingCartDelivery>
            {
                StatusCode = shoppingCartDeliveryResult.StatusCode,
                Result = shoppingCartDeliveryResult.Result ?? new ShoppingCartDelivery()
            };
        }

        /// <summary>
        /// 获取订单台位信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单台位信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ShoppingCartDesk> GetShoppingCartDesk(string source, string id)
        {
            var shoppingCartDeskCacheResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartDesk(source, id);

            var shoppingCartDeskCache = shoppingCartDeskCacheResult.Result;

            if (shoppingCartDeskCache == null)
            {
                return new ServicesResult<ShoppingCartDesk>
                    {
                        StatusCode = shoppingCartDeskCacheResult.StatusCode,
                        Result =  new ShoppingCartDesk()
                    };
            }

            if (shoppingCartDeskCache.DeskTypeId == 0)
            {
                return new ServicesResult<ShoppingCartDesk>
                    {
                        StatusCode = shoppingCartDeskCacheResult.StatusCode,
                        Result = shoppingCartDeskCache
                    };
            }

            var deskType = (from deskTypeEntity in this.deskTypeEntityRepository.EntityQueryable
                            where deskTypeEntity.Id == shoppingCartDeskCache.DeskTypeId
                            select new ShoppingCartDesk
                                {
                                    DeskTypeId = deskTypeEntity.Id,
                                    RoomType = deskTypeEntity.RoomType,
                                    TblTypeId = deskTypeEntity.TableType == null ? 0 : deskTypeEntity.TableType.Id,
                                    TblTypeName = deskTypeEntity.TableType == null ? string.Empty : deskTypeEntity.TableType.TblTypeName,
                                    MaxNumber = deskTypeEntity.MaxNumber,
                                    MinNumber = deskTypeEntity.MinNumber,
                                    LowCost = deskTypeEntity.LowCost,
                                    DepositAmount = deskTypeEntity.DepositAmount
                                }).FirstOrDefault();

            if (deskType != null)
            {
                shoppingCartDeskCache.RoomType = deskType.RoomType;
                shoppingCartDeskCache.TblTypeId = deskType.TblTypeId;
                shoppingCartDeskCache.TblTypeName = deskType.TblTypeName;
                shoppingCartDeskCache.MaxNumber = deskType.MaxNumber;
                shoppingCartDeskCache.MinNumber = deskType.MinNumber;
                shoppingCartDeskCache.LowCost = deskType.LowCost;
                shoppingCartDeskCache.DepositAmount = deskType.DepositAmount;
            }

            return new ServicesResult<ShoppingCartDesk>
            {
                StatusCode = shoppingCartDeskCacheResult.StatusCode,
                Result = shoppingCartDeskCache
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
        public ServicesResult<bool> SaveShoppingCart(string source, EtsWapDingTaiShoppingCart shoppingCart)
        {
            var saveShoppingCartResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCart(source, shoppingCart);
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
        public ServicesResult<bool> SaveShoppingCartOrder(string source, EtsWapDingTaiShoppingCartOrder shoppingCartOrder)
        {
            var saveShoppingCartOrderResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartOrder(source, shoppingCartOrder);
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
            var saveShoppingCartDeliveryResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartDelivery(source, shoppingCartDelivery);
            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartDeliveryResult.StatusCode,
                Result = saveShoppingCartDeliveryResult.Result
            };
        }

        /// <summary>
        /// 保存订单台位信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartDesk">台位信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 11:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveShoppingCartDesk(string source, ShoppingCartDesk shoppingCartDesk)
        {
            var saveShoppingCartDeskResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartDesk(source,
                                                                                                              shoppingCartDesk);
            return new ServicesResult<bool>
                {
                    StatusCode = saveShoppingCartDeskResult.StatusCode,
                    Result = saveShoppingCartDeskResult.Result
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
        public ServicesResult<EtsWapDingTaiShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId)
        {
            var getShoppingCartLinkResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartLink(source, shoppingCartLinkId);
            return new ServicesResult<EtsWapDingTaiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapDingTaiShoppingCartLink()
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
        public ServicesResult<EtsWapDingTaiShoppingCartLink> GetShoppingCartLink(string source, int supplierId, string anonymityId)
        {
            var getShoppingCartLinkResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartLink(source, string.Format("{0}_{1}", anonymityId, supplierId));
            var shoppingCartLink = getShoppingCartLinkResult.Result ?? new EtsWapDingTaiShoppingCartLink();
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            if (getShoppingCartOrderResult.Result.IsComplete)
            {
                return new ServicesResult<EtsWapDingTaiShoppingCartLink>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = null
                };
            }

            return new ServicesResult<EtsWapDingTaiShoppingCartLink>
            {
                StatusCode = getShoppingCartLinkResult.StatusCode,
                Result = getShoppingCartLinkResult.Result ?? new EtsWapDingTaiShoppingCartLink()
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
        public ServicesResult<bool> SaveShoppingCartLink(string source, EtsWapDingTaiShoppingCartLink shoppingCartLink)
        {
            var saveShoppingCartLinkResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartLink(source, shoppingCartLink);
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
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartCacheServices.GetShoppingCartOrder(source, orderId);
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

            var saveShoppingCartOrderResult = this.etsWapDingTaiShoppingCartCacheServices.SaveShoppingCartOrder(source, order);

            return new ServicesResult<bool>
            {
                StatusCode = saveShoppingCartOrderResult.StatusCode,
                Result = saveShoppingCartOrderResult.Result
            };
        }
    }
}
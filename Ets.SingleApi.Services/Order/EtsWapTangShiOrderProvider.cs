using Ets.SingleApi.Model.Controller;

namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IExternalServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Services.ICacheServices;

    /// <summary>
    /// 类名称：EtsWapTangShiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：堂食订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/22/2013 3:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class EtsWapTangShiOrderProvider : TangShiOrderProvider
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierDishEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository;

        /// <summary>
        /// 字段tableReservationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TableReservationEntity> tableReservationEntityRepository;

        /// <summary>
        /// 字段paymentEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:30 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository;

        /// <summary>
        /// 字段orderDetailEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 4:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段etsWapShoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapTangShiShoppingCartProvider etsWapShoppingCartProvider;

        /// <summary>
        /// 字段shoppingCartBaseCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 4:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiOrderProvider" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// <param name="paymentRecordEntityRepository">The paymentRecordEntityRepository</param>
        /// <param name="orderDetailEntityRepository">The orderDetailEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// <param name="etsWapShoppingCartProvider">The shoppingCartProvider</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalService</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapTangShiOrderProvider(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository,
            INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository,
            IEtsWapTangShiShoppingCartProvider etsWapShoppingCartProvider,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices,
            ISingleApiOrdersExternalService singleApiOrdersExternalService, INHibernateRepository<CustomerEntity> customerEntityRepository, INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository)
            : base(orderNumberDtEntityRepository, singleApiOrdersExternalService)
        {
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.paymentRecordEntityRepository = paymentRecordEntityRepository;
            this.orderDetailEntityRepository = orderDetailEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.etsWapShoppingCartProvider = etsWapShoppingCartProvider;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 9:26 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank)
        {
            //获取ShoppingCartLink信息
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = false
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;

            //获取 订单信息
            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = false
                };
            }

            //订单信息
            var orderInfo = getShoppingCartOrderResult.Result;
            //修改 缓存订单支付方式
            var modifyOrderPaymentMethodResult = this.etsWapShoppingCartProvider.ModifyOrderPaymentMethod(source, orderInfo.Id, paymentMethodId, payBank);
            if (modifyOrderPaymentMethodResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = modifyOrderPaymentMethodResult.StatusCode,
                    Result = false
                };
            }

            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 查询订单是否完成，订单是否已支付
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <returns>
        /// ServicesResult{OrderIsCompleteIsPaidModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 8:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId)
        {
            //获取ShoppingCartLink信息
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;

            //获取 订单信息
            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            var tableReservationEntity = this.tableReservationEntityRepository.EntityQueryable.FirstOrDefault(c => c.OrderNumber == getShoppingCartOrderResult.Result.OrderId);
            if (tableReservationEntity == null)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            return new ServicesResult<OrderShoppingCartStatusModel>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = new OrderShoppingCartStatusModel
                    {
                        IsComplete = getShoppingCartOrderResult.Result.IsComplete,
                        IsPaid = tableReservationEntity.IsPaId ?? false,
                        OrderStatusId = tableReservationEntity.TableStatus ?? -1
                    }
            };
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId)
        {
            var tableReservationEntity = (from entity in this.tableReservationEntityRepository.EntityQueryable
                                          where entity.OrderNumber == orderId
                                          select entity).FirstOrDefault();

            if (tableReservationEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
            }

            var waiMaiOrderDishList = (from entity in this.orderDetailEntityRepository.EntityQueryable
                                       where entity.OrderId == tableReservationEntity.TableReservationId
                                       select new TangShiOrderDishModel
                                               {
                                                   SupplierDishId = entity.SupplierDishId ?? 0,
                                                   SupplierDishName = entity.SupplierDishName,
                                                   Instruction = entity.SpecialInstruction,
                                                   Price = entity.SupplierPrice,
                                                   Quantity = entity.Quantity ?? 0
                                               }).ToList();

            var supplierId = tableReservationEntity.Supplier.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new TangShiOrderDetailModel()
                };
            }

            decimal baIduLat;
            decimal.TryParse(supplierEntity.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(supplierEntity.BaIduLong, out baIduLong);
            var tableReservationId = tableReservationEntity.TableReservationId.ToString();
            var paymentEntity = this.paymentRecordEntityRepository.EntityQueryable.FirstOrDefault(p => p.OrderId == tableReservationId);
            var gender = tableReservationEntity.Contactsex;
            if (gender.IsEmptyOrNull())
            {
                gender = ServicesCommon.DefaultGender.ToString();
            }

            if (string.Equals(gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase)
                || string.Equals(gender, "1", StringComparison.OrdinalIgnoreCase))
            {
                gender = "1";
            }
            else
            {
                gender = "0";
            }

            //总价 未折扣
            var total = tableReservationEntity.Total ?? 0;
            //总价 折扣后
            var customerTotal = tableReservationEntity.CustomerTotal ?? 0;
            //折扣
            var coupon = Math.Max(total - customerTotal, 0);

            var shoppingCartResult = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            var shoppingCartId = shoppingCartResult == null ? string.Empty : shoppingCartResult.Result;

            var result = new TangShiOrderDetailModel
            {
                ShoppingCartId = shoppingCartId,
                OrderId = tableReservationEntity.OrderNumber.HasValue ? tableReservationEntity.OrderNumber.Value : 0,
                OrderTypeId = (int)OrderType.TangShi,
                OrderStatusId = tableReservationEntity.TableStatus,
                DateReserved = tableReservationEntity.DateReserved.ToString("yyyy-MM-dd HH:mm"),
                Description = tableReservationEntity.Notes ?? string.Empty,
                SupplierGroupId = supplierEntity.SupplierGroupId,
                SupplierId = supplierEntity.SupplierId,
                SupplierName = supplierEntity.SupplierName ?? string.Empty,
                SupplierTelephone = supplierEntity.Telephone ?? string.Empty,
                SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
                SupplierBaIduLat = baIduLat,
                SupplierBaIduLong = baIduLong,
                InvoiceTitle = tableReservationEntity.InvoiceTitle ?? string.Empty,
                IsPaid = tableReservationEntity.IsPaId ?? false,
                DishList = waiMaiOrderDishList,
                PaymentMethodId = paymentEntity == null ? null : paymentEntity.PaymentMethodId,
                IsConfirm = paymentEntity != null,
                ContactName = tableReservationEntity.ContactName,
                ContactNumber = tableReservationEntity.ContactNumber,
                Contactsex = gender,
                TabelNo =tableReservationEntity.TabelNo,
                TeaBitFee = (tableReservationEntity.TeaBitFee ?? 0).ToString("#0.00"),
                ServiceFee = (tableReservationEntity.ConsumerAmount ?? 0).ToString("#0.00"),
                Coupon = coupon.ToString("#0.00"),//折扣
                CustomerTotal = customerTotal.ToString("#0.00"),//总价 折扣后
                Total = total.ToString("#0.00")//总价 未折扣
            };

            if (result.InvoiceTitle.IsEmptyOrNull())
            {
                result.InvoiceTitle = ServicesCommon.EmptyInvoiceTitle;
            }

            return new ServicesResult<IOrderDetailModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public override ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey, string appPassword)
        {
            var getShoppingCartLinkResult = this.etsWapShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartSupplierResult = this.etsWapShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartCustomerResult = this.etsWapShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartOrderResult = this.etsWapShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartDeliveryResult = this.etsWapShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;

            var shoppingCartBase = this.shoppingCartBaseCacheServices.GetShoppingCartBase(source, shoppingCartId);
            if (shoppingCartBase.Result.IsComplete)
            {
                return new ServicesResult<string>
                    {
                        Result = shoppingCartBase.Result.OrderNumber.ToString()
                    };
            }

            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            if (shoppingList.Count == 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode,
                    Result = string.Empty
                };
            }

            var supplierId = supplier.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            var orderId = shoppingCartBase.Result.OrderNumber <= 0 ? this.GetOrderNumberId(source, appKey, appPassword) : shoppingCartBase.Result.OrderNumber;
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var customerId = customer.CustomerId;
            var tableReservationId = this.SaveTableReservationEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order);
            this.SaveOrderDetailEntity(customerId, tableReservationId, shoppingList);
            this.SavePaymentEntity(tableReservationId, order.CustomerTotalFee, order.PaymentMethodId, order.PayBank);

            this.shoppingCartBaseCacheServices.SaveShoppingCartId(source, orderId, shoppingCartId);
            this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, true);
            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// 保存堂食订单信息
        /// </summary>
        /// <param name="tangShiOrdersParameter">The tangShiOrdersParameter</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// 保存堂食订单信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public override ServicesResult<string> SaveTempOrder(SaveTangShiOrdersParameter tangShiOrdersParameter, string appKey, string appPassword)
        {
            if (tangShiOrdersParameter == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            var orderId = this.GetOrderNumberId(tangShiOrdersParameter.Source, appKey, appPassword);
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == tangShiOrdersParameter.SupplierID);
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.FirstOrDefault(p => p.LoginId == supplierEntity.Login.LoginId);
            if (customer == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.NotFoundCustomerId,
                    Result = string.Empty
                };
            }

            var supplierDishIdList = tangShiOrdersParameter.SupplierDishList.Select(p => p.SupplierDishId).Distinct().Cast<int?>().ToList();
            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == tangShiOrdersParameter.SupplierID
                                          && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                          && supplierDishIdList.Contains(supplierDishEntity.SupplierDishId)
                                    select new
                                    {
                                        supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId,
                                        supplierDishEntity.SupplierDishName,
                                        supplierDishEntity.SuppllierDishDescription,
                                        supplierDishEntity.SpicyLevel,
                                        supplierDishEntity.AverageRating,
                                        supplierDishEntity.IsCommission,
                                        supplierDishEntity.IsDiscount,
                                        supplierDishEntity.Recipe,
                                        supplierDishEntity.Recommended,
                                        supplierDishEntity.PackagingFee,
                                        SupplierId =
                                    supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var dishlist = (from supplierdish in supplierDishList
                            select new SupplierDish
                                {
                                    SupplierDishId = supplierdish.SupplierDishId,
                                    SupplierDishName = supplierdish.SupplierDishName,
                                    SuppllierDishDescription = supplierdish.SuppllierDishDescription,
                                    Price = supplierdish.Price,
                                    DishCount = (from k in tangShiOrdersParameter.SupplierDishList
                                                 where k.SupplierDishId == supplierdish.SupplierDishId
                                                 select k.DishCount).FirstOrDefault()
                                }).ToList();

            var customerTotalFee = dishlist.Sum(supplierdish => (double)(supplierdish.Price * supplierdish.DishCount));

            var tableReservationId = this.SaveTempTableReservationEntity(orderId, customer.CustomerId, tangShiOrdersParameter);
            this.SaveTempOrderDetailEntity(customer.CustomerId, tableReservationId, dishlist);
            this.SavePaymentEntity(tableReservationId, (decimal) customerTotalFee,
                                   tangShiOrdersParameter.PayMentMethodId, string.Empty);

            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// Gets the type of the order source.
        /// </summary>
        /// <returns>
        /// The OrderSourceType
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 3:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override OrderSourceType GetOrderSourceType()
        {
            return OrderSourceType.EtsWap;
        }

        /// <summary>
        /// 保存自提订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="delivery">The delivery</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveTableReservationEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, EtsWapTangShiShoppingCartOrder order)
        {
            var tableReservationEntity = this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new TableReservationEntity
            {
                Supplier = new SupplierEntity
                    {
                        SupplierId = supplierId
                    },

                CustomerId = customerId,
                OrderNumber = orderId,
                TableStatus = 1,
                DateReserved = DateTime.Now,
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                IsAdd = false,
                IsDeal = true,
                Type = 1,
                IsReminder = true,
                IsService = true
            };

            tableReservationEntity.Notes = order.OrderInstruction;
            tableReservationEntity.CustomerTotal = order.CustomerTotalFee;
            tableReservationEntity.Total = order.TotalFee;
            tableReservationEntity.ConsumerAmount = order.ServiceFee;
            tableReservationEntity.TeaBitFee = order.TeaBitFee;
            tableReservationEntity.ModifyDate = DateTime.Now;
            tableReservationEntity.NumberOfPeople = order.DinnerNumber;
            tableReservationEntity.TabelNo = order.SeatNumber;
            tableReservationEntity.CouponCode = order.CouponCode;
            tableReservationEntity.ContactNumber = delivery.Telephone;
            tableReservationEntity.Contactsex = delivery.Gender;
            tableReservationEntity.ContactName = delivery.Name;
            tableReservationEntity.InvoiceRequired = order.InvoiceRequired;
            tableReservationEntity.InvoiceTitle = order.InvoiceTitle;
            tableReservationEntity.Path = order.Path;
            tableReservationEntity.TemplateId = order.Template;

            this.tableReservationEntityRepository.Save(tableReservationEntity);
            return tableReservationEntity.TableReservationId;
        }
        /// <summary>
        /// 保存堂食订单信息
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="tangShiOrdersParameter">The tangShiOrdersParameter</param>
        /// <returns>
        /// 保存堂食订单信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveTempTableReservationEntity(int orderId, int customerId, SaveTangShiOrdersParameter tangShiOrdersParameter)
        {
            var tableReservationEntity = this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new TableReservationEntity
            {
                Supplier = new SupplierEntity
                {
                    SupplierId = tangShiOrdersParameter.SupplierID
                },

                CustomerId = customerId,
                OrderNumber = orderId,
                TableStatus = 1,
                DateReserved = DateTime.Now,
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                IsAdd = false,
                IsDeal = true,
                Type = 1,
                IsReminder = true,
                IsService = true
            };

            tableReservationEntity.Notes = tangShiOrdersParameter.Remark + tangShiOrdersParameter.TempOrderNumber;
            //tableReservationEntity.CustomerTotal = order.CustomerTotalFee;
            //tableReservationEntity.Total = order.TotalFee;
            //tableReservationEntity.ConsumerAmount = order.ServiceFee;
            //tableReservationEntity.TeaBitFee = order.TeaBitFee;
            tableReservationEntity.ModifyDate = DateTime.Now;
            //tableReservationEntity.NumberOfPeople = order.DinnerNumber;
            tableReservationEntity.TabelNo = tangShiOrdersParameter.TableNo;
            //tableReservationEntity.CouponCode = order.CouponCode;
            //tableReservationEntity.ContactNumber = delivery.Telephone;
            tableReservationEntity.Contactsex = tangShiOrdersParameter.CustomerSex;
            tableReservationEntity.ContactName = tangShiOrdersParameter.CustomerName;
            //tableReservationEntity.InvoiceRequired = order.InvoiceRequired;
            //tableReservationEntity.InvoiceTitle = order.InvoiceTitle;
            tableReservationEntity.Path = tangShiOrdersParameter.Path;
            //tableReservationEntity.TemplateId = order.Template;

            this.tableReservationEntityRepository.Save(tableReservationEntity);
            return tableReservationEntity.TableReservationId;
        }
        /// <summary>
        /// 保存订单详情信息
        /// </summary>
        /// <param name="customerId">顾客Id</param>
        /// <param name="orderId">订单Id</param>
        /// <param name="shoppingList">商品列表</param>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveOrderDetailEntity(int customerId, int orderId, IEnumerable<ShoppingCartItem> shoppingList)
        {
            var removeOrderList = this.orderDetailEntityRepository.FindByExpression(p => p.CustomerId == customerId && p.OrderId == orderId).ToList();
            this.orderDetailEntityRepository.Remove(removeOrderList);

            var orderList = (from dish in shoppingList
                             select new OrderDetailEntity
                             {
                                 OrderId = orderId,
                                 CustomerId = customerId,
                                 SupplierDishId = dish.ItemId,
                                 Quantity = dish.Quantity,
                                 SupplierPrice = dish.Price,
                                 SupplierDishName = dish.ItemName,
                                 Total = dish.Price * dish.Quantity,
                                 SpecialInstruction = dish.Instruction,
                                 OrderDate = DateTime.Now,
                                 IsAdd = false,
                                 OrderType = 1
                             }).ToList();

            this.orderDetailEntityRepository.Save(orderList);
        }

        /// <summary>
        /// 保存订单菜品详细信息
        /// </summary>
        /// <param name="customerId">The customerId</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="supplierDishList">The supplierDishList</param>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 11:31 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveTempOrderDetailEntity(int customerId, int orderId, IEnumerable<SupplierDish> supplierDishList)
        {
            var removeOrderList = this.orderDetailEntityRepository.FindByExpression(p => p.CustomerId == customerId && p.OrderId == orderId).ToList();
            this.orderDetailEntityRepository.Remove(removeOrderList);

            //var supplierDishIdList = tangShiOrdersParameter.SupplierDishList.Select(p => p.SupplierDishId).Distinct().Cast<int?>().ToList();
            //var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
            //                        where supplierDishEntity.Supplier.SupplierId == tangShiOrdersParameter.SupplierID
            //                              && supplierDishEntity.Online && supplierDishEntity.IsDel == false
            //                              && supplierDishIdList.Contains(supplierDishEntity.SupplierDishId)
            //                        select new
            //                        {
            //                            supplierDishEntity.SupplierCategoryId,
            //                            supplierDishEntity.DishNo,
            //                            supplierDishEntity.Price,
            //                            supplierDishEntity.SupplierDishId,
            //                            supplierDishEntity.SupplierDishName,
            //                            supplierDishEntity.SuppllierDishDescription,
            //                            supplierDishEntity.SpicyLevel,
            //                            supplierDishEntity.AverageRating,
            //                            supplierDishEntity.IsCommission,
            //                            supplierDishEntity.IsDiscount,
            //                            supplierDishEntity.Recipe,
            //                            supplierDishEntity.Recommended,
            //                            supplierDishEntity.PackagingFee,
            //                            SupplierId =
            //                        supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
            //                            ImagePath = string.Empty,
            //                            DishCount = (from k in tangShiOrdersParameter.SupplierDishList 
            //                                         where k.SupplierDishId == supplierDishEntity.SupplierDishId 
            //                                         select k.DishCount).FirstOrDefault()
            //                        }).OrderBy(p => p.DishNo).ToList();

            var orderList = (from dish in supplierDishList
                             select new OrderDetailEntity
                             {
                                 OrderId = orderId,
                                 CustomerId = customerId,
                                 SupplierDishId = dish.SupplierDishId,
                                 Quantity = dish.DishCount,
                                 SupplierPrice = dish.Price,
                                 SupplierDishName = dish.SupplierDishName,
                                 Total = dish.Price * dish.DishCount,
                                 SpecialInstruction = dish.SuppllierDishDescription,
                                 OrderDate = DateTime.Now,
                                 IsAdd = false,
                                 OrderType = 1
                             }).ToList();

            this.orderDetailEntityRepository.Save(orderList);
        }

        /// <summary>
        /// 保存支付信息
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="customerTotal">支付总金额</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">The payBank</param>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePaymentEntity(int orderId, decimal customerTotal, int paymentMethodId, string payBank)
        {
            if (paymentMethodId <= 0)
            {
                return;
            }

            var tableReservationId = orderId.ToString();
            var paymentRecordEntity = this.paymentRecordEntityRepository.EntityQueryable.FirstOrDefault(p => p.OrderId == tableReservationId)
                                 ?? new PaymentRecordEntity
                                 {
                                     PaymentTypeId = 1,
                                     OrderId = tableReservationId,
                                     PaymentDate = DateTime.Now
                                 };

            paymentRecordEntity.Amount = customerTotal;
            paymentRecordEntity.OrderTypeId = 1; //订台 2 堂食 1
            paymentRecordEntity.PaymentMethodId = paymentMethodId;
            paymentRecordEntity.PayBank = payBank;
            this.paymentRecordEntityRepository.Save(paymentRecordEntity);
        }
    }
}

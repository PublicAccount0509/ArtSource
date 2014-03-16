﻿using Ets.SingleApi.Services.ICacheServices;

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

    /// <summary>
    /// 类名称：HaiDiLaoWaiMaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：海底捞外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/22/2013 3:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class HaiDiLaoWaiMaiOrderProvider : WaiMaiOrderProvider
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段sourcePathEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:30 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SourcePathEntity> sourcePathEntityRepository;

        /// <summary>
        /// 字段sourceTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:31 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository;

        /// <summary>
        /// 字段paymentEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:30 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentEntity> paymentEntityRepository;

        /// <summary>
        /// 字段supplierCommissionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:30 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCommissionEntity> supplierCommissionEntityRepository;

        /// <summary>
        /// 字段orderEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderEntity> orderEntityRepository;

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
        /// 字段customerAddressEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 6:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository;

        /// <summary>
        /// 字段deliveryAddressEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 6:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository;

        /// <summary>
        /// 字段packageSelectedEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/19/2013 11:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PackageSelectedEntity> packageSelectedEntityRepository;

        /// <summary>
        /// 字段packageSelectedDetailEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/19/2013 11:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PackageSelectedDetailEntity> packageSelectedDetailEntityRepository;

        /// <summary>
        /// 字段distance
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/5/2013 9:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IDistance distance;

        /// <summary>
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHaiDiLaoShoppingCartProvider haiDiLaoShoppingCartProvider;

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
        /// Initializes a new instance of the <see cref="HaiDiLaoWaiMaiOrderProvider" /> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="sourcePathEntityRepository">The sourcePathEntityRepository</param>
        /// <param name="sourceTypeEntityRepository">The sourceTypeEntityRepository</param>
        /// <param name="paymentEntityRepository">The paymentEntityRepository</param>
        /// <param name="supplierCommissionEntityRepository">The supplierCommissionEntityRepository</param>
        /// <param name="orderEntityRepository">The orderEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="deliveryAddressEntityRepository">The deliveryAddressEntityRepository</param>
        /// <param name="packageSelectedEntityRepository">The packageSelectedEntityRepository</param>
        /// <param name="packageSelectedDetailEntityRepository">The packageSelectedDetailEntityRepository</param>
        /// <param name="orderNumberDcEntityRepository">The orderNumberDcEntityRepository</param>
        /// <param name="distance">The distance</param>
        /// <param name="shoppingCartProvider">The shoppingCartProvider</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalService</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HaiDiLaoWaiMaiOrderProvider(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SourcePathEntity> sourcePathEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository,
            INHibernateRepository<PaymentEntity> paymentEntityRepository,
            INHibernateRepository<SupplierCommissionEntity> supplierCommissionEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository,
            INHibernateRepository<PackageSelectedEntity> packageSelectedEntityRepository,
            INHibernateRepository<PackageSelectedDetailEntity> packageSelectedDetailEntityRepository,
            INHibernateRepository<OrderNumberDcEntity> orderNumberDcEntityRepository,
            IDistance distance,
            IHaiDiLaoShoppingCartProvider shoppingCartProvider,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices,
            ISingleApiOrdersExternalService singleApiOrdersExternalService)
            : base(orderNumberDcEntityRepository, singleApiOrdersExternalService)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.sourcePathEntityRepository = sourcePathEntityRepository;
            this.sourceTypeEntityRepository = sourceTypeEntityRepository;
            this.paymentEntityRepository = paymentEntityRepository;
            this.supplierCommissionEntityRepository = supplierCommissionEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.deliveryAddressEntityRepository = deliveryAddressEntityRepository;
            this.packageSelectedEntityRepository = packageSelectedEntityRepository;
            this.packageSelectedDetailEntityRepository = packageSelectedDetailEntityRepository;
            this.distance = distance;
            this.haiDiLaoShoppingCartProvider = shoppingCartProvider;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
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
            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
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
            var modifyOrderPaymentMethodResult = this.haiDiLaoShoppingCartProvider.ModifyOrderPaymentMethod(source, orderInfo.Id, paymentMethodId, payBank);
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
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
            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            // Delivery信息
            var deliveryInfo =
                this.deliveryEntityRepository.EntityQueryable.FirstOrDefault(
                    c => c.OrderNumber == getShoppingCartOrderResult.Result.OrderId);

            if (deliveryInfo == null)
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
                    IsPaid = deliveryInfo.IsPaId ?? false,
                    OrderStatusId = deliveryInfo.OrderStatusId
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
            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new HaiDiLaoWaiMaiOrderDetailModel()
                };
            }

            var waiMaiOrderDishList = deliveryEntity.OrderList.Select(p => new HaiDiLaoWaiMaiOrderDishModel
            {
                SupplierDishId = p.SupplierDishId,
                SupplierDishName = p.SupplierDishName,
                Instruction = p.SpecialInstruction,
                Price = p.SupplierPrice,
                Quantity = p.Quantity,
                Type = 0,
                ParentId = 0
            }).ToList();

            var supplierId = deliveryEntity.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new HaiDiLaoWaiMaiOrderDetailModel()
                };
            }

            var packageList = (from entity in this.packageSelectedEntityRepository.EntityQueryable
                               where entity.Supplier.SupplierId == supplierId && entity.Delivery.DeliveryId == deliveryEntity.DeliveryId
                               select new HaiDiLaoWaiMaiOrderDishModel
                               {
                                   SupplierDishId = entity.Package.PackageId,
                                   SupplierDishName = entity.PackageName,
                                   Instruction = entity.Comment,
                                   Price = entity.PackagePrice,
                                   Quantity = entity.PackageNum,
                                   Type = 3,
                                   ParentId = 0
                               }).ToList();

            if (packageList.Count > 0)
            {
                waiMaiOrderDishList.AddRange(packageList);
            }

            var packageDetailList = (from entity in this.packageSelectedDetailEntityRepository.EntityQueryable
                                     where entity.DeliveryId == deliveryEntity.DeliveryId
                                     select new HaiDiLaoWaiMaiOrderDishModel
                                     {
                                         SupplierDishName = entity.DishName,
                                         Instruction = string.Empty,
                                         Price = entity.DishPrice,
                                         Quantity = entity.DishNum,
                                         Type = 0,
                                         ParentId = entity.PackageSelected.Package.PackageId
                                     }).ToList();

            if (packageDetailList.Count > 0)
            {
                waiMaiOrderDishList.AddRange(packageDetailList);
            }

            decimal baIduLat;
            decimal.TryParse(supplierEntity.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(supplierEntity.BaIduLong, out baIduLong);
            var paymentEntity = this.paymentEntityRepository.EntityQueryable.FirstOrDefault(p => p.Delivery.DeliveryId == deliveryEntity.DeliveryId);
            var deliveryAddressEntity = this.deliveryAddressEntityRepository.EntityQueryable.FirstOrDefault(p => p.DeliveryAddressId == deliveryEntity.DeliveryAddressId);
            var gender = deliveryEntity.Gender.IsEmptyOrNull()
                ? (deliveryAddressEntity == null ? ServicesCommon.DefaultGender : (deliveryAddressEntity.Sex ?? ServicesCommon.DefaultGender)).ToString()
                : deliveryEntity.Gender;

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

            var shoppingCartResult = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            var shoppingCartId = shoppingCartResult == null ? string.Empty : shoppingCartResult.Result;
            var result = new HaiDiLaoWaiMaiOrderDetailModel
            {
                ShoppingCartId = shoppingCartId,
                OrderId = deliveryEntity.OrderNumber.HasValue ? deliveryEntity.OrderNumber.Value : 0,
                OrderTypeId = (int)OrderType.WaiMai,
                OrderStatusId = deliveryEntity.OrderStatusId,
                DateReserved = deliveryEntity.DateAdded == null ? string.Empty : deliveryEntity.DateAdded.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryTime = deliveryEntity.DeliveryDate == null ? string.Empty : deliveryEntity.DeliveryDate.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryInstruction = deliveryEntity.DeliveryInstruction ?? string.Empty,
                CustomerTotal = (deliveryEntity.ReceivablePrice ?? 0).ToString("#0.00"),
                Total = (deliveryEntity.CustomerTotal ?? 0).ToString("#0.00"),
                DishTotal = (deliveryEntity.RealSupplierPrice ?? 0).ToString("#0.00"),
                CookingFee = ((deliveryEntity.CustomerTotal ?? 0) - (deliveryEntity.RealSupplierPrice ?? 0) - (deliveryEntity.ServiceFee ?? 0) - (deliveryEntity.DeliverCharge ?? 0)).ToString("#0.00"),
                Coupon = Math.Max(((deliveryEntity.CustomerTotal ?? 0) - (deliveryEntity.ReceivablePrice ?? 0)), 0).ToString("#0.00"),
                Commission = "0.00",
                RealSupplierType = deliveryEntity.RealSupplierType,
                SupplierGroupId = supplierEntity.SupplierGroupId,
                SupplierId = supplierEntity.SupplierId,
                SupplierName = supplierEntity.SupplierName ?? string.Empty,
                SupplierTelephone = supplierEntity.Telephone ?? string.Empty,
                SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
                SupplierFixedDeliveryFee = (supplierEntity.FixedDeliveryCharge ?? 0).ToString("#0.00"),
                SupplierBaIduLat = baIduLat,
                SupplierBaIduLong = baIduLong,
                DeliveryMethodId = deliveryEntity.DeliveryMethodId,
                InvoiceTitle = deliveryEntity.InvoiceTitle ?? string.Empty,
                IsPaid = deliveryEntity.IsPaId ?? false,
                DishList = waiMaiOrderDishList,
                PaymentMethodId = paymentEntity == null ? (int?)null : paymentEntity.PaymentMethodId,
                IsConfirm = paymentEntity != null,
                DeliveryAddress = deliveryAddressEntity == null ? string.Empty : string.Format("{0}{1}", deliveryAddressEntity.Address1, deliveryAddressEntity.Address2),
                DeliveryCustomerName = deliveryEntity.Contact.IsEmptyOrNull() ? (deliveryAddressEntity == null ? string.Empty : deliveryAddressEntity.Recipient) : deliveryEntity.Contact,
                DeliveryCustomerTelphone = deliveryEntity.ContactPhone.IsEmptyOrNull() ? (deliveryAddressEntity == null ? string.Empty : deliveryAddressEntity.Telephone) : deliveryEntity.ContactPhone,
                DeliveryCustomerGender = gender,
                ServicesFee = (deliveryEntity.ServiceFee ?? 0).ToString("#0.00"),
                FixedDeliveryFee = (deliveryEntity.DeliverCharge ?? 0).ToString("#0.00"),
                CookingCount = deliveryEntity.Stove ?? 0,
                PanCount = deliveryEntity.Pot ?? 0,
                DiningCount = deliveryEntity.NumOfPeople ?? 0,
                IsSelfPan = (deliveryEntity.ZBGD ?? 0) == 1,
                IsSelfDip = (deliveryEntity.ZBXL ?? 0) == 1
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
            var getShoppingCartLinkResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.haiDiLaoShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartSupplierResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartCustomerResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartOrderResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartDeliveryResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartDeliveryResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartExtraResult = this.haiDiLaoShoppingCartProvider.GetShoppingCartExtra(source, shoppingCartLink.ExtraId);
            if (getShoppingCartExtraResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartExtraResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var extra = getShoppingCartExtraResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            var deliveryTime = order.DeliveryDateTime;
            if (deliveryTime <= DateTime.Now)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode,
                    Result = string.Empty
                };
            }

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

            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == delivery.CustomerAddressId && p.CustomerId == customer.CustomerId);
            if (customerAddressEntity == null && order.DeliveryMethodId != ServicesCommon.PickUpDeliveryMethodId)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCustomerAddressIdCode,
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
            var deliveryId = order.DeliveryMethodId == ServicesCommon.PickUpDeliveryMethodId
                ? this.SavePickUpDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order, extra)
                : this.SaveDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order, extra);

            var totalFee = order.TotalFee - order.PackagingFee - order.FixedDeliveryFee;
            this.SaveSupplierCommission(deliveryId, totalFee, supplierEntity);
            this.SaveOrderEntity(customerId, deliveryId, shoppingList);
            this.SavePackageEntity(supplier.SupplierId, deliveryId, shoppingList);
            this.SavePaymentEntity(deliveryId, order.CustomerTotalFee, order.PaymentMethodId, order.PayBank);

            this.shoppingCartBaseCacheServices.SaveShoppingCartId(source, orderId, shoppingCartId);
            this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, true);
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
            return OrderSourceType.HaiDiLao;
        }

        /// <summary>
        /// 保存自提订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="delivery">The delivery</param>
        /// <param name="order">订单信息</param>
        /// <param name="extra">The extra</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SavePickUpDeliveryEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, HaiDiLaoShoppingCartOrder order, ShoppingCartExtra extra)
        {
            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new DeliveryEntity
            {
                SupplierId = supplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                IsPaId = false,
                IsRating = false,
                Cancelled = false
            };

            var userName = delivery.Name;
            var deliveryAddressEntity = this.deliveryAddressEntityRepository.FindSingleByExpression(p => p.DeliveryAddressId == deliveryEntity.DeliveryAddressId && p.IsDel == false) ?? new DeliveryAddressEntity
            {
                CustomerId = customerId,
                IsDel = false
            };

            var gender = string.Equals(delivery.Gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase);
            deliveryAddressEntity.Recipient = userName.IsEmptyOrNull() ? delivery.Name : userName;
            deliveryAddressEntity.Telephone = delivery.Telephone;
            deliveryAddressEntity.Sex = (gender || delivery.Gender == "1") ? 1 : 0;
            this.deliveryAddressEntityRepository.Save(deliveryAddressEntity);

            deliveryEntity.DeliveryMethodId = order.DeliveryMethodId;
            deliveryEntity.DeliveryInstruction = order.DeliveryInstruction;
            deliveryEntity.CustomerTotal = order.TotalFee;
            deliveryEntity.ReceivablePrice = order.CustomerTotalFee;
            deliveryEntity.Total = order.TotalPrice;
            deliveryEntity.RealSupplierPrice = order.TotalPrice - order.CouponFee;
            deliveryEntity.PackagingFee = order.PackagingFee;
            deliveryEntity.DeliverCharge = order.FixedDeliveryFee;
            deliveryEntity.ContactPhone = deliveryAddressEntity.Telephone;
            deliveryEntity.Gender = deliveryAddressEntity.Sex.ToString();
            deliveryEntity.Contact = deliveryAddressEntity.Recipient;
            deliveryEntity.DeliveryDate = order.DeliveryDateTime;
            deliveryEntity.Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Template);
            deliveryEntity.InvoiceRequired = order.InvoiceRequired;
            deliveryEntity.InvoiceTitle = order.InvoiceTitle;
            deliveryEntity.Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Path);
            deliveryEntity.OrderNotes = order.OrderNotes;
            deliveryEntity.AreaId = order.AreaId;
            deliveryEntity.IPAddress = delivery.IpAddress;
            deliveryEntity.IsTakeInvoice = order.IsTakeInvoice;
            deliveryEntity.ZBGD = order.IsSelfPan ? 1 : 0;
            deliveryEntity.ZBXL = order.IsSelfDip ? 1 : 0;
            deliveryEntity.ServiceFee = order.ServicesFee;
            deliveryEntity.Pot = extra.PanCount;
            deliveryEntity.Stove = extra.CookingCount;
            deliveryEntity.NumOfPeople = extra.DiningCount;
            deliveryEntity.DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId;
          
            this.deliveryEntityRepository.Save(deliveryEntity);
            return deliveryEntity.DeliveryId;
        }

        /// <summary>
        /// 保存送餐订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="delivery">The delivery</param>
        /// <param name="order">订单信息</param>
        /// <param name="extra">The extra</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveDeliveryEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, HaiDiLaoShoppingCartOrder order, ShoppingCartExtra extra)
        {
            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new DeliveryEntity
            {
                SupplierId = supplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                IsPaId = false,
                IsRating = false,
                Cancelled = false
            };

            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == delivery.CustomerAddressId && p.CustomerId == customerId);
            var deliveryAddressEntity = this.deliveryAddressEntityRepository.FindSingleByExpression(p => p.DeliveryAddressId == deliveryEntity.DeliveryAddressId && p.IsDel == false) ?? new DeliveryAddressEntity
            {
                CustomerId = customerId,
                IsDel = false
            };

            deliveryAddressEntity.Recipient = customerAddressEntity.Recipient;
            deliveryAddressEntity.AddressAlias = customerAddressEntity.AddressAlias;
            deliveryAddressEntity.Address1 = customerAddressEntity.Address1;
            deliveryAddressEntity.AddressBuilding = customerAddressEntity.AddressBuilding;
            deliveryAddressEntity.AddressDetail = customerAddressEntity.AddressDetail;
            deliveryAddressEntity.Address2 = customerAddressEntity.Address2;
            deliveryAddressEntity.CityId = customerAddressEntity.CityId;
            deliveryAddressEntity.CountyId = customerAddressEntity.CountyId;
            deliveryAddressEntity.CountryId = customerAddressEntity.CountryId;
            deliveryAddressEntity.Telephone = customerAddressEntity.Telephone;
            deliveryAddressEntity.Sex = customerAddressEntity.Sex;
            this.deliveryAddressEntityRepository.Save(deliveryAddressEntity);

            deliveryEntity.DeliveryMethodId = order.DeliveryMethodId;
            deliveryEntity.DeliveryInstruction = order.DeliveryInstruction;
            deliveryEntity.CustomerTotal = order.TotalFee;
            deliveryEntity.ReceivablePrice = order.CustomerTotalFee;
            deliveryEntity.Total = order.TotalPrice;
            deliveryEntity.RealSupplierPrice = order.TotalPrice - order.CouponFee;
            deliveryEntity.PackagingFee = order.PackagingFee;
            deliveryEntity.DeliverCharge = order.FixedDeliveryFee;
            deliveryEntity.ContactPhone = deliveryAddressEntity.Telephone;
            deliveryEntity.Gender = deliveryAddressEntity.Sex.ToString();
            deliveryEntity.Contact = deliveryAddressEntity.Recipient;
            deliveryEntity.DeliveryDate = order.DeliveryDateTime;
            deliveryEntity.Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Template);
            deliveryEntity.InvoiceRequired = order.InvoiceRequired;
            deliveryEntity.InvoiceTitle = order.InvoiceTitle;
            deliveryEntity.Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Path);
            deliveryEntity.OrderNotes = order.OrderNotes;
            deliveryEntity.AreaId = order.AreaId;
            deliveryEntity.IPAddress = delivery.IpAddress;
            deliveryEntity.IsTakeInvoice = order.IsTakeInvoice;
            deliveryEntity.ZBGD = order.IsSelfPan ? 1 : 0;
            deliveryEntity.ZBXL = order.IsSelfDip ? 1 : 0;
            deliveryEntity.ServiceFee = order.ServicesFee;
            deliveryEntity.Pot = extra.PanCount;
            deliveryEntity.Stove = extra.CookingCount;
            deliveryEntity.NumOfPeople = extra.DiningCount;
            deliveryEntity.DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId;

            //计算送餐距离
            var supplierLocation = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId)
                  .Select(p => new { p.BaIduLat, p.BaIduLong })
                  .FirstOrDefault();

            if (supplierLocation == null)
            {
                this.deliveryEntityRepository.Save(deliveryEntity);
                return deliveryEntity.DeliveryId;
            }

            var customerLocation = distance.GetLocation(string.Format("{0}{1}", customerAddressEntity.Address1, customerAddressEntity.AddressBuilding), string.Empty);
            if (customerLocation == null)
            {
                this.deliveryEntityRepository.Save(deliveryEntity);
                return deliveryEntity.DeliveryId;
            }

            double baIduLat;
            double baIduLong;
            double.TryParse(supplierLocation.BaIduLat, out baIduLat);
            double.TryParse(supplierLocation.BaIduLong, out baIduLong);

            deliveryEntity.Lat = customerLocation.Lat;
            deliveryEntity.Lng = customerLocation.Lng;
            deliveryEntity.DeliveryDistance = distance.GetDistance(customerLocation, new Location { Lat = baIduLat, Lng = baIduLong }, GaussSphere.Beijing54);
            this.deliveryEntityRepository.Save(deliveryEntity);
            return deliveryEntity.DeliveryId;
        }

        /// <summary>
        /// 保存餐厅佣金信息
        /// </summary>
        /// <param name="deliveryId">订单Id</param>
        /// <param name="totalFee">总费用</param>
        /// <param name="supplierEntity">餐厅信息</param>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveSupplierCommission(int deliveryId, decimal totalFee, SupplierEntity supplierEntity)
        {
            var supplierCommissionEntity = this.supplierCommissionEntityRepository.FindSingleByExpression(p => p.Supplier.SupplierId == supplierEntity.SupplierId && p.DeliveryId == deliveryId) ?? new SupplierCommissionEntity
            {
                Supplier = supplierEntity,
                DeliveryId = deliveryId,
                Canncelled = false,
                DateAdded = DateTime.Now
            };

            supplierCommissionEntity.Total = totalFee;
            supplierCommissionEntity.Commission = totalFee * (supplierEntity.CashCommisionFee ?? 0);
            this.supplierCommissionEntityRepository.Save(supplierCommissionEntity);
        }

        /// <summary>
        /// 保存订单详情信息
        /// </summary>
        /// <param name="customerId">顾客Id</param>
        /// <param name="deliveryId">订单Id</param>
        /// <param name="shoppingList">商品列表</param>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveOrderEntity(int customerId, int deliveryId, IEnumerable<ShoppingCartItem> shoppingList)
        {
            var removeOrderList = this.orderEntityRepository.FindByExpression(p => p.CustomerId == customerId && p.Delivery.DeliveryId == deliveryId).ToList();
            this.orderEntityRepository.Remove(removeOrderList);

            var typeList = new List<int> { 0, 1, 2 };
            var orderList = (from dish in shoppingList.Where(p => typeList.Contains(p.Type) && p.ParentId == 0)
                             select new OrderEntity
                             {
                                 Delivery = new DeliveryEntity
                                     {
                                         DeliveryId = deliveryId
                                     },
                                 CustomerId = customerId,
                                 SupplierDishId = dish.ItemId,
                                 Quantity = dish.Quantity,
                                 SupplierPrice = dish.Price,
                                 SupplierDishName = dish.ItemName,
                                 Total = dish.Price * dish.Quantity,
                                 SpecialInstruction = dish.Instruction,
                                 OrderDate = DateTime.Now
                             }).ToList();

            this.orderEntityRepository.Save(orderList);
        }

        /// <summary>
        /// 保存订单套餐信息
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryId">订单Id</param>
        /// <param name="shoppingList">商品列表</param>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePackageEntity(int supplierId, int deliveryId, List<ShoppingCartItem> shoppingList)
        {
            var removePackageSelectedDetailList = this.packageSelectedDetailEntityRepository.FindByExpression(p => p.DeliveryId == deliveryId).ToList();
            this.packageSelectedDetailEntityRepository.Remove(removePackageSelectedDetailList);

            var removePackageSelectedList = this.packageSelectedEntityRepository.FindByExpression(p => p.Delivery.DeliveryId == deliveryId).ToList();
            this.packageSelectedEntityRepository.Remove(removePackageSelectedList);

            var packageSelectedList = (from dish in shoppingList.Where(p => p.Type == 3)
                                       select new PackageSelectedEntity
                                       {
                                           Delivery = new DeliveryEntity
                                           {
                                               DeliveryId = deliveryId
                                           },
                                           Package = new PackageNameEntity
                                               {
                                                   PackageId = dish.ItemId
                                               },
                                           Supplier = new SupplierEntity
                                               {
                                                   SupplierId = supplierId
                                               },
                                           PackageNum = dish.Quantity,
                                           PackagePrice = dish.Price,
                                           PackageName = dish.ItemName,
                                           Comment = dish.Instruction
                                       }).ToList();

            this.packageSelectedEntityRepository.Save(packageSelectedList);

            var typeList = new List<int> { 0, 1, 2 };
            var packageSelectedDetailList = (from dish in shoppingList.Where(p => typeList.Contains(p.Type) && p.ParentId != 0)
                                             select new PackageSelectedDetailEntity
                                             {
                                                 PackageSelected = packageSelectedList.FirstOrDefault(p => p.Package.PackageId == dish.ParentId),
                                                 DeliveryId = deliveryId,
                                                 DishNum = dish.Quantity,
                                                 DishPrice = dish.Price,
                                                 DishName = dish.ItemName,
                                             }).ToList();

            this.packageSelectedDetailEntityRepository.Save(packageSelectedDetailList);
        }

        /// <summary>
        /// 保存支付信息
        /// </summary>
        /// <param name="deliveryId">订单Id</param>
        /// <param name="customerTotal">支付总金额</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">The payBank</param>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePaymentEntity(int deliveryId, decimal customerTotal, int paymentMethodId, string payBank)
        {
            if (paymentMethodId <= 0)
            {
                return;
            }

            var paymentEntity = this.paymentEntityRepository.EntityQueryable.FirstOrDefault(p => p.Delivery.DeliveryId == deliveryId)
                                 ?? new PaymentEntity
                                 {
                                     PaymentTypeId = 1,
                                     Delivery = new DeliveryEntity { DeliveryId = deliveryId },
                                     TransactionCode = string.Empty,
                                     CardId = string.Empty,
                                     Authorized = false,
                                     CVV = 0,
                                     AVS = string.Empty,
                                     PC = 0,
                                     AuthCode = string.Empty,
                                     VoicePayResponse = string.Empty,
                                     TransactionFee = 0
                                 };

            paymentEntity.Amount = customerTotal;
            paymentEntity.MethodChangeHistory = paymentEntity.PaymentMethodId.ToString();
            paymentEntity.PaymentMethodId = paymentMethodId;
            paymentEntity.PayBank = payBank;
            this.paymentEntityRepository.Save(paymentEntity);
        }
    }
}
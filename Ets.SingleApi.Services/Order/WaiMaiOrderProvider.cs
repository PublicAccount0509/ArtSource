namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WaiMaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/22/2013 3:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class WaiMaiOrderProvider : IOrderProvider
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
        /// 字段orderNumberDcEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 12:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDcEntity> orderNumberDcEntityRepository;

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
        private readonly IShoppingCartProvider shoppingCartProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiOrderProvider" /> class.
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
        /// <param name="orderNumberDcEntityRepository">The orderNumberDcEntityRepository</param>
        /// <param name="distance">The distance</param>
        /// <param name="shoppingCartProvider">The shoppingCartProvider</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderProvider(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SourcePathEntity> sourcePathEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository,
            INHibernateRepository<PaymentEntity> paymentEntityRepository,
            INHibernateRepository<SupplierCommissionEntity> supplierCommissionEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository,
            INHibernateRepository<OrderNumberDcEntity> orderNumberDcEntityRepository,
            IDistance distance,
            IShoppingCartProvider shoppingCartProvider)
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
            this.orderNumberDcEntityRepository = orderNumberDcEntityRepository;
            this.distance = distance;
            this.shoppingCartProvider = shoppingCartProvider;
        }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderType OrderType
        {
            get
            {
                return OrderType.WaiMai;
            }
        }

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(string source, int orderId)
        {
            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<int>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            return new ServicesResult<int>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = deliveryEntity.IsPaId == true ? 1 : 2
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
        public ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId)
        {
            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
            }

            var waiMaiOrderDishList = deliveryEntity.OrderList.Select(p => new WaiMaiOrderDishModel
            {
                SupplierDishId = p.SupplierDishId,
                SupplierDishName = p.SupplierDishName,
                Price = p.SupplierPrice,
                Quantity = p.Quantity
            }).ToList();

            var supplierId = deliveryEntity.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
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

            var result = new WaiMaiOrderDetailModel
            {
                OrderId = deliveryEntity.OrderNumber.HasValue ? deliveryEntity.OrderNumber.Value : 0,
                OrderTypeId = (int)OrderType.WaiMai,
                OrderStatusId = deliveryEntity.OrderStatusId,
                DateReserved = deliveryEntity.DateAdded == null ? string.Empty : deliveryEntity.DateAdded.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryTime = deliveryEntity.DeliveryDate == null ? string.Empty : deliveryEntity.DeliveryDate.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryInstruction = deliveryEntity.DeliveryInstruction ?? string.Empty,
                CustomerTotal = (deliveryEntity.CustomerTotal ?? 0).ToString("#0.00"),
                Total = (deliveryEntity.Total ?? 0).ToString("#0.00"),
                Coupon = Math.Max(((deliveryEntity.Total ?? 0) - (deliveryEntity.CustomerTotal ?? 0)), 0).ToString("#0.00"),
                Commission = "0.00",
                RealSupplierType = deliveryEntity.RealSupplierType,
                SupplierId = supplierEntity.SupplierId,
                SupplierName = supplierEntity.SupplierName ?? string.Empty,
                SupplierTelephone = supplierEntity.Telephone ?? string.Empty,
                SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
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
                DeliveryCustomerGender = gender
            };

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
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public ServicesResult<string> SaveOrder(string source, string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartDeliveryResult = this.shoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
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
            if (order.IsComplete)
            {
                return new ServicesResult<string>
                    {
                        Result = order.OrderId.ToString()
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

            var orderId = this.GetOrderNumberId();
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var deliveryTime = order.DeliveryDateTime;
            if (deliveryTime <= DateTime.Now)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidDeliveryTimeCode,
                    Result = string.Empty
                };
            }

            var customerId = customer.CustomerId;
            var deliveryId = order.DeliveryMethodId == ServicesCommon.PickUpDeliveryMethodId
                ? this.SavePickUpDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order)
                : this.SaveDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order);
            this.SaveSupplierCommission(deliveryId, order.TotalFee, supplierEntity);
            this.SaveOrderEntity(customerId, deliveryId, shoppingList);
            this.SavePaymentEntity(deliveryId, order.CustomerTotalFee, order.PaymentMethodId);
            order.IsComplete = true;
            order.OrderId = orderId;
            this.shoppingCartProvider.SaveShoppingCartOrder(source, order);
            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderNumber(string source)
        {
            var orderId = this.GetOrderNumberId();
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            return new ServicesResult<string>
                {
                    Result = orderId.ToString()
                };
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
        private int SavePickUpDeliveryEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, ShoppingCartOrder order)
        {
            var userName = delivery.Name;
            var deliveryAddressEntity = new DeliveryAddressEntity
            {
                Recipient = userName.IsEmptyOrNull() ? delivery.Name : userName,
                Telephone = delivery.Telephone,
                Sex = string.Equals(delivery.Gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase) || delivery.Gender == "1" ? 1 : 0,
                CustomerId = customerId,
                IsDel = false
            };
            this.deliveryAddressEntityRepository.Save(deliveryAddressEntity);

            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = supplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                DeliveryMethodId = order.DeliveryMethodId,
                DeliveryInstruction = order.DeliveryInstruction,
                CustomerTotal = order.CustomerTotalFee,
                Total = order.TotalFee,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                PackagingFee = order.PackagingFee,
                DeliverCharge = order.FixedDeliveryFee,
                ContactPhone = deliveryAddressEntity.Telephone,
                Gender = (deliveryAddressEntity.Sex ?? ServicesCommon.DefaultGender).ToString(),
                Contact = deliveryAddressEntity.Recipient,
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                DeliveryDate = order.DeliveryDateTime,
                Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Template),
                InvoiceRequired = order.InvoiceRequired,
                InvoiceTitle = order.InvoiceTitle,
                Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Path),
                OrderNotes = order.OrderNotes,
                AreaId = order.AreaId,
                IPAddress = delivery.IpAddress,
                IsTakeInvoice = order.IsTakeInvoice,
                DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId
            };

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
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveDeliveryEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, ShoppingCartOrder order)
        {
            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == delivery.CustomerAddressId && p.CustomerId == customerId);
            var deliveryAddressEntity = new DeliveryAddressEntity
            {
                Recipient = customerAddressEntity.Recipient,
                AddressAlias = customerAddressEntity.AddressAlias,
                Address1 = customerAddressEntity.Address1,
                AddressBuilding = customerAddressEntity.AddressBuilding,
                AddressDetail = customerAddressEntity.AddressDetail,
                Address2 = customerAddressEntity.Address2,
                CityId = customerAddressEntity.CityId,
                CountyId = customerAddressEntity.CountyId,
                CountryId = customerAddressEntity.CountryId,
                Telephone = customerAddressEntity.Telephone,
                Sex = customerAddressEntity.Sex,
                CustomerId = customerId,
                IsDel = false
            };
            this.deliveryAddressEntityRepository.Save(deliveryAddressEntity);

            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = supplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                DeliveryMethodId = order.DeliveryMethodId,
                DeliveryInstruction = order.DeliveryInstruction,
                CustomerTotal = order.CustomerTotalFee,
                Total = order.TotalFee,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                PackagingFee = order.PackagingFee,
                DeliverCharge = order.FixedDeliveryFee,
                ContactPhone = deliveryAddressEntity.Telephone,
                Gender = (deliveryAddressEntity.Sex ?? ServicesCommon.DefaultGender).ToString(),
                Contact = deliveryAddressEntity.Recipient,
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                DeliveryDate = order.DeliveryDateTime,
                Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Template),
                InvoiceRequired = order.InvoiceRequired,
                InvoiceTitle = order.InvoiceTitle,
                Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == order.Path),
                OrderNotes = order.OrderNotes,
                AreaId = order.AreaId,
                IPAddress = delivery.IpAddress,
                IsTakeInvoice = order.IsTakeInvoice,
                DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId
            };

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
            var supplierCommissionEntity = new SupplierCommissionEntity
            {
                Supplier = supplierEntity,
                DeliveryId = deliveryId,
                Total = totalFee,
                Canncelled = false,
                DateAdded = DateTime.Now,
                Commission = 0
            };

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
            var orderList = (from dish in shoppingList
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
        /// 保存支付信息
        /// </summary>
        /// <param name="deliveryId">订单Id</param>
        /// <param name="customerTotal">支付总金额</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePaymentEntity(int deliveryId, decimal customerTotal, int paymentMethodId)
        {
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
            this.paymentEntityRepository.Save(paymentEntity);
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int GetOrderNumberId()
        {
            var entity = this.orderNumberDcEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return 0;
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDcEntityRepository.Remove(entity);
            return orderNumber;
        }
    }
}
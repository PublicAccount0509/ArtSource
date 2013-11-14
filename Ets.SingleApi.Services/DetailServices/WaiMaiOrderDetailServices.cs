namespace Ets.SingleApi.Services.DetailServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WaiMaiOrderDetailServices
    /// 命名空间：Ets.SingleApi.Services.DetailServices
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 8:21 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class WaiMaiOrderDetailServices : IWaiMaiOrderDetailServices
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

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
        /// 字段supplierDishEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository;

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
        /// 字段orderNumber
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IOrderNumber orderNumber;

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
        /// Initializes a new instance of the <see cref="WaiMaiOrderDetailServices" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="sourcePathEntityRepository">The sourcePathEntityRepository</param>
        /// <param name="sourceTypeEntityRepository">The sourceTypeEntityRepository</param>
        /// <param name="paymentEntityRepository">The paymentEntityRepository</param>
        /// <param name="supplierCommissionEntityRepository">The supplierCommissionEntityRepository</param>
        /// <param name="orderEntityRepository">The orderEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="deliveryAddressEntityRepository">The deliveryAddressEntityRepository</param>
        /// <param name="orderNumber">The orderNumber</param>
        /// <param name="distance">The distance</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderDetailServices(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SourcePathEntity> sourcePathEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository,
            INHibernateRepository<PaymentEntity> paymentEntityRepository,
            INHibernateRepository<SupplierCommissionEntity> supplierCommissionEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository,
            IOrderNumber orderNumber,
            IDistance distance)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.sourcePathEntityRepository = sourcePathEntityRepository;
            this.sourceTypeEntityRepository = sourceTypeEntityRepository;
            this.paymentEntityRepository = paymentEntityRepository;
            this.supplierCommissionEntityRepository = supplierCommissionEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.deliveryAddressEntityRepository = deliveryAddressEntityRepository;
            this.orderNumber = orderNumber;
            this.distance = distance;
        }

        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<WaiMaiOrderDetailModel> GetOrder(int orderId, int userId)
        {
            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == userId).Select(p => new { p.CustomerId, p.LoginId }).FirstOrDefault();
            if (customer == null)
            {
                return new ServicesResult<WaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
            }

            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId && entity.CustomerId == customer.CustomerId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<WaiMaiOrderDetailModel>
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
                return new ServicesResult<WaiMaiOrderDetailModel>
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

            var result = new WaiMaiOrderDetailModel
                {
                    OrderId = deliveryEntity.OrderNumber.HasValue ? deliveryEntity.OrderNumber.Value : 0,
                    OrderTypeId = deliveryEntity.DeliveryMethodId,
                    OrderStatusId = deliveryEntity.OrderStatusId,
                    DateReserved = deliveryEntity.DateAdded,
                    DeliveryInstruction = deliveryEntity.DeliveryInstruction,
                    CustomerTotal = deliveryEntity.CustomerTotal,
                    Total = deliveryEntity.Total,
                    RealSupplierType = deliveryEntity.RealSupplierType,
                    SupplierId = supplierEntity.SupplierId,
                    SupplierName = supplierEntity.SupplierName,
                    SupplierTelephone = supplierEntity.Telephone,
                    SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
                    SupplierBaIduLat = baIduLat,
                    SupplierBaIduLong = baIduLong,
                    DeliveryMethodId = deliveryEntity.DeliveryMethodId,
                    IsPaid = deliveryEntity.IsPaId,
                    DishList = waiMaiOrderDishList,
                    PaymentMethodId = paymentEntity == null ? (int?)null : paymentEntity.PaymentMethodId,
                    IsConfirm = paymentEntity != null
                };

            return new ServicesResult<WaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = result
                };
        }

        /// <summary>
        /// 添加外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<AddWaiMaiOrderModel> AddOrder(AddWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var supplierEntity = this.supplierEntityRepository.EntityQueryable.FirstOrDefault(p => p.SupplierId == parameter.SupplierId);
            if (supplierEntity == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId).Select(p => new { p.CustomerId, p.LoginId, p.Mobile, p.Gender, p.Forename, p.Surname }).FirstOrDefault();
            if (customer == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var getOrderNumberResult = this.orderNumber.GetOrderNumber();
            if (getOrderNumberResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = getOrderNumberResult.StatusCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var customerId = customer.CustomerId;
            var dishList = parameter.DishList ?? new List<AddWaiMaiOrderDishModel>();
            var supplierDishIdList = dishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishList = (from supplierDish in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDish.Supplier.SupplierId == parameter.SupplierId
                                    && supplierDishIdList.Contains(supplierDish.SupplierDishId)
                                    select new
                                    {
                                        supplierDish.SupplierDishId,
                                        supplierDish.Price,
                                        supplierDish.SupplierDishName
                                    }).ToList();

            var dishTotal = supplierDishList.Sum(item => (item.Price * dishList.Where(p => p.SupplierDishId == item.SupplierDishId).Select(p => p.Quantity).FirstOrDefault()));
            var fixedDeliveryCharge = (supplierEntity.FreeDeliveryLine ?? 0) <= dishTotal
                                          ? 0
                                          : supplierEntity.FixedDeliveryCharge ?? 0;

            var total = parameter.DeliveryMethodId == 2
                    ? dishTotal + (supplierEntity.PackagingFee ?? 0) + fixedDeliveryCharge
                    : dishTotal + (supplierEntity.PackagingFee ?? 0);
            var customerTotal = parameter.DeliveryMethodId == 2
                    ? dishTotal + (supplierEntity.PackagingFee ?? 0) + fixedDeliveryCharge
                    : dishTotal + (supplierEntity.PackagingFee ?? 0);

            var orderId = getOrderNumberResult.OrderNumber;
            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = parameter.SupplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                DeliveryMethodId = parameter.DeliveryMethodId,
                DeliveryInstruction = parameter.DeliveryInstruction,
                CustomerTotal = customerTotal,
                Total = total,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                PackagingFee = supplierEntity.PackagingFee,
                DeliverCharge = parameter.DeliveryMethodId == ServicesCommon.PickUpDeliveryMethodId ? 0 : fixedDeliveryCharge,
                ContactPhone = customer.Mobile,
                Gender = string.Equals(customer.Gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase) ? "1" : "0",
                Contact = string.Format("{0}{1}", customer.Forename, customer.Surname),
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                DeliveryDate = DateTime.Now.AddMinutes(60),
                Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == parameter.Template),
                InvoiceRequired = parameter.InvoiceRequired,
                InvoiceTitle = parameter.InvoiceTitle,
                Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == parameter.Path),
                OrderNotes = parameter.OrderNotes,
                AreaId = parameter.AreaId,
                IPAddress = parameter.IpAddress,
                IsTakeInvoice = parameter.IsTakeInvoice
            };

            this.deliveryEntityRepository.Save(deliveryEntity);

            var supplierCommissionEntity = new SupplierCommissionEntity
                {
                    Supplier = supplierEntity,
                    DeliveryId = deliveryEntity.DeliveryId,
                    Total = total,
                    Canncelled = false,
                    DateAdded = DateTime.Now,
                    Commission = 0
                };

            this.supplierCommissionEntityRepository.Save(supplierCommissionEntity);

            if (dishList.Count == 0)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new AddWaiMaiOrderModel
                    {
                        OrderId = orderId,
                        CustomerTotal = customerTotal,
                        SupplierName = supplierEntity.SupplierName,
                        SupplierId = supplierEntity.SupplierId,
                        SupplierDishCount = this.orderEntityRepository.EntityQueryable.Where(p => p.CustomerId == customerId && p.Delivery.DeliveryId == deliveryEntity.DeliveryId).Sum(p => p.Quantity)
                    }
                };
            }

            var orderList = (from dish in parameter.DishList
                             let supplierDish = supplierDishList.FirstOrDefault(p => p.SupplierDishId == dish.SupplierDishId)
                             where supplierDish != null
                             select new OrderEntity
                             {
                                 Delivery = deliveryEntity,
                                 CustomerId = customerId,
                                 SupplierDishId = dish.SupplierDishId,
                                 Quantity = dish.Quantity,
                                 SupplierPrice = supplierDish.Price,
                                 SupplierDishName = supplierDish.SupplierDishName,
                                 Total = supplierDish.Price * dish.Quantity,
                                 OrderDate = DateTime.Now
                             }).ToList();

            this.orderEntityRepository.Save(orderList);

            return new DetailServicesResult<AddWaiMaiOrderModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new AddWaiMaiOrderModel
                {
                    OrderId = orderId,
                    CustomerTotal = customerTotal,
                    SupplierName = supplierEntity.SupplierName,
                    SupplierId = supplierEntity.SupplierId,
                    SupplierDishCount = this.orderEntityRepository.EntityQueryable.Where(p => p.CustomerId == customerId && p.Delivery.DeliveryId == deliveryEntity.DeliveryId).Sum(p => p.Quantity)
                }
            };
        }

        /// <summary>
        /// 确认订单
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<ConfirmWaiMaiOrderModel> ConfirmOrder(ConfirmWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId).Select(p => new { p.CustomerId, p.LoginId, p.Mobile }).FirstOrDefault();
            if (customer == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            var customerId = customer.CustomerId;
            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == parameter.OrderId && p.CustomerId == customerId);
            if (deliveryEntity == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            var paymentEntity = this.paymentEntityRepository.EntityQueryable.FirstOrDefault(p => p.Delivery.DeliveryId == deliveryEntity.DeliveryId)
                                  ?? new PaymentEntity
                                  {
                                      PaymentTypeId = 1,
                                      Delivery = deliveryEntity,
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

            paymentEntity.Amount = deliveryEntity.CustomerTotal ?? 0;
            paymentEntity.MethodChangeHistory = paymentEntity.PaymentMethodId.ToString();
            paymentEntity.PaymentMethodId = parameter.PaymentMethodId;
            this.paymentEntityRepository.Save(paymentEntity);

            if (deliveryEntity.DeliveryMethodId == ServicesCommon.PickUpDeliveryMethodId)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new ConfirmWaiMaiOrderModel
                    {
                        OrderId = parameter.OrderId
                    }
                };
            }

            //非自提类型，添加送餐地址
            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == parameter.CustomerAddressId && p.CustomerId == customerId);
            if (customerAddressEntity == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCustomerAddressIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

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

            deliveryEntity.Contact = customerAddressEntity.Recipient;
            deliveryEntity.ContactPhone = customerAddressEntity.Telephone;
            deliveryEntity.Gender = (customerAddressEntity.Sex == null ? ServicesCommon.DefaultGender : customerAddressEntity.Sex.Value).ToString();
            //保存订单送餐地址
            deliveryEntity.DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId;
            if (deliveryEntity.SupplierId == null)
            {
                this.deliveryEntityRepository.Save(deliveryEntity);

                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new ConfirmWaiMaiOrderModel
                    {
                        OrderId = parameter.OrderId
                    }
                };
            }

            //计算送餐距离
            var supplierLocation = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == deliveryEntity.SupplierId)
                  .Select(p => new { p.BaIduLat, p.BaIduLong })
                  .FirstOrDefault();

            if (supplierLocation == null)
            {
                this.deliveryEntityRepository.Save(deliveryEntity);

                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new ConfirmWaiMaiOrderModel
                    {
                        OrderId = parameter.OrderId
                    }
                };
            }

            var customerLocation = distance.GetLocation(string.Format("{0}{1}", customerAddressEntity.Address1, customerAddressEntity.AddressBuilding), string.Empty);
            if (customerLocation == null)
            {
                this.deliveryEntityRepository.Save(deliveryEntity);

                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new ConfirmWaiMaiOrderModel
                    {
                        OrderId = parameter.OrderId
                    }
                };
            }

            double baIduLat;
            double baIduLong;
            double.TryParse(supplierLocation.BaIduLat, out baIduLat);
            double.TryParse(supplierLocation.BaIduLong, out baIduLong);

            deliveryEntity.Lat = customerLocation.Lat;
            deliveryEntity.Lng = customerLocation.Lng;
            deliveryEntity.DeliveryDistance = distance.GetDistance(customerLocation, new Location { Lat = baIduLat, Lng = baIduLong }, GaussSphere.Beijing54);
            this.deliveryEntityRepository.Save(deliveryEntity);

            return new DetailServicesResult<ConfirmWaiMaiOrderModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new ConfirmWaiMaiOrderModel
                {
                    OrderId = parameter.OrderId
                }
            };
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DetailServicesResult<PaymentWaiMaiOrderModel> PaymentOrder(PaymentWaiMaiOrderParameter parameter)
        {
            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId).Select(p => new { p.CustomerId, p.LoginId, p.Mobile }).FirstOrDefault();
            if (customer == null)
            {
                return new DetailServicesResult<PaymentWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new PaymentWaiMaiOrderModel()
                };
            }

            var customerId = customer.CustomerId;
            var telephone = customer.Mobile;
            var authCode = CacheUtility.GetInstance().Get(string.Format("{0}{1}", ServicesCommon.WaiMaiAuthCodeCacheKey, telephone));
            if (parameter.AuthCode == (authCode == null ? string.Empty : authCode.ToString()))
            {
                return new DetailServicesResult<PaymentWaiMaiOrderModel>
                {
                    Result = new PaymentWaiMaiOrderModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                };
            }

            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == parameter.OrderId && p.CustomerId == customerId);

            return null;
        }
    }
}
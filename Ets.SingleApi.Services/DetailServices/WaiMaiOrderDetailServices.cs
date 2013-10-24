namespace Ets.SingleApi.Services.DetailServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

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
        /// 字段smsDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 8:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsDetailServices smsDetailServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiOrderDetailServices" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="orderEntityRepository">The orderEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="deliveryAddressEntityRepository">The deliveryAddressEntityRepository</param>
        /// <param name="smsDetailServices">The smsDetailServices</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderDetailServices(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository,
            ISmsDetailServices smsDetailServices)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.deliveryAddressEntityRepository = deliveryAddressEntityRepository;
            this.smsDetailServices = smsDetailServices;
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
                                  where entity.DeliveryId == orderId && entity.CustomerId == customer.CustomerId
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

            var result = new WaiMaiOrderDetailModel
                {
                    OrderId = deliveryEntity.DeliveryId,
                    OrderTypeId = deliveryEntity.DeliveryMethodId,
                    OrderStatusId = deliveryEntity.OrderStatusId,
                    DateReserved = deliveryEntity.DateAdded,
                    DeliveryInstruction = deliveryEntity.DeliveryInstruction,
                    CustomerTotal = deliveryEntity.CustomerTotal,
                    Total = deliveryEntity.Total,
                    SupplierId = supplierEntity.SupplierId,
                    SupplierName = supplierEntity.SupplierName,
                    SupplierTelephone = supplierEntity.Telephone,
                    DishList = waiMaiOrderDishList
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

            var supplierEntity = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == parameter.SupplierId)
                                .Select(p => new { p.SupplierId, p.SupplierName, p.PackagingFee, p.FixedDeliveryCharge })
                                .FirstOrDefault();
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
            var total = parameter.DeliveryMethodId == 2
                    ? dishTotal + (supplierEntity.PackagingFee ?? 0) + (supplierEntity.FixedDeliveryCharge ?? 0)
                    : dishTotal;
            var customerTotal = parameter.DeliveryMethodId == 2
                    ? dishTotal + (supplierEntity.PackagingFee ?? 0) + (supplierEntity.FixedDeliveryCharge ?? 0)
                    : dishTotal;

            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = parameter.SupplierId,
                CustomerId = customerId,
                DeliveryMethodId = parameter.DeliveryMethodId,
                DeliveryInstruction = parameter.DeliveryInstruction,
                CustomerTotal = customerTotal,
                Total = total,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                PackagingFee = supplierEntity.PackagingFee,
                DeliverCharge = supplierEntity.FixedDeliveryCharge,
                ContactPhone = customer.Mobile,
                Gender = customer.Gender,
                Contact = string.Format("{0}{1}", customer.Forename, customer.Surname),
                IsPaId = false,
                IsRating = false,
                Cancelled = false
            };

            this.deliveryEntityRepository.Save(deliveryEntity);

            var orderId = deliveryEntity.DeliveryId;
            if (dishList.Count == 0)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new AddWaiMaiOrderModel
                    {
                        OrderId = orderId,
                        CustomerTotal = parameter.DeliveryMethodId == 2 ? customerTotal + (supplierEntity.PackagingFee ?? 0) + (supplierEntity.FixedDeliveryCharge ?? 0) : customerTotal,
                        SupplierName = supplierEntity.SupplierName,
                        SupplierId = supplierEntity.SupplierId,
                        SupplierDishCount = this.orderEntityRepository.EntityQueryable.Where(p => p.CustomerId == customerId && p.Delivery.DeliveryId == orderId).Sum(p => p.Quantity)
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
                    CustomerTotal = parameter.DeliveryMethodId == 2 ? customerTotal + (supplierEntity.PackagingFee ?? 0) + (supplierEntity.FixedDeliveryCharge ?? 0) : customerTotal,
                    SupplierName = supplierEntity.SupplierName,
                    SupplierId = supplierEntity.SupplierId,
                    SupplierDishCount = this.orderEntityRepository.EntityQueryable.Where(p => p.CustomerId == customerId && p.Delivery.DeliveryId == orderId).Sum(p => p.Quantity)
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
            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == parameter.CustomerAddressId && p.CustomerId == customerId);
            if (customerAddressEntity == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            var deliveryAddressEntity = new DeliveryAddressEntity
            {
                Recipient = customerAddressEntity.Recipient,
                AddressAlias = customerAddressEntity.AddressAlias,
                Address1 = customerAddressEntity.Address1,
                Address2 = customerAddressEntity.Address2,
                CityId = customerAddressEntity.CityId,
                CountyId = customerAddressEntity.CountyId,
                CountryId = customerAddressEntity.CountryId,
                Telephone = customerAddressEntity.Telephone,
                Sex = customerAddressEntity.Sex,
                CustomerId = customer.CustomerId,
                IsDel = false
            };
            this.deliveryAddressEntityRepository.Save(deliveryAddressEntity);

            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.DeliveryId == parameter.OrderId && p.CustomerId == customerId);
            deliveryEntity.RealSupplierType = parameter.RealSupplierType;
            deliveryEntity.DeliveryAddressId = deliveryAddressEntity.DeliveryAddressId;
            this.deliveryEntityRepository.Save(deliveryEntity);


            var code = CommonUtility.RandNum(6);
            CacheUtility.GetInstance().Set(string.Format("{0}{1}", ServicesCommon.AuthCodeCacheKey, customer.Mobile), code, DateTime.Now.AddMinutes(5));

            var result = this.smsDetailServices.SendSms(customer.Mobile, string.Format("{0}", code));
            if (result == null)
            {
                return new DetailServicesResult<ConfirmWaiMaiOrderModel>
                {
                    Result = new ConfirmWaiMaiOrderModel
                    {
                        OrderId = parameter.OrderId
                    },
                    StatusCode = (int)StatusCode.General.SmsSendError
                };
            }

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

            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.DeliveryId == parameter.OrderId && p.CustomerId == customerId);

            return null;
        }
    }
}
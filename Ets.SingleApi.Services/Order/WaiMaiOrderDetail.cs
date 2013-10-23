namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WaiMaiOrderDetail
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:29 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiOrderDetail : IOrderDetail
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
        /// Initializes a new instance of the <see cref="WaiMaiOrderDetail" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="orderEntityRepository">The orderEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="deliveryAddressEntityRepository">The deliveryAddressEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderDetail(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.deliveryAddressEntityRepository = deliveryAddressEntityRepository;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderData">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 10:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderDetailResult<IOrderResult> AddOrder(IOrderData orderData)
        {
            var parameter = orderData as AddWaiMaiOrderData;
            if (parameter == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new AddWaiMaiOrderResult()
                };
            }

            var supplierEntity = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == parameter.SupplierId)
                                .Select(p => new { p.SupplierId, p.SupplierName, p.PackagingFee, p.FixedDeliveryCharge })
                                .FirstOrDefault();
            if (supplierEntity == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new AddWaiMaiOrderResult()
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId).Select(p => new { p.CustomerId, p.LoginId }).FirstOrDefault();
            if (customer == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderResult()
                };
            }

            var customerId = customer.CustomerId;
            var dishList = parameter.DishList ?? new List<AddWaiMaiOrderDishData>();
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

            var customerTotal = supplierDishList.Sum(item => (item.Price * dishList.Where(p => p.SupplierDishId == item.SupplierDishId).Select(p => p.Quantity).FirstOrDefault()));
            var total = parameter.DeliveryMethodId == 2
                    ? customerTotal + (supplierEntity.PackagingFee ?? 0) + (supplierEntity.FixedDeliveryCharge ?? 0)
                    : customerTotal;
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
                DeliverCharge = supplierEntity.FixedDeliveryCharge
            };

            this.deliveryEntityRepository.Save(deliveryEntity);

            var orderId = deliveryEntity.DeliveryId;
            if (dishList.Count == 0)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new AddWaiMaiOrderResult
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

            return new OrderDetailResult<IOrderResult>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new AddWaiMaiOrderResult
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
        /// <param name="orderData">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderDetailResult<IOrderResult> ConfirmOrder(IOrderData orderData)
        {
            var parameter = orderData as ConfirmWaiMaiOrderData;
            if (parameter == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new ConfirmWaiMaiOrderResult()
                };
            }

            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId).Select(p => new { p.CustomerId, p.LoginId }).FirstOrDefault();
            if (customer == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderResult()
                };
            }

            var customerId = customer.CustomerId;
            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == parameter.CustomerAddressId && p.CustomerId == customerId);
            if (customerAddressEntity == null)
            {
                return new OrderDetailResult<IOrderResult>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderResult()
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

            return new OrderDetailResult<IOrderResult>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new ConfirmWaiMaiOrderResult
                    {
                        OrderId = parameter.OrderId
                    }
            };
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="orderData">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderDetailResult<IOrderResult> PaymentOrder(IOrderData orderData)
        {
            return null;
        }
    }
}
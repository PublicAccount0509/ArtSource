namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.DetailServices;
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
    public class WaiMaiOrderProvider : IOrderProvider
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
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/14/2013 10:28 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

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
        /// 字段supplierFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/20/2013 1:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository;

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
        /// 字段shoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartProvider shoppingCartProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiOrderProvider"/> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
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
        /// <param name="supplierFeatureEntityRepository">The supplierFeatureEntityRepository</param>
        /// <param name="orderNumber">The orderNumber</param>
        /// <param name="distance">The distance</param>
        /// <param name="shoppingCartProvider">The shoppingCartProvider</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderProvider(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
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
            INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository,
            IOrderNumber orderNumber,
            IDistance distance,
            IShoppingCartProvider shoppingCartProvider)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
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
            this.supplierFeatureEntityRepository = supplierFeatureEntityRepository;
            this.orderNumber = orderNumber;
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
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveOrder(string shoppingCartId)
        {
            var getShoppingCartLinkResult = this.shoppingCartProvider.GetShoppingCartLink(shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.shoppingCartProvider.GetShoppingCart(shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartSupplierResult = this.shoppingCartProvider.GetShoppingCartSupplier(shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartCustomerResult = this.shoppingCartProvider.GetShoppingCartCustomer(shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            var getShoppingCartOrderResult = this.shoppingCartProvider.GetShoppingCartOrder(shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;

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

            var getOrderNumberResult = this.orderNumber.GetOrderNumber();
            if (getOrderNumberResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getOrderNumberResult.StatusCode,
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
            var orderId = getOrderNumberResult.OrderNumber;
            var deliveryId = this.SaveDeliveryEntity(orderId, supplier.SupplierId, customer, order);
            this.SaveSupplierCommission(deliveryId, order.TotalFee, supplierEntity);

            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            if (shoppingList.Count == 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = orderId.ToString()
                };
            }

            this.SaveOrderEntity(customerId, deliveryId, shoppingList);

            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// 保存订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customer">顾客信息</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveDeliveryEntity(int orderId, int supplierId, ShoppingCartCustomer customer, ShoppingCartOrder order)
        {
            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = supplierId,
                CustomerId = customer.CustomerId,
                OrderNumber = orderId,
                DeliveryMethodId = order.DeliveryMethodId,
                DeliveryInstruction = order.DeliveryInstruction,
                CustomerTotal = order.CustomerTotalFee,
                Total = order.TotalFee,
                OrderStatusId = 1,
                DateAdded = DateTime.Now,
                PackagingFee = order.PackagingFee,
                DeliverCharge = order.FixedDeliveryFee,
                ContactPhone = customer.Telephone,
                Gender = customer.Gender,
                Contact = customer.Name,
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
                IPAddress = customer.IpAddress,
                IsTakeInvoice = order.IsTakeInvoice
            };

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
                                 OrderDate = DateTime.Now
                             }).ToList();

            this.orderEntityRepository.Save(orderList);
        }
    }
}
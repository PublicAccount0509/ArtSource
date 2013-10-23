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
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiOrderDetail(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="addOrderData">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 10:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderDetailResult<IAddOrderResult> AddOrder(IAddOrderData addOrderData)
        {
            var parameter = addOrderData as AddWaiMaiOrderData;
            if (parameter == null)
            {
                return new OrderDetailResult<IAddOrderResult>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new AddWaiMaiOrderResult()
                };
            }

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
            var customerId = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == parameter.UserId)
                    .Select(p => p.CustomerId).FirstOrDefault();
            var deliveryEntity = new DeliveryEntity
            {
                SupplierId = parameter.SupplierId,
                CustomerId = customerId,
                DeliveryMethodId = parameter.DeliveryMethodId,
                DeliveryInstruction = parameter.DeliveryInstruction,
                CustomerTotal = customerTotal,
                OrderStatusId = 1,
                DateAdded = DateTime.Now
            };

            this.deliveryEntityRepository.Save(deliveryEntity);

            var orderId = deliveryEntity.DeliveryId;
            if (dishList.Count == 0)
            {
                return new OrderDetailResult<IAddOrderResult>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new AddWaiMaiOrderResult
                        {
                            OrderId = orderId,
                            CustomerTotal = customerTotal
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
            return new OrderDetailResult<IAddOrderResult>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = new AddWaiMaiOrderResult
                {
                    OrderId = orderId,
                    CustomerTotal = customerTotal
                }
            };
        }
    }
}
namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UserWaiMaiOrders
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/21 0:21
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserWaiMaiOrders : IUserOrders
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段orderEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：3/12/2014 6:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderEntity> orderEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:26
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 支付信息
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：3/13/2014 1:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentEntity> paymentEntityRepository;

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
        /// Initializes a new instance of the <see cref="UserWaiMaiOrders" /> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="orderEntityRepository">The orderEntityRepositoryDefault documentation</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="paymentEntityRepository">The paymentEntityRepositoryDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserWaiMaiOrders(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<OrderEntity> orderEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<PaymentEntity> paymentEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.orderEntityRepository = orderEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.paymentEntityRepository = paymentEntityRepository;
        }

        /// <summary>
        /// 取得订单列表
        /// </summary>
        /// <param name="parameter">查询用户订单参数</param>
        /// <returns>
        /// 返回订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserOrdersResult GetUserOrderList(UserOrdersParameter parameter)
        {
            if (parameter == null)
            {
                return new UserOrdersResult
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    OrderList = new List<IOrderModel>()
                };
            }

            var waiMaiOrderList = this.GetWaiMaiOrderList(parameter);
            var supplierIdList = waiMaiOrderList.Select(p => p.SupplierId).ToList();
            var supplierList = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                where supplierIdList.Contains(supplierEntity.SupplierId)
                                select new { supplierEntity.SupplierId, supplierEntity.SupplierName }).ToList();

            foreach (var order in waiMaiOrderList)
            {
                var supplier = supplierList.FirstOrDefault(p => p.SupplierId == order.SupplierId);
                order.SupplierName = supplier == null ? string.Empty : supplier.SupplierName;
            }

            return new UserOrdersResult
                {
                    OrderList = waiMaiOrderList.Cast<IOrderModel>().ToList()
                };
        }

        /// <summary>
        /// 转换为用户订单
        /// </summary>
        /// <param name="orderModelList">The orderModelList</param>
        /// <returns>
        /// 返回用户订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 13:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<UserOrderModel> Convert(List<IOrderModel> orderModelList)
        {
            if (orderModelList == null)
            {
                return new List<UserOrderModel>();
            }

            var list = orderModelList.Cast<WaiMaiOrderModel>().ToList();
            if (list.Count == 0)
            {
                return new List<UserOrderModel>();
            }

            return list.Select(p => new UserOrderModel
                {
                    OrderId = p.OrderId,
                    SupplierId = p.SupplierId,
                    SupplierName = p.SupplierName,
                    DateReserved = p.DateReserved,
                    CustomerTotal = p.CustomerTotal,
                    OrderStatusId = p.OrderStatusId,
                    OrderStatus = p.OrderStatus,
                    OrderType = p.OrderType,
                    DeliveryMethodId = p.DeliveryMethodId,
                    IsPaid = p.IsPaid,
                    DishNames = p.DishNames,
                    PaymentMethodId = p.PaymentMethodId
                }).ToList();
        }

        /// <summary>
        /// 取得用户订单列表
        /// </summary>
        /// <param name="parameter">查询用户订单参数</param>
        /// <returns>
        /// 用户订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<WaiMaiOrderModel> GetWaiMaiOrderList(UserOrdersParameter parameter)
        {
            var retentionSupplierGroupIdList = ServicesCommon.RetentionSupplierGroupIdList.Select(p => (int?)p).ToList();

            var queryableTemp = (from deliveryEntity in this.deliveryEntityRepository.EntityQueryable
                                 from entity in this.supplierEntityRepository.EntityQueryable
                                 where deliveryEntity.SupplierId == entity.SupplierId
                                 && deliveryEntity.CustomerId == parameter.CustomerId
                                 select new
                                     {
                                         deliveryEntity.DeliveryId,
                                         deliveryEntity.OrderNumber,
                                         deliveryEntity.SupplierId,
                                         deliveryEntity.DateAdded,
                                         deliveryEntity.CustomerTotal,
                                         deliveryEntity.OrderStatusId,
                                         deliveryEntity.DeliveryMethodId,
                                         deliveryEntity.IsPaId,
                                         entity.SupplierGroupId
                                     });

            if (parameter.SupplierGroupId != null)
            {
                queryableTemp = queryableTemp.Where(p => p.SupplierGroupId == parameter.SupplierGroupId);
            }

            if (parameter.IsEtaoshi)
            {
                queryableTemp = queryableTemp.Where(p => retentionSupplierGroupIdList.Contains(p.SupplierGroupId));
            }

            if (parameter.SupplierId != null)
            {
                queryableTemp = queryableTemp.Where(p => p.SupplierId == parameter.SupplierId);
            }

            if (parameter.OrderStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.OrderStatusId == parameter.OrderStatus);
            }

            if (parameter.PaidStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.IsPaId == parameter.PaidStatus);
            }

            queryableTemp = queryableTemp.OrderByDescending(p => p.DateAdded);
            if (parameter.PageIndex != null)
            {
                queryableTemp = queryableTemp.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize);
            }

            //菜品名称（菜品1,菜品2,菜品3)
            var deliveryList = queryableTemp.ToList();
            var deliveryIdList = deliveryList.Select(p => p.DeliveryId).ToList();

            var orderList = (from order in this.orderEntityRepository.EntityQueryable
                             where deliveryIdList.Contains(order.Delivery.DeliveryId)
                             select new
                                 {
                                     order.SupplierDishName,
                                     order.Delivery.DeliveryId
                                 }
               ).ToList();

            var result = deliveryList.Select(p => new WaiMaiOrderModel
                                 {
                                     OrderId = p.OrderNumber.HasValue ? p.OrderNumber.Value : 0,
                                     SupplierId = p.SupplierId,
                                     SupplierName = string.Empty,
                                     DateReserved = p.DateAdded,
                                     CustomerTotal = p.CustomerTotal,
                                     OrderStatusId = p.OrderStatusId,
                                     OrderStatus = string.Empty,
                                     OrderType = (int)this.OrderType,
                                     DeliveryMethodId = p.DeliveryMethodId,
                                     IsPaid = p.IsPaId,
                                     DishNames = string.Join("，", orderList.Where(q => q.DeliveryId == p.DeliveryId).Select(c => c.SupplierDishName).ToList()),
                                     //支付方式
                                     PaymentMethodId = this.paymentEntityRepository.EntityQueryable.Where(pay=>pay.Delivery.DeliveryId == p.DeliveryId).Select(pay=>pay.PaymentMethodId).FirstOrDefault()
                                 }).ToList();

            return result;
        }
    }
}
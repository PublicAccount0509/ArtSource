namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 类名称：UserAllOrders
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/21 0:20
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserAllOrders : IUserOrders
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/21 14:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/21 14:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段tableReservationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TableReservationEntity> tableReservationEntityRepository;

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
                return OrderType.All;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAllOrders" /> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserAllOrders(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.tableReservationEntityRepository = tableReservationEntityRepository;
        }

        /// <summary>
        /// 取得订单列表
        /// </summary>
        /// <param name="customerId">用户Id</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// 返回订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserOrdersData GetUserOrderList(int customerId, int? orderStatus, int pageSize, int? pageIndex)
        {
            var orderList = orderStatus == null
                                ? this.GetAllOrderList(customerId, pageSize, pageIndex)
                                : this.GetAllOrderList(customerId, orderStatus.Value, pageSize, pageIndex);

            var supplierIdList = orderList.Where(p => p.OrderType == (int)OrderType.WaiMai).Select(p => p.SupplierId).ToList();
            var supplierList = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                where supplierIdList.Contains(supplierEntity.SupplierId)
                                select new { supplierEntity.SupplierId, supplierEntity.SupplierName }).ToList();

            foreach (var order in orderList)
            {
                var supplier = supplierList.FirstOrDefault(p => p.SupplierId == order.SupplierId);
                order.SupplierName = supplier == null ? string.Empty : supplier.SupplierName;
            }

            return new UserOrdersData
                {
                    OrderList = orderList.Cast<IOrderModel>().ToList()
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

            var list = orderModelList.Cast<AllOrderModel>().ToList();
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
                DineNumber = p.DineNumber
            }).ToList();
        }

        /// <summary>
        /// 取得用户订单列表
        /// </summary>
        /// <param name="customerId">用户Id</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// 用户订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<AllOrderModel> GetAllOrderList(int customerId, int pageSize, int? pageIndex)
        {
            var queryable = ((from tableReservation in this.tableReservationEntityRepository.EntityQueryable
                              where tableReservation.CustomerId == customerId
                              select
                                  new AllOrderModel
                                      {
                                          OrderId = tableReservation.TableReservationId,
                                          SupplierId = tableReservation.Supplier.SupplierId,
                                          SupplierName = tableReservation.Supplier.SupplierName,
                                          DateReserved = tableReservation.DateReserved,
                                          CustomerTotal = tableReservation.CustomerTotal,
                                          OrderStatusId = tableReservation.TableStatus,
                                          OrderStatus = string.Empty,
                                          OrderType = (int)OrderType.DingTai,
                                          DineNumber = tableReservation.DineNumber
                                      }).Union(
                                         (from deliveryEntity in this.deliveryEntityRepository.EntityQueryable
                                          where deliveryEntity.CustomerId == customerId
                                          select
                                              new AllOrderModel
                                                  {
                                                      OrderId = deliveryEntity.DeliveryId,
                                                      SupplierId = deliveryEntity.SupplierId,
                                                      SupplierName = string.Empty,
                                                      DateReserved = deliveryEntity.DateAdded,
                                                      CustomerTotal = deliveryEntity.CustomerTotal,
                                                      OrderStatusId = deliveryEntity.OrderStatusId,
                                                      OrderStatus = string.Empty,
                                                      OrderType = (int)OrderType.WaiMai,
                                                      DineNumber = 0
                                                  }))).OrderByDescending(p => p.DateReserved);

            if (pageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip(pageIndex.Value).Take(pageSize).ToList();
        }

        /// <summary>
        /// 取得用户订单列表
        /// </summary>
        /// <param name="customerId">用户Id</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// 用户订单列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<AllOrderModel> GetAllOrderList(int customerId, int orderStatus, int pageSize, int? pageIndex)
        {
            var queryable = ((from tableReservation in this.tableReservationEntityRepository.EntityQueryable
                              where tableReservation.CustomerId == customerId && tableReservation.TableStatus == orderStatus
                              select
                                  new AllOrderModel
                                  {
                                      OrderId = tableReservation.TableReservationId,
                                      SupplierId = tableReservation.Supplier.SupplierId,
                                      SupplierName = tableReservation.Supplier.SupplierName,
                                      DateReserved = tableReservation.DateReserved,
                                      CustomerTotal = tableReservation.CustomerTotal,
                                      OrderStatusId = tableReservation.TableStatus,
                                      OrderStatus = string.Empty,
                                      OrderType = (int)OrderType.DingTai,
                                      DineNumber = tableReservation.DineNumber
                                  }).Union(
                                         (from deliveryEntity in this.deliveryEntityRepository.EntityQueryable
                                          where deliveryEntity.CustomerId == customerId && deliveryEntity.OrderStatusId == orderStatus
                                          select
                                              new AllOrderModel
                                              {
                                                  OrderId = deliveryEntity.DeliveryId,
                                                  SupplierId = deliveryEntity.SupplierId,
                                                  SupplierName = string.Empty,
                                                  DateReserved = deliveryEntity.DateAdded,
                                                  CustomerTotal = deliveryEntity.CustomerTotal,
                                                  OrderStatusId = deliveryEntity.OrderStatusId,
                                                  OrderStatus = string.Empty,
                                                  OrderType = (int)OrderType.WaiMai,
                                                  DineNumber = 0
                                              }))).OrderByDescending(p => p.DateReserved);

            if (pageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip(pageIndex.Value).Take(pageSize).ToList();
        }
    }
}

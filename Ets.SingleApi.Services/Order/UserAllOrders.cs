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
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/25/2013 11:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

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
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserAllOrders(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
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

            //var queryable = this.GetDingTaiOrderQueryable(parameter).Union(this.GetWaiMaiOrderQueryable(parameter));
            //var list1 = new List<UserOrderModel>();
            //if (parameter.PageIndex == null)
            //{
            //    list1 = queryable.ToList();
            //}

            //list1 = queryable.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize).ToList();

            var list = this.customerEntityRepository.NamedQuery("Pro_QueryUserOrderList")
                        .SetInt32("CustomerID", parameter.CustomerId)
                        .SetInt32("OrderStatusID", parameter.OrderStatus ?? -1)
                        .SetInt32("PaidStatus", parameter.PaidStatus == null ? -1 : parameter.PaidStatus == true ? 1 : 0)
                        .SetInt32("PageIndex", parameter.PageIndex ?? -1)
                        .SetInt32("PageSize", parameter.PageSize).List();

            var orderList = (from object[] item in list
                             select new AllOrderModel
                             {
                                 OrderId = item[0].ObjectToInt(),
                                 DateReserved = item[1].ObjectToDateTime(),
                                 CustomerTotal = item[2].ObjectToDecimal(),
                                 OrderStatusId = item[3].ObjectToInt(),
                                 DineNumber = item[4].ObjectToInt(),
                                 OrderType = item[5].ObjectToInt(),
                                 SupplierId = item[6].ObjectToInt(),
                                 SupplierName = item[7].ObjectToString(),
                                 OrderStatus = string.Empty,
                                 DeliveryMethodId = item[8].ObjectToIntObject(),
                                 IsPaid = item[9].ObjectToBoolean()
                             }).ToList();

            var supplierIdList = orderList.Where(p => p.OrderType == (int)OrderType.WaiMai).Select(p => p.SupplierId).ToList();
            var supplierList = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                where supplierIdList.Contains(supplierEntity.SupplierId)
                                select new { supplierEntity.SupplierId, supplierEntity.SupplierName }).ToList();

            foreach (var order in orderList)
            {
                var supplier = supplierList.FirstOrDefault(p => p.SupplierId == order.SupplierId);
                order.SupplierName = supplier == null ? string.Empty : supplier.SupplierName;
            }

            return new UserOrdersResult
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
                DineNumber = p.DineNumber,
                DeliveryMethodId = p.DeliveryMethodId,
                IsPaid = p.IsPaid
            }).ToList();
        }

        /// <summary>
        /// 取得用户外卖订单IQueryable
        /// </summary>
        /// <param name="parameter">查询用户订单参数</param>
        /// <returns>
        /// 用户订单外卖订单IQueryable
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IQueryable<UserOrderModel> GetWaiMaiOrderQueryable(UserOrdersParameter parameter)
        {
            var queryableTemp = this.deliveryEntityRepository.EntityQueryable.Where(p => p.CustomerId == parameter.CustomerId && p.SupplierId != null);
            if (parameter.OrderStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.OrderStatusId == parameter.OrderStatus);
            }

            if (parameter.PaidStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.IsPaId == parameter.PaidStatus);
            }

            var queryable = queryableTemp.Select(p => new UserOrderModel
            {
                OrderId = p.OrderNumber.HasValue ? p.OrderNumber.Value : 0,
                SupplierId = p.SupplierId,
                SupplierName = string.Empty,
                DateReserved = p.DateAdded,
                CustomerTotal = p.CustomerTotal,
                OrderStatusId = p.OrderStatusId,
                DineNumber = 0,
                OrderStatus = string.Empty,
                OrderType = (int)OrderType.WaiMai
            });

            return queryable;
        }

        /// <summary>
        /// 取得用户订台订单IQueryable
        /// </summary>
        /// <param name="parameter">查询用户订单参数</param>
        /// <returns>
        /// 用户订台订单IQueryable
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 15:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IQueryable<UserOrderModel> GetDingTaiOrderQueryable(UserOrdersParameter parameter)
        {
            var queryableTemp = this.tableReservationEntityRepository.EntityQueryable.Where(p => p.CustomerId == parameter.CustomerId && p.Supplier != null);
            if (parameter.OrderStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.TableStatus == parameter.OrderStatus);
            }

            if (parameter.PaidStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.IsPaId == parameter.PaidStatus);
            }

            var queryable = queryableTemp.Select(p => new UserOrderModel
            {
                OrderId = p.OrderNumber.HasValue ? p.OrderNumber.Value : 0,
                SupplierId = p.Supplier.SupplierId,
                SupplierName = p.Supplier.SupplierName,
                DateReserved = p.DateReserved,
                CustomerTotal = p.CustomerTotal,
                OrderStatusId = p.TableStatus,
                DineNumber = p.DineNumber,
                OrderStatus = string.Empty,
                OrderType = (int)OrderType.DingTai
            });

            return queryable;
        }
    }
}
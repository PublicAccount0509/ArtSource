namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 类名称：UserDingTaiOrders
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/21 0:20
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserDingTaiOrders : IUserOrders
    {
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
                return OrderType.WaiMai;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDingTaiOrders" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserDingTaiOrders(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository)
        {
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
        public UserOrdersResult GetUserOrderList(int customerId, int? orderStatus, int pageSize, int? pageIndex)
        {
            var orderList = orderStatus == null
                                ? this.GetDingTaiOrderList(customerId, pageSize, pageIndex)
                                : this.GetDingTaiOrderList(customerId, orderStatus.Value, pageSize, pageIndex);

            var dingTaiOrderList = orderList.Select(order => new DingTaiOrderModel
                {
                    OrderId = order.OrderId,
                    SupplierId = order.SupplierId,
                    SupplierName = order.SupplierName,
                    DateReserved = order.DateReserved,
                    CustomerTotal = order.CustomerTotal,
                    OrderStatusId = order.OrderStatusId,
                    OrderStatus = string.Empty,
                    DineNumber = order.DineNumber,
                    OrderType = (int)this.OrderType
                }).ToList();

            return new UserOrdersResult
                {
                    OrderList = dingTaiOrderList.Cast<IOrderModel>().ToList()
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

            var list = orderModelList.Cast<DingTaiOrderModel>().ToList();
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
        private List<DingTaiOrderModel> GetDingTaiOrderList(int customerId, int pageSize, int? pageIndex)
        {
            var queryable = (from tableReservation in this.tableReservationEntityRepository.EntityQueryable
                             where tableReservation.CustomerId == customerId
                             select new DingTaiOrderModel
                             {
                                 OrderId = tableReservation.OrderNumber.HasValue ? tableReservation.OrderNumber.Value : 0,
                                 SupplierId = tableReservation.Supplier.SupplierId,
                                 SupplierName = tableReservation.Supplier.SupplierName,
                                 DateReserved = tableReservation.DateReserved,
                                 CustomerTotal = tableReservation.CustomerTotal,
                                 OrderStatusId = tableReservation.TableStatus,
                                 DineNumber = tableReservation.DineNumber
                             });

            if (pageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip((pageIndex.Value - 1) * pageSize).Take(pageSize).ToList();
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
        private List<DingTaiOrderModel> GetDingTaiOrderList(int customerId, int orderStatus, int pageSize, int? pageIndex)
        {
            var queryable = (from tableReservation in this.tableReservationEntityRepository.EntityQueryable
                             where tableReservation.CustomerId == customerId && tableReservation.TableStatus == orderStatus
                             select new DingTaiOrderModel
                             {
                                 OrderId = tableReservation.OrderNumber.HasValue ? tableReservation.OrderNumber.Value : 0,
                                 SupplierId = tableReservation.Supplier.SupplierId,
                                 SupplierName = tableReservation.Supplier.SupplierName,
                                 DateReserved = tableReservation.DateReserved,
                                 CustomerTotal = tableReservation.CustomerTotal,
                                 OrderStatusId = tableReservation.TableStatus,
                                 DineNumber = tableReservation.DineNumber
                             });

            if (pageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip((pageIndex.Value - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

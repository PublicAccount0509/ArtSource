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
                return OrderType.DingTai;
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

            var orderList = this.GetDingTaiOrderList(parameter);
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
                DineNumber = p.DineNumber,
                IsPaid = p.IsPaid
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
        private IEnumerable<DingTaiOrderModel> GetDingTaiOrderList(UserOrdersParameter parameter)
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

            var queryable = queryableTemp.Select(p => new DingTaiOrderModel
                             {
                                 OrderId = p.OrderNumber.HasValue ? p.OrderNumber.Value : 0,
                                 SupplierId = p.Supplier.SupplierId,
                                 SupplierName = p.Supplier.SupplierName,
                                 DateReserved = p.DateReserved,
                                 CustomerTotal = p.CustomerTotal,
                                 OrderStatusId = p.TableStatus,
                                 DineNumber = p.DineNumber,
                                 OrderStatus = string.Empty,
                                 OrderType = (int)this.OrderType,
                                 IsPaid = p.IsPaId
                             }).OrderByDescending(p => p.DateReserved);

            if (parameter.PageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize).ToList();
        }
    }
}

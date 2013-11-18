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
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:26
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

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
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserWaiMaiOrders(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
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
                    OrderType = p.OrderType
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
            var queryableTemp = this.deliveryEntityRepository.EntityQueryable.Where(p => p.CustomerId == parameter.CustomerId && p.SupplierId != null);
            if (parameter.OrderStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.OrderStatusId == parameter.OrderStatus);
            }

            if (parameter.PaidStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.IsPaId == parameter.PaidStatus);
            }

            var queryable = queryableTemp.Select(p => new WaiMaiOrderModel
                               {
                                   OrderId = p.OrderNumber.HasValue ? p.OrderNumber.Value : 0,
                                   SupplierId = p.SupplierId,
                                   SupplierName = string.Empty,
                                   DateReserved = p.DateAdded,
                                   CustomerTotal = p.CustomerTotal,
                                   OrderStatusId = p.OrderStatusId,
                                   OrderStatus = string.Empty,
                                   OrderType = (int)this.OrderType
                               }).OrderByDescending(p => p.DateReserved);

            if (parameter.PageIndex == null)
            {
                return queryable.ToList();
            }

            return queryable.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize).ToList();
        }
    }
}
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
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/25/2013 11:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 可见店铺表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 10:26 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository;

        /// <summary>
        /// 可见集团表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 10:26 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupPlatformEntity> supplierGroupPlatformEntityRepository;

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
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierPlatformRelationEntityRepository">The supplierPlatformRelationEntityRepositoryDefault documentation</param>
        /// <param name="supplierGroupPlatformEntityRepository">The supplierGroupPlatformEntityRepositoryDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserAllOrders(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository,
            INHibernateRepository<SupplierGroupPlatformEntity> supplierGroupPlatformEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.supplierPlatformRelationEntityRepository = supplierPlatformRelationEntityRepository;
            this.supplierGroupPlatformEntityRepository = supplierGroupPlatformEntityRepository;
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
        public ServicesResultList<IOrderModel> GetUserOrderList(UserOrdersParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<IOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new List<IOrderModel>()
                };
            }

            //可见集团列表
            var retentionSupplierGroupIdList = supplierGroupPlatformEntityRepository.EntityQueryable
                                                .Where(c => c.PlatformId == parameter.PlatformId)
                                                .Select(p => p.SupplierGroupId)
                                                .ToList();

            //可见店铺列表
            var retentionSupplierIdList = supplierPlatformRelationEntityRepository.EntityQueryable
                                            .Where(c => c.PlatformId == parameter.PlatformId)
                                            .Select(p => (int?)p.SupplierId)
                                            .ToList();

            var list = this.customerEntityRepository.NamedQuery("Pro_QueryUserOrderList")
                        .SetInt32("CustomerID", parameter.CustomerId)
                        .SetInt32("OrderStatusID", parameter.OrderStatus ?? -1)
                        .SetInt32("PaidStatus", parameter.PaidStatus == null ? -1 : parameter.PaidStatus == true ? 1 : 0)
                        .SetInt32("PageIndex", parameter.PageIndex ?? -1)
                        .SetInt32("PageSize", parameter.PageSize)
                        .SetString("SupplierGroupIdList", string.Join(",", retentionSupplierGroupIdList))
                        .SetString("SupplierIdList", string.Join(",", retentionSupplierIdList)).List();

            var orderList = (from object[] item in list
                             let dateReserved = item[1].ObjectToDateTime()
                             select new AllOrderModel
                             {
                                 OrderId = item[0].ObjectToInt(),
                                 DateReserved = dateReserved == null ? string.Empty : dateReserved.Value.ToString("yyyy-MM-dd HH:mm"),
                                 CustomerTotal = item[2].ObjectToDecimal() ?? 0,
                                 OrderStatusId = item[3].ObjectToInt(),
                                 DineNumber = item[4].ObjectToInt(),
                                 OrderType = item[5].ObjectToInt(),
                                 SupplierId = item[6].ObjectToInt(),
                                 SupplierName = item[7].ObjectToString(),
                                 OrderStatus = string.Empty,
                                 DeliveryMethodId = item[8].ObjectToIntObject() ?? 0,
                                 IsPaid = item[9].ObjectToBoolean() ?? false
                             }).ToList();

            return new ServicesResultList<IOrderModel>
            {
                Result = orderList.Cast<IOrderModel>().ToList()
            };
        }
    }
}
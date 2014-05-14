﻿namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UserTangShiOrders
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/21 0:20
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserTangShiOrders : IUserOrders
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
        /// 字段orderDetailEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/16/2014 9:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository;

        /// <summary>
        /// 字段paymentRecordEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/16/2014 9:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository;

        /// <summary>
        /// 可见店铺表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 10:18 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository;

        /// <summary>
        /// 可见集团表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 10:18 AM
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
                return OrderType.TangShi;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDingTaiOrders" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// <param name="orderDetailEntityRepository">The orderDetailEntityRepository</param>
        /// <param name="paymentRecordEntityRepository">The paymentRecordEntityRepository</param>
        /// <param name="supplierPlatformRelationEntityRepository">The supplierPlatformRelationEntityRepositoryDefault documentation</param>
        /// <param name="supplierGroupPlatformEntityRepository">The supplierGroupPlatformEntityRepositoryDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserTangShiOrders(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository,
            INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository,
            INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository,
            INHibernateRepository<SupplierGroupPlatformEntity> supplierGroupPlatformEntityRepository)
        {
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.orderDetailEntityRepository = orderDetailEntityRepository;
            this.paymentRecordEntityRepository = paymentRecordEntityRepository;
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

            var orderList = this.GetTangShiOrderList(parameter);
            return new ServicesResultList<IOrderModel>
                {
                    Result = orderList.Cast<IOrderModel>().ToList()
                };
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
        private IEnumerable<TangShiOrderModel> GetTangShiOrderList(UserOrdersParameter parameter)
        {
            var queryableTemp = (from tableReservationEntity in this.tableReservationEntityRepository.EntityQueryable
                                 where tableReservationEntity.CustomerId == parameter.CustomerId
                                 && tableReservationEntity.Cancelled == parameter.Cancelled
                                 && tableReservationEntity.Type == 1
                                 select new
                                 {
                                     tableReservationEntity.TableReservationId,
                                     tableReservationEntity.OrderNumber,
                                     tableReservationEntity.Supplier.SupplierId,
                                     tableReservationEntity.Supplier.SupplierName,
                                     tableReservationEntity.DateReserved,
                                     tableReservationEntity.CustomerTotal,
                                     tableReservationEntity.TableStatus,
                                     tableReservationEntity.DineNumber,
                                     tableReservationEntity.IsPaId,
                                     tableReservationEntity.Supplier.SupplierGroupId
                                 });

            if (parameter.SupplierGroupId != null)
            {
                queryableTemp = queryableTemp.Where(p => p.SupplierGroupId == parameter.SupplierGroupId);
            }

            if (parameter.IsEtaoshi)
            {
                //显示 可见集团列表，可见店铺列表
                queryableTemp = (from queryable in queryableTemp
                                 from supplierGroupPlatform in supplierGroupPlatformEntityRepository.EntityQueryable
                                 from supplierPlatformRelation in supplierPlatformRelationEntityRepository.EntityQueryable
                                 where queryable.SupplierGroupId == supplierGroupPlatform.SupplierGroupId
                                       && supplierGroupPlatform.PlatformId == parameter.PlatformId
                                       && queryable.SupplierId == supplierPlatformRelation.SupplierId
                                       && supplierPlatformRelation.PlatformId == parameter.PlatformId
                                 select new
                                 {
                                     queryable.TableReservationId,
                                     queryable.OrderNumber,
                                     queryable.SupplierId,
                                     queryable.SupplierName,
                                     queryable.DateReserved,
                                     queryable.CustomerTotal,
                                     queryable.TableStatus,
                                     queryable.DineNumber,
                                     queryable.IsPaId,
                                     queryable.SupplierGroupId
                                 });
            }

            if (parameter.SupplierId != null)
            {
                queryableTemp = queryableTemp.Where(p => p.SupplierId == parameter.SupplierId);
            }

            if (parameter.OrderStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.TableStatus == parameter.OrderStatus);
            }

            if (parameter.PaidStatus != null)
            {
                queryableTemp = queryableTemp.Where(p => p.IsPaId == parameter.PaidStatus);
            }

            queryableTemp = queryableTemp.OrderByDescending(p => p.DateReserved);
            if (parameter.PageIndex != null)
            {
                queryableTemp = queryableTemp.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize);
            }

            //菜品名称（菜品1,菜品2,菜品3)
            var tableReservationList = queryableTemp.ToList();
            var tableReservationIdList = tableReservationList.Select(p => (int?)p.TableReservationId).ToList();

            var orderList = (from order in this.orderDetailEntityRepository.EntityQueryable
                             where tableReservationIdList.Contains(order.OrderId)
                             select new
                             {
                                 order.SupplierDishName,
                                 order.OrderId
                             }).ToList();

            var strTableReservationIdList = tableReservationList.Select(p => p.TableReservationId.ToString()).ToList();
            var paymentList = (from payment in this.paymentRecordEntityRepository.EntityQueryable
                               where strTableReservationIdList.Contains(payment.OrderId)
                               select new
                               {
                                   payment.PaymentMethodId,
                                   payment.OrderId
                               }).ToList();

            var result = tableReservationList.Select(p => new TangShiOrderModel
            {
                OrderId = p.OrderNumber ?? 0,
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName ?? string.Empty,
                DateReserved = p.DateReserved.ToString("yyyy-MM-dd HH:mm"),
                CustomerTotal = p.CustomerTotal ?? 0,
                OrderStatusId = p.TableStatus ?? 0,
                DineNumber = p.DineNumber ?? 0,
                OrderStatus = string.Empty,
                OrderType = (int)this.OrderType,
                IsPaid = p.IsPaId ?? false,
                DishNames = string.Join("，", orderList.Where(q => q.OrderId == p.TableReservationId).Select(c => c.SupplierDishName).ToList()),
                //支付方式
                PaymentMethodId = paymentList.Where(q => q.OrderId == p.TableReservationId.ToString()).Select(pay => pay.PaymentMethodId).FirstOrDefault() ?? -1
            }).ToList();

            return result;
        }
    }
}
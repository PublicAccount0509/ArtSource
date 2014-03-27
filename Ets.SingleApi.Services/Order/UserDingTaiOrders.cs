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

        private readonly INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository;

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
            get { return OrderType.DingTai; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDingTaiOrders" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// <param name="orderDetailEntityRepository">The orderDetailEntityRepository</param>
        /// <param name="paymentRecordEntityRepository">The paymentRecordEntityRepository</param>
        /// <param name="deskBookingEntityRepository">The deskBookingEntityRepositoryDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UserDingTaiOrders(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository,
            INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository,
            INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository)
        {
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.orderDetailEntityRepository = orderDetailEntityRepository;
            this.paymentRecordEntityRepository = paymentRecordEntityRepository;
            this.deskBookingEntityRepository = deskBookingEntityRepository;
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

            var orderList = this.GetDingTaiOrderList(parameter);
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
        private IEnumerable<DingTaiOrderModel> GetDingTaiOrderList(UserOrdersParameter parameter)
        {
            var retentionSupplierGroupIdList =
                ServicesCommon.RetentionSupplierGroupIdList.Select(p => (int?)p).ToList();
            var queryableTemp = (from tableReservationEntity in this.tableReservationEntityRepository.EntityQueryable
                                 where tableReservationEntity.CustomerId == parameter.CustomerId
                                       && tableReservationEntity.Cancelled == parameter.Cancelled
                                       && (tableReservationEntity.Type == 2 || tableReservationEntity.Type == 3)
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
                queryableTemp = queryableTemp.Where(p => retentionSupplierGroupIdList.Contains(p.SupplierGroupId));
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
                queryableTemp =
                    queryableTemp.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize).Take(parameter.PageSize);
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



            /*订台信息*/
            var orderNumberList = tableReservationList.Select(p => p.OrderNumber).ToList();
            var deskBookingList = (from deskBooking in this.deskBookingEntityRepository.EntityQueryable
                                   where orderNumberList.Contains(deskBooking.OrderNo)
                                   select new
                                       {
                                           deskBooking.OrderNo,
                                           deskBooking.Desk.DeskNo,
                                           deskBooking.DeskType.RoomType,
                                           RoomTypeName = deskBooking.DeskType.RoomType == null ? "" : (deskBooking.DeskType.RoomType == 0 ? "散座" : "包房"),
                                           deskBooking.DeskType.MinNumber,
                                           deskBooking.DeskType.MaxNumber,
                                           BookDate = deskBooking.ReservationTime,
                                           deskBooking.Desk.ImgPath,
                                           deskBooking.DeskType.TableType.TblTypeName
                                       }
                                  ).ToList();

            var result = (from p in tableReservationList
                          let deskBooking = deskBookingList.FirstOrDefault(q => q.OrderNo == p.OrderNumber)
                          select new DingTaiOrderModel
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
                                  DishNames =
                                      string.Join("，",
                                                  orderList.Where(q => q.OrderId == p.TableReservationId)
                                                           .Select(c => c.SupplierDishName)
                                                           .ToList()),
                                  //支付方式
                                  PaymentMethodId =
                                      paymentList.Where(q => q.OrderId == p.TableReservationId.ToString())
                                                 .Select(pay => pay.PaymentMethodId)
                                                 .FirstOrDefault() ?? -1,
                                  DeskNo = deskBooking == null ? string.Empty : deskBooking.DeskNo,
                                  RoomType = deskBooking == null ? 0 : deskBooking.RoomType ?? 0,
                                  RoomTypeName = deskBooking == null ? string.Empty : (deskBooking.RoomType == null ? string.Empty : (deskBooking.RoomType == 0 ? "散座" : "包房")),
                                  MinNumber = deskBooking == null ? 0 : deskBooking.MinNumber,
                                  MaxNumber = deskBooking == null ? 0 : deskBooking.MaxNumber,
                                  BookDate = deskBooking == null ? null : deskBooking.BookDate,
                                  BookTime = deskBooking == null ? string.Empty : deskBooking.BookDate.Value.ToString("HH:mm"),
                                  DeskImgUrl = deskBooking == null ? string.Empty : string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, deskBooking.ImgPath),
                                  TblTypeName = deskBooking == null ? string.Empty : deskBooking.TblTypeName
                              }).ToList();
            return result;
        }
    }
}
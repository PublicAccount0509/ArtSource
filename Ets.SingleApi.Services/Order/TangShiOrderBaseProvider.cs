using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.IRepository;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Services
{
    using System;

    /// <summary>
    /// 类名称：TangShiOrderBaseProvider
    /// 命名空间：Ets.SingleApi.Services.Order
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 4:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TangShiOrderBaseProvider : IOrderBaseProvider
    {
        /// <summary>
        /// 字段tableReservationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TableReservationEntity> tableReservationEntityRepository;

        /// <summary>
        /// 字段orderNumberDtEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository;

        /// <summary>
        /// 字段paymentRecordEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TangShiOrderBaseProvider" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The tableReservationEntityRepository</param>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// <param name="paymentRecordEntityRepository">The paymentRecordEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public TangShiOrderBaseProvider(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository,
            INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository)
        {
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
            this.paymentRecordEntityRepository = paymentRecordEntityRepository;
        }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderType OrderType
        {
            get { return OrderType.TangShi; }
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderNumber(string source)
        {
            var entity = this.orderNumberDtEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDtEntityRepository.Remove(entity);
            return new ServicesResult<string>
            {
                Result = orderNumber.ToString()
            };
        }

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(string source, int orderId)
        {
            var tableReservationEntity = (from entity in this.tableReservationEntityRepository.EntityQueryable
                                          where entity.OrderNumber == orderId
                                          select entity).FirstOrDefault();

            if (tableReservationEntity == null)
            {
                return new ServicesResult<int>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            return new ServicesResult<int>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = tableReservationEntity.IsPaId == true ? 1 : 2
            };
        }

        /// <summary>
        /// 保存支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="isPaid">支付状态</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaid(string source, int orderId, bool isPaid)
        {
            var tableReservationEntity = this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId);
            if (tableReservationEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = false
                };
            }

            tableReservationEntity.IsPaId = true;
            this.tableReservationEntityRepository.Save(tableReservationEntity);

            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 保存订单的支付方式
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">备注</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaymentMethod(string source, int orderId, int paymentMethodId, string payBank)
        {
            var tableReservationEntity = this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId);
            if (tableReservationEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = false
                };
            }

            var tableReservationId = tableReservationEntity.TableReservationId.ToString();
            var paymentRecordEntity = this.paymentRecordEntityRepository.EntityQueryable.FirstOrDefault(p => p.OrderId == tableReservationId)
                                 ?? new PaymentRecordEntity
                                 {
                                     PaymentTypeId = 1,
                                     OrderId = tableReservationId,
                                     PaymentDate = DateTime.Now
                                 };

            paymentRecordEntity.Amount = tableReservationEntity.CustomerTotal ?? 0;
            paymentRecordEntity.OrderTypeId = 1; //订台 2 堂食 1
            paymentRecordEntity.PaymentMethodId = paymentMethodId;
            paymentRecordEntity.PayBank = payBank;
            this.paymentRecordEntityRepository.Save(paymentRecordEntity);
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 当前订单是否可以修改
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，空字串可以修改；否则，不可修改。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderEditFlag(string source, int orderId)
        {
            var tableReservationEntity = (from entity in this.tableReservationEntityRepository.EntityQueryable
                                          where entity.OrderNumber == orderId
                                          select entity).FirstOrDefault();
            if (tableReservationEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = string.Empty
                };
            }

            if (!ServicesCommon.TangShiOrderEditStatusIdList.Contains(tableReservationEntity.TableStatus ?? 0))
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = "订单已接受，无法修改"
                };
            }

            if (tableReservationEntity.IsPaId == true)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = "订单已支付，无法修改"
                };
            }

            if (tableReservationEntity.Cancelled == true)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = "订单已取消，无法修改"
                };
            }

            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = string.Empty
            };
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，true取消成功；false取消失败。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CancelOrder(string source, int orderId)
        {
            var tableReservationEntity = (from entity in this.tableReservationEntityRepository.EntityQueryable
                                          where entity.OrderNumber == orderId
                                          select entity).FirstOrDefault();
            if (tableReservationEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = false
                };
            }

            tableReservationEntity.Cancelled = true;
            this.tableReservationEntityRepository.Save(tableReservationEntity);
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }
    }
}

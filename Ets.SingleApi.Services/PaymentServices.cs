namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：PaymentServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：支付功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 3:24 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PaymentServices : IPaymentServices
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 4:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段paymentList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IPayment> paymentList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentServices" /> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="paymentList">The paymentList</param>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentServices(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            List<IPayment> paymentList)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.paymentList = paymentList;
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> UmPayment(UmPaymentParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var payment = this.paymentList.FirstOrDefault(p => p.OrderType == orderType && p.PaymentType == PaymentType.UmPayment);
            if (payment == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = payment.Payment(new UmPaymentData
                                           {
                                               OrderId = parameter.OrderId,
                                               Amount = parameter.Amount,
                                               PayDate = parameter.PayDate
                                           });

            if (result == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.UmPayment.TradeFailCode
                };
            }

            return new ServicesResult<string>
            {
                Result = result.Result,
                StatusCode = result.StatusCode
            };
        }

        /// <summary>
        /// 支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 4:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UmPaymentState(UmPaymentStateParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var payment = this.paymentList.FirstOrDefault(p => p.OrderType == orderType && p.PaymentType == PaymentType.UmPayment);
            if (payment == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = payment.QueryState(new UmPaymentQueryData
            {
                OrderId = parameter.OrderId,
                PayDate = parameter.PayDate
            });

            if (result == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.UmPayment.TradeFailCode
                };
            }

            return new ServicesResult<bool>
            {
                Result = result.Result,
                StatusCode = result.StatusCode
            };
        }
    }
}
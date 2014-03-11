using Ets.SingleApi.Services.Payment;

namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
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
        /// 字段paymentList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IPayment> paymentList;

        /// <summary>
        /// 字段orderBaseProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 9:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IOrderBaseProvider> orderBaseProviderList;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentServices" /> class.
        /// </summary>
        /// <param name="paymentList">The paymentList</param>
        /// <param name="orderBaseProviderList">The orderBaseProviderList</param>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentServices(
            List<IPayment> paymentList,
            List<IOrderBaseProvider> orderBaseProviderList)
        {
            this.paymentList = paymentList;
            this.orderBaseProviderList = orderBaseProviderList;
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> UmPayment(string source, UmPaymentParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var existResult = orderBaseProvider.Exist(source, parameter.OrderId);
            if (existResult == null || existResult.Result == 0)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            if (existResult.Result == 1)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.DoublePayment
                };
            }

            var payment = this.paymentList.FirstOrDefault(p => p.PaymentType == PaymentType.UmPayment);
            if (payment == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidPaymentType
                };
            }

            var result = payment.Payment(new UmPaymentData
                                           {
                                               OrderId = parameter.OrderId,
                                               Amount = parameter.Amount,
                                               PayDate = parameter.PayDate,
                                               ReturnUrl = parameter.ReturnUrl,
                                               NotifyUrl = parameter.NotifyUrl
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
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 4:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UmPaymentState(string source, UmPaymentStateParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var existResult = orderBaseProvider.Exist(source, parameter.OrderId);
            if (existResult == null || existResult.Result == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            var payment = this.paymentList.FirstOrDefault(p => p.PaymentType == PaymentType.UmPayment);
            if (payment == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidPaymentType
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

            if (result.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    Result = result.Result,
                    StatusCode = result.StatusCode
                };
            }

            var saveOrderPaidResult = orderBaseProvider.SaveOrderPaid(source, parameter.OrderId, true);
            return new ServicesResult<bool>
            {
                Result = saveOrderPaidResult.Result,
                StatusCode = saveOrderPaidResult.StatusCode
            };
        }

        /// <summary>
        /// 获取百付宝支付请求Url
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 百付宝支付请求Url
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> BaiFuBaoPayment(string source, BaiFuBaoPaymentParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var existResult = orderBaseProvider.Exist(source, parameter.OrderId);
            if (existResult == null || existResult.Result == 0)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            if (existResult.Result == 1)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.DoublePayment
                };
            }

            var payment = this.paymentList.FirstOrDefault(p => p.PaymentType == PaymentType.BaiFuBaoPayment);
            if (payment == null)
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.Validate.InvalidPaymentType
                };
            }

            var result = payment.Payment(new BaiFuBaoPaymentData
            {
                OrderId = parameter.OrderId.ToString(),
                GoodsName = parameter.GoodsName,
                Amount = parameter.Amount,
                PageUrl = parameter.PageUrl
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
        /// 百付宝支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// The Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 1:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> BaiFuBaoPaymentState(string source, BaiFuBaoPaymentStateParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var orderType = (OrderType)parameter.OrderType;
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var existResult = orderBaseProvider.Exist(source, parameter.OrderId);
            if (existResult == null || existResult.Result == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            var payment = this.paymentList.FirstOrDefault(p => p.PaymentType == PaymentType.BaiFuBaoPayment);
            if (payment == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidPaymentType
                };
            }

            var result = payment.QueryState(new BaiFuBaoPaymentQueryData
            {
                OrderId = parameter.OrderId
            });

            if (result == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.UmPayment.TradeFailCode
                };
            }

            if (result.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    Result = result.Result,
                    StatusCode = result.StatusCode
                };
            }

            var saveOrderPaidResult = orderBaseProvider.SaveOrderPaid(source, parameter.OrderId, true);
            return new ServicesResult<bool>
            {
                Result = saveOrderPaidResult.Result,
                StatusCode = saveOrderPaidResult.StatusCode
            };
        }


        /// <summary>
        /// 微信 支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付状态
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：3/10/2014 6:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> WeChatPayMentState(string source, UmPaymentStateParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var orderType = (OrderType)parameter.OrderType;

            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var existResult = orderBaseProvider.Exist(source, parameter.OrderId);
            if (existResult == null || existResult.Result == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            var payment = this.paymentList.FirstOrDefault(p => p.PaymentType == PaymentType.WeChatPayment);
            if (payment == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.Validate.InvalidPaymentType
                };
            }

            var saveOrderPaidResult = orderBaseProvider.SaveOrderPaid(source, parameter.OrderId, true);
            return new ServicesResult<bool>
            {
                Result = saveOrderPaidResult.Result,
                StatusCode = saveOrderPaidResult.StatusCode
            };
        }
    }
}
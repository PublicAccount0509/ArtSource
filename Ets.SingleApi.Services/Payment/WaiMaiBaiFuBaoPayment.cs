namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WaiMaiUmPayment
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：百付宝支付
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：02/10/2014 1:54 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiBaiFuBaoPayment : IPayment
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiUmPayment"/> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiBaiFuBaoPayment(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
        }

        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 2:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentType PaymentType
        {
            get
            {
                return PaymentType.BaiFuBaoPayment;
            }
        }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 3:14 PM
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
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> Payment(IPaymentData parameter)
        {
            return new PaymentResult<string>{Result = string.Empty};
        }

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<bool> QueryState(IPaymentData parameter)
        {
            var umPaymentQueryData = parameter as UmPaymentQueryData;
            if (umPaymentQueryData == null)
            {
                return new PaymentResult<bool>
                    {
                        StatusCode = (int)StatusCode.System.InvalidPaymentRequest
                    };
            }

            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == umPaymentQueryData.OrderId);
            if (deliveryEntity == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            deliveryEntity.IsPaId = true;
            this.deliveryEntityRepository.Save(deliveryEntity);

            return new PaymentResult<bool>
            {
                StatusCode = (int)StatusCode.UmPayment.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 取得返回状态码
        /// </summary>
        /// <param name="tradeState">State of the trade.</param>
        /// <returns>
        /// 状态码
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 2:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private StatusCode.UmPayment GetTradeState(string tradeState)
        {
            switch (tradeState)
            {
                case "WAIT_BUYER_PAY":
                    return StatusCode.UmPayment.WaitBuyerPayCode;
                case "TRADE_SUCCESS":
                    return StatusCode.UmPayment.TradeSuccessCode;
                case "TRADE_CLOSED":
                    return StatusCode.UmPayment.TradeClosedCode;
                case "TRADE_CANCEL":
                    return StatusCode.UmPayment.TradeCancelCode;
                case "TRADE_FAIL":
                    return StatusCode.UmPayment.TradeFailCode;
                default:
                    return StatusCode.UmPayment.UnknowErrorCode;
            }
        }

        /// <summary>
        /// 金钱格式转换，34.576会被转换为3457，表示34圆5角7分
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 2:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string AmountToString(decimal amount)
        {
            var str = amount.ToString("C").TrimStart('¥').Replace(",", string.Empty);
            var n = str.IndexOf(".", StringComparison.Ordinal);
            var pre = str.Substring(0, n);
            var end = str.Substring(n, 3).Trim('.');
            return pre + end;
        }

        /// <summary>
        /// 发起http get请求 取页面内容
        /// </summary>
        /// <param name="url">url地址</param>
        /// <returns>
        /// 返回页面内容
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 2:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string HttpGet(string url)
        {
            var request = System.Net.WebRequest.Create(url);
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null)
                    {
                        return string.Empty;
                    }

                    using (var reader = new System.IO.StreamReader(stream))
                    {
                        return reader.ReadToEnd().Trim();
                    }
                }
            }
        }
    }
}
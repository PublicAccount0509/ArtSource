namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Services.Payment;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UmPayment
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：联动优势支付
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 1:54 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UmPayment : IPayment
    {
        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentType PaymentType
        {
            get
            {
                return PaymentType.UmPayment;
            }
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> Payment(IPaymentData parameter)
        {
            var umPaymentData = parameter as UmPaymentData;
            if (umPaymentData == null)
            {
                return new PaymentResult<string>
                    {
                        StatusCode = (int)StatusCode.System.InvalidPaymentRequest
                    };
            }

            var ht = new Hashtable();
            ht.Add("service", "pay_req"); // 接口名称 pay_req:一般支付请求 pay_req_ivr_call:IVR支付方式下单 pay_req_ivr_tcall:IVR转呼方式下单
            ht.Add("charset", "UTF-8"); // 字符编码
            ht.Add("sign_type", ServicesCommon.UmPaySignType); // 签名方式
            ht.Add("version", ServicesCommon.UmPayVersion); //版本号
            ht.Add("mer_id", ServicesCommon.UmPayMerId); //商户号
            ht.Add("order_id", umPaymentData.OrderId);  //订单号
            ht.Add("goodsInf", umPaymentData.OrderId);  //商品信息
            ht.Add("mer_date", umPaymentData.PayDate.ToString("yyyyMMdd")); //订单日期
            ht.Add("amount", AmountToString(umPaymentData.Amount).TrimStart('0')); //金额,格式为圆角分，例如:3456表示34圆5角6分
            //ht.Add("amount", "1"); //金额,格式为圆角分，例如:3456表示34圆5角6分
            ht.Add("amt_type", "RMB"); //金额类型
            ht.Add("mer_priv", "delivery"); //商户私有信息

            if (!umPaymentData.ReturnUrl.IsEmptyOrNull())
            {
                ht.Add("ret_url", umPaymentData.ReturnUrl); //页面返回地址
            }
            if (!umPaymentData.NotifyUrl.IsEmptyOrNull())
            {
                ht.Add("notify_url", umPaymentData.NotifyUrl); //结果通讯地址
            }

            var reqData = com.umpay.api.paygate.v40.Mer2Plat_v40.ReqDataByGet(ht); //标准支付下单
            if (reqData == null)
            {
                return new PaymentResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.UmPayment.PaymentReqDataByGetErrorCode
                };
            }

            var request = this.HttpGet(reqData.Url); //请求结果
            var req = com.umpay.api.paygate.v40.Plat2Mer_v40.getResData(request); //解析html
            if (req == null)
            {
                return new PaymentResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.UmPayment.PaymentGetResDataErrorCode
                };
            }

            return new PaymentResult<string>
                {
                    Result = req.ContainsKey("trade_no") ? (req["trade_no"] ?? string.Empty).ToString() : string.Empty
                };
        }

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:50 PM
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

            var ht = new Hashtable();
            ht.Add("service", "query_order"); // 接口名称 pay_req:一般支付请求 pay_req_ivr_call:IVR支付方式下单 pay_req_ivr_tcall:IVR转呼方式下单
            ht.Add("charset", "UTF-8"); // 字符编码
            ht.Add("sign_type", ServicesCommon.UmPaySignType); // 签名方式
            ht.Add("version", ServicesCommon.UmPayVersion); //版本号
            ht.Add("mer_id", ServicesCommon.UmPayMerId); //商户号
            ht.Add("order_id", umPaymentQueryData.OrderId);  //订单号
            ht.Add("mer_date", umPaymentQueryData.PayDate.ToString("yyyyMMdd")); //订单日期
            var reqData = com.umpay.api.paygate.v40.Mer2Plat_v40.ReqDataByGet(ht); //标准支付下单
            if (reqData == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.UmPayment.PaymentReqDataByGetErrorCode
                };
            }

            var request = this.HttpGet(reqData.Url); //请求结果
            var req = com.umpay.api.paygate.v40.Plat2Mer_v40.getResData(request); //解析html
            if (req == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.UmPayment.PaymentGetResDataErrorCode
                };
            }

            if ((req["ret_code"] ?? string.Empty).ToString() == "00060760")
            {
                return new PaymentResult<bool>
                    {
                        StatusCode = (int)StatusCode.UmPayment.InvalidPaymentNoCode
                    };
            }

            var result = this.GetTradeState((req["trade_state"] ?? string.Empty).ToString());
            if (result != StatusCode.UmPayment.Ok && result != StatusCode.UmPayment.TradeSuccessCode)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)this.GetTradeState((req["trade_state"] ?? string.Empty).ToString())
                };
            }

            return new PaymentResult<bool>
            {
                StatusCode = (int)StatusCode.UmPayment.Ok,
                Result = true
            };
        }

        public PaymentResult<bool> Verify(IPaymentData parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得返回状态码
        /// </summary>
        /// <param name="tradeState">State of the trade.</param>
        /// <returns>
        /// 状态码
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:56 PM
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
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:55 PM
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
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:02 PM
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


        public PaymentResult<string> PaymentQr(IPaymentData parameter)
        {
            throw new NotImplementedException();
        }


        public PaymentResult<WechatResponsePaymentDataQrPackage> PaymentQrPackage(IPaymentData parameter)
        {
            throw new NotImplementedException();
        }
    }
}
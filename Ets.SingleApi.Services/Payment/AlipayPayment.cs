using Ets.SingleApi.Model;
using Ets.SingleApi.Services.Payment;
using Ets.SingleApi.Utility;
using System;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：AlipayPayment
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：支付宝支付功能
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：3/10/2014 1:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AlipayPayment : IPayment
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
                return PaymentType.AlipayPayment;
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
            var alipayPaymentData = parameter as AlipayPaymentData;

            if (alipayPaymentData == null)
            {
                return new PaymentResult<string> { Result = string.Empty, StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }
            
            //获取授权Token
            var token = AlipayPaymentCommon.RequestToken(alipayPaymentData);

            //if (token.IsEmptyOrNull())
            //{
            //    return new PaymentResult<string>
            //        {
            //            Result = "",
            //            StatusCode = (int) StatusCode.Validate.InvalidDeliveryTimeCode
            //        };
            //}

            var requestPaymentUrl = alipayPaymentData.GateWayNew + AlipayPaymentCommon.BuildRequestPaymentUrl(alipayPaymentData, token, true) + "&sign=" +
                                    AlipayPaymentCommon.SignMd5(AlipayPaymentCommon.BuildRequestPaymentUrl(alipayPaymentData, token, false),
                                        alipayPaymentData.Key, alipayPaymentData.InputCharSet);

            return new PaymentResult<string> { Result = requestPaymentUrl, StatusCode = (int)StatusCode.Succeed.Ok };
        }

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：10/28/2014 4:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<bool> QueryState(IPaymentData parameter)
        {
            var alipayPaymentQueryData = parameter as AlipayPaymentQueryData;
            if (alipayPaymentQueryData == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest
                };
            }

            //验签名
            //var isdsd = AlipayPaymentCommon.VerifyMd5(alipayPaymentQueryData.NotSign, alipayPaymentQueryData.Sign, Controllers.ControllersCommon.AlipayKey, Controllers.ControllersCommon.AlipayInputCharSet);

            //if (!isdsd)
            //{
            //    return new PaymentResult<bool>
            //    {
            //        StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
            //        Result = false
            //    };
            //}
            var isPayment = AlipayPaymentCommon.OrderQuery(alipayPaymentQueryData.OrderId);

            return isPayment;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// The Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/4/2014 11:31 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<bool> Verify(IPaymentData parameter)
        {
            var alipayPaymentBackgroundNoticeData = parameter as AlipayPaymentBackgroundNoticeData;

            if (alipayPaymentBackgroundNoticeData == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }
            var verifyResult = AlipayPaymentCommon.VerifyNotify(alipayPaymentBackgroundNoticeData.Request, alipayPaymentBackgroundNoticeData.Sign);
            
            return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = verifyResult
                };
        }

        /// <summary>
        /// 二维码支付功能
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：2014/10/27 14:14
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> PaymentQr(IPaymentData parameter)
        {
            var paymentData = parameter as AlipayPaymentDataQr;

            if (paymentData == null)
            {
                return new PaymentResult<string> { Result = string.Empty, StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }

            var paymentQr = new AlipayPaymentCommon.PaymentQr(paymentData.Productid, paymentData.DeviceNumber, paymentData.CustomerTotal);


            string requestPaymentJsonStr = paymentQr.ToPaymentQr();

            return new PaymentResult<string> { Result = requestPaymentJsonStr, StatusCode = (int)StatusCode.Succeed.Ok };
        }


        public PaymentResult<WechatResponsePaymentDataQrPackage> PaymentQrPackage(IPaymentData parameter)
        {
            throw new NotImplementedException();
        }
    }
}

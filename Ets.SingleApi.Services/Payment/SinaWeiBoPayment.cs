using Ets.SingleApi.Model;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：SinaWeiBoPayment
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：新浪微博支付功能
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：3/10/2014 1:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SinaWeiBoPayment : IPayment
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
                return PaymentType.SinaWeiBoPayment;
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

            //后台通知地址
            alipayPaymentData.NotifyUrl = Controllers.ControllersCommon.AlipayBackgroundNoticeUrl;

            //获取授权Token
            var token = AlipayPaymentCommon.RequestToken(alipayPaymentData);
            
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
        /// 创建者：周超
        /// 创建日期：10/28/2013 1:50 PM
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
            var isdsd = AlipayPaymentCommon.VerifyMd5(alipayPaymentQueryData.NotSign, alipayPaymentQueryData.Sign, Controllers.ControllersCommon.AlipayKey, Controllers.ControllersCommon.AlipayInputCharSet);

            if (!isdsd)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }

            //result：success
            if (alipayPaymentQueryData.Result != "success")
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }

            return new PaymentResult<bool>
            {
                StatusCode = (int)StatusCode.UmPayment.Ok,
                Result = true
            };
        }
    }
}

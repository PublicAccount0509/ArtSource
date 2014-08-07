namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Services.Payment;
    using Ets.SingleApi.Utility;


    /// <summary>
    /// 类名称：WechatPayment
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：微信支付
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/3/14 18:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPayment : IPayment
    {

        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 18:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentType PaymentType
        {
            get { return PaymentType.WechatPayment; }
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付请求参数
        /// </returns>
        /// 创建者：孟祺宙 创建日期：2014/3/14 18:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> Payment(IPaymentData parameter)
        {
            var paymentData = parameter as WechatPaymentData;

            if (paymentData == null)
            {
                return new PaymentResult<string> { Result = string.Empty, StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }

            var packAge = new WechatPaymentCommon.PackAgeEntity(paymentData.Body, paymentData.Attach, paymentData.OrderId, paymentData.Amount, paymentData.NotifyUrl, paymentData.SpbillCreateIp, null, null, null, null);

            string package = packAge.BuildPackAge();
            var brandWcPayRequest = new WechatPaymentCommon.BrandWcPayRequest(package);

            string requestPaymentJsonStr = brandWcPayRequest.ToWxpaymentJsonString();

            return new PaymentResult<string> { Result = requestPaymentJsonStr, StatusCode = (int)StatusCode.Succeed.Ok };
        }

        /// <summary>
        /// 二维码支付功能
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/8/5 17:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> PaymentQr(IPaymentData parameter)
        {
            var paymentData = parameter as WechatPaymentDataQr;

            if (paymentData == null)
            {
                return new PaymentResult<string> { Result = string.Empty, StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }

            var paymentQr = new WechatPaymentCommon.PaymentQr(paymentData.Productid);


            string requestPaymentJsonStr = paymentQr.ToPaymentQr();

            return new PaymentResult<string> { Result = requestPaymentJsonStr, StatusCode = (int)StatusCode.Succeed.Ok };
        }



        /// <summary>
        /// 二维码支付获取package
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/8/6 10:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<WechatResponsePaymentDataQrPackage> PaymentQrPackage(IPaymentData parameter)
        {
            var paymentData = parameter as WechatPaymentDataQrPackage;
            if (paymentData == null)
            {
                return new PaymentResult<WechatResponsePaymentDataQrPackage> { Result = new WechatResponsePaymentDataQrPackage(), StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }

            var paymentQrPackage = new WechatPaymentCommon.PaymentQrPackage(paymentData);
            if (!paymentQrPackage.Authentication())
            {
                return new PaymentResult<WechatResponsePaymentDataQrPackage> { Result = new WechatResponsePaymentDataQrPackage(), StatusCode = (int)StatusCode.System.Unauthorized };
            }

            var notifyUrl = "http://htjnew.singleapi.etaoshi.com/payment/WechatPaymentNotify/" + paymentData.OrderType.ToString();
            var package = new WechatPaymentCommon.PackAgeEntity("黄太吉，快速点餐机", "", int.Parse(paymentData.ProductId), paymentData.TotalFee, notifyUrl, paymentData.SpbillCreateIp, null, null, null, null).BuildPackAge();

            int retcode = 0;
            string reterrmsg = "获取订单信息成功";
            if (paymentData.IsPaid)
            {
                retcode = 1;
                reterrmsg = "订单已被支付过了";
            }
            var appSignature = paymentQrPackage.GetAppSignature(package, retcode.ToString(), reterrmsg);


            var result = new WechatResponsePaymentDataQrPackage
                             {
                                 AppId = paymentQrPackage.AppId,
                                 NonceStr = paymentQrPackage.NonceStr,
                                 TimeStamp = paymentQrPackage.TimeStamp,
                                 Package = package,
                                 RetCode = retcode,
                                 RetErrMsg = reterrmsg,
                                 SignMethod = paymentQrPackage.SignMethod,
                                 AppSignature = appSignature
                             };

            return new PaymentResult<WechatResponsePaymentDataQrPackage> { Result = result, StatusCode = (int)StatusCode.Succeed.Ok };
        }

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 10:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<bool> QueryState(IPaymentData parameter)
        {
            var wechatPaymentQueryData = parameter as WechatPaymentQueryData;
            if (wechatPaymentQueryData == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest
                };
            }
            var isdsd = WechatPaymentCommon.BrandWechatPayCallBack.ValidateAppSignature(wechatPaymentQueryData);

            if (!isdsd)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }
            var isPayment = WechatPaymentCommon.BrandWechatPayCallBackQueryOrNotify.OrderQuery(wechatPaymentQueryData.out_trade_no);
            if (!isPayment)
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

        public PaymentResult<bool> Verify(IPaymentData parameter)
        {
            throw new System.NotImplementedException();
        }




    }
}

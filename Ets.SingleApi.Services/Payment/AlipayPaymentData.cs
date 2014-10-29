using System;
using Ets.SingleApi.Controllers;

namespace Ets.SingleApi.Services
{
    public class AlipayPaymentData : IPaymentData
    {
        private readonly string partner;
        private readonly string key;
        private readonly string privateKey;
        private readonly string publicKey;
        private readonly string inputCharset;
        private readonly string signType;
        private readonly string gatewayNew;
        private readonly string format;
        private readonly string v;
        private readonly string reqId;
        private readonly string sellerEmail;

        private readonly string outTradeNo;
        private readonly string subject;
        private readonly string totalFee;
        private readonly string callBackUrl;
        private readonly string notifyUrl;
        private readonly string merchantUrl;

        public AlipayPaymentData(string orderNo, string orderName, string amount,
                                 string callBackUrl, string merchantUrl, string notifyUrl)
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "2088211414008373";

            //交易安全检验码，由数字和字母组成的32位字符串
            //如果签名方式设置为“MD5”时，请设置该参数
            key = ControllersCommon.AlipayKey;

            //商户的私钥
            //如果签名方式设置为“0001”时，请设置该参数
            privateKey = @"mo4h0xascl7yzt0ebv1k7oeohkgwn2uk";

            //支付宝的公钥
            //如果签名方式设置为“0001”时，请设置该参数
            publicKey = @"";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

            //字符编码格式 目前支持 utf-8
            inputCharset = ControllersCommon.AlipayInputCharSet;

            //签名方式，选择项：0001(RSA)、MD5
            signType = ControllersCommon.AlipaySignType;
            //无线的产品中，签名方式为rsa时，sign_type需赋值为0001而不是RSA

            //支付宝网关地址
            gatewayNew = "https://mapi.alipay.com/gateway.do?";

            //返回格式
            format = "xml";
            //必填，不需要修改

            //返回格式
            v = "2.0";
            //必填，不需要修改

            //请求号
            reqId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //必填，须保证每次请求都是唯一

            //卖家支付宝帐户
            sellerEmail = "info@etaoshi.com";
            //必填

            //商户订单号
            outTradeNo = orderNo;

            //订单名称
            subject = orderName;

            //付款金额
            totalFee = amount;

            //页面跳转同步通知页面路径
            this.callBackUrl = callBackUrl;

            //服务器异步通知页面路径
            this.notifyUrl = notifyUrl;

            //操作中断返回地址
            this.merchantUrl = merchantUrl;
        }

        public string Partner { get { return partner; } }
        public string Key { get { return key; } }
        public string PrivateKey { get { return privateKey; } }
        public string Publickey { get { return publicKey; } }
        public string InputCharSet { get { return inputCharset; } }
        public string SignType { get { return signType; } }
        public string GateWayNew { get { return gatewayNew; } }
        public string Format { get { return format; } }
        public string V { get { return v; } }
        public string ReqId { get { return reqId; } }
        public string SellerEmail { get { return sellerEmail; } }
        public string OutTradeNo { get { return outTradeNo; } }
        public string Subject { get { return subject; } }
        public string TotalFee { get { return totalFee; } }
        public string CallBackUrl { get { return callBackUrl; } }
        public string MerchantUrl { get { return merchantUrl; } }

        public string NotifyUrl { get { return notifyUrl; } }
    }
}

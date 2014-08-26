
using Ets.SingleApi.Controllers;
using Ets.SingleApi.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Ets.SingleApi.Services.Payment
{
    /// <summary>
    /// 类名称：微信支付加密类
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 创建日期：2014/3/14 20:00
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPaymentCommon
    {
        /// <summary>
        /// 类名称：PaymentQrPackage
        /// 命名空间：Ets.SingleApi.Services.Payment.WechatPaymentCommon
        /// 类功能：二维码支付package
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 10:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public class PaymentQrPackage
        {
            /// <summary>
            /// 字段WechatPaymentDataQrPackageRequest
            /// </summary>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 11:43
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private readonly WechatPaymentDataQrPackage wechatPaymentDataQrPackageRequest;

            /// <summary>
            /// Initializes a new instance of the <see cref="PaymentQrPackage"/> class.
            /// </summary>
            /// <param name="paymentData">The paymentData</param>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 10:53
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public PaymentQrPackage(WechatPaymentDataQrPackage paymentData)
            {
                this.wechatPaymentDataQrPackageRequest = paymentData;

                this.AppId = paymentData.AppId;
                this.AppSignature = paymentData.AppSignature;
                this.IsSubscribe = paymentData.IsSubscribe;
                this.OpenId = paymentData.OpenId;
                this.ProductId = paymentData.ProductId;
                this.SignMethod = paymentData.SignMethod;

                this.NonceStr = Guid.NewGuid().ToString("N");
                this.TimeStamp = WinDateToLinuxDate(DateTime.Now).ToString();

                this.AppKey = ControllersCommon.ConstWechatPaymentPaySignKey;
            }

            /// <summary>
            /// The method will 
            /// </summary>
            /// <returns>
            /// The Boolean
            /// </returns>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 11:37
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public bool Authentication()
            {
                var signature = this.BuildPaySign(new Dictionary<string, string>{
                                                                                    { "appid",this.wechatPaymentDataQrPackageRequest.AppId },
                                                                                    { "appkey", this.AppKey },
                                                                                    { "productid", this.wechatPaymentDataQrPackageRequest.ProductId },
                                                                                    { "timestamp", this.wechatPaymentDataQrPackageRequest.TimeStamp },
                                                                                    { "noncestr", this.wechatPaymentDataQrPackageRequest.NonceStr },
                                                                                    { "openid", this.wechatPaymentDataQrPackageRequest.OpenId },
                                                                                    { "issubscribe", this.wechatPaymentDataQrPackageRequest.IsSubscribe }
                                                                                });
                return this.AppSignature.Equals(signature);
            }
            /// <summary>
            /// Builds the pay sign.
            /// </summary>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 11:33
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private string BuildPaySign(Dictionary<string, string> dictionary)
            {
                var string1 = BrandWechatPaySign.AsciiOrderAscKeyToLower(dictionary);
                return BrandWechatPaySign.Sha1String1(string1);
            }

            /// <summary>
            /// To the payment package.
            /// </summary>
            /// <param name="package">The package</param>
            /// <param name="retcode">The retcode</param>
            /// <param name="reterrmsg">The reterrmsg</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙
            /// 创建日期：2014/8/6 11:38
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string GetAppSignature(string package, string retcode, string reterrmsg)
            {
                return this.BuildPaySign(new Dictionary<string, string>
                                             {
                                                 { "appid", this.AppId },
                                                 { "appkey", this.AppKey },
                                                 { "package", package },
                                                 { "timestamp", this.TimeStamp },
                                                 { "noncestr", this.NonceStr },
                                                 { "retcode", retcode },
                                                 { "reterrmsg", reterrmsg }
                                             });
            }

            /// <summary>
            /// Gets or sets the AppKey of PaymentQrPackage
            /// </summary>
            /// <value>
            /// The AppKey
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 11:35
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string AppKey { get; set; }

            /// <summary>
            /// Gets or sets the OpenId of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The OpenId
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:48
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string OpenId { get; set; }

            /// <summary>
            /// Gets or sets the AppId of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The AppId
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:48
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string AppId { get; set; }

            /// <summary>
            /// Gets or sets the IsSubscribe of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The IsSubscribe
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:51
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string IsSubscribe { get; set; }

            /// <summary>
            /// Gets or sets the ProductId of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The ProductId
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:51
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string ProductId { get; set; }

            /// <summary>
            /// Gets or sets the TimeStamp of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The TimeStamp
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:51
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string TimeStamp { get; set; }

            /// <summary>
            /// Gets or sets the NonceStr of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The NonceStr
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:51
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string NonceStr { get; set; }

            /// <summary>
            /// Gets or sets the AppSignature of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The AppSignature
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:52
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string AppSignature { get; set; }

            /// <summary>
            /// Gets or sets the SignMethod of WechatPaymentRequestQrPackage
            /// </summary>
            /// <value>
            /// The SignMethod
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/6 9:52
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string SignMethod { get; set; }
        }

        /// <summary>
        /// 类名称：PaymentQr
        /// 命名空间：Ets.SingleApi.Services.Payment.WechatPaymentCommon
        /// 类功能：二维码支付
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/5 17:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public class PaymentQr
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PaymentQr"/> class.
            /// </summary>
            /// <param name="_productid">The _productid</param>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:24
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public PaymentQr(string _productid)
            {
                this.appid = ControllersCommon.ConstWechatPaymentAppId;
                this.appkey = ControllersCommon.ConstWechatPaymentPaySignKey;
                this.noncestr = Guid.NewGuid().ToString("N");
                this.timestamp = WinDateToLinuxDate(DateTime.Now).ToString();
                //(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("#");
                this.productid = _productid;
            }

            /// <summary>
            /// Gets the appid.
            /// </summary>
            /// <value>
            /// The appid.
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:20
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string appid { get; internal set; }

            /// <summary>
            /// Gets the appkey.
            /// </summary>
            /// <value>
            /// The appkey.
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:21
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string appkey { get; internal set; }

            /// <summary>
            /// Gets the noncestr.
            /// </summary>
            /// <value>
            /// The noncestr.
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:21
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string noncestr { get; set; }

            /// <summary>
            /// Gets or sets the timestamp of PaymentQr
            /// </summary>
            /// <value>
            /// The timestamp
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:21
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string timestamp { get; set; }

            /// <summary>
            /// Gets or sets the productid of PaymentQr
            /// </summary>
            /// <value>
            /// The productid
            /// </value>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:22
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string productid { get; set; }

            /// <summary>
            /// Builds the pay sign.
            /// </summary>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private string BuildPaySign()
            {
                var string1 = BrandWechatPaySign.AsciiOrderAscKeyToLower(new Dictionary<string, string>
                                                                                {
                                                                                    { "appid",this.appid },
                                                                                    { "appkey", this.appkey },
                                                                                    { "noncestr", this.noncestr },
                                                                                    { "timestamp", this.timestamp },
                                                                                    { "productid", this.productid }
                                                                                });
                return BrandWechatPaySign.Sha1String1(string1);
            }

            /// <summary>
            /// To the payment qr.
            /// </summary>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:30
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public string ToPaymentQr()
            {
                // "weixin://wxpay/bizpayurl?sign=" + sign + "&appid=" + TenpayUtil.appid + "&productid=" + productid + "&timeStamp=" + timeStamp + "&nonceStr=" + nonceStr;
                var sign = this.BuildPaySign();

                string qr = string.Format("weixin://wxpay/bizpayurl?sign={0}&appid={1}&productid={2}&timeStamp={3}&nonceStr={4}", sign, this.appid, this.productid, this.timestamp, this.noncestr);

                string template = "{ \"Qr\": \"$$Qr$$\", \"OrderId\": \"$$OrderId$$\" }";


                // string.Format("===============================\r\n THE SaveTangShiOrder 002 \r\n {0} \r\n===============================", this.ToString()).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                return template.Replace("$$Qr$$", qr).Replace("$$OrderId$$", this.productid);
            }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            /// 创建者：孟祺宙 
            /// 创建日期：2014/8/5 17:31
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            override public string ToString()
            {
                string str = String.Empty;
                str = String.Concat(str, "appid = ", appid, "\r\n");
                //str = String.Concat(str, "appkey = ", appkey, "\r\n");
                str = String.Concat(str, "noncestr = ", noncestr, "\r\n");
                str = String.Concat(str, "timestamp = ", timestamp, "\r\n");
                str = String.Concat(str, "productid = ", productid, "\r\n");
                return str;
            }
        }

        //JSAPI 支付接口（getBrandWCPayRequest）定义
        public class BrandWcPayRequest
        {
            public BrandWcPayRequest(string _package)
            {
                this.appKey = ControllersCommon.ConstWechatPaymentPaySignKey;
                this.appId = ControllersCommon.ConstWechatPaymentAppId;
                this.timeStamp = (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("#");
                this.nonceStr = Guid.NewGuid().ToString("N");
                this.package = _package;
                this.signType = "SHA1";
                this.paySign = BuildPaySign();//                
            }
            /// <summary>
            /// 
            /// </summary>
            public string appId { get; private set; }
            /// <summary>
            /// paySignKey公众号支付请求中用于加密的密钥 Key，可验证商户唯一身份，PaySignKey 对应于支付场景中的 appKey 值。
            /// </summary>
            public string appKey { get; private set; }
            /// <summary>
            /// 时间戳 1970 年 1 月 1 日 00：00：00 至今的秒数 (32字节以下)
            /// </summary>
            public string timeStamp { get; private set; }
            /// <summary>
            /// 随机字符串（32字节以下）
            /// </summary>
            public string nonceStr { get; private set; }
            /// <summary>
            /// 商户将订单信息组成该字符串（4096 个字节以下）
            /// </summary>
            private string _package;
            public string package
            {
                get { return _package; }
                private set
                {
                    if (value.Length > 4096) throw new ArgumentOutOfRangeException("package max length 4096");
                    _package = value;
                }
            }
            /// <summary>
            /// 签名方式（目前仅支持 SHA1）
            /// </summary>
            public string signType { get; private set; }
            /// <summary>
            /// 签名 商户将接口列表中的参数按照指定方式进行签名，签名方式使用 signType 中标示的签名方式（40 个字符）
            /// </summary>
            public string paySign { get; set; }

            private string BuildPaySign()
            {
                string string1 = BrandWechatPaySign.AsciiOrderAscKeyToLower(SourceDic);
                return BrandWechatPaySign.Sha1String1(string1);
            }
            private Dictionary<string, string> SourceDic
            {
                get
                {
                    return new Dictionary<string, string>
                {
                    { "appId", appId },
                    { "appKey", appKey },
                    { "timeStamp", timeStamp },
                    { "nonceStr", nonceStr },
                    { "package", package }
                };
                }
            }
            override public string ToString()
            {
                string str = String.Empty;
                str = String.Concat(str, "appId = ", appId, "\r\n");
                //str = String.Concat(str, "appKey = ", appKey, "\r\n");
                str = String.Concat(str, "timeStamp = ", timeStamp, "\r\n");
                str = String.Concat(str, "nonceStr = ", nonceStr, "\r\n");
                str = String.Concat(str, "package = ", package, "\r\n");
                str = String.Concat(str, "signType = ", signType, "\r\n");
                str = String.Concat(str, "paySign = ", paySign, "\r\n");
                return str;
            }
            public string ToWxpaymentJsonString()
            {
                string template = "{ \"appId\":\"$appId$\", \"timeStamp\":\"$timeStamp$\", \"nonceStr\":\"$nonceStr$\", \"package\":\"$package$\", \"signType\":\"$signType$\", \"paySign\":\"$paySign$\" }";
                return template.Replace("$appId$", this.appId).Replace("$timeStamp$", this.timeStamp).Replace("$nonceStr$", this.nonceStr).Replace("$package$", this.package).Replace("$signType$", this.signType).Replace("$paySign$", this.paySign);
            }
        }

        /// <summary>
        /// 订单详情（package）扩展字符串定义
        /// </summary>
        public class PackAgeEntity
        {
            private readonly string fstPaternerKey;
            public PackAgeEntity(string _body, string _attach, int _out_trade_no, decimal _total_fee, string _notify_url, string _spbill_create_ip, DateTime? _time_start, DateTime? _time_expire, decimal? _transport_fee, decimal? _product_fee, string _goods_tag = "")
            {
                this.fstPaternerKey = ControllersCommon.ConstWechatPaymentPartnerKey;
                this.bank_type = "WX";
                this.body = _body;
                this.attach = _attach;
                this.partner = ControllersCommon.ConstWechatPaymentPartnerId;
                this.out_trade_no = _out_trade_no;
                this.total_fee = "1";//((int)Math.Round(_total_fee * 100)).ToString();//元转成分
                this.fee_type = "1";
                this.notify_url = _notify_url;
                this.spbill_create_ip = _spbill_create_ip;
                //this.time_start = _time_start.HasValue ? _time_start.Value.ToString("yyyyMMddHHmmss") : string.Empty;
                //this.time_expire = _time_expire.HasValue ? _time_expire.Value.ToString("yyyyMMddHHmmss") : string.Empty;
                //this.transport_fee = _transport_fee.HasValue ? ((int)Math.Round(_transport_fee.Value * 100)).ToString().ToString() : string.Empty;
                //this.product_fee = _product_fee.HasValue ? _product_fee.Value.ToString() : string.Empty;
                this.goods_tag = _goods_tag;
                this.input_charset = "UTF-8";
            }
            /// <summary>
            /// 银行通道类型，由于这里是使用的微信公众号支付，因此 这个字段固定为 WX，注意大写。参数取值："WX"
            /// </summary>
            public string bank_type { get; private set; }//
            /// <summary>
            /// 商品描述。参数长度：128 字节以下
            /// </summary>
            private string _body;
            public string body
            {
                get { return _body; }
                private set
                {
                    if (value.Length > 128) throw new ArgumentOutOfRangeException("body max length 128");
                    _body = value;
                }
            }
            /// <summary>
            /// 附加数据，原样返回。128 字节以下
            /// </summary>
            public string attach { get; private set; }
            /// <summary>
            /// 商户号,即注册时分配的 partnerId
            /// </summary>
            public string partner { get; private set; }//
            /// <summary>
            /// 商户系统内部的订单号,32 个字符内、 可包含字母,确保在商 户系统唯一。参数取值范围：32 字节以下
            /// </summary>
            public int out_trade_no { get; private set; }
            /// <summary>
            /// 订单总金额，单位为分
            /// </summary>
            public string total_fee { get; private set; }
            /// <summary>
            /// 现金支付币种,取值：1（人民币）,默认值是 1，暂只支持 1
            /// </summary>
            public string fee_type { get; private set; }//
            /// <summary>
            /// 通知 URL,在支付完成后,接收微信通知支付结果的 URL,需要给出绝对路径（255 字节以内）
            /// </summary>
            private string _notify_url;
            public string notify_url
            {
                get { return _notify_url; }
                private set
                {
                    if (value.Length > 255) throw new ArgumentOutOfRangeException("notify_url max length 255");
                    _notify_url = value;
                }
            }
            /// <summary>
            /// 订单生成的机器 IP，指用户浏览器端 IP，不是商户服务器IP，格式为 IPV4 整型。（15 字节以内）
            /// </summary>
            public string spbill_create_ip { get; private set; }
            /// <summary>
            /// 交 易 起 始 时 间 ， 也 是 订 单 生 成 时 间 ， 格 式 为yyyyMMddHHmmss （14 字节）
            /// </summary>
            private string _time_start;
            public string time_start
            {
                get { return _time_start; }
                private set
                {
                    if (value.Length > 14) throw new ArgumentOutOfRangeException("time_start max length 14");
                    _time_start = value;
                }
            }
            /// <summary>
            /// 交 易 结 束 时 间 ， 也 是 订 单 失 效 时 间 ， 格 式 为yyyyMMddHHmmss（14 字节）
            /// </summary>
            private string _time_expire;
            public string time_expire
            {
                get { return _time_expire; }
                private set
                {
                    if (value.Length > 14) throw new ArgumentOutOfRangeException("time_start max length 14");
                    _time_expire = value;
                }
            }
            /// <summary>
            /// 物流费用，单位为分。如果有值，必须保证 transport_fee + product_fee = total_fee
            /// </summary>
            public string transport_fee { get; private set; }
            /// <summary>
            /// 商品费用，单位为分。如果有值，必须保证 transport_fee + product_fee=total_fee
            /// </summary>
            public string product_fee { get; private set; }
            /// <summary>
            /// 商品标记，优惠券时可能用到
            /// </summary>
            public string goods_tag { get; private set; }
            /// <summary>
            /// 传入参数字符编码。取值范围："GBK"、"UTF-8"。默认："GBK"
            /// </summary>
            public string input_charset { get; private set; }

            public string BuildPackAge()
            {

                string string1 = BrandWechatPaySign.AsciiOrderAsc(SourceDic);
                string signValue = BrandWechatPaySign.Md5ColumnParamsAndPaternerKey(string1, fstPaternerKey);
                string string2 = BrandWechatPaySign.UrlencodeParamsValue(SourceDic);

                return string.Format("{0}&sign={1}", string2, signValue);
            }

            private Dictionary<string, string> SourceDic
            {
                get
                {
                    var dic = new Dictionary<string, string> { 
                 {"bank_type",bank_type},
                 {"body",body}, 
                 {"attach",attach}, 
                 {"partner",partner}, 
                 {"out_trade_no",out_trade_no.ToString()}, 
                 {"total_fee",total_fee}, 
                 {"fee_type",fee_type}, 
                 {"notify_url",notify_url}, 
                 {"spbill_create_ip",spbill_create_ip}, 
                 {"time_start",time_start}, 
                 {"time_expire",time_expire}, 
                 {"transport_fee",transport_fee}, 
                 {"product_fee",product_fee}, 
                 {"goods_tag",goods_tag}, 
                 {"input_charset" ,input_charset}
            };
                    return dic.Where(item => !string.IsNullOrEmpty(item.Value)).ToDictionary(item => item.Key, item => item.Value);
                }
            }

            override public string ToString()
            {
                string str = String.Empty;
                str = String.Concat(str, "bank_type = ", bank_type, "\r\n");
                str = String.Concat(str, "body = ", body, "\r\n");
                str = String.Concat(str, "attach = ", attach, "\r\n");
                str = String.Concat(str, "partner = ", partner, "\r\n");
                str = String.Concat(str, "out_trade_no = ", out_trade_no, "\r\n");
                str = String.Concat(str, "total_fee = ", total_fee, "\r\n");
                str = String.Concat(str, "fee_type = ", fee_type, "\r\n");
                str = String.Concat(str, "notify_url = ", notify_url, "\r\n");
                str = String.Concat(str, "spbill_create_ip = ", spbill_create_ip, "\r\n");
                str = String.Concat(str, "time_start = ", time_start, "\r\n");
                str = String.Concat(str, "time_expire = ", time_expire, "\r\n");
                str = String.Concat(str, "transport_fee = ", transport_fee, "\r\n");
                str = String.Concat(str, "product_fee = ", product_fee, "\r\n");
                str = String.Concat(str, "goods_tag = ", goods_tag, "\r\n");
                str = String.Concat(str, "input_charset = ", input_charset, "\r\n");
                return str;
            }
        }

        /// <summary>
        /// Js Api 支付签名
        /// </summary>
        public class BrandWechatPaySign
        {

            /// <summary>
            /// a) 对所有传入参数按照字段名的 ASCII 码从小到大排序（字典序）后，使用 URL 键值对的格式（即 key1=value1&key2=value2…）拼接成字符串 string1
            /// </summary>
            /// <param name="sourceDic">The sourceDic</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:12
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static string AsciiOrderAsc(Dictionary<string, string> sourceDic)
            {
                return AsciiOrderAsc(sourceDic, null);
            }

            /// <summary>
            /// a_2) a -> key 小写
            /// </summary>
            /// <param name="sourceDic">The sourceDic</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:12
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static string AsciiOrderAscKeyToLower(Dictionary<string, string> sourceDic)
            {
                return AsciiOrderAsc(sourceDic, item => item.ToLower());
            }

            /// <summary>
            /// b) string1 最后拼接上 key=paternerKey 得到stringSignTemp字符串 进行md5 运算
            /// </summary>
            /// <param name="string1">The string1</param>
            /// <param name="paternerKey">The paternerKey</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:12
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static string Md5ColumnParamsAndPaternerKey(string string1, string paternerKey)
            {
                string stringSignTemp = string.Format("{0}&key={1}", string1, paternerKey);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] stringSignTempByte = md5.ComputeHash(Encoding.UTF8.GetBytes(stringSignTemp));
                return BitConverter.ToString(stringSignTempByte).Replace("-", "");
            }
            /// <summary>
            /// b.1 对string1 进行SHA1 小写
            /// </summary>
            /// <param name="sting1">The sting1</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:13
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static string Sha1String1(string sting1)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] string1Sha1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(sting1));
                return BitConverter.ToString(string1Sha1).Replace("-", "").ToLower();
            }

            /// <summary>
            /// c）对 string1 中的所有键值对中的 value 进行 encodeURIComponent 转码， 按照 a 步骤重新拼接成字符串，得到 string2
            /// </summary>
            /// <param name="sourceDic">The sourceDic</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:13
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static string UrlencodeParamsValue(Dictionary<string, string> sourceDic)
            {
                var dic = AsciiOrderAscByColumnDic(sourceDic, Uri.EscapeDataString);//
                return string.Join("&", dic.Select(item => string.Format("{0}={1}", item.Key, item.Value)));
            }

            /// <summary>
            /// ASCIIs the order asc.
            /// </summary>
            /// <param name="sourceDic">The sourceDic</param>
            /// <param name="func">The func</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:14
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static string AsciiOrderAsc(Dictionary<string, string> sourceDic, Func<string, string> func)
            {
                var dic = AsciiOrderAscByColumnDic(sourceDic);
                return string.Join("&", dic.Select(item => string.Format("{0}={1}", func != null ? func(item.Key) : item.Key, item.Value)));
            }

            /// <summary>
            /// ASCIIs the order asc by column dic.
            /// </summary>
            /// <param name="sourceDic">The sourceDic</param>
            /// <param name="func">The func</param>
            /// <returns>
            /// String}
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/14 20:16
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static SortedDictionary<string, string> AsciiOrderAscByColumnDic(Dictionary<string, string> sourceDic, Func<string, string> func = null)
            {
                var keys = sourceDic.Keys.ToArray();
                Array.Sort(keys, string.CompareOrdinal);

                var sortedDict = new SortedDictionary<string, string>();
                foreach (var key in keys)
                {
                    sortedDict.Add(key, func != null ? func(sourceDic[key]) : sourceDic[key]);
                }
                return sortedDict;
                //return keys.ToDictionary(item => item, item => func != null ? func(sourceDic[item]) : sourceDic[item]);
            }
        }



        //=============回传验证

        public class BrandWechatPayCallBack
        {

            /// <summary>
            /// Validates the application signature.
            /// </summary>
            /// <param name="entity">The entity</param>
            /// <returns>
            /// Boolean
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 16:49
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static bool ValidateAppSignature(WechatPaymentQueryData entity)
            {
                string expect = entity.AppSignature;

                string string1 = BrandWechatPaySign.AsciiOrderAscKeyToLower(new Dictionary<string, string> { 
                { "appid", entity.AppId },
                { "appkey", ControllersCommon.ConstWechatPaymentPaySignKey },
                { "timestamp", entity.TimeStamp.ToString() },
                { "noncestr", entity.NonceStr },
                { "openid", entity.OpenId },
                { "issubscribe", entity.IsSubscribe.ToString() }
            });
                string actual = BrandWechatPaySign.Sha1String1(string1);
                return expect == actual;
            }
        }


        public class BrandWechatPayCallBackQueryOrNotify
        {

            /// <summary>
            /// 查询订单支付状态
            /// </summary>
            /// <param name="out_trade_no">The out_trade_no</param>
            /// <returns>
            /// 是否已经支付 True 已经支付 False 未支付
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 18:37
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static bool OrderQuery(string out_trade_no)
            {
                string string1 = BrandWechatPaySign.AsciiOrderAsc(new Dictionary<string, string> { { "out_trade_no", out_trade_no }, { "partner", ControllersCommon.ConstWechatPaymentPartnerId } });
                string querySign = BrandWechatPaySign.Md5ColumnParamsAndPaternerKey(string1, ControllersCommon.ConstWechatPaymentPartnerKey);
                string package = string.Format("out_trade_no={0}&partner={1}&sign={2}", out_trade_no, ControllersCommon.ConstWechatPaymentPartnerId, querySign);


                string timestamp = WinDateToLinuxDate(DateTime.Now).ToString();//linux时间戳 10位

                var dicSha1 =
                    BrandWechatPaySign.AsciiOrderAsc(new Dictionary<string, string>
                            {
                                {"appid", ControllersCommon.ConstWechatPaymentAppId},
                                {"appkey", ControllersCommon.ConstWechatPaymentPaySignKey},
                                {"package", package},
                                {"timestamp", timestamp}
                            });
                string app_signature = BrandWechatPaySign.Sha1String1(dicSha1);

                string postJsonString = "{ \"appid\":\"" + ControllersCommon.ConstWechatPaymentAppId +
                                        "\", \"package\":\"" + package +
                                        "\", \"timestamp\":\"" + timestamp + "\", \"app_signature\":\"" +
                                        app_signature +
                                        "\", \"sign_method\":\"sha1\" }";

                string access_token = GetAccessToken();

                string resultJson = HttpRequestPost(postJsonString,
                                                    string.Format(
                                                        "https://api.weixin.qq.com/pay/orderquery?access_token={0}",
                                                        access_token), (ex) => string.Format("===============================\r\n THE 003_HTTP_POST_EX \r\n {0} \r\n {1} \r\n===============================", ex.Message, ex.ToString(), ex.StackTrace).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info));

                JObject jsonObject = JObject.Parse(resultJson);


                if (jsonObject["errcode"].ToString() != "0") return false;

                string ret_code = jsonObject["order_info"]["ret_code"].ToString();
                string trade_state = jsonObject["order_info"]["trade_state"].ToString();



                return ret_code == "0" && trade_state == "0";

            }


            /// <summary>
            /// 通知微信已经确认订单
            /// 收到支付通知发货后，一定调用发货通知接口，否则可能影响商户信誉和资金结算
            /// </summary>
            /// <param name="out_trade_no">系统内部订单号</param>
            /// <param name="transid">微信内部订单号</param>
            /// <param name="openid">wechatId</param>
            /// <returns>
            /// Boolean
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/19 10:31
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            public static bool Notify(string out_trade_no, string transid, string openid)
            {
                var dic = new Dictionary<string, string>
                {
                    {"appid", ControllersCommon.ConstWechatPaymentAppId },
                    {"appkey", ControllersCommon.ConstWechatPaymentPaySignKey },
                    {"openid",openid},
                    {"transid",transid},
                    {"out_trade_no",out_trade_no},
                    {"deliver_timestamp",WinDateToLinuxDate(DateTime.Now).ToString()},
                    {"deliver_status","1"},
                    {"deliver_msg","ok"}
                };
                string string1 = BrandWechatPaySign.AsciiOrderAscKeyToLower(dic);
                string app_signature = BrandWechatPaySign.Sha1String1(string1);
                string template = "{ \"appid\":\"$appid$\", \"openid\":\"$openid$\", \"transid\":\"$transid$\", \"out_trade_no\":\"$out_trade_no$\", \"deliver_timestamp\":\"$deliver_timestamp$\", \"deliver_status\":\"$deliver_status$\", \"deliver_msg\":\"$deliver_msg$\", \"app_signature\":\"$app_signature$\", \"sign_method\":\"sha1\" }";
                string postJsonString = template.Replace("$appid$", dic["appid"]).Replace("$openid$", dic["openid"]).Replace("$transid$", dic["transid"]).Replace("$out_trade_no$", dic["out_trade_no"]).Replace("$deliver_timestamp$", dic["deliver_timestamp"]).Replace("$deliver_status$", dic["deliver_status"]).Replace("$deliver_msg$", dic["deliver_msg"]).Replace("$app_signature$", app_signature);

                string access_token = GetAccessToken();

                string resultJson = HttpRequestPost(postJsonString, string.Format("https://api.weixin.qq.com/pay/delivernotify?access_token={0}", access_token), (ex) => string.Format("===============================\r\n THE DeliveryNotify _HTTP_POST_EX \r\n {0} \r\n {1} \r\n===============================", ex.Message, ex.ToString(), ex.StackTrace).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info));

                JObject jObject = JObject.Parse(resultJson);
                return jObject["errcode"].ToString() == "0";
            }


            /// <summary>
            /// 获取微信OAUTH2 access_token
            /// </summary>
            /// <returns>
            /// access_token
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 17:14
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static string GetAccessToken()
            {
                    string retJson = HttpRequestGetRetString(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", ControllersCommon.ConstWechatPaymentAppId, ControllersCommon.ConstWechatPaymentAppSecret), (content) => content);
                    JsonValue jsonValue = JsonValue.Parse(retJson);
                    return jsonValue["access_token"];
            }

            /// <summary>
            /// HTTPs the request get ret string.
            /// </summary>
            /// <param name="pstUrl">The pstUrl</param>
            /// <param name="callback">The callback</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 17:14
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static string HttpRequestGetRetString(string pstUrl, Func<string, string> callback)
            {
                string content = string.Empty;
                HttpWebRequest request;
                if (pstUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(pstUrl) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(pstUrl);
                }
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        content = callback(reader.ReadToEnd());
                    }
                }
                return content;
            }
            /// <summary>
            /// Checks the validation result.
            /// </summary>
            /// <param name="sender">The sender</param>
            /// <param name="certificate">The certificate</param>
            /// <param name="chain">The chain</param>
            /// <param name="sslPolicyErrors">The sslPolicyErrors</param>
            /// <returns>
            /// Boolean
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 17:14
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static bool CheckValidationResult(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true; //总是接受  
            }
            /// <summary>
            /// 发送HTTP POST
            /// </summary>
            /// <param name="pstUrlParams">The pstUrlParams</param>
            /// <param name="pstSenUrl">The pstSenUrl</param>
            /// <param name="callBack">The callBack</param>
            /// <param name="pobHeaders">The pobHeaders</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/17 17:15
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static string HttpRequestPost(string pstUrlParams, string pstSenUrl, Action<Exception> callBack, Dictionary<string, string> pobHeaders = null)
            {
                var res = string.Empty;
                HttpWebRequest request;
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(pstSenUrl);
                    request.Method = "POST";
                    byte[] sendData = Encoding.UTF8.GetBytes(pstUrlParams);
                    request.ContentLength = sendData.Length;
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.162 Safari/535.19";

                    if (pobHeaders != null)
                    {
                        foreach (var item in pobHeaders)
                        {
                            request.Headers.Add(item.Key, UrlEncodeUtf8(item.Value));
                        }
                    }
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(sendData, 0, sendData.Length);
                    }
                }
                catch (Exception ex)
                {
                    callBack(ex); return res;//!!!
                }
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                return res;
            }

            /// <summary>
            /// URLs the encode UTF8.
            /// </summary>
            /// <param name="pstBase">The pstBase</param>
            /// <returns>
            /// String
            /// </returns>
            /// 创建者：孟祺宙 创建日期：2014/3/19 10:19
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            private static string UrlEncodeUtf8(string pstBase)
            {
                return HttpUtility.UrlEncode(pstBase, Encoding.UTF8);
            }

        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">The time</param>
        /// <returns>
        /// Int32
        /// </returns>
        /// 创建者：孟祺宙 创建日期：2014/3/17 17:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int WinDateToLinuxDate(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}

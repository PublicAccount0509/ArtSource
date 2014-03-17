
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Ets.SingleApi.Controllers;

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

        //JSAPI 支付接口（getBrandWCPayRequest）定义
        public class BrandWcPayRequest
        {
            public BrandWcPayRequest(string _package)
            {
                this.appKey = ControllersCommon.ConstWechatPaymentPaySignKey; 
                this.appId = ControllersCommon.ConstWechatPaymentAppId ;
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
                string string1 = BrandWcPaySign.AsciiOrderAscKeyToLower(SourceDic);
                return BrandWcPaySign.Sha1String1(string1);
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
            public PackAgeEntity(string _body, string _attach, string _out_trade_no, decimal _total_fee, string _notify_url, string _spbill_create_ip, DateTime? _time_start, DateTime? _time_expire, decimal? _transport_fee, decimal? _product_fee, string _goods_tag = "")
            {
                this.fstPaternerKey = ControllersCommon.ConstWechatPaymentPartnerKey;
                this.bank_type = "WX";
                this.body = _body;
                this.attach = _attach;
                this.partner = ControllersCommon.ConstWechatPaymentPartnerId;
                this.out_trade_no = _out_trade_no;
                this.total_fee = ((int)Math.Round(_total_fee * 100)).ToString();//元转成分
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
            private string _out_trade_no;
            public string out_trade_no
            {
                get { return _out_trade_no; }
                private set
                {
                    if (value.Length > 32) throw new ArgumentOutOfRangeException("out_trade_no max length 32");
                    _out_trade_no = value;
                }
            }
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
                string string1 = BrandWcPaySign.AsciiOrderAsc(SourceDic);
                string signValue = BrandWcPaySign.Md5ColumnParamsAndPaternerKey(string1, fstPaternerKey);
                string string2 = BrandWcPaySign.UrlencodeParamsValue(SourceDic);

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
                 {"out_trade_no",out_trade_no}, 
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
        public class BrandWcPaySign
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
            private static Dictionary<string, string> AsciiOrderAscByColumnDic(Dictionary<string, string> sourceDic, Func<string, string> func = null)
            {
                var keys = sourceDic.Keys.ToArray();
                Array.Sort(keys, string.CompareOrdinal);

                return keys.ToDictionary(item => item, item => func != null ? func(sourceDic[item]) : sourceDic[item]);
                //return sourceDic.Keys.ToDictionary(item => item, item => (int)Encoding.UTF8.GetBytes(item)[0]).OrderBy(item => item.Value).ToDictionary(item => item.Key, item => func != null ? func(sourceDic[item.Key]) : sourceDic[item.Key]);
            }
        }
    }
}

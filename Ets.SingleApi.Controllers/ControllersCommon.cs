namespace Ets.SingleApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class ControllersCommon
    {
        /// <summary>
        /// 外卖FeatureId
        /// </summary>
        /// <value>
        /// 外卖FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int WaiMaiFeatureId
        {
            get
            {
                var waiMaiFeatureId = ConfigurationManager.AppSettings["WaiMaiFeatureId"] ?? "1";
                int result;
                if (!Int32.TryParse(waiMaiFeatureId, out result))
                {
                    result = 1;
                }

                return result;
            }
        }

        /// <summary>
        /// 订台FeatureId
        /// </summary>
        /// <value>
        /// 订台FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DingTaiFeatureId
        {
            get
            {
                var dingTaiFeatureId = ConfigurationManager.AppSettings["DingTaiFeatureId"] ?? "2";
                int result;
                if (!Int32.TryParse(dingTaiFeatureId, out result))
                {
                    result = 2;
                }

                return result;
            }
        }

        /// <summary>
        /// 堂食FeatureId
        /// </summary>
        /// <value>
        /// 堂食FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int TangShiFeatureId
        {
            get
            {
                var tangShiFeatureId = ConfigurationManager.AppSettings["TangShiFeatureId"] ?? "9";
                int result;
                if (!Int32.TryParse(tangShiFeatureId, out result))
                {
                    result = 9;
                }

                return result;
            }
        }

        /// <summary>
        /// 排队FeatureId
        /// </summary>
        /// <value>
        /// 排队FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int PaiDuiFeatureId
        {
            get
            {
                var paiDuiFeatureId = ConfigurationManager.AppSettings["PaiDuiFeatureId"] ?? "59";
                int result;
                if (!Int32.TryParse(paiDuiFeatureId, out result))
                {
                    result = 9;
                }

                return result;
            }
        }

        /// <summary>
        /// 立即送餐
        /// </summary>
        /// <value>
        /// 立即送餐
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int QuickDeliveryType
        {
            get
            {
                var quickDeliveryMethod = ConfigurationManager.AppSettings["QuickDeliveryType"] ?? "1";
                int result;
                if (!Int32.TryParse(quickDeliveryMethod, out result))
                {
                    result = 1;
                }

                return result;
            }
        }

        /// <summary>
        /// 按照用户指定时间送餐
        /// </summary>
        /// <value>
        /// 按照用户指定时间送餐
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int AssignDeliveryType
        {
            get
            {
                var assignDeliveryMethod = ConfigurationManager.AppSettings["AssignDeliveryType"] ?? "2";
                int result;
                if (!Int32.TryParse(assignDeliveryMethod, out result))
                {
                    result = 2;
                }

                return result;
            }
        }

        /// <summary>
        /// 默认性别
        /// </summary>
        /// <value>
        /// 默认性别
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DefaultGender
        {
            get
            {
                var defaultGender = ConfigurationManager.AppSettings["DefaultGender"] ?? "0";
                int result;
                if (!Int32.TryParse(defaultGender, out result))
                {
                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// 是否开启权限验证
        /// </summary>
        /// <value>
        /// 是否开启权限验证
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool ApplicationValidationEnabled
        {
            get
            {
                return String.Equals(ConfigurationManager.AppSettings["ApplicationValidationEnabled"], "true", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// 默认权限码
        /// </summary>
        /// <value>
        /// 默认权限码
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string DefaultAppKey
        {
            get
            {
                return (ConfigurationManager.AppSettings["DefaultAppKey"] ?? String.Empty).Trim();
            }
        }

        /// <summary>
        /// 默认权限码密码
        /// </summary>
        /// <value>
        /// 默认权限码密码
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string DefaultAppPassword
        {
            get
            {
                return (ConfigurationManager.AppSettings["DefaultAppPassword"] ?? String.Empty).Trim();
            }
        }

        /// <summary>
        /// 空发票显示信息
        /// </summary>
        /// <value>
        /// 空发票显示信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmptyInvoiceTitle
        {
            get
            {
                return (ConfigurationManager.AppSettings["EmptyInvoiceTitle"] ?? String.Empty).Trim();
            }
        }

        /// <summary>
        /// 未知来源
        /// </summary>
        /// <value>
        /// 未知来源
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/4/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string UnkownSource
        {
            get
            {
                return (ConfigurationManager.AppSettings["UnkownSource"] ?? String.Empty).Trim();
            }
        }

        /// <summary>
        /// 开通城市列表
        /// </summary>
        /// <value>
        /// 开通城市列表
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<string> OpenCityList
        {
            get
            {
                return (ConfigurationManager.AppSettings["OpenCityList"] ?? String.Empty).Split(',').ToList();
            }
        }

        /// <summary>
        /// 百付宝安全密钥
        /// </summary>
        /// <value>
        /// 百付宝安全密钥
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/10/2014 3:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string BaiFuBaoSecretKey = "5QRFWZ97iQfJJfcQ8XJJSK2m5juKUVLX";

        /// <summary>
        /// 商户编号
        /// </summary>
        /// <value>
        /// 商户编号
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/10/2014 3:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string BaiFuBaoMerchantAcctId
        {
            get
            {
                var result = (ConfigurationManager.AppSettings["BaiFuBaoMerchantAcctId"] ?? String.Empty).Trim();
                return result.Length == 0 ? "9000100008" : result;
            }
        }

        /// <summary>
        /// 通过该地址百付宝可查询到通知是否收到
        /// </summary>
        /// <value>
        /// The bai fu bao request URL.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 4:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string BaiFuBaoBackgroundNoticeUrl
        {
            get
            {
                return (ConfigurationManager.AppSettings["BaiFuBaoBackgroundNoticeUrl"] ?? String.Empty).Trim().TrimEnd('/', '\\');
            }
        }

        /// <summary>
        /// 按订单号查询支付结果接口
        /// </summary>
        public static string RequestForOrderUrl = "https://wallet.baidu.com/api/0/query/0/pay_result_by_order_no";

        /// <summary>
        /// 即时到账支付接口（不要求登录百度钱包）
        /// </summary>
        public const string InstantToAccountUrl = "https://wallet.baidu.com/api/0/pay/0/direct";

        /// <summary>
        /// 即时到账支付接口（要求登录百度钱包）
        /// </summary>
        public static string InstantToAccountUrl2 = "https://wallet.baidu.com/api/0/pay/0/direct/0";

        /// <summary>
        /// 移动端即时到账支付接口（要求登录百付宝）
        /// </summary>
        public static string InstantToAccountUrlWapBaiDuLogin = "https://www.baifubao.com/api/0/pay/0/wapdirect/0";

        /// <summary>
        /// 移动端即时到账支付接口（不要求登录百度钱包）
        /// </summary>
        public static string InstantToAccountUrlWapNotBaiDuLogin = "https://www.baifubao.com/api/0/pay/0/wapdirect";
        /// <summary>
        /// 支付宝网关地址（新）
        /// </summary>
        public static string AlipayGatewayNew = "https://mapi.alipay.com/gateway.do?";
        /// <summary>
        /// 支付宝合作身份者ID
        /// </summary>
        /// <value>
        /// 合作身份者ID
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 6:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string AlipayPartnerId
        {
            get
            {
                return (ConfigurationManager.AppSettings["AlipayPartnerId"] ?? String.Empty).Trim().TrimEnd('/', '\\');
            }
        }
        /// <summary>
        /// 支付宝key
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string AlipayKey = "mo4h0xascl7yzt0ebv1k7oeohkgwn2uk";

        /// <summary>
        /// 支付宝账号
        /// </summary>
        /// 创建者：黄磊
        /// 创建日期：27/10/2014 17:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string AlipaySellerEmail = "2336172035@qq.com";
        /// <summary>
        /// 字符编码格式(目前支持 utf-8)
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 5:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string AlipayInputCharSet = "utf-8";

        /// <summary>
        /// 签名方式(MD5)
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 5:52 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string AlipaySignType = "MD5";

        /// <summary>
        /// 支付宝后台通知Url地址
        /// </summary>
        /// <value>
        /// 支付宝后台通知Url地址
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 6:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string AlipayBackgroundNoticeUrl
        {
            get
            {
                return (ConfigurationManager.AppSettings["AlipayBackgroundNoticeUrl"] ?? String.Empty).Trim().TrimEnd('/', '\\');
            }
        }

        /// <summary>
        /// 微信AppId
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 20:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string ConstWechatPaymentAppId = "wx75b95d84726db237";

        /// <summary>
        /// 微信AppSecret
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 20:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string ConstWechatPaymentAppSecret = "c7aa42d95405a9b9ea9523380c49a263";

        /// <summary>
        /// 微信PaySignKey 在支付的时候很蛋疼的叫AppKey
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 20:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string ConstWechatPaymentPaySignKey = "Vn4I8Pdul1Y1bwdXW2flysRWjYyBx4jMCapeuQ2bM7QTSHFeaxAr2GzsorPF9mM4UGftfYJq5mP8DDwNFg3glmXdFiWnnEp1M7W9Z0qN3tvsKPoEeChiQhd1wGGgLbA4";

        /// <summary>
        /// 微信分配财付通PartnerKey
        /// </summary>
        /// 创建者：孟祺宙 创建日期：2014/3/14 20:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string ConstWechatPaymentPartnerKey = "35585d777e8dc9e86f627a2003e03069";

        /// <summary>
        /// 微信分配财付通PartnerId
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 20:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public const string ConstWechatPaymentPartnerId = "1219830301";

        /// <summary>
        /// 百度统计用AppId
        /// </summary>
        /// <value>
        /// The bai du statistics application identifier.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：6/10/2014 9:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int BaiDuStatisticsAppId
        {
            get
            {
                var baiDuStatisticsAppId = ConfigurationManager.AppSettings["BaiDuStatisticsAppId"] ?? "100011";
                int result;
                if (!Int32.TryParse(baiDuStatisticsAppId, out result))
                {
                    result = 1;
                }

                return result;
            }
        }
    }
}
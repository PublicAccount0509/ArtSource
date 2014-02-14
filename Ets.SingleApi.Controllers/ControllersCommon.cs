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
                if (!int.TryParse(waiMaiFeatureId, out result))
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
                if (!int.TryParse(dingTaiFeatureId, out result))
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
                if (!int.TryParse(tangShiFeatureId, out result))
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
                if (!int.TryParse(quickDeliveryMethod, out result))
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
                if (!int.TryParse(assignDeliveryMethod, out result))
                {
                    result = 2;
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
                return string.Equals(ConfigurationManager.AppSettings["ApplicationValidationEnabled"], "true", StringComparison.OrdinalIgnoreCase);
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
                return (ConfigurationManager.AppSettings["DefaultAppKey"] ?? string.Empty).Trim();
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
                return (ConfigurationManager.AppSettings["EmptyInvoiceTitle"] ?? string.Empty).Trim();
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
                return (ConfigurationManager.AppSettings["UnkownSource"] ?? string.Empty).Trim();
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
                return (ConfigurationManager.AppSettings["OpenCityList"] ?? string.Empty).Split(',').ToList();
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
                var result = (ConfigurationManager.AppSettings["BaiFuBaoMerchantAcctId"] ?? string.Empty).Trim();
                return result.Length == 0 ? "9000100008" : result;
            }
        }

        /// <summary>
        /// 按订单号查询支付结果接口
        /// </summary>
        public static string RequestForOrderURL = "https://wallet.baidu.com/api/0/query/0/pay_result_by_order_no";

        /// <summary>
        /// 即时到账支付接口（不要求登录百度钱包）
        /// </summary>
        public const string InstantToAccountURL = "https://wallet.baidu.com/api/0/pay/0/direct";

        /// <summary>
        /// 即时到账支付接口（要求登录百度钱包）
        /// </summary>
        public static string InstantToAccountURL2 = "https://wallet.baidu.com/api/0/pay/0/direct/0";

        /// <summary>
        /// 移动端即时到账支付接口（要求登录百付宝）
        /// </summary>
        public static string InstantToAccountURL_Wap_BaiDuLogin = "https://www.baifubao.com/api/0/pay/0/wapdirect/0";

        /// <summary>
        /// 移动端即时到账支付接口（不要求登录百度钱包）
        /// </summary>
        public static string InstantToAccountURL_Wap_NotBaiDuLogin = "https://www.baifubao.com/api/0/pay/0/wapdirect";
    }
}
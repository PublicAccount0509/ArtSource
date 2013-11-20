namespace Ets.SingleApi.Controllers
{
    using System;
    using System.Configuration;

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
    }
}
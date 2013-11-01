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
                return 35;
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
                return 36;
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
        public static string DefaultAutorizationCode
        {
            get
            {
                return (ConfigurationManager.AppSettings["DefaultAutorizationCode"] ?? string.Empty).Trim();
            }
        }
    }
}
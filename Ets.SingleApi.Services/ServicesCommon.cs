namespace Ets.SingleApi.Services
{
    using System.Configuration;

    /// <summary>
    /// 类名称：ServicesCommon
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：公用类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 11:15
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ServicesCommon
    {
        /// <summary>
        /// WapCustom用户
        /// </summary>
        /// <value>
        /// 返回用户code
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 17:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string WapCustomSourceTypeCode
        {
            get
            {
                return ConfigurationManager.AppSettings["WapCustomSourceTypeCode"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 易淘食短信验证码
        /// </summary>
        /// <value>
        /// 易淘食短信验证码
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EtkAuthCodeType
        {
            get
            {
                return ConfigurationManager.AppSettings["EtkAuthCodeType"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 外卖短信验证码
        /// </summary>
        /// <value>
        /// 外卖短信验证码
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string WaiMaiAuthCodeType
        {
            get
            {
                return ConfigurationManager.AppSettings["WaiMaiAuthCodeType"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 图片服务器地址
        /// </summary>
        /// <value>
        /// 图片服务器地址
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ImageSiteUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ImageSiteUrl"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 图片存储路径
        /// </summary>
        /// <value>
        /// 图片存储路径
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ImagePath
        {
            get
            {
                return ConfigurationManager.AppSettings["ImagePath"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 短信验证码缓存关键字前缀
        /// </summary>
        /// <value>
        /// 短信验证码缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string AuthCodeCacheKey
        {
            get
            {
                return "auth_code";
            }
        }

        /// <summary>
        /// 短信验证码最后一次发送时间缓存关键字前缀
        /// </summary>
        /// <value>
        /// 短信验证码最后一次发送时间缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string AuthSecondCacheKey
        {
            get
            {
                return "auth_second";
            }
        }

        /// <summary>
        /// 找回密码最后一次发送时间缓存关键字前缀
        /// </summary>
        /// <value>
        /// 找回密码最后一次发送时间缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string FindPasswordSecondCacheKey
        {
            get
            {
                return "find_password_second";
            }
        }
    }
}
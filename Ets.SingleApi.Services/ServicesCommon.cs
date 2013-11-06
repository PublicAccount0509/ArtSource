namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

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
        /// 外卖短信验有效时间
        /// </summary>
        /// <value>
        /// 短信验证码有效时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int AuthCodeExpiredTime
        {
            get
            {
                var expiredTime = ConfigurationManager.AppSettings["AuthCodeExpiredTime"] ?? "5";
                int result;
                if (!int.TryParse(expiredTime, out result))
                {
                    result = 5;
                }

                return result;
            }
        }

        /// <summary>
        /// 外卖短信验有效时间
        /// </summary>
        /// <value>
        /// 短信验证码有效时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int PasswordMinLength
        {
            get
            {
                var passwordMinLength = ConfigurationManager.AppSettings["PasswordMinLength"] ?? "6";
                int result;
                if (!int.TryParse(passwordMinLength, out result))
                {
                    result = 6;
                }

                return result <= 0 ? 6 : result;
            }
        }

        /// <summary>
        /// 百度地图AK
        /// </summary>
        /// <value>
        /// 百度地图AK
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string BaiduMapAk
        {
            get
            {
                return ConfigurationManager.AppSettings["BaiduMapAk"] ?? string.Empty;
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
        /// 邮箱地址
        /// </summary>
        /// <value>
        /// 邮箱地址
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmailAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailAccount"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 邮箱密码
        /// </summary>
        /// <value>
        /// 邮箱密码
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailPassword"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 邮件服务器
        /// </summary>
        /// <value>
        /// 邮件服务器
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailServer"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 邮件主题
        /// </summary>
        /// <value>
        /// 邮件主题
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmailSubject
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailSubject"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 邮箱找回密码通知信息
        /// </summary>
        /// <value>
        /// 邮箱找回密码通知信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmailFindPasswordMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailFindPasswordMessage"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 短信找回密码通知信息
        /// </summary>
        /// <value>
        /// 短信找回密码通知信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string SmsFindPasswordMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["SmsFindPasswordMessage"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 首次购物账号获得密码通知信息
        /// </summary>
        /// <value>
        /// 首次购物账号获得密码通知信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string FirstRegisterMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["FirstRegisterMessage"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 短信验证码通知信息
        /// </summary>
        /// <value>
        /// 短信验证码通知信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string AuthCodeMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["AuthCodeMessage"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 更变密码通知信息
        /// </summary>
        /// <value>
        /// 更变密码通知信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ModifyPasswordMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["ModifyPasswordMessage"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 测试集团Id
        /// </summary>
        /// <value>
        /// 测试集团Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<int> TestSupplierGroupId
        {
            get
            {
                var list = (ConfigurationManager.AppSettings["TestSupplierGroupId"] ?? string.Empty).Split(',').ToList();
                var supplierGroupIdList = new List<int>();
                foreach (var item in list)
                {
                    int supplierGroupId;
                    if (!int.TryParse(item, out supplierGroupId))
                    {
                        continue;
                    }

                    supplierGroupIdList.Add(supplierGroupId);
                }

                return supplierGroupIdList;
            }
        }

        /// <summary>
        /// 货到付款支付类型
        /// </summary>
        /// <value>
        /// 货到付款支付类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<string> CompleteRealSupplierType
        {
            get
            {
                return (ConfigurationManager.AppSettings["CompleteRealSupplierType"] ?? string.Empty).Split(',').ToList();
            }
        }

        /// <summary>
        /// 外卖短信验证码缓存关键字前缀
        /// </summary>
        /// <value>
        /// 外卖短信验证码缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 8:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string WaiMaiAuthCodeCacheKey
        {
            get
            {
                return "waimai_auth_code";
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
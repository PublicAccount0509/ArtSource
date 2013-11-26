namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using Ets.SingleApi.Model.Services;

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
        /// 默认的送餐方式
        /// </summary>
        /// <value>
        /// 默认的送餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int MinDeliveryHours
        {
            get
            {
                var minDeliveryHours = ConfigurationManager.AppSettings["MinDeliveryHours"] ?? "45";
                int result;
                if (!int.TryParse(minDeliveryHours, out result))
                {
                    result = 45;
                }

                return result;
            }
        }

        /// <summary>
        /// 默认的送餐方式
        /// </summary>
        /// <value>
        /// 默认的送餐方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DefaultDeliveryMethodId
        {
            get
            {
                var defaultDeliveryMethodId = ConfigurationManager.AppSettings["DefaultDeliveryMethodId"] ?? "2";
                int result;
                if (!int.TryParse(defaultDeliveryMethodId, out result))
                {
                    result = 2;
                }

                return result;
            }
        }

        /// <summary>
        /// 默认的送餐类型
        /// </summary>
        /// <value>
        /// 默认的送餐类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DefaultDeliveryType
        {
            get
            {
                var defaultDeliveryType = ConfigurationManager.AppSettings["DefaultDeliveryType"] ?? "1";
                int result;
                if (!int.TryParse(defaultDeliveryType, out result))
                {
                    result = 1;
                }

                return result;
            }
        }

        /// <summary>
        /// 阶梯打包FeatureId
        /// </summary>
        /// <value>
        /// 阶梯打包FeatureId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int PackageFeatureId
        {
            get
            {
                var packageFeatureId = ConfigurationManager.AppSettings["PackageFeatureId"] ?? "34";
                int result;
                if (!int.TryParse(packageFeatureId, out result))
                {
                    result = 34;
                }

                return result;
            }
        }

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
        /// 密码最小长度
        /// </summary>
        /// <value>
        /// 密码最小长度
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
        /// 外卖自提Id
        /// </summary>
        /// <value>
        /// 外卖自提Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int PickUpDeliveryMethodId
        {
            get
            {
                var pickUpDeliveryMethodId = ConfigurationManager.AppSettings["PickUpDeliveryMethodId"] ?? "1";
                int result;
                if (!int.TryParse(pickUpDeliveryMethodId, out result))
                {
                    result = 1;
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
                if (!int.TryParse(defaultGender, out result))
                {
                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// Female字串
        /// </summary>
        /// <value>
        /// Female字串
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string FemaleGender
        {
            get
            {
                return ConfigurationManager.AppSettings["FemaleGender"] ?? string.Empty;
            }
        }

        /// <summary>
        /// 外卖送餐上门默认时间
        /// </summary>
        /// <value>
        /// 外卖送餐上门默认时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DefaultDeliveryTime
        {
            get
            {
                var defaultDeliveryTime = ConfigurationManager.AppSettings["DefaultDeliveryTime"] ?? "45";
                int result;
                if (!int.TryParse(defaultDeliveryTime, out result))
                {
                    result = 45;
                }

                return result;
            }
        }

        /// <summary>
        /// 外卖自取默认时间
        /// </summary>
        /// <value>
        /// 外卖自取默认时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DefaultPickUpTime
        {
            get
            {
                var defaultPickUpTime = ConfigurationManager.AppSettings["DefaultPickUpTime"] ?? "60";
                int result;
                if (!int.TryParse(defaultPickUpTime, out result))
                {
                    result = 60;
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
        /// 联动优势商户号
        /// </summary>
        /// <value>
        /// 联动优势商户号
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string UmPayMerId
        {
            get
            {
                var result = (ConfigurationManager.AppSettings["UmPayMerId"] ?? string.Empty).Trim();
                return result.Length == 0 ? "7378" : result;
            }
        }

        /// <summary>
        /// 联动优势版本号
        /// </summary>
        /// <value>
        /// 联动优势版本号
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string UmPayVersion
        {
            get
            {
                var result = (ConfigurationManager.AppSettings["UmPayVersion"] ?? string.Empty).Trim();
                return result.Length == 0 ? "4.0" : result;
            }
        }

        /// <summary>
        /// 联动优势版本号
        /// </summary>
        /// <value>
        /// 联动优势版本号
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string UmPaySignType
        {
            get
            {
                var result = (ConfigurationManager.AppSettings["UmPaySignType"] ?? string.Empty).Trim();
                return result.Length == 0 ? "RSA" : result;
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
                return ConfigurationManager.AppSettings["EmailAddress"] ?? string.Empty;
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

        /// <summary>
        /// 找回密码验证码缓存关键字前缀
        /// </summary>
        /// <value>
        /// 找回密码验证码缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string FindPasswordCodeCacheKey
        {
            get
            {
                return "find_password_code";
            }
        }

        /// <summary>
        /// 计算打包费
        /// </summary>
        /// <param name="packageWay">是否阶梯打包</param>
        /// <param name="supplierPack">餐厅打包费</param>
        /// <param name="packLadder">阶梯打包费</param>
        /// <param name="dishList">菜品信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static decimal GetPackagingFee(bool packageWay, decimal supplierPack, decimal packLadder, List<PackagingFeeItem> dishList)
        {
            var totalPrice = dishList.Sum(item => item.Price * item.Quantity);
            if (totalPrice <= 0)
            {
                return 0;
            }

            if (!packageWay)
            {
                var fee = dishList.Sum(item => item.PackagingFee * item.Quantity);
                return fee;
            }

            if (packLadder == 0)
            {
                return supplierPack;
            }

            long x;
            var y = Math.DivRem((long)totalPrice, (long)packLadder, out x);
            return (y + 1) * supplierPack;
        }
    }
}
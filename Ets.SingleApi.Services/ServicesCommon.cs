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
        /// 单个锅的押金
        /// </summary>
        /// <value>
        /// 单个锅的押金
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int PotDeposit
        {
            get
            {
                var potDeposit = ConfigurationManager.AppSettings["PotDeposit"] ?? "20";
                int result;
                if (!int.TryParse(potDeposit, out result))
                {
                    result = 20;
                }

                return result;
            }
        }

        /// <summary>
        /// 单个电磁炉的押金
        /// </summary>
        /// <value>
        /// 单个电磁炉的押金
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int CookingDeposit
        {
            get
            {
                var cookingDeposit = ConfigurationManager.AppSettings["CookingDeposit"] ?? "500";
                int result;
                if (!int.TryParse(cookingDeposit, out result))
                {
                    result = 500;
                }

                return result;
            }
        }

        /// <summary>
        /// 优惠折扣类型Id
        /// </summary>
        /// <value>
        /// 优惠折扣类型Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int CouponTypeFirstId
        {
            get
            {
                var couponTypeFirstId = ConfigurationManager.AppSettings["CouponTypeFirstId"] ?? "1";
                int result;
                if (!int.TryParse(couponTypeFirstId, out result))
                {
                    result = 1;
                }

                return result;
            }
        }

        /// <summary>
        /// 优惠满折类型Id
        /// </summary>
        /// <value>
        /// 优惠满折类型Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int CouponTypeSecondId
        {
            get
            {
                var couponTypeSecondId = ConfigurationManager.AppSettings["CouponTypeSecondId"] ?? "2";
                int result;
                if (!int.TryParse(couponTypeSecondId, out result))
                {
                    result = 2;
                }

                return result;
            }
        }

        /// <summary>
        /// 计算打折的方式，1 先减后打折 2 先打折后减  3 叠加最优惠的  4 不叠加最优惠的  5 满减优先  6 折扣优先
        /// </summary>
        /// <value>
        /// 计算打折的方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int CalculateCouponWay
        {
            get
            {
                var calculateCouponWay = ConfigurationManager.AppSettings["CalculateCouponWay"] ?? "4";
                int result;
                if (!int.TryParse(calculateCouponWay, out result))
                {
                    result = 4;
                }

                return result;
            }
        }

        /// <summary>
        /// 营业前准备时间
        /// </summary>
        /// <value>
        /// 营业前准备时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ServiceTimeBeginReadyTime
        {
            get
            {
                var serviceTimeBeginReadyTime = ConfigurationManager.AppSettings["ServiceTimeBeginReadyTime"] ?? "60";
                int result;
                if (!int.TryParse(serviceTimeBeginReadyTime, out result))
                {
                    result = 60;
                }

                return result;
            }
        }

        /// <summary>
        /// 打烊前准备时间
        /// </summary>
        /// <value>
        /// 打烊前准备时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ServiceTimeEndReadyTime
        {
            get
            {
                var serviceTimeEndReadyTime = ConfigurationManager.AppSettings["ServiceTimeEndReadyTime"] ?? "45";
                int result;
                if (!int.TryParse(serviceTimeEndReadyTime, out result))
                {
                    result = 45;
                }

                return result * (-1);
            }
        }

        /// <summary>
        /// 服务时间间隔
        /// </summary>
        /// <value>
        /// 服务时间间隔
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ServiceTimeInterval
        {
            get
            {
                var serviceTimeInterval = ConfigurationManager.AppSettings["ServiceTimeInterval"] ?? "15";
                int result;
                if (!int.TryParse(serviceTimeInterval, out result))
                {
                    result = 15;
                }

                return result;
            }
        }

        /// <summary>
        /// 取得服务时间的默认天数
        /// </summary>
        /// <value>
        /// 取得服务时间的默认天数
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ServiceTimeDefaultDays
        {
            get
            {
                var serviceTimeDefaultDays = ConfigurationManager.AppSettings["ServiceTimeDefaultDays"] ?? "3";
                int result;
                if (!int.TryParse(serviceTimeDefaultDays, out result))
                {
                    result = 3;
                }

                return result;
            }
        }

        /// <summary>
        /// 营业前准备时间
        /// </summary>
        /// <value>
        /// 营业前准备时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DeliveryTimeBeginReadyTime
        {
            get
            {
                var deliveryTimeBeginReadyTime = ConfigurationManager.AppSettings["DeliveryTimeBeginReadyTime"] ?? "0";
                int result;
                if (!int.TryParse(deliveryTimeBeginReadyTime, out result))
                {
                    result = 0;
                }

                return result;
            }
        }

        /// <summary>
        /// 打烊前准备时间
        /// </summary>
        /// <value>
        /// 打烊前准备时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DeliveryTimeEndReadyTime
        {
            get
            {
                var deliveryTimeEndReadyTime = ConfigurationManager.AppSettings["DeliveryTimeEndReadyTime"] ?? "0";
                int result;
                if (!int.TryParse(deliveryTimeEndReadyTime, out result))
                {
                    result = 0;
                }

                return result * (-1);
            }
        }

        /// <summary>
        /// 送餐时间间隔
        /// </summary>
        /// <value>
        /// 送餐时间间隔
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DeliveryTimeInterval
        {
            get
            {
                var deliveryTimeInterval = ConfigurationManager.AppSettings["DeliveryTimeInterval"] ?? "15";
                int result;
                if (!int.TryParse(deliveryTimeInterval, out result))
                {
                    result = 15;
                }

                return result;
            }
        }

        /// <summary>
        /// 取得送餐时间的默认天数
        /// </summary>
        /// <value>
        /// 取得送餐时间的默认天数
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int DeliveryTimeDefaultDays
        {
            get
            {
                var deliveryTimeDefaultDays = ConfigurationManager.AppSettings["DeliveryTimeDefaultDays"] ?? "3";
                int result;
                if (!int.TryParse(deliveryTimeDefaultDays, out result))
                {
                    result = 3;
                }

                return result;
            }
        }

        /// <summary>
        /// 最快送餐时间
        /// </summary>
        /// <value>
        /// 最快送餐时间
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
        /// 最快取餐时间
        /// </summary>
        /// <value>
        /// 最快取餐时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int MinPickUpHours
        {
            get
            {
                var minPickUpHours = ConfigurationManager.AppSettings["MinPickUpHours"] ?? "45";
                int result;
                if (!int.TryParse(minPickUpHours, out result))
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
        /// 直辖市标记
        /// </summary>
        /// <value>
        /// 直辖市标记
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 17:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string MunicipalitySign
        {
            get
            {
                return ConfigurationManager.AppSettings["MunicipalitySign"] ?? string.Empty;
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
        /// 送餐时间为空时默认送餐时间
        /// </summary>
        /// <value>
        /// 送餐时间为空时默认送餐时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string EmptyDeliveryTime
        {
            get
            {
                return ConfigurationManager.AppSettings["EmptyDeliveryTime"] ?? string.Empty;
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
        /// 是否开启送餐时间验证
        /// </summary>
        /// <value>
        /// 是否开启送餐时间验证
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool ValidateDeliveryTimeEnabled
        {
            get
            {
                return string.Equals(ConfigurationManager.AppSettings["ValidateDeliveryTimeEnabled"], "true", StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// 合作商户订餐热线
        /// </summary>
        /// <value>
        /// 合作商户订餐热线
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string CooperationHotline
        {
            get
            {
                return ConfigurationManager.AppSettings["CooperationHotline"] ?? string.Empty;
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
        /// 外卖合作商户所必须开通的功能
        /// </summary>
        /// <value>
        /// 外卖合作商户所必须开通的功能
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<int> CooperationWaimaiFeatures
        {
            get
            {
                var list = (ConfigurationManager.AppSettings["CooperationWaimaiFeatures"] ?? string.Empty).Split(',').ToList();
                var cooperationWaimaiFeatureList = new List<int>();
                foreach (var item in list)
                {
                    int featureId;
                    if (!int.TryParse(item, out featureId))
                    {
                        continue;
                    }

                    cooperationWaimaiFeatureList.Add(featureId);
                }

                return cooperationWaimaiFeatureList;
            }
        }

        /// <summary>
        /// 堂食合作商户所必须开通的功能
        /// </summary>
        /// <value>
        /// 堂食合作商户所必须开通的功能
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<int> CooperationTangshiFeatures
        {
            get
            {
                var list = (ConfigurationManager.AppSettings["CooperationTangshiFeatures"] ?? string.Empty).Split(',').ToList();
                var cooperationTangshiFeatureList = new List<int>();
                foreach (var item in list)
                {
                    int featureId;
                    if (!int.TryParse(item, out featureId))
                    {
                        continue;
                    }

                    cooperationTangshiFeatureList.Add(featureId);
                }

                return cooperationTangshiFeatureList;
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
        /// 不参加优惠的餐厅群组Id
        /// </summary>
        /// <value>
        /// 不参加优惠的餐厅群组Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<int?> NoCouponSupplierGroupList
        {
            get
            {
                var list = (ConfigurationManager.AppSettings["NoCouponSupplierGroupList"] ?? string.Empty).Split(',').ToList();
                var noCouponSupplierGroupList = new List<int?>();
                foreach (var item in list)
                {
                    int itemId;
                    if (!int.TryParse(item, out itemId))
                    {
                        continue;
                    }

                    noCouponSupplierGroupList.Add(itemId);
                }

                return noCouponSupplierGroupList;
            }
        }

        /// <summary>
        /// 海底捞不能出现在菜单的类目
        /// </summary>
        /// <value>
        /// 海底捞不能出现在菜单的类目
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<string> HaiDiLaoNoContainMenuList
        {
            get
            {
                return (ConfigurationManager.AppSettings["HaiDiLaoNoContainMenuList"] ?? string.Empty).Split(',').ToList();
            }
        }

        /// <summary>
        /// 海底捞排在菜单面前的类目
        /// </summary>
        /// <value>
        /// 海底捞排在菜单面前的类目
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<string> HaiDiLaoFrontMenuList
        {
            get
            {
                return (ConfigurationManager.AppSettings["HaiDiLaoFrontMenuList"] ?? string.Empty).Split(',').ToList();
            }
        }

        /// <summary>
        /// 海底捞排在菜单最后的类目
        /// </summary>
        /// <value>
        /// 海底捞排在菜单最后的类目
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static List<string> HaiDiLaoEndMenuList
        {
            get
            {
                return (ConfigurationManager.AppSettings["HaiDiLaoEndMenuList"] ?? string.Empty).Split(',').ToList();
            }
        }

        /// <summary>
        /// 海底捞在菜单的套餐类目显示的名称
        /// </summary>
        /// <value>
        /// 海底捞在菜单的套餐类目显示的名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string HaiDiLaoPackageMenu
        {
            get
            {
                return (ConfigurationManager.AppSettings["HaiDiLaoPackageMenu"] ?? string.Empty).Trim();
            }
        }

        /// <summary>
        /// 赠品菜菜单的类目
        /// </summary>
        /// <value>
        /// 赠品菜菜单的类目
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string PresentMenu
        {
            get
            {
                return (ConfigurationManager.AppSettings["PresentMenu"] ?? string.Empty).Trim();
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

        /// <summary>
        /// 计算折扣
        /// </summary>
        /// <param name="total">消费总额</param>
        /// <param name="calculateCouponWay">计算打折的方式，1 先减后打折 2 先打折后减  3 叠加最优惠的  4 不叠加最优惠的  5 满减优先  6 折扣优先</param>
        /// <param name="supplierCouponList">折扣信息</param>
        /// <returns>
        /// 返回计算结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/9/2013 9:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static decimal CalculateCoupon(decimal total, int calculateCouponWay, List<SupplierCouponModel> supplierCouponList)
        {
            var firstDiscount = supplierCouponList.Any(p => p.CouponTypeId == CouponTypeFirstId) ?
                                supplierCouponList.Where(p => p.CouponTypeId == CouponTypeFirstId).Select(p => p.Discount).Max() : 0;

            var secondDiscount = supplierCouponList.Any(p => p.CouponTypeId == CouponTypeSecondId) ?
                                 supplierCouponList.Where(p => p.CouponTypeId == CouponTypeSecondId).Select(p => p.Discount).Max() / 10 : 1;

            if (secondDiscount <= 0)
            {
                secondDiscount = 1;
            }

            secondDiscount = 1 - secondDiscount;
            if (calculateCouponWay == 1)
            {
                return (total - firstDiscount) * secondDiscount;
            }

            if (calculateCouponWay == 2)
            {
                return total * secondDiscount - firstDiscount;
            }

            if (calculateCouponWay == 3)
            {
                return Math.Min((total - firstDiscount) * secondDiscount, total * secondDiscount - firstDiscount);
            }

            if (calculateCouponWay == 4)
            {
                return Math.Min(total - firstDiscount, total * secondDiscount);
            }

            if (calculateCouponWay == 5)
            {
                return firstDiscount > 0 ? total - firstDiscount : total * secondDiscount;
            }

            if (calculateCouponWay == 6)
            {
                return secondDiscount >= 0 && secondDiscount <= 1 ? total * secondDiscount : total - firstDiscount;
            }

            return total;
        }
    }
}
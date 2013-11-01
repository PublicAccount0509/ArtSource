﻿namespace Ets.SingleApi.UnitTest.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 类名称：CommonUtility
    /// 命名空间：Ets.SingleApi.UnitTest.Utility
    /// 类功能：定义一些公用的方法
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:34
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public static class CommonUtility
    {
        #region Write log

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="name">The name</param>
        /// <param name="logType">Type of the log.</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void WriteLog(this string message, string name, Log4NetType logType)
        {
            var log = Log4NetUtility.GetInstance().GetLog(name);
            if (logType == Log4NetType.Debug)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Error)
            {
                log.Error(message);
                return;
            }

            if (logType == Log4NetType.Fatal)
            {
                log.Debug(message);
                return;
            }

            if (logType == Log4NetType.Info)
            {
                log.Info(message);
                return;
            }

            log.Warn(message);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="exception">The exception</param>
        /// <param name="name">The name</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void WriteLog(this Exception exception, string name)
        {
            var log = Log4NetUtility.GetInstance().GetLog(name);
            log.Error(exception);
        }

        #endregion

        /// <summary>
        /// 判定字符串是否为空或null
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool IsEmptyOrNull(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return value.Trim().Length == 0;
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="d">The d</param>
        /// <returns>
        /// The Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// Gets the distance.
        /// </summary>
        /// <param name="lat1">The lat1</param>
        /// <param name="lng1">The lng1</param>
        /// <param name="lat2">The lat2</param>
        /// <param name="lng2">The lng2</param>
        /// <returns>
        /// Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var radLat1 = Rad(lat1);
            var radLat2 = Rad(lat2);
            var lat = radLat1 - radLat2;
            var lng = Rad(lng1) - Rad(lng2);
            var distance = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(lat / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(lng / 2), 2)));
            distance = distance * 6376.5;
            return distance;
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="str">待加密的字串</param>
        /// <returns>
        /// 返回加密字串
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string Md5(this string str)
        {
            var b = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(str));
            var ret = string.Empty;
            for (var i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }

            return ret;
        }

        /// <summary>
        /// 获取Token过期时间
        /// </summary>
        /// <returns>
        /// 返回Token过期时间
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int GetTokenExpiresIn()
        {
            const int TokenExpiresIn = 60 * 60 * 24 * 30; //30天
            int tempTokenExpiresIn;
            if (int.TryParse(ConfigurationManager.AppSettings["TokenExpiresIn"], out tempTokenExpiresIn))
            {
                return tempTokenExpiresIn;
            }

            return TokenExpiresIn;
        }

        /// <summary>
        /// 获取Token类型
        /// </summary>
        /// <returns>
        /// 返回Token类型
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string GetTokenType()
        {
            return "Bearer";
        }

        /// <summary>
        /// 生成随机指定长度的数字
        /// </summary>
        /// <param name="length">长度</param>
        /// <returns>
        /// 返回随机码
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string RandNum(int length)
        {
            var list = new List<int>();
            for (var i = 0; i < length; i++)
            {
                list.Add(new Random(i * ((int)DateTime.Now.Ticks)).Next(0, 10));
            }

            return string.Concat(list);
        }

        /// <summary>
        /// 将Object类型转换为string
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ObjectToString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return obj.ToString();
        }

        /// <summary>
        /// 将Object类型转换为Int32
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int? ObjectToInt32(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Int32
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ObjectToInt(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// 将Object类型转换为Double
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static double? ObjectToDouble(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            double result;
            if (double.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Decimal
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static decimal? ObjectToDecimal(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            decimal result;
            if (decimal.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为Boolean
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool? ObjectToBoolean(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            bool result;
            if (bool.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 将Object类型转换为DateTime
        /// </summary>
        /// <param name="obj">待转换的值</param>
        /// <returns>
        /// 返回转换后的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static DateTime? ObjectToDateTime(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            DateTime result;
            if (DateTime.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 检测手机号是否合法
        /// </summary>
        /// <param name="mobilephone">手机号</param>
        /// <returns>合法True，不合法False</returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 19:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool IsMobilephone(this string mobilephone)
        {
            return Regex.IsMatch(mobilephone ?? string.Empty, @"(^18\d{9}$)|(^13\d{9}$)|(^15\d{9}$)");
        }
    }
}
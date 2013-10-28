using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Ets.SingleApi.Pay.Allscore
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置商户有关信息及返回路径
    /// 版本：1.0
    /// 日期：2011-12-20
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究奥斯卡接口使用，只是提供一个参考。
    /// 
    /// 提示：如何获取安全校验码、商户号和终端号
    /// 1.致电奥斯卡客服热线（400-620-7575）进行咨询
    /// 
    /// </summary>
    internal class Config
    {
        #region 字段
        private static string merchantId = "";
        private static string terminalId = "";
        private static string key = "";
        private static string input_charset = "";
        private static string transport = "";
        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //商户id
            merchantId = "888110000180006";

            //终端号
            terminalId = "00180006";

            //交易安全检验码，由数字和字母组成的32位字符串
            key = "03168389348e46f6ad3d2bf931ee499b";



            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 请使用 utf-8
            input_charset = "utf-8";

            //访问模式,根据自己的服务器是否支持ssl访问，若支持请选择https；若不支持请选择http，测试时请使用http。
            transport = "http";
        }

        #region 属性
        /// <summary>
        /// 获取或设置商户id
        /// </summary>
        public static string MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }

        /// <summary>
        /// 获取或设置交易安全检验码
        /// </summary>
        public static string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 获取或设置终端号
        /// </summary>
        public static string TerminalId
        {
            get { return terminalId; }
            set { terminalId = value; }
        }



        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }


        /// <summary>
        /// 获取访问模式
        /// </summary>
        public static string Transport
        {
            get { return transport; }
        }
        #endregion
    }
}
namespace Ets.SingleApi.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// 类名称：ErrorUtility
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：状态码信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 19:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class StatusUtility
    {
        /// <summary>
        /// 字段instance
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static StatusUtility instance;

        /// <summary>
        /// The messageDictionary
        /// </summary>
        /// Creator:zhouchao
        /// Creation Date:11/25/2011 11:23 AM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private readonly Dictionary<string, string> messageDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusUtility"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected StatusUtility()
        {
            var xmlDocument = new XmlDocument { XmlResolver = null };
            xmlDocument.Load(string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["status"]));
            var element = XDocument.Parse(xmlDocument.InnerXml).Element("status");
            if (element == null)
            {
                return;
            }

            this.messageDictionary = new Dictionary<string, string>();
            var list = (from item in element.Elements("item")
                        select new
                        {
                            Code = item.GetAttribute("code"),
                            Message = item.GetAttribute("message"),
                        }).ToList();

            foreach (var item in list)
            {
                this.messageDictionary.Add(item.Code, item.Message);
            }
        }

        /// <summary>
        /// 注册状态码
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void Register()
        {
            if (instance == null)
            {
                instance = new StatusUtility();
            }
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns>
        /// 返回实例
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static StatusUtility GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// 获取状态信息
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns>
        /// 返回状态信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 19:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string GetMessage(string statusCode)
        {
            return messageDictionary.ContainsKey(statusCode) ? messageDictionary[statusCode] : string.Empty;
        }
    }
}
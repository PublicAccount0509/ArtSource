namespace Ets.SingleApi.UnitTest.Utility
{
    using System;
    using System.Configuration;
    using System.IO;

    using log4net;
    using log4net.Config;

    /// <summary>
    /// Log4Net类型枚举
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public enum Log4NetType
    {
        /// <summary>
        /// 字段Debug
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Debug,

        /// <summary>
        /// 字段Error
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Error,

        /// <summary>
        /// 字段Info
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Info,

        /// <summary>
        /// 字段Fatal
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Fatal,

        /// <summary>
        /// 字段Warn
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Warn
    }

    /// <summary>
    /// 类名称：Log4NetUtility
    /// 命名空间：Ets.SingleApi.UnitTest.Utility
    /// 类功能：注册Log4Net相关信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:36
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class Log4NetUtility
    {
        /// <summary>
        /// 字段instance
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static Log4NetUtility instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetUtility"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected Log4NetUtility()
        {
            var logPath = ConfigurationManager.AppSettings["log4net"] ?? string.Empty;
            var filePath = string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/'), logPath.TrimStart('\\', '/'));
            XmlConfigurator.ConfigureAndWatch(new FileInfo(filePath));
        }

        /// <summary>
        /// 注册Log4Net相关信息
        /// </summary>
        /// <returns>
        /// The Log4NetUtility
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void Register()
        {
            if (instance == null)
            {
                instance = new Log4NetUtility();
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
        public static Log4NetUtility GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// 获取日志对象
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>
        /// The ILog
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ILog GetLog(string name)
        {
            var logger = LogManager.GetLogger(name);
            return logger;
        }
    }
}
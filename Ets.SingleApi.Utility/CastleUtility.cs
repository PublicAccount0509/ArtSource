﻿namespace Ets.SingleApi.Utility
{
    using System.Configuration;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    using Castle.Windsor;

    /// <summary>
    /// 类名称：CastleUtility
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：注册Castle以及一些Castle相关的信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:29
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CastleUtility
    {
        /// <summary>
        /// CastleUtility实例
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static CastleUtility instance;

        /// <summary>
        /// WindsorContainer容器
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private WindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleUtility"/> class.
        /// </summary>
        /// <param name="config">The config</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected CastleUtility(HttpConfiguration config)
        {
            if (config == null)
            {
                return;
            }

            config.Services.Replace(typeof(IHttpControllerActivator), new CastleHttpControllerActivator(this.Container.Kernel));
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IWindsorContainer Container
        {
            get
            {
                return this.container ?? (this.container = new WindsorContainer(ConfigurationManager.AppSettings["IWindsorContainer"]));
            }
        }

        /// <summary>
        /// 注册castle相关信息
        /// </summary>
        /// <param name="config">The config</param>
        /// <returns>
        /// The CastleUtility
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void Register(HttpConfiguration config)
        {
            if (instance == null)
            {
                instance = new CastleUtility(config);
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
        public static CastleUtility GetInstance()
        {
            return instance;
        }
    }
}
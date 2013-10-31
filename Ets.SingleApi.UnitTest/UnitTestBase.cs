namespace Ets.SingleApi.UnitTest
{
    using System.Configuration;
    using System.Net;
    using System.Text;

    using Castle.Windsor;

    using Ets.SingleApi.UnitTest.Utility;

    using NUnit.Framework;

    /// <summary>
    /// 类名称：UnitTestBase
    /// 命名空间：Ets.SingleApi.UnitTest
    /// 类功能：单元测试基类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 3:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [TestFixture]
    public class UnitTestBase
    {
        /// <summary>
        /// Gets the test controller.
        /// </summary>
        /// <value>
        /// The test controller.
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 4:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected string TestController
        {
            get
            {
                return ConfigurationManager.AppSettings["TestController"] ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 3:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected IWindsorContainer Container { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 3:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [TestFixtureSetUp]
        public virtual void Init()
        {
            Log4NetUtility.Register();
            CastleUtility.Register();

            this.Container = CastleUtility.GetInstance().Container;
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        /// Creator:zhouchao
        /// Creation Date:12/8/2011 10:22 AM
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        [TestFixtureTearDown]
        public virtual void TearDown()
        {
        }

        /// <summary>
        /// Creates the web client.
        /// </summary>
        /// <returns>
        /// WebClient
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 3:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected WebClient CreateWebClient()
        {
            return this.CreateWebClient(string.Empty);
        }

        /// <summary>
        /// Creates the web client.
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>
        /// WebClient
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 3:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected WebClient CreateWebClient(string token)
        {
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Headers["AppKey"] = ConfigurationManager.AppSettings["AppKey"];
            client.Headers["AppPassword"] = ConfigurationManager.AppSettings["AppPassword"];
            client.Headers["Token"] = token;
            client.Encoding = Encoding.UTF8;
            return client;
        }
    }
}
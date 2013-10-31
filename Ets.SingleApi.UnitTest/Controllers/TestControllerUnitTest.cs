namespace Ets.SingleApi.UnitTest.Controllers
{
    using System.Json;

    using Ets.SingleApi.Controllers;

    using NUnit.Framework;

    using StatusCode = Ets.SingleApi.UnitTest.Utility.StatusCode;

    /// <summary>
    /// 类名称：TestControllerUnitTest
    /// 命名空间：Ets.SingleApi.UnitTest.Controllers
    /// 类功能：TestController单元测试
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 3:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [TestFixture]
    public class TestControllerUnitTest : UnitTestBase
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 3:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override void Init()
        {
            base.Init();
            var testController = this.Container.Resolve<TestController>("Ets.SingleApi.Controllers.TestController");
            if (testController == null)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests the test.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 4:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Test]
        public void TestTest()
        {
            using (var client = this.CreateWebClient())
            {
                var url = string.Format("{0}/{1}", this.TestController.TrimEnd('/'), "Test");
                var result = client.DownloadString(url);
                var jsonValue = JsonValue.Parse(result);
                if (jsonValue == null || jsonValue["Message"] == null)
                {
                    Assert.Fail();
                }

                int statusCode = jsonValue["Message"]["StatusCode"];
                Assert.True(statusCode == (int)StatusCode.Succeed.Ok);
            }
        }
    }
}
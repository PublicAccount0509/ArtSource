namespace Ets.SingleApi.UnitTest.Controllers
{
    using System.Json;

    using Ets.SingleApi.Controllers;
    using Ets.SingleApi.UnitTest.Utility;

    using NUnit.Framework;

    using StatusCode = Ets.SingleApi.UnitTest.Utility.StatusCode;

    /// <summary>
    /// 类名称：OrdersControllerUnitTest
    /// 命名空间：Ets.SingleApi.UnitTest.Controllers
    /// 类功能：OrdersController单元测试
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 3:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [TestFixture]
    public class OrdersControllerUnitTest : UnitTestBase
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
            var ordersController = this.Container.Resolve<OrdersController>("Ets.SingleApi.Controllers.OrdersController");
            if (ordersController == null)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Orders the number test.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/1/2013 10:51 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Test]
        public void OrderNumberTest()
        {
            using (var client = this.CreateWebClient())
            {
                var url = string.Format("{0}/{1}?ordertype={2}", this.OrdersController.TrimEnd('/'), "OrderNumber", 0);
                var result = client.DownloadString(url);
                var jsonValue = JsonValue.Parse(result);
                if (jsonValue == null || jsonValue["Message"] == null || jsonValue["Result"] == null)
                {
                    Assert.Fail();
                }

                int statusCode = jsonValue["Message"]["StatusCode"];
                Assert.True(statusCode == (int)StatusCode.Succeed.Ok);
                string orderNumber = jsonValue["Result"]["OrderNumber"];
                Assert.True(!orderNumber.IsEmptyOrNull());
            }
        }
    }
}
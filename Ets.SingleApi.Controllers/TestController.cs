namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：TestController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：测试
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 6:03 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TestController : ApiController
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        [HttpPost]
        public Response<string> Test()
        {
            return new Response<string>
            {
                Result = string.Format("Welcome to {0}.", this.ControllerContext.ControllerDescriptor.ControllerName)
            };
        }
    }
}
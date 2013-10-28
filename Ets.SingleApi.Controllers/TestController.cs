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
    public class TestController : SingleApiController
    {
        /// <summary>
        /// 测试方法
        /// </summary>
        /// <returns>
        /// The ApiResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 6:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ApiResponse Test()
        {
            return new ApiResponse();
        }
    }
}
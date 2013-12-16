namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：TestService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：测试服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService : ITestService
    {
        /// <summary>
        /// GET测试方法
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Test", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> GetTest()
        {
            return new Response<string>
            {
                Result = "Hello World!"
            };
        }

        /// <summary>
        /// POST测试方法
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Test", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> PostTest()
        {
            return new Response<string>
            {
                Result = "Hello World!"
            };
        }
    }
}
namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：BaiDuLightService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：百度轻应用服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BaiDuLightService : IBaiDuLightService
    {
        /// <summary>
        /// 获取轻应用程序Id
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/LightApplicationId?applicationId={applicationId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> LightApplicationId(string applicationId)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 获取轻应用餐厅或集团模板信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/LightSupplierTemplate?applicationId={applicationId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<LightSupplierTemplate> LightSupplierTemplate(string applicationId)
        {
            return new Response<LightSupplierTemplate>();
        }

        /// <summary>
        /// 获取轻应用餐厅或集团信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/LightSupplier?applicationId={applicationId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<LightSupplier> LightSupplier(string applicationId)
        {
            return new Response<LightSupplier>();
        }

        /// <summary>
        /// 获取轻应用餐厅或集团详细信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/LightSupplierDetail?applicationId={applicationId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<LightSupplierDetail> LightSupplierDetail(string applicationId)
        {
            return new Response<LightSupplierDetail>();
        }
    }
}
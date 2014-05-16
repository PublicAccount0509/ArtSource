namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：BusinessAreaService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：BusinessArea服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BusinessAreaService : IBusinessAreaService
    {
        /// <summary>
        /// 获取区域和商圈信息列表
        /// </summary>
        /// <param name="parentCode">区域或商圈父节点Id</param>
        /// <returns>
        /// 返回区域和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/BusinessAreaList?parentCode={parentCode}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<BusinessArea> BusinessAreaList(string parentCode)
        {
            return new ListResponse<BusinessArea>();
        }

        /// <summary>
        /// 获取已开通城市列表
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns>
        /// 返回已开通城市列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/OpenCityList?parentCode={parentCode}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<BusinessArea> OpenCityList(string parentCode)
        {
            return new ListResponse<BusinessArea>();
        }

        /// <summary>
        /// 获取地区和商圈信息列表
        /// </summary>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回地区和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/RegionBusinessAreaList?parentCode={parentCode}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<BusinessArea> RegionBusinessAreaList(string parentCode)
        {
            return new ListResponse<BusinessArea>();
        }

        /// <summary>
        /// 获取商圈信息
        /// </summary>
        /// <param name="id">商圈Id</param>
        /// <param name="businessAreaName">商圈名称</param>
        /// <returns>
        /// 返回商圈信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/BusinessArea/{id}?businessAreaName={businessAreaName}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<BusinessArea> BusinessArea(string id, string businessAreaName)
        {
            return new Response<BusinessArea>();
        }

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="id">区域Id</param>
        /// <param name="regionName">区域名称</param>
        /// <returns>
        /// 返回区域信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Region/{id}?regionName={regionName}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<BusinessArea> Region(string id, string regionName)
        {
            return new Response<BusinessArea>();
        }
    }
}
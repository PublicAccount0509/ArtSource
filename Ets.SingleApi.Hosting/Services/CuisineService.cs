namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：CuisineService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：Cuisine服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CuisineService : ICuisineService
    {
        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <returns>
        /// 返回菜品列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/CuisineList", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Cuisine> CuisineList()
        {
            return new ListResponse<Cuisine>();
        }

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <param name="cityId">城市Id</param>
        /// <returns>
        /// 返回菜品列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/CityCuisineList?cityId={cityId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Cuisine> CityCuisineList(string cityId)
        {
            return new ListResponse<Cuisine>();
        }

        /// <summary>
        /// 获取菜品信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cuisineName"></param>
        /// <returns>
        /// 返回菜品信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Cuisine/{id}?cuisineName={cuisineName}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<Cuisine> Cuisine(string id, string cuisineName)
        {
            return new Response<Cuisine>();
        }
    }
}
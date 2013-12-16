namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：WapSupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：WapSupplier服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WapSupplierService : IWapSupplierService
    {
        /// <summary>
        /// 根据餐厅域名获取餐厅信息
        /// </summary>
        /// <param name="supplierDomain">餐厅域名</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/RoughSupplier?supplierDomain={supplierDomain}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<RoughSupplier> RoughSupplier(string supplierDomain)
        {
            return new Response<RoughSupplier>();
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="supplierName">餐厅名称</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">用户经度</param>
        /// <param name="userLong">用户纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="buildingLat">楼宇经度</param>
        /// <param name="buildingLong">楼宇纬度</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SearchSupplierList?supplierName={supplierName}&regionId={regionId}&userLat={userLat}&userLong={userLong}&distance={distance}&pageSize={pageSize}&pageIndex={pageIndex}&buildingLat={buildingLat}&buildingLong={buildingLong}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Supplier> SearchSupplierList(
            string supplierName,
            string regionId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            string buildingLat,
            string buildingLong)
        {
            return new ListResponse<Supplier>();
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/NearSupplierList?cuisineId={cuisineId}&regionId={regionId}&businessAreaId={businessAreaId}&userLat={userLat}&userLong={userLong}&distance={distance}&pageSize={pageSize}&pageIndex={pageIndex}&orderByType={orderByType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Supplier> NearSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType)
        {
            return new ListResponse<Supplier>();
        }

        /// <summary>
        /// 获取外卖餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回外卖餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/WaiMaiSupplierList?cuisineId={cuisineId}&regionId={regionId}&businessAreaId={businessAreaId}&userLat={userLat}&userLong={userLong}&distance={distance}&pageSize={pageSize}&pageIndex={pageIndex}&orderByType={orderByType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Supplier> WaiMaiSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType)
        {
            return new ListResponse<Supplier>();
        }

        /// <summary>
        /// 获取订台餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回订台餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/DingTaiSupplierList?cuisineId={cuisineId}&regionId={regionId}&businessAreaId={businessAreaId}&userLat={userLat}&userLong={userLong}&distance={distance}&pageSize={pageSize}&pageIndex={pageIndex}&orderByType={orderByType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Supplier> DingTaiSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType)
        {
            return new ListResponse<Supplier>();
        }
    }
}
namespace Ets.SingleApi.Hosting.Services
{
    using System;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：SupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：餐厅服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SupplierService : ISupplierService
    {
        /// <summary>
        /// 计算餐厅打包费
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">菜品信息</param>
        /// <returns>
        /// 返回打包费
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/PackagingFee/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<decimal> PackagingFee(string id, PackagingFeeRequst requst)
        {
            return new Response<decimal>();
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Supplier/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<SupplierDetail> Supplier(string id)
        {
            return new Response<SupplierDetail>();
        }

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
        /// 获取餐厅基本信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierSimple/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<SupplierSimple> SupplierSimple(string id)
        {
            return new Response<SupplierSimple>();
        }

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GroupSupplierList?supplierGroupId={supplierGroupId}&featureId={featureId}&pageSize={pageSize}&pageIndex={pageIndex}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<GroupSupplier> GroupSupplierList(int supplierGroupId, int featureId, int pageSize, string pageIndex)
        {
            return new ListResponse<GroupSupplier>();
        }

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="cityId">The cityId</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SearchGroupSupplierList?supplierGroupId={supplierGroupId}&userLat={userLat}&userLong={userLong}&featureId={featureId}&cityId={cityId}&pageSize={pageSize}&pageIndex={pageIndex}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<GroupSupplier> SearchGroupSupplierList(int supplierGroupId, int userLat, int userLong, int featureId, int cityId, int pageSize, int pageIndex)
        {
            return new ListResponse<GroupSupplier>();
        }

        /// <summary>
        /// 获取餐厅已经开通的功能列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回餐厅已经开通的功能列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierFeatureList/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierFeature> SupplierFeatureList(string id)
        {
            return new ListResponse<SupplierFeature>();
        }

        /// <summary>
        /// 获取餐厅菜单
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜单
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Menu/{id}?supplierMenuCategoryTypeId={supplierMenuCategoryTypeId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierCuisine> Menu(string id, int supplierMenuCategoryTypeId)
        {
            return new ListResponse<SupplierCuisine>();
        }

        /// <summary>
        /// 获取赠品菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回赠品菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/PresentDishList/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierDish> PresentDishList(string id)
        {
            return new ListResponse<SupplierDish>();
        }

        /// <summary>
        /// 获取餐厅菜系列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜系列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierCuisineList/{id}?supplierMenuCategoryTypeId={supplierMenuCategoryTypeId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierCuisineDetail> SupplierCuisineList(string id, int supplierMenuCategoryTypeId)
        {
            return new ListResponse<SupplierCuisineDetail>();
        }

        /// <summary>
        /// 获取餐厅菜系
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierCategoryId">菜系Id</param>
        /// <returns>
        /// 返回餐厅菜系
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierCuisine/{id}?supplierCategoryId={supplierCategoryId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<SupplierCuisineDetail> SupplierCuisine(string id, int supplierCategoryId)
        {
            return new Response<SupplierCuisineDetail>();
        }

        /// <summary>
        /// 添加餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AddSupplierCuisine/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> AddSupplierCuisine(string id, SaveSupplierCuisineRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 修改餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/UpdateSupplierCuisine/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> UpdateSupplierCuisine(string id, SaveSupplierCuisineRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 删除餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/DeleteSupplierCuisine/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> DeleteSupplierCuisine(string id, DeleteSupplierCuisineRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 获取餐厅菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <param name="supplierCategoryId">餐厅菜系Id</param>
        /// <returns>
        /// 返回餐厅菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierDishList/{id}?supplierMenuCategoryTypeId={supplierMenuCategoryTypeId}&supplierCategoryId={supplierCategoryId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierDishDetail> SupplierDishList(string id, int supplierMenuCategoryTypeId, string supplierCategoryId)
        {
            return new ListResponse<SupplierDishDetail>();
        }

        /// <summary>
        /// 获取餐厅菜
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierDishId">餐厅菜Id</param>
        /// <returns>
        /// 返回餐厅菜
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierDish/{id}?supplierDishId={supplierDishId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<SupplierDishDetail> SupplierDish(string id, int supplierDishId)
        {
            return new Response<SupplierDishDetail>();
        }

        /// <summary>
        /// 添加餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AddSupplierDish/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> AddSupplierDish(string id, SaveSupplierDishRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 修改餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/UpdateSupplierDish/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> UpdateSupplierDish(string id, SaveSupplierDishRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 删除餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/DeleteSupplierDish/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> DeleteSupplierDish(string id, DeleteSupplierDishRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierServiceTime/{id}?startDate={startDate}&days={days}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierServiceTime> SupplierServiceTime(string id, string startDate, string days)
        {
            return new ListResponse<SupplierServiceTime>();
        }

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierDeliveryTime/{id}?startDate={startDate}&days={days}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(string id, string startDate, string days)
        {
            return new ListResponse<SupplierDeliveryTime>();
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userLat"></param>
        /// <param name="userLong"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetDistance/{id}?userLat={userLat}&userLong={userLong}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<DistanceResult> GetDistance(string id, double userLat, double userLong)
        {
            return new Response<DistanceResult>();
        }

        /// <summary>
        /// 获取订台台位列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订日期</param>
        /// <param name="bookingTime">预订时间</param>
        /// <param name="peopleCount">预定人数</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/DeskList/{id}?bookingDate={bookingDate}&bookingTime={bookingTime}&peopleCount={peopleCount}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<DingTaiDesk> DeskList(string id, DateTime bookingDate, string bookingTime, int peopleCount)
        {
            return new ListResponse<DingTaiDesk>();
        }

        /// <summary>
        /// 获取餐厅订台开放时间列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订时间</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/DeskOpenTimeList/{id}?bookingDate={bookingDate}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<string> DeskOpenTimeList(string id, DateTime bookingDate)
        {
            return new ListResponse<string>();
        }

        /// <summary>
        /// 获取餐厅订台开放日期列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="days">The days</param>
        /// <returns>
        /// ListResponse{DeskOpenDate}
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 7:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/DeskOpenDateList/{id}?days={days}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<DeskOpenDate> DeskOpenDateList(string id, int days)
        {
            return new ListResponse<DeskOpenDate>();
        }

        /// <summary>
        /// 查检订台台位是否被锁
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">The requst.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:11 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CheckDesk/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CheckDesk(string id, CheckDeskRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 检查桌号是否有效
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="tableNo">桌号</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/24/2014 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/CheckTableNumIsEffective?supplierId={supplierId}&tableNo={tableNo}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CheckTableNumIsEffective(int supplierId, string tableNo)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 根据桌子Id查询桌子编号
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="tableNo">The tableNo</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetDeskNoById?supplierId={supplierId}&tableNo={tableNo}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> GetDeskNoById(int supplierId, int tableNo)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 查询推荐菜品列表
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// 推荐菜品列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/27/2014 3:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetRecommendedDishList/{id}?pageIndex={pageIndex}&pageSize={pageSize}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierRecommendedDish> GetRecommendedDishList(string id, int pageIndex, int pageSize)
        {
            return new ListResponse<SupplierRecommendedDish>();
        }
    }
}
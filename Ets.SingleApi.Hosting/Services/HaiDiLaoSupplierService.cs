namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：HaiDiLaoSupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：海底捞餐厅服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HaiDiLaoSupplierService : IHaiDiLaoSupplierService
    {
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
        /// 获取套餐详细信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="packageId">套餐Id</param>
        /// <returns>
        /// 返回套餐详细信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/PackageDetail/{id}?packageId={packageId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<PackageCuisine> PackageDetail(string id, int packageId)
        {
            return new ListResponse<PackageCuisine>();
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
        /// 创建者：单琪彬
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
        /// 创建者：单琪彬
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SupplierDeliveryTime/{id}?startDate={startDate}&days={days}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(string id, string startDate, string days)
        {
            return new ListResponse<SupplierDeliveryTime>();
        }
    }
}
namespace Ets.SingleApi.Hosting.Services
{
    using System;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：DirectPayService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：当面付服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DirectPayService : IDirectPayService
    {
        /// <summary>
        /// 创建当面付订单信息
        /// </summary>
        /// <param name="requst">The requstDefault documentation</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CreateOrder", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> CreateOrder(SaveDirectPayRequest requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 检查手机号支付次数是否超过上限
        /// </summary>
        /// <param name="telephone">手机号</param>
        /// <param name="upperLimit">当天的当面付支付上限次数</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CheckPhoneNoPayMoreThanUpperLimit?telephone={telephone}&upperLimit={upperLimit}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CheckPhoneNoPayMoreThanUpperLimit(string telephone, int upperLimit)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 获取当面付订单详情
        /// </summary>
        /// <param name="id">The idDefault documentation</param>
        /// <returns>
        /// Response{QueueDetail}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:15 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetOrderDetail/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<DirectPayDetail> GetOrderDetail(string id)
        {
            return new Response<DirectPayDetail>();
        }

        /// <summary>
        /// 查询排队列表
        /// </summary>
        /// <param name="startDate">The startDateDefault documentation</param>
        /// <param name="endDate">The queueEndDate</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="userId">The userId</param>
        /// <param name="platformId">平台Id</param>
        /// <returns>
        /// 排队列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/22/2014 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetOrderList?startDate={startDate}&endDate={endDate}&supplierId={supplierId}&supplierGroupId={supplierGroupId}&pageSize={pageSize}&pageIndex={pageIndex}&userId={userId}&platformId={platformId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<DirectPayModelResponse> GetOrderList(
            DateTime startDate,
            DateTime endDate,
            int supplierId,
            int supplierGroupId,
            int pageSize,
            int pageIndex,
            int userId,
            int platformId)
        {
            return new ListResponse<DirectPayModelResponse>();
        }

        /// <summary>
        /// 取消当面付订单
        /// </summary>
        /// <param name="requst">The cancelDirectPayParameterDefault documentation</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/6/2014 8:57 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CanceledDirectPay", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CanceledDirectPay(CancelDirectPayRequest requst)
        {
            return new Response<bool>();
        }
    }
}
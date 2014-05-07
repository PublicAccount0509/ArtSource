namespace Ets.SingleApi.Hosting.Services
{
    using System;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：QueueService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：排队服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class QueueService : IQueueService
    {
        /// <summary>
        /// 取得排队台位类型信息
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="queueDate">The queueDate</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 排队台位类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/DeskList?supplierId={supplierId}&queueDate={queueDate}&userId={userId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<QueueDesk> DeskList(int supplierId, DateTime queueDate, int userId)
        {
            return new ListResponse<QueueDesk>();
        }

        /// <summary>
        /// 保存排队信息
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回排队号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SaveQueue", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> SaveQueue(SaveQueueRequst requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 检测台位状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CheckQueueDeskState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CheckQueueDeskState(CheckQueueDeskStateRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 取得排队详情信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// 返回排队详情信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetQueue/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<QueueDetail> GetQueue(string id)
        {
            return new Response<QueueDetail>();
        }

        /// <summary>
        /// 查询排队列表
        /// </summary>
        /// <param name="queueStartDate">The queueStartDate</param>
        /// <param name="queueEndDate">The queueEndDate</param>
        /// <param name="queueStatus">The queueStatus</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="cancelled">The  cancelled indicates whether</param>
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
        [WebGet(UriTemplate = "/GetQueueList?queueStartDate={queueStartDate}&queueEndDate={queueEndDate}&queueStatus={queueStatus}&supplierId={supplierId}&supplierGroupId={supplierGroupId}&pageSize={pageSize}&pageIndex={pageIndex}&cancelled={cancelled}&userId={userId}&platformId={platformId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<Queue> GetQueueList(
            DateTime queueStartDate,
            DateTime queueEndDate,
            int queueStatus,
            int supplierId,
            int supplierGroupId,
            int pageSize,
            int pageIndex,
            bool cancelled,
            int userId,
            int platformId)
        {
            return new ListResponse<Queue>();
        }

        /// <summary>
        /// 取消排队
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 9:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CancelQueue", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CancelQueue(CancelQueueRequst requst)
        {
            return new Response<bool>();
        }
    }
}
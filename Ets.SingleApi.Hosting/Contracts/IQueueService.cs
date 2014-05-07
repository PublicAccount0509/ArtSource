namespace Ets.SingleApi.Hosting.Contracts
{
    using System;
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IFunctionService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Function服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IQueueService
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
        [OperationContract]
        [Description("方法功能：取得排队台位类型信息；参数说明：supplierId（餐厅Id），queueDate（排队日期），userId（用户Id）")]
        ListResponse<QueueDesk> DeskList(int supplierId, DateTime queueDate, int userId);

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
        [OperationContract]
        [Description("方法功能：保存排队信息；返回结果：返回排队号")]
        Response<string> SaveQueue(SaveQueueRequst requst);

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
        [OperationContract]
        [Description("方法功能：检测台位状态")]
        Response<bool> CheckQueueDeskState(CheckQueueDeskStateRequst requst);

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
        [OperationContract]
        [Description("方法功能：取得排队详情信息；参数说明：id（排队Id）")]
        Response<QueueDetail> GetQueue(string id);

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
        [OperationContract]
        [Description("方法功能：查询排队列表；参数说明：queueStartDate（起始日期），queueEndDate（结束日期），queueStatus（排队状态），supplierId（餐厅Id），supplierGroupId（集团Id），pageSize（页数），pageIndex（当前页码），cancelled（取消状态），userId（用户Id），platformId（平台Id）")]
        ListResponse<Queue> GetQueueList(
           DateTime queueStartDate,
           DateTime queueEndDate,
           int queueStatus,
           int supplierId,
           int supplierGroupId,
           int pageSize,
           int pageIndex,
           bool cancelled,
           int userId,
           int platformId);

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
        [OperationContract]
        [Description("方法功能：取消排队；")]
        Response<bool> CancelQueue(CancelQueueRequst requst);
    }
}
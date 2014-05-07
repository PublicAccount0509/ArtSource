namespace Ets.SingleApi.Hosting.Contracts
{
    using System;
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IDirectPayService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：当面付服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IDirectPayService
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
        [OperationContract]
        [Description("方法功能：创建当面付订单信息；")]
        Response<string> CreateOrder(SaveDirectPayRequest requst);

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
        [OperationContract]
        [Description("方法功能：检查手机号支付次数是否超过上限；参数说明：telephone（手机号），upperLimit（最大支付次数）")]
        Response<bool> CheckPhoneNoPayMoreThanUpperLimit(string telephone, int upperLimit);

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
        [OperationContract]
        [Description("方法功能：获取当面付订单详情；")]
        Response<DirectPayDetail> GetOrderDetail(string id);

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
        [OperationContract]
        [Description("方法功能：获取当面付订单详情；")]
        ListResponse<DirectPay> GetOrderList(
            DateTime startDate,
            DateTime endDate,
            int supplierId,
            int supplierGroupId,
            int pageSize,
            int pageIndex,
            int userId,
            int platformId);

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
        [OperationContract]
        [Description("方法功能：取消当面付订单；")]
        Response<bool> CanceledDirectPay(CancelDirectPayRequst requst);
    }
}
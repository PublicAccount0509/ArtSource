using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：QueueController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：排队公用方法
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class QueueController : SingleApiController
    {
        /// <summary>
        /// 字段supplierServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IQueueServices queueServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionController" /> class.
        /// </summary>
        /// <param name="queueServices">The queueServices</param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public QueueController(IQueueServices queueServices)
        {
            this.queueServices = queueServices;
        }

        /// <summary>
        /// 取得排队台位类型信息
        /// </summary>
        /// <param name="id">The id</param>
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
        [HttpGet]
        public ListResponse<QueueDesk> DeskList(int id, DateTime queueDate, int? userId)
        {
            var list = this.queueServices.GetQueueDeskList(this.Source, new GetQueueDeskListParameter
                {
                    SupplierId = id,
                    QueueDate = queueDate,
                    UserId = userId
                });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<QueueDesk>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok
                                        ? (int)StatusCode.Succeed.Empty
                                        : list.StatusCode
                            },
                        Result = new List<QueueDesk>()
                    };
            }

            var result = list.Result.Select(p => new QueueDesk
                {
                    Id = p.Id,
                    BoxName = p.BoxName,
                    Description = p.Description,
                    DeskTypeName = p.DeskTypeName,
                    MaxNumber = p.MaxNumber,
                    MinNumber = p.MinNumber,
                    QueueNumber = p.QueueNumber,
                    RoomType = p.RoomType ?? 0,
                    TblTypeId = p.TblTypeId,
                    TblTypeName = p.TblTypeName,
                }).ToList();

            return new ListResponse<QueueDesk>
            {
                Result = result
            };
        }
    }
}
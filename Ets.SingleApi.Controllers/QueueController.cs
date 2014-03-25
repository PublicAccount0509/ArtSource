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
        [HttpGet]
        public ListResponse<QueueDesk> DeskList(int supplierId, DateTime queueDate, int? userId)
        {
            var list = this.queueServices.GetQueueDeskList(this.Source, new GetQueueDeskListParameter
                {
                    SupplierId = supplierId,
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
        [HttpPost]
        public Response<string> SaveQueue(SaveQueueRequst requst)
        {
            if (requst == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = string.Empty
                };
            }

            var result = this.queueServices.SaveQueueDesk(this.Source, new SaveQueueDeskParameter
                {
                    DeskTypeId = requst.DeskTypeId,
                    Description = (requst.Description ?? string.Empty).Trim(),
                    Gender = requst.Gender,
                    SeatNumber = requst.SeatNumber,
                    SupplierId = requst.SupplierId,
                    Telephone = (requst.Telephone ?? string.Empty).Trim(),
                    UserId = requst.UserId,
                    UserName = (requst.UserName ?? string.Empty).Trim(),
                    SourceType = (requst.SourceType ?? string.Empty).Trim(),
                    Template = (requst.Template ?? string.Empty).Trim(),
                });

            return new Response<string>
            {
                Result = result.Result,
                Message = new ApiMessage
                    {
                        StatusCode = result.StatusCode
                    },
                ResultTotalCount = result.ResultTotalCount
            };
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
        [HttpPost]
        public Response<bool> CheckQueueDeskState(CheckQueueDeskStateRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var result = this.queueServices.CheckQueueDeskState(this.Source, new CheckQueueDeskStateParameter
                {
                    SupplierId = requst.SupplierId,
                    DeskTypeId = requst.DeskTypeId,
                    UserId = requst.UserId
                });

            return new Response<bool>
            {
                Result = result.Result,
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                ResultTotalCount = result.ResultTotalCount
            };
        }

        /// <summary>
        /// 取得排队台位类型信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// 排队台位类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<QueueDetail> GetQueue(int id)
        {
            var queue = this.queueServices.GetQueue(this.Source, id);

            if (queue.Result == null)
            {
                return new Response<QueueDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = queue.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : queue.StatusCode
                    },
                    Result = new QueueDetail()
                };
            }

            var result = new QueueDetail
                {
                    BoxName = queue.Result.BoxName,
                    DeskTypeId = queue.Result.DeskTypeId,
                    DeskTypeDescription = queue.Result.DeskTypeDescription,
                    DeskTypeName = queue.Result.DeskTypeName,
                    QueueDescription = queue.Result.QueueDescription,
                    Gender = queue.Result.Gender ?? ControllersCommon.DefaultGender,
                    MaxNumber = queue.Result.MaxNumber,
                    MinNumber = queue.Result.MinNumber,
                    Number = queue.Result.Number,
                    QueueId = queue.Result.QueueId,
                    QueueStateId = queue.Result.QueueStateId,
                    RoomType = queue.Result.RoomType ?? 0,
                    SeatNumber = queue.Result.SeatNumber,
                    SupplierId = queue.Result.SupplierId,
                    SupplierName = queue.Result.SupplierName,
                    TblTypeId = queue.Result.TblTypeId,
                    TblTypeName = queue.Result.TblTypeName,
                    Telephone = queue.Result.Telephone,
                    UserName = queue.Result.UserName,
                    CeateDate = queue.Result.CeateDate.ToString("yyyy-MM-dd HH:mm")
                };

            return new Response<QueueDetail>
            {
                Result = result
            };
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
        /// <returns>
        /// 排队列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/22/2014 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<Queue> GetQueueList(DateTime? queueStartDate, DateTime? queueEndDate, int? queueStatus, int? supplierId, int? supplierGroupId, int pageSize, int? pageIndex, bool cancelled,int userId)
        {
            var list = this.queueServices.GetQueueList(this.Source, new GetQueuesParameter
            {
                QueueStartDate = queueStartDate,
                QueueEndDate = queueEndDate,
                QueueStatus = queueStatus,
                SupplierId = supplierId,
                SupplierGroupId = supplierGroupId,
                IsEtaoshi = this.IsEtaoshi,
                PageSize = pageSize,
                PageIndex = pageIndex ?? 1,
                Cancelled = cancelled,
                UserId = userId
            });

            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<Queue>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : list.StatusCode
                    },
                    Result = new List<Queue>()
                };
            }

            var result = list.Result.Select(p => new Queue
            {
                QueueId = p.QueueId,
                Number = p.Number,
                QueueStateId = p.QueueStateId,
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName,
                RoomType = p.RoomType ?? 0,
                TblTypeId = p.TblTypeId,
                TblTypeName = p.TblTypeName,
                BoxName = p.BoxName,
                DeskTypeName = p.DeskTypeName,
                MaxNumber = p.MaxNumber,
                MinNumber = p.MinNumber,
                QueueNumber = p.QueueNumber,
                CeateDate = p.CeateDate.ToString("yyyy-MM-dd HH:mm")
            }).ToList();

            return new ListResponse<Queue>
            {
                Result = result
            };
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
        [HttpPost]
        public Response<bool> CancelQueue(CancelQueueRequst requst)
        {
            if (requst == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            var result = this.queueServices.CancelQueue(this.Source, new CancelQueueParameter
            {
                TableReservationId = requst.TableReservationId
            });

            return new Response<bool>
            {
                Result = result.Result,
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                ResultTotalCount = result.ResultTotalCount
            };
        }
    }
}
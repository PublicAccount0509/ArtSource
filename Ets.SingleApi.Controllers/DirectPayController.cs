﻿namespace Ets.SingleApi.Controllers
{
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    /// <summary>
    /// 类名称：DirectPayController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：当面付业务操作
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 4:54 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DirectPayController : SingleApiController
    {
        /// <summary>
        /// 字段supplierServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IDirectPayServices directPayServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectPayController"/> class.
        /// </summary>
        /// <param name="directPayServices">The directPayServicesDefault documentation</param>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 4:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DirectPayController(IDirectPayServices directPayServices)
        {
            this.directPayServices = directPayServices;
        }

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
        [HttpPost]
        public Response<string> CreateOrder(SaveDirectPayRequest requst)
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

            var result = this.directPayServices.CreateOrder(this.Source,this.AppKey,this.AppPassword,new SaveDirectPayParameter
                {
                    SupplierId = requst.SupplierId,
                    Amount = requst.Amount,
                    PaymentMethodId = requst.PaymentMethodId,
                    IPAddress = requst.IPAddress,
                    Template = requst.Template,
                    PayBank = requst.PayBank,
                    TelePhone = requst.PhoneNo,
                    SourceType = requst.SourceType,
                    UserId = requst.UserId
                } );

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
        /// 检查手机号支付次数是否超过上限
        /// </summary>
        /// <param name="telephone">手机号</param>
        /// <param name="upperLimit">当天的当面付支付上限次数</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 5:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> CheckPhoneNoPayMoreThanUpperLimit(string telephone, int upperLimit)
        {
            if (telephone == null)
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            //检查手机号支付次数是否超过上限
            var result = this.directPayServices.CheckTelePhonePayMoreThanUpperLimit(this.Source, telephone, upperLimit);

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
        [HttpGet]
        public Response<DirectPayDetail> GetOrderDetail(int id)
        {
            var orderDetail = this.directPayServices.GetOrderDetail(this.Source, id);

            if (orderDetail.Result == null)
            {
                return new Response<DirectPayDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = orderDetail.StatusCode == (int)StatusCode.Succeed.Ok
                                ? (int)StatusCode.Succeed.Empty
                                : orderDetail.StatusCode
                    },
                    Result = new DirectPayDetail()
                };
            }

            var result = new DirectPayDetail
                {
                    SupplierId = orderDetail.Result.SupplierId,
                    PaymentMethodId = orderDetail.Result.PaymentMethodId,
                    SupplierName = orderDetail.Result.SupplierName,
                    CeateDate = orderDetail.Result.CreateDate,
                    Telephone = orderDetail.Result.Telephone,
                    IsPaid = orderDetail.Result.IsPaid
                };

            return new Response<DirectPayDetail>
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
        /// <param name="platformId">平台Id</param>
        /// <returns>
        /// 排队列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/22/2014 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<DirectPayModel> GetOrderList(DateTime? queueStartDate, DateTime? queueEndDate, int? queueStatus, int? supplierId,
                                                int? supplierGroupId, int pageSize, int? pageIndex, bool? cancelled,
                                                int userId, int? platformId)
        {
            return new ListResponse<DirectPayModel>();
        }
    }
}
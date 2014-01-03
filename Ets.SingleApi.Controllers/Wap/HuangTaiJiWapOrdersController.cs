namespace Ets.SingleApi.Controllers.Wap
{
    using System;
    using System.Collections.Generic;

    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;

    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HuangTaiJiWapOrdersController
    /// 命名空间：Ets.SingleApi.Controllers.Wap
    /// 类功能：黄太极订单功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/30/2013 5:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [TokenFilter]
    public class HuangTaiJiWapOrdersController : SingleApiController
    {
        /// <summary>
        /// 字段orderServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IHuangTaiJiOrderServicesTemp huangTaiJiOrderServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WapOrdersController"/> class.
        /// </summary>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiWapOrdersController(IHuangTaiJiOrderServicesTemp huangTaiJiOrderServices)
        {
            this.huangTaiJiOrderServices = huangTaiJiOrderServices;
        }

        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// WaiMaiOrderResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/24/2013 10:44 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<HuangTaiJiWaiMaiOrderDetail> WaiMaiOrder(int id, int userId)
        {
            if (!this.ValidateUserId(userId))
            {
                return new Response<HuangTaiJiWaiMaiOrderDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new HuangTaiJiWaiMaiOrderDetail()
                };
            }

            var getWaiMaiOrderResult = this.huangTaiJiOrderServices.GetWaiMaiOrder(id, userId);
            if (getWaiMaiOrderResult.Result == null)
            {
                return new Response<HuangTaiJiWaiMaiOrderDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getWaiMaiOrderResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getWaiMaiOrderResult.StatusCode
                    },
                    Result = new HuangTaiJiWaiMaiOrderDetail()
                };
            }

            var dishList = getWaiMaiOrderResult.Result.DishList ?? new List<HuangTaiJiWaiMaiOrderDishModel>();
            var result = new HuangTaiJiWaiMaiOrderDetail
                {
                    OrderId = getWaiMaiOrderResult.Result.OrderId,
                    OrderStatusId = getWaiMaiOrderResult.Result.OrderStatusId,
                    OrderTypeId = getWaiMaiOrderResult.Result.OrderTypeId,
                    DateReserved = getWaiMaiOrderResult.Result.DateReserved,
                    DeliveryTime = getWaiMaiOrderResult.Result.DeliveryTime,
                    SupplierId = getWaiMaiOrderResult.Result.SupplierId,
                    SupplierName = getWaiMaiOrderResult.Result.SupplierName ?? string.Empty,
                    SupplierAddress = getWaiMaiOrderResult.Result.SupplierAddress ?? string.Empty,
                    SupplierTelephone = getWaiMaiOrderResult.Result.SupplierTelephone ?? string.Empty,
                    SupplierBaIduLat = getWaiMaiOrderResult.Result.SupplierBaIduLat,
                    SupplierBaIduLong = getWaiMaiOrderResult.Result.SupplierBaIduLong,
                    DeliveryInstruction = getWaiMaiOrderResult.Result.DeliveryInstruction ?? string.Empty,
                    CustomerTotal = getWaiMaiOrderResult.Result.CustomerTotal,
                    Commission = getWaiMaiOrderResult.Result.Commission,
                    Coupon = getWaiMaiOrderResult.Result.Coupon,
                    Total = getWaiMaiOrderResult.Result.Total,
                    RealSupplierType = getWaiMaiOrderResult.Result.RealSupplierType,
                    DeliveryMethodId = getWaiMaiOrderResult.Result.DeliveryMethodId,
                    IsPaid = getWaiMaiOrderResult.Result.IsPaid,
                    IsConfirm = getWaiMaiOrderResult.Result.IsConfirm,
                    PaymentMethodId = getWaiMaiOrderResult.Result.PaymentMethodId,
                    InvoiceTitle = getWaiMaiOrderResult.Result.InvoiceTitle.IsEmptyOrNull() ? ControllersCommon.EmptyInvoiceTitle : getWaiMaiOrderResult.Result.InvoiceTitle,
                    DeliveryAddress = getWaiMaiOrderResult.Result.DeliveryAddress ?? string.Empty,
                    DishList = dishList.Select(p => new HuangTaiJiWaiMaiOrderDish
                        {
                            SupplierDishName = p.SupplierDishName,
                            Quantity = p.Quantity,
                            Price = p.Price == null ? 0 : p.Price.Value,
                            OrderParentId = p.OrderParentId,
                            OrderId = p.OrderId
                        }).ToList()
                };

            return new Response<HuangTaiJiWaiMaiOrderDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getWaiMaiOrderResult.StatusCode
                    },
                    Result = result
                };
        }

        /// <summary>
        /// 添加一个外卖订单
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// AddWaiMaiOrderResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 6:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        //[HttpPost]
        //public Response<AddWaiMaiOrderResult> AddWaiMaiOrder(AddWaiMaiOrderRequst requst)
        //{
        //    if (requst == null)
        //    {
        //        return new Response<AddWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.System.InvalidRequest
        //            },
        //            Result = new AddWaiMaiOrderResult()
        //        };
        //    }

        //    if (!this.ValidateUserId(requst.UserId))
        //    {
        //        return new Response<AddWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.OAuth.AccessDenied
        //            },
        //            Result = new AddWaiMaiOrderResult()
        //        };
        //    }

        //    var deliveryDate = (requst.DeliveryDate ?? DateTime.Now).ToString("yyyy-MM-dd");
        //    DateTime deliveryTime;
        //    if (!DateTime.TryParse(string.Format("{0} {1}", deliveryDate, requst.DeliveryTime), out deliveryTime))
        //    {
        //        deliveryTime = (requst.DeliveryDate ?? DateTime.Now);
        //    }

        //    if (requst.DeliveryType == ControllersCommon.QuickDeliveryType)
        //    {
        //        deliveryTime = (requst.DeliveryDate ?? DateTime.Now);
        //    }

        //    var dishList = requst.DishList ?? new List<AddWaiMaiOrderDish>();
        //    var addWaiMaiOrderResult = this.orderServices.AddWaiMaiOrder(new AddWaiMaiOrderParameter
        //    {
        //        UserId = requst.UserId,
        //        DeliveryMethodId = requst.DeliveryMethodId,
        //        SupplierId = requst.SupplierId,
        //        DeliveryInstruction = (requst.DeliveryInstruction ?? string.Empty).Trim(),
        //        InvoiceRequired = requst.InvoiceRequired ?? false,
        //        InvoiceTitle = (requst.InvoiceTitle ?? string.Empty).Trim(),
        //        IsTakeInvoice = requst.IsTakeInvoice ?? false,
        //        OrderNotes = (requst.OrderNotes ?? string.Empty).Trim(),
        //        Template = (requst.Template ?? string.Empty).Trim(),
        //        Path = (requst.Path ?? string.Empty).Trim(),
        //        AreaId = requst.AreaId,
        //        IpAddress = (requst.IpAddress ?? string.Empty).Trim(),
        //        DeliveryTime = deliveryTime,
        //        DeliveryType = requst.DeliveryType,
        //        DishList = dishList.Select(p => new AddWaiMaiOrderDishModel
        //            {
        //                SupplierDishId = p.SupplierDishId,
        //                Quantity = p.Quantity
        //            }).ToList()
        //    });

        //    var result = addWaiMaiOrderResult.Result ?? new AddWaiMaiOrderModel();
        //    return new Response<AddWaiMaiOrderResult>
        //    {
        //        Message = new ApiMessage
        //        {
        //            StatusCode = addWaiMaiOrderResult.StatusCode
        //        },
        //        Result = new AddWaiMaiOrderResult
        //            {
        //                OrderId = result.OrderId,
        //                CustomerTotal = result.CustomerTotal,
        //                SupplierId = result.SupplierId,
        //                SupplierName = result.SupplierName ?? string.Empty,
        //                SupplierDishCount = result.SupplierDishCount
        //            }
        //    };
        //}

        ///// <summary>
        ///// 确认外卖订单
        ///// </summary>
        ///// <param name="id">订单Id</param>
        ///// <param name="requst">The requst</param>
        ///// <returns>
        ///// ConfirmWaiMaiOrderResponse
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/23/2013 9:01 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //[HttpPost]
        //public Response<ConfirmWaiMaiOrderResult> ConfirmWaiMaiOrder(int id, ConfirmWaiMaiOrderRequst requst)
        //{
        //    if (requst == null)
        //    {
        //        return new Response<ConfirmWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.System.InvalidRequest
        //            },
        //            Result = new ConfirmWaiMaiOrderResult()
        //        };
        //    }

        //    if (!this.ValidateUserId(requst.UserId))
        //    {
        //        return new Response<ConfirmWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.OAuth.AccessDenied
        //            },
        //            Result = new ConfirmWaiMaiOrderResult()
        //        };
        //    }

        //    var confirmWaiMaiOrderResult = this.orderServices.ConfirmWaiMaiOrder(new ConfirmWaiMaiOrderParameter
        //        {
        //            UserId = requst.UserId,
        //            OrderId = id,
        //            CustomerAddressId = requst.CustomerAddressId,
        //            PaymentMethodId = requst.PaymentMethodId
        //        });

        //    var result = confirmWaiMaiOrderResult.Result ?? new ConfirmWaiMaiOrderModel();
        //    return new Response<ConfirmWaiMaiOrderResult>
        //    {
        //        Message = new ApiMessage
        //        {
        //            StatusCode = confirmWaiMaiOrderResult.StatusCode
        //        },
        //        Result = new ConfirmWaiMaiOrderResult
        //        {
        //            OrderId = result.OrderId
        //        }
        //    };
        //}

        ///// <summary>
        ///// 支付订单
        ///// </summary>
        ///// <param name="id">订单Id</param>
        ///// <param name="requst">The requst</param>
        ///// <returns>
        ///// PaymentWaiMaiOrderResponse
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/23/2013 9:01 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //[HttpPost]
        //public Response<PaymentWaiMaiOrderResult> PaymentWaiMaiOrder(int id, PaymentWaiMaiOrderRequst requst)
        //{
        //    if (requst == null)
        //    {
        //        return new Response<PaymentWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.System.InvalidRequest
        //            },
        //            Result = new PaymentWaiMaiOrderResult()
        //        };
        //    }

        //    if (!this.ValidateUserId(requst.UserId))
        //    {
        //        return new Response<PaymentWaiMaiOrderResult>
        //        {
        //            Message = new ApiMessage
        //            {
        //                StatusCode = (int)StatusCode.OAuth.AccessDenied
        //            },
        //            Result = new PaymentWaiMaiOrderResult()
        //        };
        //    }

        //    var paymentWaiMaiOrderResult = this.orderServices.PaymentWaiMaiOrder(new PaymentWaiMaiOrderParameter
        //        {
        //            UserId = requst.UserId,
        //            OrderId = id,
        //            AuthCode = (requst.AuthCode ?? string.Empty).Trim()
        //        });

        //    var result = paymentWaiMaiOrderResult.Result ?? new PaymentWaiMaiOrderModel();
        //    return new Response<PaymentWaiMaiOrderResult>
        //    {
        //        Message = new ApiMessage
        //        {
        //            StatusCode = paymentWaiMaiOrderResult.StatusCode
        //        },
        //        Result = new PaymentWaiMaiOrderResult
        //        {
        //            OrderId = result.OrderId
        //        }
        //    };
        //}
    }
}
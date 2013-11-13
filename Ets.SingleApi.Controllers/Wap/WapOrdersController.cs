namespace Ets.SingleApi.Controllers.Wap
{
    using System.Collections.Generic;

    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;

    using System.Web.Http;
    using System.Linq;

    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：WapOrdersController
    /// 命名空间：Ets.SingleApi.Controllers.Wap
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [TokenFilter]
    public class WapOrdersController : SingleApiController
    {
        /// <summary>
        /// 字段orderServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IOrderServices orderServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="WapOrdersController"/> class.
        /// </summary>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WapOrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
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
        public WaiMaiOrderResponse WaiMaiOrder(int id, int userId)
        {
            if (!this.ValidateUserId(userId))
            {
                return new WaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new WaiMaiOrderDetail()
                };
            }

            var getWaiMaiOrderResult = this.orderServices.GetWaiMaiOrder(id, userId);
            if (getWaiMaiOrderResult.Result == null)
            {
                return new WaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getWaiMaiOrderResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getWaiMaiOrderResult.StatusCode
                    },
                    Result = new WaiMaiOrderDetail()
                };
            }

            var dishList = getWaiMaiOrderResult.Result.DishList ?? new List<WaiMaiOrderDishModel>();
            var result = new WaiMaiOrderDetail
                {
                    OrderId = getWaiMaiOrderResult.Result.OrderId,
                    OrderStatusId = getWaiMaiOrderResult.Result.OrderStatusId,
                    OrderTypeId = getWaiMaiOrderResult.Result.OrderTypeId,
                    DateReserved = getWaiMaiOrderResult.Result.DateReserved == null ? string.Empty : getWaiMaiOrderResult.Result.DateReserved.Value.ToString("yyyy-MM-dd HH:mm"),
                    SupplierId = getWaiMaiOrderResult.Result.SupplierId,
                    SupplierName = getWaiMaiOrderResult.Result.SupplierName ?? string.Empty,
                    SupplierAddress = getWaiMaiOrderResult.Result.SupplierAddress ?? string.Empty,
                    SupplierTelephone = getWaiMaiOrderResult.Result.SupplierTelephone ?? string.Empty,
                    SupplierBaIduLat = getWaiMaiOrderResult.Result.SupplierBaIduLat,
                    SupplierBaIduLong = getWaiMaiOrderResult.Result.SupplierBaIduLong,
                    DeliveryInstruction = getWaiMaiOrderResult.Result.DeliveryInstruction ?? string.Empty,
                    CustomerTotal = getWaiMaiOrderResult.Result.CustomerTotal == null ? "0.00" : getWaiMaiOrderResult.Result.CustomerTotal.Value.ToString("#0.00"),
                    Commission = getWaiMaiOrderResult.Result.Commission == null ? "0.00" : getWaiMaiOrderResult.Result.Commission.Value.ToString("#0.00"),
                    Coupon = getWaiMaiOrderResult.Result.Coupon == null ? "0.00" : getWaiMaiOrderResult.Result.Coupon.Value.ToString("#0.00"),
                    Total = getWaiMaiOrderResult.Result.Total == null ? "0.00" : getWaiMaiOrderResult.Result.Total.Value.ToString("#0.00"),
                    RealSupplierType = getWaiMaiOrderResult.Result.RealSupplierType,
                    DeliveryMethodId = getWaiMaiOrderResult.Result.DeliveryMethodId,
                    IsPaid = getWaiMaiOrderResult.Result.IsPaid ?? false,
                    DishList = dishList.Select(p => new WaiMaiOrderDish
                        {
                            SupplierDishName = p.SupplierDishName,
                            Quantity = p.Quantity,
                            Price = p.Price == null ? 0 : p.Price.Value
                        }).ToList()
                };

            return new WaiMaiOrderResponse
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
        [HttpPost]
        public AddWaiMaiOrderResponse AddWaiMaiOrder(AddWaiMaiOrderRequst requst)
        {
            if (requst == null)
            {
                return new AddWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new AddWaiMaiOrderResult()
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new AddWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new AddWaiMaiOrderResult()
                };
            }

            var dishList = requst.DishList ?? new List<AddWaiMaiOrderDish>();
            var addWaiMaiOrderResult = this.orderServices.AddWaiMaiOrder(new AddWaiMaiOrderParameter
            {
                UserId = requst.UserId,
                DeliveryMethodId = requst.DeliveryMethodId,
                SupplierId = requst.SupplierId,
                DeliveryInstruction = (requst.DeliveryInstruction ?? string.Empty).Trim(),
                InvoiceRequired = requst.InvoiceRequired ?? false,
                InvoiceTitle = (requst.InvoiceTitle ?? string.Empty).Trim(),
                IsTakeInvoice = requst.IsTakeInvoice ?? false,
                OrderNotes = (requst.OrderNotes ?? string.Empty).Trim(),
                Template = (requst.Template ?? string.Empty).Trim(),
                Path = (requst.Path ?? string.Empty).Trim(),
                AreaId = requst.AreaId,
                IpAddress = (requst.IpAddress ?? string.Empty).Trim(),
                DishList = dishList.Select(p => new AddWaiMaiOrderDishModel
                    {
                        SupplierDishId = p.SupplierDishId,
                        Quantity = p.Quantity
                    }).ToList()
            });

            var result = addWaiMaiOrderResult.Result ?? new AddWaiMaiOrderModel();
            return new AddWaiMaiOrderResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = addWaiMaiOrderResult.StatusCode
                },
                Result = new AddWaiMaiOrderResult
                    {
                        OrderId = result.OrderId,
                        CustomerTotal = result.CustomerTotal,
                        SupplierId = result.SupplierId,
                        SupplierName = result.SupplierName ?? string.Empty,
                        SupplierDishCount = result.SupplierDishCount
                    }
            };
        }

        /// <summary>
        /// 确认外卖订单
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// ConfirmWaiMaiOrderResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public ConfirmWaiMaiOrderResponse ConfirmWaiMaiOrder(int id, ConfirmWaiMaiOrderRequst requst)
        {
            if (requst == null)
            {
                return new ConfirmWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new ConfirmWaiMaiOrderResult()
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new ConfirmWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new ConfirmWaiMaiOrderResult()
                };
            }

            var confirmWaiMaiOrderResult = this.orderServices.ConfirmWaiMaiOrder(new ConfirmWaiMaiOrderParameter
                {
                    UserId = requst.UserId,
                    OrderId = id,
                    CustomerAddressId = requst.CustomerAddressId,
                    RealSupplierType = requst.RealSupplierType
                });

            var result = confirmWaiMaiOrderResult.Result ?? new ConfirmWaiMaiOrderModel();
            return new ConfirmWaiMaiOrderResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = confirmWaiMaiOrderResult.StatusCode
                },
                Result = new ConfirmWaiMaiOrderResult
                {
                    OrderId = result.OrderId
                }
            };
        }

        /// <summary>
        /// 支付订单
        /// </summary>
        /// <param name="id">订单Id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// PaymentWaiMaiOrderResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public PaymentWaiMaiOrderResponse PaymentWaiMaiOrder(int id, PaymentWaiMaiOrderRequst requst)
        {
            if (requst == null)
            {
                return new PaymentWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    },
                    Result = new PaymentWaiMaiOrderResult()
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new PaymentWaiMaiOrderResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new PaymentWaiMaiOrderResult()
                };
            }

            var paymentWaiMaiOrderResult = this.orderServices.PaymentWaiMaiOrder(new PaymentWaiMaiOrderParameter
                {
                    UserId = requst.UserId,
                    OrderId = id,
                    AuthCode = (requst.AuthCode ?? string.Empty).Trim()
                });

            var result = paymentWaiMaiOrderResult.Result ?? new PaymentWaiMaiOrderModel();
            return new PaymentWaiMaiOrderResponse
            {
                Message = new ApiMessage
                {
                    StatusCode = paymentWaiMaiOrderResult.StatusCode
                },
                Result = new PaymentWaiMaiOrderResult
                {
                    OrderId = result.OrderId
                }
            };
        }
    }
}
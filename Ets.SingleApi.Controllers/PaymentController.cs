namespace Ets.SingleApi.Controllers
{
    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;
    using System.Web.Http;

    /// <summary>
    /// 类名称：PaymentController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：支付功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 1:18 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PaymentController : SingleApiController
    {
        /// <summary>
        /// 字段paymentServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IPaymentServices paymentServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentController"/> class.
        /// </summary>
        /// <param name="paymentServices">The paymentServices</param>
        /// 创建者：周超
        /// 创建日期：10/28/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentController(
            IPaymentServices paymentServices)
        {
            this.paymentServices = paymentServices;
        }

        /// <summary>
        /// Ums the payment.
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// UmPaymentResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 4:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        [TokenFilter]
        public Response<PaymentResult> UmPayment(UmPaymentRequst requst)
        {
            if (requst == null)
            {
                return new Response<PaymentResult>
                {
                    Result = new PaymentResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new Response<PaymentResult>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = new PaymentResult()
                };
            }

            var umPaymentResult = this.paymentServices.UmPayment(this.Source, new UmPaymentParameter
                                  {
                                      OrderId = requst.OrderId,
                                      Amount = requst.Amount,
                                      PayDate = System.DateTime.Now,
                                      OrderType = requst.OrderType,
                                      ReturnUrl = requst.ReturnUrl,
                                      NotifyUrl = requst.NotifyUrl
                                  });

            return new Response<PaymentResult>
            {
                Result = new PaymentResult
                    {
                        Result = umPaymentResult.StatusCode == (int)StatusCode.Succeed.Ok,
                        PaymentNo = umPaymentResult.Result
                    },
                Message = new ApiMessage
                {
                    StatusCode = umPaymentResult.StatusCode
                }
            };
        }

        /// <summary>
        /// Ums the state of the payment.
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The UmPaymentStateResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 4:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        [TokenFilter]
        public Response<bool> UmPaymentState(UmPaymentStateRequst requst)
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

            if (!this.ValidateUserId(requst.UserId))
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.paymentServices.UmPaymentState(this.Source, new UmPaymentStateParameter
            {
                OrderId = requst.OrderId,
                PayDate = System.DateTime.Now,
                OrderType = requst.OrderType
            });

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        [HttpPost]
        [TokenFilter]
        public Response<string> BaiFuBaoPayment(BaiFuBaoPaymentRequst requst)
        {
            if (requst == null)
            {
                return new Response<string>
                {
                    Result = string.Empty,
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    },
                    Result = string.Empty
                };
            }

            var baiFuBaoPaymentResult = this.paymentServices.BaiFuBaoPayment(this.Source, new BaiFuBaoPaymentParameter
            {
                OrderId = requst.OrderId,
                GoodsName = requst.GoodsName,
                Amount = requst.Amount,
                OrderType = requst.OrderType,
                PageUrl = requst.PageUrl
            });

            return new Response<string>
            {
                Result = baiFuBaoPaymentResult.Result,
                Message = new ApiMessage
                {
                    StatusCode = baiFuBaoPaymentResult.StatusCode
                }
            };
        }
        [HttpPost]
        [TokenFilter]
        public Response<bool> BaiFuBaoPaymentState(BaiFuBaoPaymentStateRequst requst)
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

            if (!this.ValidateUserId(requst.UserId))
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.paymentServices.BaiFuBaoPaymentState(this.Source, new BaiFuBaoPaymentStateParameter
            {
                OrderId = requst.OrderId,
                OrderType = requst.OrderType
            });

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }

        [HttpPost]
        [TokenFilter]
        public Response<bool> WeChatPayMentState(UmPaymentStateRequst requst)
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

            if (!this.ValidateUserId(requst.UserId))
            {
                return new Response<bool>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var result = this.paymentServices.UmPaymentState(this.Source, new UmPaymentStateParameter
            {
                OrderId = requst.OrderId,
                PayDate = System.DateTime.Now,
                OrderType = requst.OrderType
            });

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = result.StatusCode
                },
                Result = result.Result
            };
        }


    }
}
namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Utility;

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
        public UmPaymentResponse UmPayment(UmPaymentRequst requst)
        {
            if (requst == null)
            {
                return new UmPaymentResponse
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
                return new UmPaymentResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var umPaymentResult = this.paymentServices.UmPayment(new UmPaymentParameter
                                  {
                                      OrderId = requst.OrderId,
                                      Amount = requst.Amount,
                                      PayDate = requst.PayDate,
                                      OrderType = requst.OrderType
                                  });

            return new UmPaymentResponse
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
        public UmPaymentStateResponse UmPaymentState(UmPaymentStateRequst requst)
        {
            if (requst == null)
            {
                return new UmPaymentStateResponse
                {
                    Result = new PaymentStateResult(),
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest
                    }
                };
            }

            if (!this.ValidateUserId(requst.UserId))
            {
                return new UmPaymentStateResponse
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.OAuth.AccessDenied
                    }
                };
            }

            var umPaymentStateResult = this.paymentServices.UmPaymentState(new UmPaymentStateParameter
            {
                OrderId = requst.OrderId,
                PayDate = requst.PayDate,
                OrderType = requst.OrderType
            });

            return new UmPaymentStateResponse
            {
                Result = new PaymentStateResult
                {
                    Result = umPaymentStateResult.Result
                },
                Message = new ApiMessage
                {
                    StatusCode = umPaymentStateResult.StatusCode
                }
            };
        }
    }
}
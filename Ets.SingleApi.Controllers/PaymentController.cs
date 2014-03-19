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
        public Response<string> AlipayPayment(AlipayPaymentRequst requst)
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

            var baiFuBaoPaymentResult = this.paymentServices.AlipayPayment(this.Source, new AlipayPaymentParameter
            {
                OrderId = requst.OrderId,
                OrderName = requst.OrderName,
                Amount = requst.Amount,
                OrderType = requst.OrderType,
                CallBackUrl = requst.CallBackUrl,
                MerchantUrl = requst.MerchantUrl
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
        public Response<bool> AlipayPaymentState(AlipayPaymentStateRequst requst)
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

            var result = this.paymentServices.AlipayPaymentState(this.Source, new AlipayPaymentStateParameter
            {
                NotSign = requst.NotSign,
                Sign = requst.Sign,
                OrderId = requst.OrderId,
                Result = requst.Result,
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
        public Response<string> WechatPayment(WechatPaymentRequest requst)
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


            var wechatPaymentResult = this.paymentServices.WechatPayment(this.Source, new WechatPaymentParameter
            {
                Amount = requst.Amount,
                Attach = requst.Attach,
                Body = requst.Body,
                NotifyUrl = requst.NotifyUrl,
                OrderId = requst.OrderId,
                OrderType = requst.OrderType,
                SpbillCreateIp = requst.SpbillCreateIp,
                WechatId = requst.WechatId
            });

            return new Response<string>
            {
                Result = wechatPaymentResult.Result,
                Message = new ApiMessage
                {
                    StatusCode = wechatPaymentResult.StatusCode
                }
            };
        }

        [HttpPost]
        [TokenFilter]
        public Response<bool> WechatPaymentState(WechatPaymentStateRequest requst)
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


            var result = this.paymentServices.WeChatPaymentState(this.Source, new WechatPaymentStateParameter
            {
                OrderId = requst.OrderId,
                OrderType = requst.OrderType,
                sign_type = requst.sign_type,
                service_version = requst.service_version,
                input_charset = requst.input_charset,
                sign = requst.sign,
                sign_key_index = requst.sign_key_index,
                trade_mode = requst.trade_mode,
                trade_state = requst.trade_state,
                pay_info = requst.pay_info,
                partner = requst.partner,
                bank_type = requst.bank_type,
                bank_billno = requst.bank_billno,
                total_fee = requst.total_fee,
                fee_type = requst.fee_type,
                notify_id = requst.notify_id,
                transaction_id = requst.transaction_id,
                out_trade_no = requst.out_trade_no,
                attach = requst.attach,
                time_end = requst.time_end,
                transport_fee = requst.transport_fee,
                product_fee = requst.product_fee,
                discount = requst.discount,
                buyer_alias = requst.buyer_alias,
                OpenId = requst.OpenId,
                AppId = requst.AppId,
                IsSubscribe = requst.IsSubscribe,
                TimeStamp = requst.TimeStamp,
                NonceStr = requst.NonceStr,
                AppSignature = requst.AppSignature,
                SignMethod = requst.SignMethod
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
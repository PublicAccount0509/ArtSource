using System.Collections.Generic;
using Ets.SingleApi.Model.Services;

namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：OrdersController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：订单业务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 9:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrdersController : SingleApiController
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
        /// Initializes a new instance of the <see cref="OrdersController"/> class.
        /// </summary>
        /// <param name="orderServices">The orderServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrdersController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        /// <summary>
        /// 判定指定订单支付状态
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<int> Exist(int id, int orderType, int orderSourceType = 0)
        {
            var getOrderResult = this.orderServices.Exist(this.GetSource(orderType), id, orderType, orderSourceType);
            return new Response<int>
            {
                Message = new ApiMessage
                {
                    StatusCode = getOrderResult.StatusCode
                },
                Result = getOrderResult.Result
            };
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<IOrderDetailModel> GetOrder(int id, int orderType, int orderSourceType = 0)
        {
            var getOrderResult = this.orderServices.GetOrder(this.GetSource(orderType), id, orderType, orderSourceType);
            if (getOrderResult.Result == null)
            {
                return new Response<IOrderDetailModel>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getOrderResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getOrderResult.StatusCode
                    }
                };
            }

            return new Response<IOrderDetailModel>
            {
                Message = new ApiMessage
                {
                    StatusCode = getOrderResult.StatusCode
                },
                Result = getOrderResult.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<string> SaveOrder(string shoppingCartId, int orderType, int orderSourceType = 0)
        {
            var getOrderResult = this.orderServices.SaveOrder(this.GetSource(orderType), shoppingCartId, this.AppKey, this.AppPassword, orderType, orderSourceType);
            if (getOrderResult.Result == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getOrderResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getOrderResult.StatusCode
                    }
                };
            }

            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = getOrderResult.StatusCode
                },
                Result = getOrderResult.Result
            };
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞</param>
        /// <returns>
        /// OrderNumberResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 8:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> OrderNumber(int orderType, int orderSourceType = 0)
        {
            var getOrderNumberResult = this.orderServices.GetOrderNumber(this.GetSource(orderType), this.AppKey, this.AppPassword, orderType, orderSourceType);
            if (getOrderNumberResult.Result == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getOrderNumberResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getOrderNumberResult.StatusCode
                    },
                    Result = string.Empty
                };
            }

            return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getOrderNumberResult.StatusCode
                    },
                    Result = getOrderNumberResult.Result
                };
        }

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="isPaId">The  isPaId indicates whether</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：1/26/2014 10:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> SaveOrderPaId(int orderType, int orderId, bool isPaId, int orderSourceType = 0)
        {
            var saveOrderPaIdResult = this.orderServices.SaveOrderPaId(this.GetSource(orderType), orderType, orderSourceType, orderId, isPaId);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = saveOrderPaIdResult.StatusCode
                },
                Result = saveOrderPaIdResult.Result
            };
        }

        /// <summary>
        /// 当前订单是否可以修改
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// 返回结果，空字串可以修改；否则，不可修改。
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 4:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> GetOrderEditFlag(int id, int orderType, int orderSourceType = 0)
        {
            var getOrderEditFlagResult = this.orderServices.GetOrderEditFlag(this.GetSource(orderType), orderType, orderSourceType, id);
            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = getOrderEditFlagResult.StatusCode
                },
                Result = getOrderEditFlagResult.Result
            };
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// 返回结果，true取消成功；false取消失败。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<bool> CancelOrder(int id, int orderType, int orderSourceType = 0)
        {
            var cancelOrderResult = this.orderServices.CancelOrder(this.GetSource(orderType), orderType, orderSourceType, id);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = cancelOrderResult.StatusCode
                },
                Result = cancelOrderResult.Result
            };
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/21/2014 5:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> ModifyOrderPaymentMethod(string shoppingCartId, int paymentMethodId, string payBank, int orderType, int orderSourceType = 0)
        {
            var saveOrderPaIdResult = this.orderServices.ModifyOrderPaymentMethod(this.GetSource(orderType), shoppingCartId, paymentMethodId, payBank, orderType, orderSourceType);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = saveOrderPaIdResult.StatusCode
                },
                Result = saveOrderPaIdResult.Result
            };
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="paymentMethodId">支付方式Id</param>
        /// <param name="payBank">区分银行</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="orderSourceType">来源</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/20/2014 1:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<bool> ModifyOrderPaymentMethodByOrderId(int orderId, int paymentMethodId, string payBank, int orderType, int orderSourceType = 0)
        {
            var saveOrderPaIdResult = this.orderServices.ModifyOrderPaymentMethodByOrderId(this.GetSource(orderType), orderId, paymentMethodId, payBank, orderType, orderSourceType);
            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = saveOrderPaIdResult.StatusCode
                },
                Result = saveOrderPaIdResult.Result
            };
        }

        /// <summary>
        /// Gets the order is complete is paid by shopping cart identifier.
        /// </summary>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 7:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<OrderShoppingCartStatusResult> GetShoppingCartStatus(string shoppingCartId, int orderType, int orderSourceType = 0)
        {
            var orderShoppingCartStatusResult = this.orderServices.GetOrderShoppingCartStatus(this.GetSource(orderType), shoppingCartId, orderType, orderSourceType);
            return new Response<OrderShoppingCartStatusResult>
            {
                Message = new ApiMessage
                {
                    StatusCode = orderShoppingCartStatusResult.StatusCode
                },
                Result = new OrderShoppingCartStatusResult
                    {
                        IsComplete = orderShoppingCartStatusResult.Result.IsComplete,
                        IsPaid = orderShoppingCartStatusResult.Result.IsPaid,
                        OrderStatusId = orderShoppingCartStatusResult.Result.OrderStatusId
                    }
            };
        }

        /// <summary>
        /// 取得来源信息
        /// </summary>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回来源信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/16/2014 7:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetSource(int orderType)
        {
            var preFix = ((OrderType)orderType).ToString();
            return string.Format("{0}{1}", preFix, this.Source);
        }

        /// <summary>
        /// 创建堂食订单
        /// </summary>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：5/13/2014 4:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<string> SaveTangShiOrder(SaveTangShiOrdersRequst requst)
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

            var getOrderResult = this.orderServices.SaveTempOrder(new SaveTangShiOrdersParameter
            {
                Source = requst.Source,
                Path = requst.Path,
                SupplierID = requst.SupplierId,
                CustomerName = requst.CustomerName,
                CustomerSex = requst.CustomerSex,
                TableNo = requst.TableNo,
                Remark = requst.Remark,
                TempOrderNumber = requst.TempOrderNumber,
                PayMentMethodId = requst.PayMentMethodId,
                SupplierDishList = requst.SupplierDishList ?? new List<SupplierDishItem>()
            }, this.AppKey, this.AppPassword);

            if (getOrderResult.Result == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getOrderResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getOrderResult.StatusCode
                    },
                    Result = string.Empty
                };
            }

            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = getOrderResult.StatusCode
                },
                Result = getOrderResult.Result
            };
        }
    }
}
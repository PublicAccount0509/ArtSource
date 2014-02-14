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
            var getOrderResult = this.orderServices.Exist(this.Source, id, orderType, orderSourceType);
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
            var getOrderResult = this.orderServices.GetOrder(this.Source, id, orderType, orderSourceType);
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
            var getOrderResult = this.orderServices.SaveOrder(this.Source, shoppingCartId, orderType, orderSourceType);
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
            var getOrderNumberResult = this.orderServices.GetOrderNumber(this.Source, orderType, orderSourceType);
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
        public Response<bool> SaveOrderPaId(int orderType, int orderId, bool isPaId, int orderSourceType = 0)
        {

            var saveOrderPaIdResult = this.orderServices.SaveOrderPaId(this.Source, orderType, orderSourceType, orderId, isPaId);

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
        /// 是否可以激活购物车信息
        /// </summary>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderId</param>
        /// <returns></returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 4:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Response<bool> IsActivation(int orderType, int orderSourceType, int orderId)
        {

            var isActivationResult = this.orderServices.IsActivation(this.Source, orderType, orderSourceType, orderId);

            return new Response<bool>
            {
                Message = new ApiMessage
                {
                    StatusCode = isActivationResult.StatusCode
                },
                Result = isActivationResult.Result
            };
        }
    }
}
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
        /// 取得订单详情
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<int> Exist(int id, int orderType)
        {
            var getOrderResult = this.orderServices.Exist(id, orderType);
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
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<IOrderDetailModel> GetOrder(int id, int orderType)
        {
            var getOrderResult = this.orderServices.GetOrder(id, orderType);
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
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public Response<string> SaveOrder(string shoppingCartId, int orderType)
        {
            var getOrderResult = this.orderServices.SaveOrder(shoppingCartId, orderType);
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
        /// <returns>
        /// OrderNumberResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 8:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> OrderNumber(int orderType)
        {
            var getOrderNumberResult = this.orderServices.GetOrderNumber(orderType);
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
    }
}
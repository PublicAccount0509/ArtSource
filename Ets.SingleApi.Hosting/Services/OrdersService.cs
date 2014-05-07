namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：OrdersService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：Orders服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OrdersService : IOrdersService
    {
        /// <summary>
        /// 判定指定订单支付状态
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Exist/{id}?orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<int> Exist(string id, int orderType, int orderSourceType)
        {
            return new Response<int>();
        }

        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetOrder/{id}?orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<IOrderDetailModel> GetOrder(string id, int orderType, int orderSourceType)
        {
            return new Response<IOrderDetailModel>();
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SaveOrder?shoppingCartId={shoppingCartId}&orderType={orderType}&orderSourceType={orderSourceType}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> SaveOrder(string shoppingCartId, int orderType, int orderSourceType)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 8:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/OrderNumber?orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> OrderNumber(int orderType, int orderSourceType)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderId">订单号</param>
        /// <param name="isPaId">支付状态</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：1/26/2014 10:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/SaveOrderPaId?orderType={orderType}&orderId={orderId}&isPaId={isPaId}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SaveOrderPaId(int orderType, int orderId, bool isPaId, int orderSourceType)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 当前订单是否可以修改
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果，空字串可以修改；否则，不可修改。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/13/2014 4:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetOrderEditFlag/{id}?orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> GetOrderEditFlag(string id, int orderType, int orderSourceType)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果，true取消成功；false取消失败。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CancelOrder/{id}?orderType={orderType}&orderSourceType={orderSourceType}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> CancelOrder(string id, int orderType, int orderSourceType)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">银行备注</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/21/2014 5:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/ModifyOrderPaymentMethod?shoppingCartId={shoppingCartId}&paymentMethodId={paymentMethodId}&payBank={payBank}&orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> ModifyOrderPaymentMethod(string shoppingCartId, int paymentMethodId, string payBank, int orderType, int orderSourceType)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 获取购物车状态
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付</param>
        /// <param name="orderSourceType">订单来源：0 默认类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/24/2014 7:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetShoppingCartStatus?shoppingCartId={shoppingCartId}&orderType={orderType}&orderSourceType={orderSourceType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<OrderShoppingCartStatusResult> GetShoppingCartStatus(string shoppingCartId, int orderType, int orderSourceType)
        {
            return new Response<OrderShoppingCartStatusResult>();
        }
    }
}
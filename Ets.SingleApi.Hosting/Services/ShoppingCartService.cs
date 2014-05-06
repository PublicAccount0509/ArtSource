namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：ShoppingCartService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：ShoppingCart服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// 更改购物车状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SaveShoppingCartComplete/{id}?complete={complete}&orderId={orderId}&orderType={orderType}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SaveShoppingCartComplete(string id, bool complete, int orderId, int orderType)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 取得购物车是否完成的状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetShoppingCartComplete/{id}?orderId={orderId}&orderType={orderType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> GetShoppingCartComplete(string id, int orderId, int orderType)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 取得购物车Id
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车Id
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetShoppingCartId?orderId={orderId}&orderType={orderType}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> GetShoppingCartId(int orderId, int orderType)
        {
            return new Response<string>();
        }
    }
}
namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：EtsWapDingTaiShoppingCartService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：EtsWapDingTaiShoppingCartService服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EtsWapDingTaiShoppingCartService : IEtsWapDingTaiShoppingCartService
    {
        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/ShoppingCart/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> ShoppingCart(string id)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">购物车信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/ShoppingCart/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> SaveShoppingCart(string id, EtsWapDingTaiShoppingCartRequst requst)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户的唯一标识</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Create?supplierId={supplierId}&userId={userId}&orderId={orderId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> Create(int supplierId, string userId, int orderId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 关联顾客信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Customer/{id}?userId={userId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> Customer(string id, int userId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存送餐信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Delivery/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> Delivery(string id, EtsWapDingTaiShoppingCartDeliveryRequst requst)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存全部商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Shopping/{id}?saveDeliveryMethodId={saveDeliveryMethodId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> Shopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AddShopping/{id}?saveDeliveryMethodId={saveDeliveryMethodId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> AddShopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/DeleteShopping/{id}?saveDeliveryMethodId={saveDeliveryMethodId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> DeleteShopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存确认订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">The requst.</param>
        /// <param name="isCalculateCoupon">if set to <c>true</c> [is calculate coupon].</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SaveOrderConfirm/{id}?isCalculateCoupon={isCalculateCoupon}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> SaveOrderConfirm(string id, EtsWapDingTaiShoppingCartOrderConfirmRequst requst, bool isCalculateCoupon)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">订单信息</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <param name="isValidateDeliveryTime">是否检测送餐时间</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Order/{id}?isCalculateCoupon={isCalculateCoupon}&isValidateDeliveryTime={isValidateDeliveryTime}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> Order(string id, EtsWapDingTaiShoppingCartOrderRequst requst, bool isCalculateCoupon, bool isValidateDeliveryTime)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }

        /// <summary>
        /// 保存送餐方式
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="deliveryMethodId">送餐方式Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SaveDeliveryMethod/{id}?deliveryMethodId={deliveryMethodId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<EtsWapDingTaiShoppingCartModel> SaveDeliveryMethod(string id, int deliveryMethodId)
        {
            return new Response<EtsWapDingTaiShoppingCartModel>();
        }
    }
}
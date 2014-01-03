namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：HuangTaiJiShoppingCartService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：黄太极购物车API
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class HuangTaiJiShoppingCartService : IHuangTaiJiShoppingCartService
    {
        //[WebGet(UriTemplate = "/SupplierDish/{id}?supplierDishId={supplierDishId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        //public Response<HuangTaiJiSupplierDishDetail> SupplierDish(string id, int supplierDishId)
        //{
        //    return new Response<HuangTaiJiSupplierDishDetail>();
        //}

        [WebGet(UriTemplate = "/ShoppingCart/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<HuangTaiJiShoppingCartModel> ShoppingCart(string id)
        {
            return new Response<HuangTaiJiShoppingCartModel>();
        }
    }
}
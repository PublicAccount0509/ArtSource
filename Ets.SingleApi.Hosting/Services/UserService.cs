namespace Ets.SingleApi.Hosting.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：UserService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：用户功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/14/2013 7:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserService : IUserService
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// The ExistResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 5:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Exist", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<ExistResult> Exist(ExistRequst requst)
        {
            return new ListResponse<ExistResult>();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetUser/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<Customer> GetUser(string id)
        {
            return new Response<Customer>();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="type">账号类型 1 邮箱  2 电话</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/GetUserSimple?account={account}&type={type}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<CustomerSimple> GetUserSimple(string account, int type)
        {
            return new Response<CustomerSimple>();
        }

        /// <summary>
        /// 取得用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/CustomerAddress/{id}?customerAddressId={customerAddressId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<CustomerAddress> GetCustomerAddress(string id, int customerAddressId)
        {
            return new Response<CustomerAddress>();
        }

        /// <summary>
        /// 取得用户地址列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="cityId">The cityId</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
       [WebGet(UriTemplate = "/CustomerAddressList/{id}?cityId={cityId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<CustomerAddress> CustomerAddressList(string id, int? cityId)
        {
            return new ListResponse<CustomerAddress>();
        }

        /// <summary>
        /// 保存用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="requst">地址信息</param>
        /// <returns>
        /// The CustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:41
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/CustomerAddress/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SaveCustomerAddress(string id, CustomerAddressRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 删除用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressIdList">用户地址Id</param>
        /// <returns>
        /// The DeleteCustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/DeleteCustomerAddress/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> DeleteCustomerAddress(string id, List<int> customerAddressIdList)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 设置默认用户地址
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// The SetDefaultCustomerAddressResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SetDefaultCustomerAddress/{id}?customerAddressId={customerAddressId}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SetDefaultCustomerAddress(string id, int customerAddressId)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/Register", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<RegisterUserResult> Register(RegisterUserRequst requst)
        {
            return new Response<RegisterUserResult>();
        }

        /// <summary>
        /// 获取用户收藏的餐厅列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns>
        /// The FollowerSupplierListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/FollowerSupplierList/{id}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<FollowerSupplier> FollowerSupplierList(string id)
        {
            return new ListResponse<FollowerSupplier>();
        }

        /// <summary>
        /// 判定是否已经收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierId">The supplierId</param>
        /// <returns>
        /// The IsFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/IsFollowerSupplier/{id}?supplierId={supplierId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> IsFollowerSupplier(string id, int supplierId)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// The AddFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AddFollowerSupplier/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> AddFollowerSupplier(string id, List<int> supplierIdList)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 取消收藏餐厅
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// The DeleteFollowerSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/DeleteFollowerSupplier/{id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> DeleteFollowerSupplier(string id, List<int> supplierIdList)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 用户订单列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="paidStatus">支付状态</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// UserOrderListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 14:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/UserOrderList/{id}?orderType={orderType}&orderStatus={orderStatus}&paidStatus={paidStatus}&pageSize={pageSize}&pageIndex={pageIndex}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<UserOrder> UserOrderList(string id, int orderType, string orderStatus, string paidStatus, int pageSize, string pageIndex)
        {
            return new ListResponse<UserOrder>();
        }
    }
}
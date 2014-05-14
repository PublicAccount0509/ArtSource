namespace Ets.SingleApi.Hosting.Contracts
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IUserService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：用户功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/14/2013 6:22 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IUserService
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
        [OperationContract]
        [Description("方法功能：判断用户是否是否存在；参数说明：Type（1 邮箱  2 电话）")]
        ListResponse<ExistResult> Exist(ExistRequst requst);

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
        [OperationContract]
        [Description("方法功能：获取用户信息")]
        Response<Customer> GetUser(string id);

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
        [OperationContract]
        [Description("方法功能：获取简单的用户信息；参数说明：type（1 邮箱  2 电话）")]
        Response<CustomerSimple> GetUserSimple(string account, int type);

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
        [OperationContract]
        [Description("方法功能：取得用户地址")]
        Response<CustomerAddress> GetCustomerAddress(string id, int customerAddressId);

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
        [OperationContract]
        [Description("方法功能：取得用户地址列表")]
        ListResponse<CustomerAddress> CustomerAddressList(string id, int cityId);

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
        [OperationContract]
        [Description("方法功能：保存用户地址")]
        Response<bool> SaveCustomerAddress(string id, CustomerAddressRequst requst);

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
        [OperationContract]
        [Description("方法功能：保存用户地址")]
        Response<string> InsertCustomerAddress(string id, CustomerAddressRequst requst);

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
        [OperationContract]
        [Description("方法功能：删除用户地址")]
        Response<bool> DeleteCustomerAddress(string id, List<int> customerAddressIdList);

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
        [OperationContract]
        [Description("方法功能：设置默认用户地址")]
        Response<bool> SetDefaultCustomerAddress(string id, int customerAddressId);

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
        [OperationContract]
        [Description("方法功能：注册用户")]
        Response<RegisterUserResult> Register(RegisterUserRequst requst);

        /// <summary>
        /// 第三方登录注册用户
        /// </summary>
        /// <param name="requst">The requstDefault documentation</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/17/2014 5:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：第三方登录注册用户")]
        Response<RegisterUserResult> RegisterOAuth(RegisterUserOAuthRequst requst);

        /// <summary>
        /// 获取用户收藏的餐厅列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
        /// <returns>
        /// The FollowerSupplierListResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取用户收藏的餐厅列表")]
        ListResponse<FollowerSupplier> FollowerSupplierList(string id, int supplierGroupId);

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
        [OperationContract]
        [Description("方法功能：判定是否已经收藏餐厅")]
        Response<bool> IsFollowerSupplier(string id, int supplierId);

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
        [OperationContract]
        [Description("方法功能：收藏餐厅")]
        Response<bool> AddFollowerSupplier(string id, List<int> supplierIdList);

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
        [OperationContract]
        [Description("方法功能：取消收藏餐厅")]
        Response<bool> DeleteFollowerSupplier(string id, List<int> supplierIdList);

        /// <summary>
        /// 用户订单列表
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="supplierGroupId">The supplierGroupId</param>
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
        [OperationContract]
        [Description("方法功能：用户订单列表；参数说明：orderType（-1 所有订单  0 外卖订单  1 堂食订单  2 订台订单）、pageSize（默认值为10）")]
        ListResponse<UserOrder> UserOrderList(string id, int orderType, int supplierId, int supplierGroupId, string orderStatus, string paidStatus, int pageSize, string pageIndex);
    }
}
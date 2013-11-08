namespace Ets.SingleApi.Controllers.IServices
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IUsersServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：用户信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:16
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IUsersServices
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回用户信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<CustomerModel> GetUser(int userId);

        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<CustomerAddressModel> GetCustomerAddress(int userId, int customerAddressId);

        /// <summary>
        /// 管理用户地址
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveCustomerAddress(int userId, CustomerAddressParameter parameter);

        /// <summary>
        /// 删除用户地址
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressIdList">用户地址Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteCustomerAddress(int userId, List<int> customerAddressIdList);

        /// <summary>
        /// 设置默认用户地址
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressId">用户地址Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SetDefaultCustomerAddress(int userId, int customerAddressId);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<RegisterUserModel> Register(RegisterUserParameter parameter);

        /// <summary>
        /// 获取收藏餐厅列表
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回收藏餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<FollowerSupplierModel> GetFollowerSupplierList(int userId);

        /// <summary>
        /// 判定是否已经收藏餐厅
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <param name="supplierId">The supplierId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> IsFollowerSupplier(int userId, int supplierId);

        /// <summary>
        /// 收藏餐厅
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AddFollowerSupplier(int userId, List<int> supplierIdList);

        /// <summary>
        /// 取消收藏餐厅
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteFollowerSupplier(int userId, List<int> supplierIdList);

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="paidStatus">支付状态</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="pageSize">每页最大数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// 获取用户订单
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 13:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<UserOrderModel> GetUserOrderList(int userId, int? orderStatus, int? paidStatus, OrderType orderType, int pageSize, int? pageIndex);

        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <param name="parameterList">The parameterList</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 4:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<ExistModel> Exist(List<ExistParameter> parameterList);
    }
}
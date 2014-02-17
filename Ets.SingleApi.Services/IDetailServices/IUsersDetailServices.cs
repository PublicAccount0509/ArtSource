namespace Ets.SingleApi.Services.IDetailServices
{
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IUsersDetailServices
    /// 命名空间：Ets.SingleApi.Services.IDetailServices
    /// 接口功能：用户功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IUsersDetailServices
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<RegisterUserModel> Register(RegisterUserParameter parameter);

        /// <summary>
        /// 第三方登录注册用户
        /// </summary>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// DetailServicesResult{RegisterUserModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/17/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<RegisterUserModel> RegisterOAuth(RegisterUserOAuthParameter parameter);
    }
}
﻿namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IFilterServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：针对Filter提供一些功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/29/2013 5:33 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IFilterServices
    {
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="accessToken">The accessToken</param>
        /// <returns>
        /// ServicesResult{TokenModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<TokenModel> GetToken(string accessToken);

        /// <summary>
        /// 验证客户端
        /// </summary>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> ValidateApp(string appKey, string appPassword);
    }
}
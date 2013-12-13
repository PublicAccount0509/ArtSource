namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：Account
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：取得用户信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 12:12 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IAccount
    {
        /// <summary>
        /// 账号类型
        /// </summary>
        /// <value>
        /// 账号类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        AccountType AccountType { get; }

        /// <summary>
        /// 取得用户信息
        /// </summary>
        /// <param name="account">The account</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        AccountData GetCustomer(string account);
    }
}
namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：IExists
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：验证是否存在
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/31/2013 12:12 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IExists
    {
        /// <summary>
        /// 验证存在的类型
        /// </summary>
        /// <value>
        /// 验证存在的类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ExistsType ExistsType { get; }

        /// <summary>
        /// 验证是否存在
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
        ExistsData Exist(string account);
    }
}
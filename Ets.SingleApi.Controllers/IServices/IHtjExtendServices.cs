namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IHtjExtendServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：黄太吉扩展信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:16
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHtjExtendServices
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HtjUserModel> Register(string source, HtjRegisterUserParameter parameter);

        /// <summary>
        /// 用户关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="weChatId">The weChatId</param>
        /// <param name="sourceCd">The sourceCd</param>
        /// <param name="appKey">The appKey</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 4:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HtjUserExtendModel> GetUser(string source, string weChatId, string sourceCd, string appKey);
    }
}
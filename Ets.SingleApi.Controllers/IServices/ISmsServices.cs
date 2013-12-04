namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ISmsServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：短信服务接口
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 22:09
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISmsServices
    {
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SendAuthCodeModel> SendAuthCode(string source, SendAuthCodeParameter parameter);
    }
}
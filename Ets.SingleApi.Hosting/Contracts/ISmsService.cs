namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ISmsService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Sms服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface ISmsService
    {
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="requst">发送信息</param>
        /// <returns>
        /// 返回发送结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 21:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：发送短信验证码")]
        Response<SendAuthCodeModel> SendAuthCode(SendAuthCodeRequst requst);
    }
}
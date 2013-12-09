namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IAuthenService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Authen服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IAuthenService
    {
        /// <summary>
        /// 用户账户或邮箱登陆方法
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("用户账户或邮箱登陆方法")]
        Response<LoginResult> Login(LoginRequst requst);
    }
}
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
        [Description("方法功能：用户账户或邮箱登陆方法")]
        Response<LoginResult> Login(LoginRequst requst);

        /// <summary>
        /// 手机验证登陆方法
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
        [Description("方法功能：手机验证登陆方法")]
        Response<AuthLoginResult> AuthLogin(AuthLoginRequst requst);

        /// <summary>
        /// 第三方登录
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 11:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：第三方登录")]
        Response<OAuthLoginResult> OAuthLogin(OAuthLoginRequst requst);

        /// <summary>
        /// 仅通过手机号登录（自动登录）
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：4/30/2014 4:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：仅通过手机号登录（自动登录）")]
        Response<TelephoneNumLoginResult> TelephoneNumLogin(TelephoneNumLoginRequst requst);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：修改密码")]
        Response<bool> Password(string id, PasswordRequst requst);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：设置密码")]
        Response<bool> SetPassword(SetPasswordRequst requst);

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：找回密码")]
        Response<bool> FindPassword(FindPasswordRequst requst);

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="requst">请求参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：验证验证码")]
        Response<bool> AuthCode(AuthCodeRequst requst);
    }
}
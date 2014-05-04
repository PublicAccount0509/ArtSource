namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IAuthenServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：权限信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 21:56
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IAuthenServices
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<LoginModel> Login(string source, LoginParameter parameter);

        /// <summary>
        /// 手机验证登陆
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/24/2013 4:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<AuthLoginModel> AuthLogin(string source, AuthLoginParameter parameter);

        /// <summary>
        /// Os the authentication login.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-18 16:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<AuthLoginModel> OAuthLogin(string source, OAuthLoginParameter parameter);

        /// <summary>
        /// 仅通过手机号登录（自动登录）
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：4/30/2014 4:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<AuthLoginModel> TelphoneNumLogin(string source, TelephoneNumLoginParameter parameter);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">The userId</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回修改密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> Password(string source, int userId, PasswordParameter parameter);

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回设置密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SetPassword(string source, SetPasswordParameter parameter);

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回找回密码结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> FindPassword(string source, FindPasswordParameter parameter);

        /// <summary>
        /// 验证用户输入的验证码
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回验证结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/24/2013 4:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AuthCode(string source, AuthCodeParameter parameter);
    }
}
namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：ILogin
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：登陆
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 9:56
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ILogin
    {
        /// <summary>
        /// 登陆方式
        /// </summary>
        /// <value>
        /// 返回登陆方式
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        LoginWay LoginWay { get; }

        /// <summary>
        /// 登录方法
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password</param>
        /// <returns>
        /// 返回登陆结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        LoginData Login(string source, string userName, string password);
    }
}
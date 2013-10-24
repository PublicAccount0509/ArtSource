namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AuthLoginResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：登陆返回结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthLoginResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of AuthLoginResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuthLoginResult Result { get; set; }
    }
}
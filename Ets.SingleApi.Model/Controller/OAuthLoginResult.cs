namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AuthLoginResult
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：登陆返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OAuthLoginResult
    {
        /// <summary>
        /// Gets or sets the AccessToken of Login
        /// </summary>
        /// <value>
        /// The AccessToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the RefreshToken of AuthLoginResult
        /// </summary>
        /// <value>
        /// The RefreshToken
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the UserId of AuthLoginResult
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 0:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }
    }
}
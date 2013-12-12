namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：UserTokenModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：用户Token信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/12/2013 6:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserTokenModel
    {
        /// <summary>
        /// Gets or sets the AccessToken of UserTokenModel
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
        /// Gets or sets the RefreshToken of UserTokenModel
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
    }
}

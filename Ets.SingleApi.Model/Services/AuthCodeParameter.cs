namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：AuthCodeParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：验证验证码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthCodeParameter
    {
        /// <summary>
        /// Gets or sets the Telephone of AuthCodeParameter
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the AuthCode of AuthCodeParameter
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AuthCode { get; set; }
    }
}
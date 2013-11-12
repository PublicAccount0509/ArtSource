namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AuthCodeRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：验证验证码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthCodeRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the Telephone of AuthCodeRequst
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the AuthCode of AuthCodeRequst
        /// </summary>
        /// <value>
        /// The AuthCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AuthCode { get; set; }
    }
}
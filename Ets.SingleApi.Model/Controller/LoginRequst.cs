namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：LoginRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：登陆参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class LoginRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the Email of LoginRequst
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of LoginRequst
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
        /// Gets or sets the Password of LoginRequst
        /// </summary>
        /// <value>
        /// The Password
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the AuthCode of LoginRequst
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
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：RegisterUserRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：注册用户参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:20
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class RegisterUserRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-21 17:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the Email of RegisterUserRequst
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
        /// Gets or sets the Telephone of RegisterUserRequst
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
        /// Gets or sets the Password of RegisterUserRequst
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
        /// Gets or sets the AuthCode of RegisterUserRequst
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

        /// <summary>
        /// Gets or sets the SourceType of RegisterUserRequst
        /// </summary>
        /// <value>
        /// The AppKey
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the Template of RegisterUserRequst
        /// </summary>
        /// <value>
        /// The Template
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Template { get; set; }
    }
}
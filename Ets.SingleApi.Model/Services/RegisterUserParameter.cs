namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：RegisterUserModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：注册用户实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 10:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class RegisterUserParameter
    {
        /// <summary>
        /// Gets or sets the SourceType of RegisterUserRequst
        /// </summary>
        /// <value>
        /// The SourceType
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the Email of RegisterUserModel
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of RegisterUserModel
        /// </summary>
        /// <value>
        /// The Phone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Password of RegisterUserModel
        /// </summary>
        /// <value>
        /// The Password
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the AuthCode of RegisterUserModel
        /// </summary>
        /// <value>
        /// The AuthCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AuthCode { get; set; }

        /// <summary>
        /// Gets or sets the AppKey of RegisterUserParameter
        /// </summary>
        /// <value>
        /// The AppKey
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/24/2013 7:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppKey { get; set; }
    }
}
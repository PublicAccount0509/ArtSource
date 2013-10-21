namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：RegisterUserResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：注册用户API返回值
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 16:22
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class RegisterUserResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of RegisterUserResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public RegisterUserResult Result { get; set; }
    }
}

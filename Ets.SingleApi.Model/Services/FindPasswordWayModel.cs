namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：PasswordWay
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：找回密码的途径
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 10:33
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FindPasswordWayModel
    {
        /// <summary>
        /// Gets or sets the AccountNumber of PasswordWay
        /// </summary>
        /// <value>
        /// The AccountNumber
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PasswordType AccountType { get; set; }
    }
}

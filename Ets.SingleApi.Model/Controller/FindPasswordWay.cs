namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：PasswordWay
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：找回密码的途径
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 10:33
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FindPasswordWay
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
        /// 创建日期：2013/10/19 10:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int AccountType { get; set; }
    }
}

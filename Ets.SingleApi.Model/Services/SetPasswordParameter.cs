namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：Password
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：修改密码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SetPasswordParameter : ParameterBase
    {
        /// <summary>
        /// Gets or sets the UserName of FindPasswordRequst
        /// </summary>
        /// <value>
        /// The UserName
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the AuthCode of SetPasswordParameter
        /// </summary>
        /// <value>
        /// The AuthCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AuthCode { get; set; }

        /// <summary>
        /// Gets or sets the NewPasswrod of SetPasswordParameter
        /// </summary>
        /// <value>
        /// The NewPasswrod
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 9:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string NewPasswrod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsSendSms
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsSendSms { get; set; }
    }
}
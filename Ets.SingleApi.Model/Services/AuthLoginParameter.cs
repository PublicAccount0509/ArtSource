namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：AuthLoginParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：登陆请求参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:52
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthLoginParameter
    {
        /// <summary>
        /// Gets or sets the Telephone of AuthLoginParameter
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
        /// Gets or sets the AuthCode of AuthLoginParameter
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
        /// Gets or sets the AutorizationCode of AuthLoginParameter
        /// </summary>
        /// <value>
        /// The AutorizationCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 11:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AutorizationCode { get; set; }
    }
}
namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：LoginData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：登陆返回数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class LoginData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginData"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public LoginData()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of LoginData
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the LoginId of LoginData
        /// </summary>
        /// <value>
        /// The LoginId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 10:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int LoginId { get; set; }
    }
}
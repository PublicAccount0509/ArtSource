namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：AccountData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：验证存在返回数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AccountData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountData"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AccountData()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }

        /// <summary>
        /// Gets or sets the StatusCode of SendPasswordData
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
        /// Gets or sets the UserId of CustomerSimpleModel
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of CustomerSimpleModel
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Email of CustomerSimpleModel
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }
    }
}
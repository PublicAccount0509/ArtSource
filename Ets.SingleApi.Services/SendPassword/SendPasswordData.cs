namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：SendPasswordData
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：登陆返回数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 10:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SendPasswordData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendPasswordData"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SendPasswordData()
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
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 11:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Result { get; set; }
    }
}
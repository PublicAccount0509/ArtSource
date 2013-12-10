namespace Ets.SingleApi.Model.Controller
{
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ApiMessage
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：状态码和状态信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ApiMessage
    {
        /// <summary>
        /// Gets or sets the StatusCode of ApiMessage
        /// </summary>
        /// <value>
        /// The StatusCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Message of ApiMessage
        /// </summary>
        /// <value>
        /// The Message
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Message
        {
            get
            {
                return StatusUtility.GetInstance().GetMessage(this.StatusCode.ToString());
            }
            set { }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ApiMessage()
        {
            this.StatusCode = (int)Utility.StatusCode.Succeed.Ok;
        }
    }
}
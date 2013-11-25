namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：ApiResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：API返回值基类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:22
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the Message of ApiResponse
        /// </summary>
        /// <value>
        /// The Message
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ApiMessage Message { get; set; }

        /// <summary>
        /// Gets or sets the Cache of ApiResponse
        /// </summary>
        /// <value>
        /// The Cache
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ApiCache Cache { get; set; }

        /// <summary>
        /// Gets or sets the ResultTotalCount of ApiResponse
        /// </summary>
        /// <value>
        /// The ResultTotalCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/8/2013 12:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ResultTotalCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 7:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ApiResponse()
        {
            this.Message = new ApiMessage();
            this.Cache = new ApiCache();
        }
    }
}
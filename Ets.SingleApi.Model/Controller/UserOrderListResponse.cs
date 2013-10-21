namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：UserOrderListResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:43
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserOrderListResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of UserOrderListResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<UserOrder> Result { get; set; }
    }
}
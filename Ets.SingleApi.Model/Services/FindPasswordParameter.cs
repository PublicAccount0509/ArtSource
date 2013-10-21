namespace Ets.SingleApi.Model.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：FindPasswordParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：修改密码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FindPasswordParameter
    {
        /// <summary>
        /// Gets or sets the WayList of FindPasswordParameter
        /// </summary>
        /// <value>
        /// The WayList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<FindPasswordWayModel> WayList { get; set; }
    }
}
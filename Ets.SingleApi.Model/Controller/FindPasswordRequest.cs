namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：FindPasswordRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：修改密码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FindPasswordRequst : ApiRequst
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
        /// Gets or sets the WayList of FindPasswordRequst
        /// </summary>
        /// <value>
        /// The WayList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<FindPasswordWay> WayList { get; set; }
    }
}
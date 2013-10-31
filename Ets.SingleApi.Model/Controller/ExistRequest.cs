namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：ExistRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：用户存在参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:30
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ExistRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the ExistList of ExistRequst
        /// </summary>
        /// <value>
        /// The ExistList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/31/2013 1:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<Exist> ExistList { get; set; }
    }
}
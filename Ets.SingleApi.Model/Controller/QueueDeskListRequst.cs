using System;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：QueueDeskListRequst
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法QueueDeskList传入的参数
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class QueueDeskListRequst : ApiRequst
    {
        /// <summary>
        /// 排队日期
        /// </summary>
        /// <value>
        /// 排队日期
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime QueueDate { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>
        /// 用户Id
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }
    }
}
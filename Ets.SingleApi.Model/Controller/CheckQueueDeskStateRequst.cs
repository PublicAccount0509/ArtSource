﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：CheckQueueDeskStateRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：检测排队信息参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/12/2013 10:06 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CheckQueueDeskStateRequst : ApiRequst
    {
        /// <summary>
        /// 台位类型信息Id
        /// </summary>
        /// <value>
        /// 台位类型信息Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeskTypeId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>
        /// 用户Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }
    }
}
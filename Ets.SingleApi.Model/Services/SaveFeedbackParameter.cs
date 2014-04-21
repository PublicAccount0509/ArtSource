namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：SaveFeedbackParameter
    /// 命名空间：Ets.WapNew.Model.Services
    /// 类功能：保存意见反馈
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/11/2014 10:53 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveFeedbackParameter
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// 用户IP地址
        /// </summary>
        /// <value>
        /// The IPAddress
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string IPAddress { get; set; }

        /// <summary>
        /// 反馈内容
        /// </summary>
        /// <value>
        /// The Content
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Content { get; set; }

        /// <summary>
        /// 邮箱或者手机号
        /// </summary>
        /// <value>
        /// The EmailOrPhone
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string EmailOrPhone { get; set; }

        /// <summary>
        /// Gets or sets the Source of SaveFeedbackPatameter
        /// </summary>
        /// <value>
        /// The Source
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the Path of SaveFeedbackPatameter
        /// </summary>
        /// <value>
        /// The Path
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/11/2014 10:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Path { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value>
        /// The CreateDate
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/21/2014 10:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime CreateDate { get; set; }
    }
}
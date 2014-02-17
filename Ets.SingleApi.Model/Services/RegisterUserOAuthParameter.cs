﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：RegisterUserModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：第三方登录注册用户实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 10:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class RegisterUserOAuthParameter
    {
        /// <summary>
        /// Gets or sets the SourceType of RegisterUserRequst
        /// </summary>
        /// <value>
        /// The SourceType
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SourceType { get; set; }

        /// <summary>
        /// Gets or sets the Template of RegisterUserRequst
        /// </summary>
        /// <value>
        /// The Template
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets the AppKey of RegisterUserParameter
        /// </summary>
        /// <value>
        /// The AppKey
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/24/2013 7:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppKey { get; set; }

        /// <summary>
        /// Gets or sets the Email of RegisterUserModel
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string KeyName { get; set; }

        /// <summary>
        /// 1 QQ,2 新浪微博,3 人人
        /// </summary>
        /// <value>
        /// 1 QQ,2 新浪微博,3 人人
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int JointLoginType { get; set; }

    }
}
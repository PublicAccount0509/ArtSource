﻿namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    /// <summary>
    /// 类名称：SingleApiController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：SingleApiController
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 9:38 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SingleApiController : ApiController
    {
        /// <summary>
        /// 当前登陆用户Id
        /// </summary>
        /// <value>
        /// 当前登陆用户Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/25/2013 9:42 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the AutorizationCode of SingleApiController
        /// </summary>
        /// <value>
        /// The AutorizationCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AutorizationCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleApiController"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SingleApiController()
        {
            this.AutorizationCode = "716b590aa219495db5fb2c94d0aefaa7";
        }
    }
}
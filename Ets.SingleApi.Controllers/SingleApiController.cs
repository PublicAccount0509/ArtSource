﻿namespace Ets.SingleApi.Controllers
{
    using System.Web.Http;

    using Ets.SingleApi.Controllers.Filters;
    using Ets.SingleApi.Model.Controller;

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
    [AppFilter]
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
        /// Gets or sets the AppKey of SingleApiController
        /// </summary>
        /// <value>
        /// The AppKey
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppKey { get; set; }

        /// <summary>
        /// 验证UserId的有效性
        /// </summary>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected bool ValidateUserId(int userId)
        {
            return !ControllersCommon.ApplicationValidationEnabled || this.UserId == userId;
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public TestApiResponse Test()
        {
            return new TestApiResponse
                {
                    Result = "Hello World!"
                };
        }
    }
}
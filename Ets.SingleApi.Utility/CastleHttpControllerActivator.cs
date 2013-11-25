namespace Ets.SingleApi.Utility
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using Castle.MicroKernel;

    /// <summary>
    /// 类名称：CastleHttpControllerActivator
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：创建一个HttpControllerActivator为了适应Castle
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 21:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CastleHttpControllerActivator : IHttpControllerActivator
    {
        /// <summary>
        /// 变量kernel
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 1:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleHttpControllerActivator"/> class.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 1:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CastleHttpControllerActivator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// 创建一个 <see cref="T:System.Web.Http.Controllers.IHttpController" /> 对象。
        /// </summary>
        /// <param name="request">消息请求。</param>
        /// <param name="controllerDescriptor">HTTP 控制器描述符。</param>
        /// <param name="controllerType">控制器的类型。</param>
        /// <returns>
        ///   <see cref="T:System.Web.Http.Controllers.IHttpController" /> 对象。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/23/2013 9:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// <exception cref="System.Web.Http.HttpResponseException"></exception>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == null)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("The controller for path '{0}' could not be found.", request.RequestUri))
                    };
                throw new HttpResponseException(httpResponseMessage);
            }

            return (IHttpController)kernel.Resolve(controllerType);
        }
    }
}
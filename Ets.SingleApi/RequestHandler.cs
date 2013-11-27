namespace Ets.SingleApi
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// 类名称：RequestHandler
    /// 命名空间：Ets.SingleApi
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/26/2013 8:59 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class RequestHandler : DelegatingHandler
    {
        /// <summary>
        /// 以异步操作发送 HTTP 请求到内部管理器以发送到服务器。
        /// </summary>
        /// <param name="request">要发送到服务器的 HTTP 请求消息。</param>
        /// <param name="cancellationToken">取消操作的取消标记。</param>
        /// <returns>
        /// 返回 <see cref="T:System.Threading.Tasks.Task`1" />。 表示异步操作的任务对象。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/26/2013 8:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}
namespace Ets.SingleApi.Controllers
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
    }
}
using System.Configuration;
using System.Net;
using System.Text;
using Ets.SingleApi.Model.ExternalServices;

namespace Ets.SingleApi.ExternalServices
{
    /// <summary>
    /// 类名称：ExternalServicesCommon
    /// 命名空间：Ets.SingleApi.ExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 5:23 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ExternalServicesCommon
    {
        /// <summary>
        /// Creates the single API web client.
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// WebClient
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/9/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static WebClient CreateSingleApiWebClient(SingleApiExternalServiceAuthenParameter parameter)
        {
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            if (parameter == null)
            {
                return client;
            }

            client.Headers["AppKey"] = parameter.AppKey;
            client.Headers["AppPassword"] = parameter.AppPassword;
            client.Headers["Source"] = parameter.Source;
            return client;
        }

        /// <summary>
        /// SingleApi服务地址
        /// </summary>
        /// <value>
        /// SingleApi服务地址
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 5:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string SingleApiServer
        {
            get
            {
                return (ConfigurationManager.AppSettings["SingleApiServer"] ?? string.Empty).Trim('/', '\\');
            }
        }
    }
}

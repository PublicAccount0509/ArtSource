using Ets.SingleApi.Model.ExternalServices;
using Ets.SingleApi.Services.IExternalServices;

namespace Ets.SingleApi.ExternalServices
{
    /// <summary>
    /// 类名称：SingleApiOrdersExternalService
    /// 命名空间：Ets.SingleApi.ExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 5:02 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SingleApiOrdersExternalService : ISingleApiOrdersExternalService
    {
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="urlParameter">Url参数</param>
        /// <param name="data">请求数据</param>
        /// <param name="authenParameter">权限参数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：12/6/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ExternalServiceResult OrderNumber(IExternalUrlParameter urlParameter, string data, SingleApiExternalServiceAuthenParameter authenParameter)
        {
            var parameter = urlParameter as OrderNumberExternalUrlParameter;
            if (parameter == null)
            {
                return new ExternalServiceResult();
            }

            using (var client = ExternalServicesCommon.CreateSingleApiWebClient(authenParameter))
            {
                var url = string.Format("Orders/OrderNumber?orderType={0}", parameter.OrderType);
                var addrress = string.Format("{0}/{1}", ExternalServicesCommon.SingleApiServer, url.Trim('/', '\\'));
                var result = client.DownloadString(addrress);
                return new ExternalServiceResult
                {
                    Result = result
                };
            }
        }
    }
}

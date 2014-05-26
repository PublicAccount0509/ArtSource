using System.Net;
using System.Text;

namespace Ets.SingleApi.ExternalServices
{
    using Ets.SingleApi.Model.ExternalServices;
    using Ets.SingleApi.Services.IExternalServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SynchronousOrderExternalServices
    /// 命名空间：Ets.SingleApi.ExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：5/22/2014 4:44 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SynchronousOrderExternalServices : ISynchronousOrderExternalServices
    {
        /// <summary>
        /// 同步金百万外卖订单
        /// </summary>
        /// <param name="deliveryRequest">The deliveryRequestDefault documentation</param>
        /// <param name="authenParameter"></param>
        /// <returns>
        /// SynchronousOrderExternalServiceResult
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 4:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SynchronousOrderExternalServiceResult SynchronousWaiMaiOrderToJinBaiWan(DeliveryRequest deliveryRequest, SingleApiExternalServiceAuthenParameter authenParameter)
        {
            using (var client = ExternalServicesCommon.CreateSingleApiWebClient(authenParameter))
            {
                var url = string.Format("CreateDelivery?json={0}", deliveryRequest.Serialize());
                var addrress = string.Format("{0}/{1}", ExternalServicesCommon.OpenApiServer, url.Trim('/', '\\'));
                var result = client.UploadString(addrress, string.Empty);
                return new SynchronousOrderExternalServiceResult
                {
                    Result = result
                };
            }
        }

        /// <summary>
        /// 同步金百万外卖订单支付状态
        /// </summary>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="isPaid">The  isPaid indicates whether</param>
        /// <returns>
        /// SynchronousOrderExternalServiceResult
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 4:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SynchronousOrderExternalServiceResult SynchronousWaiMaiOrderPaymentStatusToJinBaiWan(int orderId, bool isPaid)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var url = string.Format("edit/{0}/IsPaid?ispaid={1}", orderId, isPaid ? "1" : "0");
                var addrress = string.Format("{0}/{1}", ExternalServicesCommon.OpenApiServer, url.Trim('/', '\\'));
                var result = client.UploadString(addrress, "PUT", string.Empty);

                return new SynchronousOrderExternalServiceResult
                {
                    Result = result
                };
            }
        }
    }
}

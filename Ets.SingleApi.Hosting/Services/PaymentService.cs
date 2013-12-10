namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：PaymentService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：Payment服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PaymentService : IPaymentService
    {
        /// <summary>
        /// 联动优势支付
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 4:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/UmPayment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<PaymentResult> UmPayment(UmPaymentRequst requst)
        {
            return new Response<PaymentResult>();
        }

        /// <summary>
        /// 查询联动优势支付状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 4:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/UmPaymentState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> UmPaymentState(UmPaymentStateRequst requst)
        {
            return new Response<bool>();
        }
    }
}
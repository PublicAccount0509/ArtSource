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
        /// 返回交易号
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

        /// <summary>
        /// 百付宝支付
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/BaiFuBaoPayment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> BaiFuBaoPayment(BaiFuBaoPaymentRequst requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 查询百付宝支付状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:57 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/BaiFuBaoPaymentState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> BaiFuBaoPaymentState(BaiFuBaoPaymentStateRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 支付宝支付
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AlipayPayment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> AlipayPayment(AlipayPaymentRequst requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 查询支付宝支付状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/AlipayPaymentState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> AlipayPaymentState(AlipayPaymentStateRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 新浪微博支付
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SinaWeiBoPayment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> SinaWeiBoPayment(SinaWeiBoPaymentRequst requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 查询新浪微博支付状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 1:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/SinaWeiBoPaymentState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> SinaWeiBoPaymentState(SinaWeiBoPaymentStateRequst requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/WechatPayment", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<string> WechatPayment(WechatPaymentRequest requst)
        {
            return new Response<string>();
        }

        /// <summary>
        /// 查询微信支付状态查询微信支付状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 2:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/WechatPaymentState", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> WechatPaymentState(WechatPaymentStateRequest requst)
        {
            return new Response<bool>();
        }

        /// <summary>
        /// 查询微信通知状态
        /// </summary>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/6/2014 2:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebInvoke(UriTemplate = "/WechatPaymentDeliveryNotify", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<bool> WechatPaymentDeliveryNotify(WechatPaymentStateRequest requst)
        {
            return new Response<bool>();
        }
    }
}
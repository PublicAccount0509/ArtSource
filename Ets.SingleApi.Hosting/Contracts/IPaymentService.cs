namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IPaymentService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Payment服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IPaymentService
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
        [OperationContract]
        [Description("方法功能：联动优势支付；返回结果：返回交易号")]
        Response<PaymentResult> UmPayment(UmPaymentRequst requst);

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
        [OperationContract]
        [Description("方法功能：查询联动优势支付状态")]
        Response<bool> UmPaymentState(UmPaymentStateRequst requst);

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
        [OperationContract]
        [Description("方法功能：百付宝支付；返回结果：返回交易号")]
        Response<string> BaiFuBaoPayment(BaiFuBaoPaymentRequst requst);

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
        [OperationContract]
        [Description("方法功能：查询百付宝支付状态")]
        Response<bool> BaiFuBaoPaymentState(BaiFuBaoPaymentStateRequst requst);

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
        [OperationContract]
        [Description("方法功能：支付宝支付；返回结果：返回交易号")]
        Response<string> AlipayPayment(AlipayPaymentRequst requst);

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
        [OperationContract]
        [Description("方法功能：查询支付宝支付状态")]
        Response<bool> AlipayPaymentState(AlipayPaymentStateRequst requst);

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
        [OperationContract]
        [Description("方法功能：新浪微博支付；返回结果：返回交易号")]
        Response<string> SinaWeiBoPayment(SinaWeiBoPaymentRequst requst);

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
        [OperationContract]
        [Description("方法功能：查询新浪微博支付状态")]
        Response<bool> SinaWeiBoPaymentState(SinaWeiBoPaymentStateRequst requst);

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
        [OperationContract]
        [Description("方法功能：微信支付；返回结果：返回交易号")]
        Response<string> WechatPayment(WechatPaymentRequest requst);

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
        [OperationContract]
        [Description("方法功能：查询微信支付状态")]
        Response<bool> WechatPaymentState(WechatPaymentStateRequest requst);

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
        [OperationContract]
        [Description("方法功能：查询微信通知状态")]
        Response<bool> WechatPaymentDeliveryNotify(WechatPaymentStateRequest requst);
    }
}
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
        [Description("方法功能：联动优势支付")]
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
    }
}
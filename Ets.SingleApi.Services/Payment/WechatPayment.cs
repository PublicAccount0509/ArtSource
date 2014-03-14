
using Ets.SingleApi.Model;

namespace Ets.SingleApi.Services.Payment
{

    /// <summary>
    /// 类名称：WechatPayment
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：微信支付
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/3/14 18:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPayment : IPayment
    {

        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 18:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentType PaymentType
        {
            get { return PaymentType.WeChatPayment; }
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付请求参数
        /// </returns>
        /// 创建者：孟祺宙 创建日期：2014/3/14 18:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> Payment(IPaymentData parameter)
        {
            throw new System.NotImplementedException();
        }

        public PaymentResult<bool> QueryState(IPaymentData parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}

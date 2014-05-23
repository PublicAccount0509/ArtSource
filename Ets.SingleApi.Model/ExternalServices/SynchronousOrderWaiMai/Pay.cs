namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：PaymentInfo
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：支付信息
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：5/22/2014 3:59 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class pay
    {
        /// <summary>
        /// 支付金额
        /// </summary>
        /// <value>
        /// the amount
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:59 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal amount { get; set; }

        /// <summary>
        /// 支付方式id
        /// </summary>
        /// <value>
        /// the methodid
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:59 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int methodid { get; set; }
    }
}

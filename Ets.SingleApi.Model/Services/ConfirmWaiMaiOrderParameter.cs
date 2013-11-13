namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：ConfirmWaiMaiOrderParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/23/2013 10:28 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ConfirmWaiMaiOrderParameter
    {
        /// <summary>
        /// Gets or sets the OrderId of ConfirmWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the UserId of ConfirmWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the CustomerAddressId of ConfirmWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The CustomerAddressId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CustomerAddressId { get; set; }

        /// <summary>
        /// Gets or sets the PaymentMethodId of ConfirmWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The PaymentMethodId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/13/2013 4:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PaymentMethodId { get; set; }
    }
}
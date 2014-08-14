

namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：TangShiOrderBaseModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/6 13:56
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TangShiOrderBaseModel : IOrderModel
    {
        /// <summary>
        /// Gets or sets the OrderNumber of TangShiOrderBaseModel
        /// </summary>
        /// <value>
        /// The OrderNumber
        /// </value>
        /// 创建者：孟祺宙
        /// 创建日期：2014/8/6 14:06
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderNumber { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        /// <value>
        /// The DateReserved
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 13:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime DateReserved { get; set; }

        /// <summary>
        /// pament支付方式
        /// </summary>
        /// <value>
        /// The PaymentID
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PaymentId { get; set; }

        /// <summary>
        ///订单状态
        /// </summary>
        /// <value>
        /// The TableStatus
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? TableStatus { get; set; }


        /// <summary>
        /// 用户应付金额
        /// </summary>
        /// <value>
        /// The CustomerTotal
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CustomerTotal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsConfirm
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:50
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsConfirm { get; set; }

        /// <summary>
        /// 是否支付
        /// </summary>
        /// <value>
        /// The IsPaId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 17:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaId { get; set; }

        /// <summary>
        /// 设备号或者MAC地址
        /// </summary>
        /// <value>
        /// The DeviceNumber
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/14 9:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeviceNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Model
{
    /// <summary>
    /// 类名称：SaveTangShiOrderResult
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：订单是否完成，订单号，支付宝二维码
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：10/28/2014 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveTangShiOrderResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The TradeNo
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：10/28/2014 3:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TradeNo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The QrBigPicUrl
        /// </value>
        /// 创建者：黄磊
        /// 创建日期：10/28/2014 3:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string QrBigPicUrl { get; set; }
    }
}

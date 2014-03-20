using System;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：EtsWapDingTaiShoppingCartDeskRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：订台台位信息请求参数
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/20/2014 6:58 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCartDeskRequst : ApiRequst
    {
        /// <summary>
        /// 台位类型Id
        /// </summary>
        /// <value>
        /// The desk type identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 7:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeskTypeId{ get; set; }

        /// <summary>
        /// 预订日期
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 7:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// 预订时间
        /// </summary>
        /// <value>
        /// The booking time.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 7:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BookingTime { get; set; }

        /// <summary>
        /// 预订人数
        /// </summary>
        /// <value>
        /// The people count.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 7:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PeopleCount { get; set; }
    }
}
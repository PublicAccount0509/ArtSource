using System;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：EtsWapDingTaiShoppingCartDeskRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：订台确认订单信息请求参数
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/20/2014 6:58 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class EtsWapDingTaiShoppingCartOrderConfirmRequst : ApiRequst
    {
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        /// <value>
        /// The customer gender.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerGender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        /// <value>
        /// The customer phone number.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerPhoneNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        /// <value>
        /// The remark.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Remark { get; set; }

        /// <summary>
        /// 订台方式Id（2:订台付款、3:订台点菜付款）
        /// </summary>
        /// <value>
        /// The ding tai method identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 9:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DingTaiMethodId { get; set; }
    }
}
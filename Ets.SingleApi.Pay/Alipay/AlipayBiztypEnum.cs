using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Pay.Alipay
{
    /// <summary>
    /// 类名：AlipayMethodEnum
    /// 功能：业务类型枚举类
    /// 详细：访问支付宝的业务类型枚举
    /// 创建日期：2014-10-27
    /// 说明：
    /// 根据支付宝的技术文档（示例代码2012-07-05 版本3.3）编写而成，使用时请转换int类型
    /// </summary>
    public enum AlipayBiztypEnum
    {
        /// <summary>
        /// 商品码
        /// </summary>
        GoodsCode=10,
        /// <summary>
        /// 商户码（友宝售货机码），友宝目前只支持9
        /// </summary>
        MerchantsCode=9,
        /// <summary>
        /// 链接码
        /// </summary>
        LinkCode=11,
        /// <summary>
        /// 链接码（预授权业务）
        /// </summary>
        AuthorityLinkCode = 12
    }
}

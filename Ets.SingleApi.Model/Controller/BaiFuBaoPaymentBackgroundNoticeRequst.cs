namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：UmPaymentStateRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：百付宝支付回调通知参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：3/2/2014 3:30 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoPaymentBackgroundNoticeRequst : ApiRequst
    {
        /// <summary>
        /// 百度钱包商户号
        /// </summary>
        public string sp_no { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string order_no { get; set; }
        /// <summary>
        /// 百度钱包交易号
        /// </summary>
        public string bfb_order_no { get; set; }
        /// <summary>
        /// 百度钱包交易创建时间
        /// </summary>
        public string bfb_order_create_time { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public string pay_time { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string pay_type { get; set; }
        /// <summary>
        /// 用于支付的银行编号
        /// </summary>
        public string bank_no { get; set; }
        /// <summary>
        /// 商品单价，以分为单位
        /// </summary>
        public string unit_amount { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public string unit_count { get; set; }
        /// <summary>
        /// 运费，以分为单位
        /// </summary>
        public string transport_amount { get; set; }
        /// <summary>
        /// 总金额，以分为单位
        /// </summary>
        public string total_amount { get; set; }
        /// <summary>
        /// 百度钱包收取商户的手续费，以分为单位
        /// </summary>
        public string fee_amount { get; set; }
        /// <summary>
        /// 币种，目前仅支持人民币
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 买家在商户网站的用户名
        /// </summary>
        public string buyer_sp_username { get; set; }
        /// <summary>
        /// 支付结果代码
        /// </summary>
        public string pay_result { get; set; }
        /// <summary>
        /// 请求参数的字符编码
        /// </summary>
        public string input_charset { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 签名结果
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 签名方法
        /// </summary>
        public string sign_method { get; set; }
        /// <summary>
        /// 商户自定义数据
        /// </summary>
        public string extra { get; set; }
    }
}
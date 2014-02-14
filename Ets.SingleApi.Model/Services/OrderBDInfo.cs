namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 查询订单返回数据
    /// </summary>
    public class BaiFuBaoSearchOrderInfo
    {
        /// <summary>
        /// 订单查询的错误码
        /// </summary>
        public string query_status { get; set; }
        /// <summary>
        /// 百度钱包商户号
        /// </summary>
        public string sp_no { get; set; }
        /// <summary>
        /// 订单号
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
        /// 商品的名称
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品单价，以分为单位
        /// </summary>
        public uint unit_amount { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public uint unit_count { get; set; }
        /// <summary>
        /// 运费，以分为单位
        /// </summary>
        public uint transport_amount { get; set; }
        /// <summary>
        /// 总金额，以分为单位
        /// </summary>
        public uint total_amount { get; set; }
        /// <summary>
        /// 交易现金金额，以分为单位
        /// </summary>
        public uint cash_amount { get; set; }
        /// <summary>
        /// 手续费，以分为单位
        /// </summary>
        public uint fee_amount { get; set; }
        /// <summary>
        /// 买家在商户网站的用户名
        /// </summary>
        public string buyer_sp_username { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 支付结果代码
        /// </summary>
        public string pay_result { get; set; }
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

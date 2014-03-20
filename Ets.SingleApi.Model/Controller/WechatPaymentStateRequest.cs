namespace Ets.SingleApi.Model.Controller
{
    public class WechatPaymentStateRequest : ApiRequst
    {
        /// <summary>
        /// Gets or sets the Source of WechatPaymentStateRequest
        /// </summary>
        /// <value>
        /// The Source
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/18 22:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the UserId of WechatPaymentStateRequest
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/17 15:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the OrderId of WechatPaymentStateRequest
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/17 16:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>
        /// The type of the order.
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/17 16:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }



        /// <summary>
        /// 签名方式， 取值： MD5、 RSA -> MD5   N
        /// </summary>
        private string _sign_type;
        public string sign_type { get { return _sign_type ?? "MD5"; } set { _sign_type = value; } }
        /// <summary>
        /// 接口版本，默认为 1.0    N
        /// </summary>
        private string _service_version;
        public string service_version { get { return _service_version ?? "1.0"; } set { _service_version = value; } }
        /// <summary>
        /// 字符集,取值： GBK、 UTF-8 -> GBK   N
        /// </summary>
        private string _input_charset;
        public string input_charset { get { return _input_charset ?? "GBK"; } set { _input_charset = value; } }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 密钥序号 -> 1   N
        /// </summary>
        private int _sign_key_index = 1;//
        public int sign_key_index { get { return _sign_key_index; } set { _sign_key_index = value; } }

        /// <summary>
        /// 交易模式    1-即时到账 其他保留
        /// </summary>
        public int trade_mode { get; set; }
        /// <summary>
        /// 交易状态    0—成功 其他保留
        /// </summary>
        public int trade_state { get; set; }
        /// <summary>
        /// 支付结果信息（支付成功时为空）     N
        /// </summary>
        public string pay_info { get; set; }
        /// <summary>
        /// 商户号（partnerid）
        /// </summary>
        public string partner { get; set; }
        /// <summary>
        /// 付款银行  -> 在微信中使用 WX
        /// </summary>
        public string bank_type { get; set; }
        /// <summary>
        /// 银行订单号       N
        /// </summary>
        public string bank_billno { get; set; }
        /// <summary>
        /// 总金额（单位为分 如果 discount 有值， 通知的 total_fee + discount = 请求的 total_fee）
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 币种  -> 1 人民币
        /// </summary>
        public int fee_type { get; set; }
        /// <summary>
        /// 通知 ID（对于某些特定商户，只返回通知 id，要求商户据此查询交易结果）
        /// </summary>
        public string notify_id { get; set; }
        /// <summary>
        /// 订单号（28 位长的数值，其中微信公众号支付接口文档 V2.2 前 10 位为商户号，之后 8 位为 订 单 产 生 的 日 期 ， 如20090415，最后 10 位是流水号。）
        /// </summary>
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户订单号（商户系统的订单号，与请求一致）
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商家数据包，原样返回      N
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 支付完成时间（yyyyMMddhhmmss）
        /// </summary>
        public string time_end { get; set; }
        /// <summary>
        /// 物流费用（单位分，默认 0。如 果 有 值 ， 必 须 保 证 transport_fee + product_fee = total_fee）    N
        /// </summary>
        public int transport_fee { get; set; }
        /// <summary>
        /// 物品费用（单位分。 如果有值，必 须 保 证 transport_fee + product_fee=total_fee）   N
        /// </summary>
        public int product_fee { get; set; }
        /// <summary>
        /// 折扣价格（单位分， 如果有值，通知的 total_fee + discount = 请求的 total_fee）    N
        /// </summary>
        public int discount { get; set; }
        /// <summary>
        /// 买家别名 对应买家账号的一个加密串   N
        /// </summary>
        public string buyer_alias { get; set; }

        //
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public int IsSubscribe { get; set; }
        public long TimeStamp { get; set; }
        public string NonceStr { get; set; }
        public string AppSignature { get; set; }
        public string SignMethod { get; set; }
    }
}

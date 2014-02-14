namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：BaiFuBaoSubmitParameter
    /// 命名空间：Ets.WapNew.Model.Controllers
    /// 类功能：百付宝支付 请求参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/10/2014 3:40 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoSubmitParameter
    {
        /// <summary>
        /// 服务编号
        /// 整数，目前必须为1
        /// </summary>
        public string service_code
        {
            get { return "1"; }
        }
        /// <summary>
        /// 百度钱包商户号
        /// </summary>
        public string sp_no { get; set; }
        /// <summary>
        /// 创建订单的时间
        /// YYYYMMDDHHMMSS
        /// </summary>
        public string order_create_time { get; set; }
        /// <summary>
        /// 订单号，商户须保证订单号在商户系统内部唯一。
        /// 不超过20个字符
        /// </summary>
        public string Order_no { get; set; }
        /// <summary>
        /// 商品分类号。
        ///与优惠券相关。
        ///在创建优惠券推广计划的时候，可以指定优惠券使用的商品类型。
        ///若订单的类型与优化券的类型一致时，就会出相应的优惠券。
        ///没有指定时，出用户可用的全部优惠券
        /// </summary>
        public string goods_category { get; set; }
        /// <summary>
        /// 商品的名称
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品的描述信息
        /// </summary>
        public string goods_desc { get; set; }
        /// <summary>
        /// 商品在商户网站上的URL
        /// </summary>
        public string goods_url { get; set; }
        /// <summary>
        /// 商品单价，以分为单位
        /// </summary>
        public string unit_amount { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public string unit_count { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public string transport_amount { get; set; }
        /// <summary>
        /// 总金额，以分为单位
        /// </summary>
        public string total_amount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string currency
        {
            get { return "1"; }
        }
        /// <summary>
        /// 买家在商户网站的用户名
        /// </summary>
        public string buyer_sp_username { get; set; }
        /// <summary>
        /// 百度钱包主动通知商户支付结果的URL
        /// </summary>
        public string return_url { get; set; }
        /// <summary>
        /// 用户点击该URL可以返回到商户网站；该URL也可以起到通知支付结果的作用
        /// </summary>
        public string page_url { get; set; }

        /// <summary>
        /// 默认支付方式
        /// </summary>
        public string pay_type { get; set; }
        /// <summary>
        /// 网银支付或银行网关支付时，默认银行的编码
        /// </summary>
        public string bank_no { get; set; }
        /// <summary>
        /// 交易超时时间
        /// </summary>
        public string expire_time { get; set; }
        /// <summary>
        /// 请求参数的字符编码
        /// </summary>
        public string input_charset
        {
            get { return "1"; }
        }
        /// <summary>
        /// 接口的版本号
        /// </summary>
        public string version
        {
            get { return "2"; }
        }
        /// <summary>
        /// 用户在商户端的用户id或者用户名(必须在商户端唯一，用来形成快捷支付合约)
        /// </summary>
        public string sp_uno { get; set; }
        /// <summary>
        /// 签名结果
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 签名方法
        /// </summary>
        public string sign_method
        {
            get { return "1"; }
        }
        /// <summary>
        /// 商户自定义数据
        /// </summary>
        public string extra { get; set; }
    }
}

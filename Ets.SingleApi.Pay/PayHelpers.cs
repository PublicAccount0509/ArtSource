using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using com.openunion.netpay.service;
using Ets.SingleApi.Pay.Yeepay;
using Ets.SingleApi.Pay.YaGao;
using Ets.SingleApi.Pay.Alipay;
using Ets.SingleApi.Pay.YinBaoTong;
using Ets.SingleApi.Pay.Allscore;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using Ets.SingleApi.Pay.Bill99;
namespace Ets.SingleApi.Pay
{
    public class PayHelpers
    {
        /// <summary>
        /// 支付宝交易,即时到帐
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <param name="amount">金额</param>
        /// <param name="orderType">订单类型 dingCan（订餐）  dingTai(订台) </param>
        /// <param name="desc">备注，可选参数</param>
        /// <param name="Response"></param>
        public void Alpay(string OrderNo, string amount, string desc, string return_url, string notify_url, string subjectTitle, HttpResponseBase Response)
        {
            string sHtmlText = string.Empty;
            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //必填参数//

            //请与贵网站订单系统中的唯一订单号匹配
            string out_trade_no = OrderNo;
            //返回页面,网银返回显示页面
            string _return_url = return_url;
            //返回通知页面，网银返回执行页面
            string _notify_url = notify_url;

            //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            string subject = subjectTitle;
            //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            string body = (string.IsNullOrEmpty(desc) ? "" : desc);// "描述测试";
            //订单总金额，显示在支付宝收银台里的“应付总额”里
             string total_fee = amount;//amount1;
            //string total_fee = "0.01";//amount1;
            //扩展功能参数——默认支付方式//

            //默认支付方式，代码见“即时到帐接口”技术文档
            string paymethod = "";
            //默认网银代号，代号列表见“即时到帐接口”技术文档“附录”→“银行列表”
            string defaultbank = "";

            //扩展功能参数——防钓鱼//

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            string exter_invoke_ip = "";
            //注意：
            //请慎重选择是否开启防钓鱼功能
            //exter_invoke_ip、anti_phishing_key一旦被设置过，那么它们就会成为必填参数
            //建议使用POST方式请求数据
            //示例：
            //exter_invoke_ip = "";
            //Service aliQuery_timestamp = new Service();
            //anti_phishing_key = aliQuery_timestamp.Query_timestamp();               //获取防钓鱼时间戳函数

            //扩展功能参数——其他//

            //商品展示地址，要用http:// 格式的完整路径，不允许加?id=123这类自定义参数
            string show_url = "http://www.etaoshi.com";
            //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            string extra_common_param = "";
            //默认买家支付宝账号
            string buyer_email = "";

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)//

            //提成类型，该值为固定值：10，不需要修改
            string royalty_type = "";
            //提成信息集
            string royalty_parameters = "";
            //注意：
            //与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //各分润金额的总和须小于等于total_fee
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //示例：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            sParaTemp.Add("extra_common_param", extra_common_param);
            sParaTemp.Add("buyer_email", buyer_email);
            sParaTemp.Add("royalty_type", royalty_type);
            sParaTemp.Add("royalty_parameters", royalty_parameters);
            //执行网银接口
            Ets.SingleApi.Pay.Alipay.Service ali = new Alipay.Service(_return_url, _notify_url);
            sHtmlText = ali.Create_direct_pay_by_user(sParaTemp);
            Response.Write(sHtmlText);
        }

        /// <summary>
        /// 支付宝交易,根据支付类型交易
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <param name="amount">金额</param>
        /// <param name="orderType">订单类型 dingCan（订餐）  dingTai(订台) </param>
        /// <param name="desc">备注，可选参数</param>
        /// <param name="paymethod">支付方式,如果非网银支付请传空</param>
        /// <param name="Response"></param>
        public void Alpay(string OrderNo, string amount, string desc, string return_url, string notify_url, string subjectTitle, HttpResponseBase Response, string PayMethod)
        {

            string sHtmlText = string.Empty;
            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //必填参数//

            //请与贵网站订单系统中的唯一订单号匹配
            string out_trade_no = OrderNo;
            //返回页面,网银返回显示页面
            string _return_url = return_url;
            //返回通知页面，网银返回执行页面
            string _notify_url = notify_url;

            //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            string subject = subjectTitle;


            //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            string body = (string.IsNullOrEmpty(desc) ? "" : desc);// "描述测试";
            //订单总金额，显示在支付宝收银台里的“应付总额”里
            string total_fee = amount;//amount1;
            //string total_fee = "0.01";//amount1;
            //扩展功能参数——默认支付方式//

            //默认支付方式，代码见“即时到帐接口”技术文档
            string paymethod = "";
            //默认网银代号，代号列表见“即时到帐接口”技术文档“附录”→“银行列表”
            string defaultbank = "";

            if (PayMethod != null)
            {
                if (PayMethod != "")
                {
                    if (PayMethod == "directPay")
                    {
                        paymethod = "directPay";
                    }
                    else
                    {
                        paymethod = "bankPay";
                        defaultbank = PayMethod;
                    }
                }
            }


            //扩展功能参数——防钓鱼//

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            string exter_invoke_ip = "";
            //注意：
            //请慎重选择是否开启防钓鱼功能
            //exter_invoke_ip、anti_phishing_key一旦被设置过，那么它们就会成为必填参数
            //建议使用POST方式请求数据
            //示例：
            //exter_invoke_ip = "";
            //Service aliQuery_timestamp = new Service();
            //anti_phishing_key = aliQuery_timestamp.Query_timestamp();               //获取防钓鱼时间戳函数

            //扩展功能参数——其他//

            //商品展示地址，要用http:// 格式的完整路径，不允许加?id=123这类自定义参数
            string show_url = "http://www.etaoshi.com";
            //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            string extra_common_param = "";
            //默认买家支付宝账号
            string buyer_email = "";

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)//

            //提成类型，该值为固定值：10，不需要修改
            string royalty_type = "";
            //提成信息集
            string royalty_parameters = "";
            //注意：
            //与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //各分润金额的总和须小于等于total_fee
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //示例：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            sParaTemp.Add("extra_common_param", extra_common_param);
            sParaTemp.Add("buyer_email", buyer_email);
            sParaTemp.Add("royalty_type", royalty_type);
            sParaTemp.Add("royalty_parameters", royalty_parameters);
            //执行网银接口
            Alipay.Service ali = new Alipay.Service(_return_url, _notify_url);
            sHtmlText = ali.Create_direct_pay_by_user(sParaTemp);
            Response.Write(sHtmlText);
        }
        /// <summary>
        /// 易宝支付
        /// </summary>
        /// <param name="bankCode">银行编码</param>
        /// <param name="OrderNo">订单号</param>
        /// <param name="amount">金额</param>
        /// <param name="orderType">订单类型 dingCan（订餐）  dingTai(订台) </param>
        /// <param name="desc">备注，可选参数</param>
        /// <param name="Response"></param>
        public void YeePay(string bankCode, string OrderNo, string amount, string desc, string return_url, string subjectTitle, HttpResponseBase Response)
        {

            // 设置 Response编码格式为GB2312
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            // 商户订单号,选填.
            //若不为""，提交的订单号必须在自身账户交易中唯一;为""时，易宝支付会自动生成随机的商户订单号.
            string p2_Order = OrderNo;

            // 支付金额,必填.
            //单位:元，精确到分. 
            string p3_Amt = amount;


            //交易币种,固定值"CNY".
            string p4_Cur = "CNY";

            //商品名称
            //用于支付时显示在易宝支付网关左侧的订单产品信息.
            string p5_Pid = "";//Request.Form["p5_Pid"];

            //商品种类
            string p6_Pcat = "";//Request.Form["p6_Pcat"];

            //商品描述
            string p7_Pdesc = desc;//Request.Form["p7_Pdesc"];

            //商户接收支付成功数据的地址,支付成功后易宝支付会向该地址发送两次成功通知.
            string p8_Url = return_url;
            p6_Pcat = subjectTitle;

            //送货地址
            //为“1”: 需要用户将送货地址留在易宝支付系统;为“0”: 不需要，默认为 ”0”.
            string p9_SAF = "0";

            //商户扩展信息
            //商户可以任意填写1K 的字符串,支付成功时将原样返回.	
            string pa_MP = "商户扩展信息";// Request.Form["pa_MP"];

            //银行编码
            //默认为""，到易宝支付网关.若不需显示易宝支付的页面，直接跳转到各银行、神州行支付、骏网一卡通等支付页面，该字段可依照附录:银行列表设置参数值.
            string pd_FrpId = bankCode;// Request.Form["pd_FrpId"];

            //应答机制
            //默认为"1": 需要应答机制;
            string pr_NeedResponse = "1";

            string url = Buy.CreateBuyUrl(p2_Order, p3_Amt, p4_Cur, p5_Pid, p6_Pcat, p7_Pdesc, p8_Url, p9_SAF, pa_MP, pd_FrpId, pr_NeedResponse);
            Response.Redirect(url, false);
        }



        /// <summary>
        /// 聚福卡
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <param name="amount">金额</param>
        /// <param name="orderType">订单类型 dingCan（订餐）  dingTai(订台) </param>
        /// <param name="deliverTime">订单时间</param>
        /// <param name="Response"></param>
        public void JufuPay(string OrderNo, string amount,string returnurl, HttpResponseBase Response)
        {

            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            string strMd5Info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("20111017399017701020350" + OrderNo + amount + strTime + returnurl + "1234561111111111", "MD5").ToLower();

            string str = "<form id='jufukasubmit' action='http://pay.jufuka.cn/gateway.jsp' method='post'>" +
                  "<input type='hidden' name='MerNo' value='201110173990177' />" +
                  "<input type='hidden' name='Terid' value='01020350' />" +
                  "<input type='hidden' name='BillNo' value='" + OrderNo + "' />" +
                  "<input type='hidden' name='order_sn' value='" + OrderNo + "' />" +
                  "<input type='hidden' name='order_time' value='" + strTime + "' />" +
                  "<input type='hidden' name='Amount' value='" + amount + "' />" +
                  "<input type='hidden' name='ReturnURL' value='" + returnurl + "' />" +
                  "<input type='hidden' name='MD5info' value='" + strMd5Info + "' />" +
                  "<input type='hidden' name='Pos' value='005' />" +
                  "<script>document.forms['jufukasubmit'].submit();</script>" +
                  "</form>";
            Response.Write(str);
            Response.End();
        }



        /// <summary>
        /// 雅高支付
        /// </summary>
        /// <param name="response"></param>
        /// <param name="orderNo"></param>
        /// <param name="amount"></param>
        /// <param name="ip"></param>
        public void YaGao(string orderNo, string amount, string returnurl,string ip, HttpResponseBase response)
        {

            var ms = new MpiService();
            ms.PayTrans(response, orderNo, amount, ip,returnurl);
        }

        /// <summary>
        /// 易淘卡支付
        /// </summary>
        /// <param name="response"></param>
        /// <param name="orderNo"></param>
        /// <param name="amount"></param>
        /// <param name="ip"></param>
        public void EtaoCard(string orderNo, string amount, string return_url,string ip, HttpResponseBase Response)
        {
            var ecs = new EtaoCardService();
            Response.Write(ecs.PayTrans(orderNo, amount, ip, return_url));
        }

        /// <summary>
        /// 易淘卡支付
        /// </summary>
        /// <param name="response"></param>
        /// <param name="orderNo"></param>
        /// <param name="amount"></param>
        /// <param name="ip"></param>
        public void EtaoMobile(string orderNo, string amount, string return_url, string ip, HttpResponseBase Response)
        {
            var ecs = new EtaoMobileService();
            Response.Write(ecs.PayTrans(orderNo, amount, ip, return_url));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="amount"></param>
        /// <param name="orderType"></param>
        /// <param name="returnurl"></param>
        /// <param name="cancelurl">异常url</param>
        /// <param name="response"></param>
        public void Ybt(string orderNo, string amount, string returnurl,string cancelurl, HttpResponseBase response)
        {

            var ybt = new YbtService();
            ybt.YbtCard(response, orderNo, amount,returnurl,cancelurl);
        }

         ///<summary>
         ///华瑞富达
         ///</summary>
        public void HuaPay(HttpResponseBase Response, string OrderNo, DateTime time, string amount, string returnurl)
        {
            string strTime = time.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);

            string strMd5Info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("888880100151011" + OrderNo + amount + strTime + "01" + returnurl + "120705", "MD5").ToLower();

            string str = "<form id='huaruka' action='http://www.963377.com:45485/merInterface.do' method='post'>" +
                  "<input type='hidden' name='MerCode' value='888880100151011' />" +
                  "<input type='hidden' name='BillNo' value='" + OrderNo + "' />" +
                  "<input type='hidden' name='Amount' value='" + amount + "' />" +
                  "<input type='hidden' name='MerDate' value='" + strTime + "' />" +
                   "<input type='hidden' name='PayType' value='01' />" +
                  "<input type='hidden' name='MerUrl' value='" + returnurl + "' />" +
                  "<input type='hidden' name='SignMD5' value='" + strMd5Info + "' />" +
                  "<script>document.forms['huaruka'].submit();</script>" +
                  "</form>";
            Response.Write(str);
            Response.End();
        }

        /// <summary>
        /// 联心卡支付
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="OrderNo">订单号</param>
        /// <param name="Amount">价格</param>
        /// <param name="Memo">私有域</param>
        /// <param name="UserName">买家用户名</param>
        /// <param name="GoodsName">商品名</param>
        /// <param name="SupplierName">商家用户名</param>
        /// <param name="ReturnUrl"></param>
        public void LianxinPay(HttpResponseBase Response, string OrderNo, double Amount, string Memo, string UserName, string GoodsName, string SupplierName, string ReturnUrl)
        {
            int intAmount = (int)(Amount * 100);
            CertificateService c = new CertificateService();
            string strCuryid = "156";//币种
            string strTransType = "0001";//支付类型
            string strPartner = "29990000098";
            string strMerid = "YTSSYS";
            string strOrderTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strSign = c.signWithKey(strPartner + strMerid + OrderNo + intAmount + strCuryid + strOrderTime + strTransType + "1" + "3", System.Configuration.ConfigurationManager.AppSettings["KlTongSign"] + "Pri.key");

            string str = "<form id='kltongpay' action='https://www.kltong.com/oupaygateway/payment/trade.action' METHOD=POST>" +// （这里action的内容为提交交易数据的URL地址）
            "<input type=hidden name='partner' value='" + strPartner + "'/>" +// （partner为开联通统一分配给商户的渠道号，最长32位长度，必填）
            "<input type=hidden name='merid' value='" + strMerid + "'/>" +// （MerId为开联通统一分配给商户的商户号，最长32位长度，必填）
            "<input type=hidden name='from' value='" + SupplierName + "'/>" +//（商户名称描述，可为空，如果为空那么使用商户签约信息填充，最长256字节）
            "<input type=hidden name='ordid' value='" + OrderNo + "'/>" +// （商户提交给开联通的交易订单号，最长32位长度，必填）
            "<input type=hidden name='transamt' value='" + intAmount + "'/>" +// （订单交易金额，必填,单位为分，最长12位）
            "<input type=hidden name='userName' value='" + UserName + "'/>" +//（买家用户名，最长32位长度）
            "<input type=hidden name='goodName' value='" + GoodsName + "'/>" +//（商品名称，最长256字节，必填）
            "<input type=hidden name='curyid' value='" + strCuryid + "'/>" +//（订单交易币种，3位长度，固定人民币156，必填）
            "<input type=hidden name='transdate' value='" + strOrderTime + "'/>" +//（订单交易日期，格式yyyyMMddHHmmss，必填）
            "<input type=hidden name='transtype' value='" + strTransType + "'/>" +// （交易类型（0001支付 0002退款 0003查询），4位长度，固定 0001，必填）
            "<input type=hidden name='version' value='20100301'/>" +// （支付接入版本号，必填，目前填写20100301）
            "<input type=hidden name='notify_url' value='" + ReturnUrl + "'/>" +// （后台交易接收URL，长度不要超过256个字节，必填）
            "<input type=hidden name='return_url' value='" + ReturnUrl + "'/>" +// （页面交易接收URL，长度不要超过256个字节，必填）
            "<input type=hidden name='priv1' value='Memo'>" +                       //（商户私有域，长度不要超过64个字节）
            "<input type=hidden name='sign' value='" + strSign + "'>" +             //（关键数据签名（partner +merid+ordid+transamt+curyid+transdate+transtype+ lxcardenabled+ payChannelMask），必填）
            "<input type=hidden name='lxcardenabled' value='1'>" +                  //（是否可用连心卡支付 1：可以 0：不可以，必填）
            "<input type=hidden name='gateId' value='LXCARD'>" +                          //（默认网银 默认为空）
            "<input type=hidden name='payChannelMask' value='3'>" +                 //（默认网银 默认填写3）
            "<input type=hidden name='autoJump' value='0'>" +                       //（是否自动跳转到网银 1：否 0：是，必填）
            "<script>document.forms['kltongpay'].submit();</script>" +
            "</form>";
            Response.Write(str);
            Response.End();
        }
        /// <summary>
        /// 奥斯卡支付
        /// </summary>
        /// <param name="OrderId">订单号</param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="Amount">金额</param>
        public void AllscorePay(string OrderId,decimal Amount ,string Subject,string Body,string Returnurl,string NotifyUrl)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();

            sParaTemp.Add("outOrderId", OrderId);
            sParaTemp.Add("subject", Subject);
            sParaTemp.Add("body", Body);
            sParaTemp.Add("transAmt", Amount.ToString("#0.00"));
            sParaTemp.Add("payMethod", "allscorePay");

            Ets.SingleApi.Pay.Allscore.Service allscore = new Allscore.Service();
            string sHtmlText = allscore.directPay(sParaTemp,Returnurl, NotifyUrl);

            HttpContext.Current.Response.Write(sHtmlText);
 
        }

        /// <summary>
        /// 快钱支付
        /// </summary>
        /// <param name="order">订单ID</param>
        /// <param name="amount">支付金额(以分为单位)</param>
        /// <param name="returnUrl">跳转地址</param>
        /// <param name="supplierLoginName">供应商名称</param>
        /// <param name="payerUserName">付款人姓名</param>
        /// <param name="goodsCount">商品数量</param>
        public void Bill99Pay(string order, decimal amount, string returnUrl, string supplierLoginName, string payerUserName, int goodsCount)
        {
            Bill99Service service = new Bill99Service();
            string paymenHTML = service.BuildHtml(order, amount, returnUrl, supplierLoginName, payerUserName, goodsCount);
            HttpContext.Current.Response.Write(paymenHTML);
        }
    }
}

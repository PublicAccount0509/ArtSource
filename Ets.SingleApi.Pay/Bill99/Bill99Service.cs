using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace Ets.SingleApi.Pay.Bill99
{
    public class Bill99Service
    {
        /// <summary>
        /// 生成Form表单，含有快钱支付所需的参数信息
        /// </summary>
        /// <param name="order">订单ID</param>
        /// <param name="amount">支付金额(以分为单位)</param>
        /// <param name="returnUrl">跳转地址</param>
        /// <param name="supplierLoginName">供应商名称</param>
        /// <param name="payerUserName">付款人姓名</param>
        /// <param name="goodsCount">商品数量</param>
        /// <returns></returns>
        public string BuildHtml(string order, decimal amount, string returnUrl, string supplierLoginName, string payerUserName, int goodsCount)
        {
            #region 参数说明

            //人民币网关账号，该账号为11位人民币网关商户编号+01,该参数必填。
            string merchantAcctId = "1001213884201";
            //编码方式，1代表 UTF-8; 2 代表 GBK; 3代表 GB2312 默认为1,该参数必填。
            string inputCharset = "1";
            //接收支付结果的页面地址，该参数一般置为空即可。
            string pageUrl = "";
            //服务器接收支付结果的后台地址，该参数务必填写，不能为空。
            string bgUrl = returnUrl;
            //网关版本，固定值：v2.0,该参数必填。
            string version = "v2.0";
            //语言种类，1代表中文显示，2代表英文显示。默认为1,该参数必填。
            string language = "1";
            //签名类型,该值为4，代表PKI加密方式,该参数必填。
            string signType = "4";
            //支付人姓名,可以为空。
            string payerName = payerUserName;
            //支付人联系类型，1 代表电子邮件方式；2 代表手机联系方式。可以为空。
            string payerContactType = "";
            //支付人联系方式，与payerContactType设置对应，payerContactType为1，则填写邮箱地址；payerContactType为2，则填写手机号码。可以为空。
            string payerContact = "";
            //商户订单号，以下采用时间来定义订单号，商户可以根据自己订单号的定义规则来定义该值，不能为空。
            string orderId = order;
            //订单金额，金额以“分”为单位，商户测试以1分测试即可，切勿以大金额测试。该参数必填。
            string orderAmount = string.Format("{0:###0}", amount);
            //订单提交时间，格式：yyyyMMddHHmmss，如：20071117020101，不能为空。
            string orderTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //商品名称，可以为空。
            string productName = "";
            //商品数量，可以为空。
            string productNum = Convert.ToString(goodsCount);
            //商品代码，可以为空。
            string productId = "";
            //商品描述，可以为空。
            string productDesc = "";
            //扩展字段1，商户可以传递自己需要的参数，支付完快钱会原值返回，可以为空。
            string ext1 = supplierLoginName;
            //扩展自段2，商户可以传递自己需要的参数，支付完快钱会原值返回，可以为空。
            string ext2 = "";
            //支付方式，一般为00，代表所有的支付方式。如果是银行直连商户，该值为10，必填。
            string payType = "00";
            //银行代码，如果payType为00，该值可以为空；如果payType为10，该值必须填写，具体请参考银行列表。
            string bankId = "";
            //同一订单禁止重复提交标志，实物购物车填1，虚拟产品用0。1代表只能提交一次，0代表在支付不成功情况下可以再提交。可为空。
            string redoFlag = "";
            //快钱合作伙伴的帐户号，即商户编号，可为空。
            string pid = "";
            // signMsg 签名字符串 不可空，生成加密签名串
            string signMsg = "";

            #endregion

            string certificatePath = HttpContext.Current.Server.MapPath("~/Pay/Bill99/tester-rsa.pfx");
            string certificatePassword = "123456";
            string payUrl = "https://sandbox.99bill.com/gateway/recvMerchantInfoAction.htm";

            //生产环境配置
            if (ConfigurationManager.AppSettings["Bill99Mode"] == "release")
            {
                certificatePath = HttpContext.Current.Server.MapPath("~/Pay/Bill99/99bill-rsa.pfx");
                certificatePassword = "2013@ETAO@shi";
                merchantAcctId = "1002285555501";
                payUrl = "https://www.99bill.com/gateway/recvMerchantInfoAction.htm";
            }

            #region 拼接函数

            Func<string, string, string, string> appendParam = (returnStr, paramId, paramValue) =>
            {
                if (returnStr != "")
                {
                    if (paramValue != "")
                    {
                        returnStr += "&" + paramId + "=" + paramValue;
                    }
                }
                else
                {
                    if (paramValue != "")
                    {
                        returnStr = paramId + "=" + paramValue;
                    }
                }
                return returnStr;
            };

            #endregion

            #region 拼接字符串

            string signMsgVal = "";
            signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset);
            signMsgVal = appendParam(signMsgVal, "pageUrl", pageUrl);
            signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl);
            signMsgVal = appendParam(signMsgVal, "version", version);
            signMsgVal = appendParam(signMsgVal, "language", language);
            signMsgVal = appendParam(signMsgVal, "signType", signType);
            signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId);
            signMsgVal = appendParam(signMsgVal, "payerName", payerName);
            signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType);
            signMsgVal = appendParam(signMsgVal, "payerContact", payerContact);
            signMsgVal = appendParam(signMsgVal, "orderId", orderId);
            signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount);
            signMsgVal = appendParam(signMsgVal, "orderTime", orderTime);
            signMsgVal = appendParam(signMsgVal, "productName", productName);
            signMsgVal = appendParam(signMsgVal, "productNum", productNum);
            signMsgVal = appendParam(signMsgVal, "productId", productId);
            signMsgVal = appendParam(signMsgVal, "productDesc", productDesc);
            signMsgVal = appendParam(signMsgVal, "ext1", ext1);
            signMsgVal = appendParam(signMsgVal, "ext2", ext2);
            signMsgVal = appendParam(signMsgVal, "payType", payType);
            signMsgVal = appendParam(signMsgVal, "redoFlag", redoFlag);
            signMsgVal = appendParam(signMsgVal, "pid", pid);

            #endregion

            ///PKI加密
            ///编码方式UTF-8 GB2312  用户可以根据自己系统的编码选择对应的加密方式
            ///byte[] OriginalByte=Encoding.GetEncoding("GB2312").GetBytes(OriginalString);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(signMsgVal);            
            signMsg = BuildSignature(certificatePath, certificatePassword, bytes);
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict["inputCharset"] = inputCharset;
            dict["pageUrl"] = pageUrl;
            dict["bgUrl"] = bgUrl;
            dict["version"] = version;
            dict["language"] = language;
            dict["signType"] = signType;
            dict["signMsg"] = signMsg;
            dict["merchantAcctId"] = merchantAcctId;
            dict["payerName"] = payerName;
            dict["payerContactType"] = payerContactType;
            dict["payerContact"] = payerContact;
            dict["orderId"] = orderId;
            dict["orderAmount"] = orderAmount;
            dict["orderTime"] = orderTime;
            dict["productName"] = productName;
            dict["productNum"] = productNum;
            dict["productId"] = productId;
            dict["productDesc"] = productDesc;
            dict["ext1"] = ext1;
            dict["ext2"] = ext2;
            dict["payType"] = payType;
            dict["bankId"] = bankId;
            dict["redoFlag"] = redoFlag;
            dict["pid"] = pid;
            string formName = "kqPay";

            string cotent = BuildHtmlContent(dict, formName, payUrl);
            return cotent;
        }

        /// <summary>
        /// 生成提交HTML内容
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="payUrl"></param>
        /// <returns></returns>
        private string BuildHtmlContent(Dictionary<string, string> dict, string formName, string payUrl)
        {
            //构造表单提交HTML数据
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat(@"<form id=""{0}"" name=""{0}"" action=""{1}"" method=""post"">", formName, payUrl);

            foreach (string key in dict.Keys)
            {
                buffer.AppendFormat(@"<input type=""hidden"" name=""{0}"" value=""{1}"" />", key, dict[key]);
            }

            buffer.AppendFormat("</form>");
            buffer.AppendFormat(@"<script type=""text/javascript"">");
            buffer.AppendFormat(@"  document.getElementById(""{0}"").submit();", formName);
            buffer.AppendFormat("</script>");

            return buffer.ToString();
        }

        /// <summary>
        /// 生成数字签名
        /// </summary>
        /// <param name="certificatePath"></param>
        /// <param name="certificatePassword"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string BuildSignature(string certificatePath, string certificatePassword, byte[] bytes)
        {
            X509Certificate2 cert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.MachineKeySet);
            RSACryptoServiceProvider rsapri = (RSACryptoServiceProvider)cert.PrivateKey;
            RSAPKCS1SignatureFormatter f = new RSAPKCS1SignatureFormatter(rsapri);
            byte[] result;
            f.SetHashAlgorithm("SHA1");
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(bytes);
            return System.Convert.ToBase64String(f.CreateSignature(result)).ToString(); 
        }
    }
}

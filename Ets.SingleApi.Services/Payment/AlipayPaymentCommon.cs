using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using Ets.SingleApi.Controllers;
using Ets.SingleApi.Model.Controller;
using Ets.SingleApi.Utility;
using Newtonsoft.Json.Linq;

namespace Ets.SingleApi.Services
{
    public static class AlipayPaymentCommon
    {
        private const string HttpsVeryfyUrl = "https://mapi.alipay.com/gateway.do?service=notify_verify&";

        private const string Key = ControllersCommon.AlipayKey;
        private const string InputCharSet = ControllersCommon.AlipayInputCharSet;

        private static readonly string PartnerId = ControllersCommon.AlipayPartnerId;

        /// <summary>
        /// 请求Token值
        /// </summary>
        /// <param name="alipayPaymentData">The alipayRequestDataDefault documentation</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/7/2014 4:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string RequestToken(AlipayPaymentData alipayPaymentData)
        {
            var gatewayNew = alipayPaymentData.GateWayNew;
            var inputCharset = alipayPaymentData.InputCharSet;

            var code = Encoding.GetEncoding(inputCharset);

            //HttpUrlEncode后Url字符串
            var urlEncode = BuildRequestTokenUrl(alipayPaymentData, true);

            //原Url字符串
            var url = BuildRequestTokenUrl(alipayPaymentData);

            //MD5加密字符串
            var urlSignMd5 = SignMd5(url, Key, alipayPaymentData.InputCharSet);

            //待请求参数数组字符串
            var strRequestData = urlEncode + String.Format("&sign={0}", urlSignMd5);

            //把数组转换成流中所需字节数组类型
            var bytesRequestData = code.GetBytes(strRequestData);

            //设置HttpWebRequest基本信息
            var myReq = (HttpWebRequest)WebRequest.Create(gatewayNew + "_input_charset=" + inputCharset);
            myReq.Method = "post";
            myReq.ContentType = "application/x-www-form-urlencoded";

            //填充POST数据
            myReq.ContentLength = bytesRequestData.Length;

            Stream requestStream = myReq.GetRequestStream();
            requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
            requestStream.Close();

            //发送POST数据请求服务器
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();

            if (myStream == null)
            {
                return String.Empty;
            }

            //获取服务器返回信息
            var reader = new StreamReader(myStream, code);
            var responseData = new StringBuilder();
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                responseData.Append(line);
            }

            //释放
            myStream.Close();

            //请求远程HTTP
            var strRequestResult = responseData.ToString();

            var sHtmlTextToken = HttpUtility.UrlDecode(strRequestResult, code);
            if (sHtmlTextToken == null)
            {
                return String.Empty;
            }

            var strResData = String.Empty;
            var strToken = String.Empty;

            //以“&”字符切割字符串
            var strSplitText = sHtmlTextToken.Split('&');

            foreach (var t in strSplitText)
            {
                //获得第一个=字符的位置
                var nPos = t.IndexOf('=');
                //获得字符串长度
                var nLen = t.Length;
                //获得变量名
                var strKey = t.Substring(0, nPos);
                if (!strKey.Equals("res_data"))
                {
                    continue;
                }
                //获得数值
                strResData = t.Substring(nPos + 1, nLen - nPos - 1);
                break;
            }

            if (strResData.Length > 0)
            {
                ////解析加密部分字符串（RSA与MD5区别仅此一句）
                //if (alipayPaymentData.SignType == "0001")
                //{
                //    dicText["res_data"] = RSAFromPkcs8.decryptData(dicText["res_data"], _private_key, _input_charset);
                //}

                //token从res_data中解析出来（也就是说res_data中已经包含token的内容）
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResData);
                var selectSingleNode = xmlDoc.SelectSingleNode("/direct_trade_create_res/request_token");
                if (selectSingleNode == null)
                {
                    return "Token解析错误";
                }
                strToken = selectSingleNode.InnerText;
            }

            return strToken;
        }

        /// <summary>
        /// 创建请求Url地址
        /// </summary>
        /// <param name="alipayPaymentData">The alipayPaymentDataDefault documentation</param>
        /// <param name="token">The tokenDefault documentation</param>
        /// <param name="isUrlCode">The  isUrlCode indicates whether</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 1:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string BuildRequestPaymentUrl(AlipayPaymentData alipayPaymentData, string token, bool isUrlCode = false)
        {
            var code = Encoding.GetEncoding(alipayPaymentData.InputCharSet);

            var sParaTempToken = new List<string>();

            sParaTempToken.Add(String.Format("_input_charset={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.InputCharSet, code) : alipayPaymentData.InputCharSet));//字符编码格式 
            sParaTempToken.Add(String.Format("format={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.Format) : alipayPaymentData.Format));
            sParaTempToken.Add(String.Format("partner={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.Partner) : alipayPaymentData.Partner));////合作身份者ID

            var reqDataToken = "<auth_and_execute_req><request_token>" + token + "</request_token></auth_and_execute_req>";
            sParaTempToken.Add(String.Format("req_data={0}", isUrlCode ? HttpUtility.UrlEncode(reqDataToken) : reqDataToken));
            sParaTempToken.Add(String.Format("req_id={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.ReqId) : alipayPaymentData.ReqId));
            sParaTempToken.Add(String.Format("sec_id={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.SignType) : alipayPaymentData.SignType));//签名方式
            sParaTempToken.Add(String.Format("service={0}", isUrlCode ? HttpUtility.UrlEncode("alipay.wap.auth.authAndExecute") : "alipay.wap.auth.authAndExecute"));
            sParaTempToken.Add(String.Format("v={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.V) : alipayPaymentData.V));

            return String.Join("&", sParaTempToken);
        }

        /// <summary>
        /// 创建请求TokenUrl
        /// </summary>
        /// <param name="alipayPaymentData">The alipayRequestDataDefault documentation</param>
        /// <param name="isUrlCode">The  isUrlCode indicates whether</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/7/2014 4:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static string BuildRequestTokenUrl(AlipayPaymentData alipayPaymentData, bool isUrlCode = false)
        {
            var code = Encoding.GetEncoding(alipayPaymentData.InputCharSet);

            var sParaTempToken = new List<string>();
            sParaTempToken.Add(String.Format("_input_charset={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.InputCharSet, code) : alipayPaymentData.InputCharSet));//字符编码格式 
            sParaTempToken.Add(String.Format("format={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.Format) : alipayPaymentData.Format));
            sParaTempToken.Add(String.Format("partner={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.Partner) : alipayPaymentData.Partner));////合作身份者ID

            string reqDataToken = "<direct_trade_create_req>" +
                                  "<notify_url>" + alipayPaymentData.NotifyUrl + "</notify_url>" +
                                  "<call_back_url>" + alipayPaymentData.CallBackUrl + "</call_back_url>" +
                                  "<seller_account_name>" + alipayPaymentData.SellerEmail + "</seller_account_name>" +
                                  "<out_trade_no>" + alipayPaymentData.OutTradeNo + "</out_trade_no>" +
                                  "<subject>" + alipayPaymentData.Subject + "</subject>" +
                                  "<total_fee>" + alipayPaymentData.TotalFee + "</total_fee>" +
                                  "<merchant_url>" + alipayPaymentData.MerchantUrl + "</merchant_url>" +
                                  "</direct_trade_create_req>";
            sParaTempToken.Add(String.Format("req_data={0}", isUrlCode ? HttpUtility.UrlEncode(reqDataToken) : reqDataToken));
            sParaTempToken.Add(String.Format("req_id={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.ReqId) : alipayPaymentData.ReqId));
            sParaTempToken.Add(String.Format("sec_id={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.SignType) : alipayPaymentData.SignType));//签名方式
            sParaTempToken.Add(String.Format("service={0}", isUrlCode ? HttpUtility.UrlEncode("alipay.wap.trade.create.direct") : "alipay.wap.trade.create.direct"));
            sParaTempToken.Add(String.Format("v={0}", isUrlCode ? HttpUtility.UrlEncode(alipayPaymentData.V) : alipayPaymentData.V));

            return String.Join("&", sParaTempToken);
        }

        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="prestr">待加密字符串</param>
        /// <param name="key">加密Key</param>
        /// <param name="inputCharSet">编码设置</param>
        /// <returns>
        /// MD5加密后字符串
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/7/2014 3:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string SignMd5(string prestr, string key, string inputCharSet)
        {
            var sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(inputCharSet).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="inputCharset">编码格式</param>
        /// <returns>验证结果</returns>
        public static bool VerifyMd5(string prestr, string sign, string key, string inputCharset)
        {
            var mysign = SignMd5(prestr, key, inputCharset);
            return mysign == sign;
        }

        /// <summary>
        ///  验证消息是否是支付宝发出的合法消息，验证服务器异步通知
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">支付宝生成的签名结果</param>
        /// <returns>验证结果</returns>
        public static bool VerifyNotify(Dictionary<string, string> inputPara, string sign)
        {
            ////解密
            //if (_sign_type == "0001")
            //{
            //    inputPara = Decrypt(inputPara);
            //}

            //获取是否是支付宝服务器发来的请求的验证结果
            var responseTxt = "true";
            //XML解析notify_data数据，获取notify_id
            var notifyId = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputPara["notify_data"]);
            var selectSingleNode = xmlDoc.SelectSingleNode("/notify/notify_id");
            if (selectSingleNode != null)
            {
                notifyId = selectSingleNode.InnerText;
            }

            if (notifyId != "")
            {
                responseTxt = GetResponseTxt(notifyId);
            }

            //获取返回时的签名验证结果
            var isSign = GetSignVeryfy(inputPara, sign);

            //写日志记录（若要调试，请取消下面两行注释）
            //var sWord = "responseTxt=" + responseTxt + "\n isSign=" + isSign + "\n 返回回来的参数：" + GetPreSignStr(inputPara) + "\n ";
            //LogResult(sWord);
            String.Format("AlipayNotice responseTxt={0}，isSign={1}，返回回来的参数：{2}", responseTxt, isSign, GetPreSignStr(inputPara)).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);

            //判断responsetTxt是否为true，isSign是否为true
            //responsetTxt的结果不是true，与服务器设置问题、合作身份者ID、notify_id一分钟失效有关
            //isSign不是true，与安全校验码、请求时的参数格式（如：带自定义参数等）、编码格式有关
            return responseTxt == "true" && isSign;
        }

        /// <summary>
        /// 获取待签名字符串（调试用）
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <returns>待签名字符串</returns>
        private static string GetPreSignStr(Dictionary<string, string> inputPara)
        {
            //过滤空值、sign与sign_type参数
            var sPara = FilterPara(inputPara);

            //根据字母a到z的顺序把参数排序
            sPara = SortPara(sPara);

            //获取待签名字符串
            var preSignStr = CreateLinkString(sPara);

            return preSignStr;
        }

        /// <summary>
        /// 除去数组中的空值和签名参数
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        private static Dictionary<string, string> FilterPara(Dictionary<string, string> dicArrayPre)
        {
            return dicArrayPre.Where(temp => temp.Key.ToLower() != "sign" && temp.Key.ToLower() != "sign_type" && !String.IsNullOrEmpty(temp.Value)).OrderBy(temp=>temp.Key).ToDictionary(temp => temp.Key, temp => temp.Value);
        }

        /// <summary>
        /// 根据字母a到z的顺序把参数排序
        /// </summary>
        /// <param name="dicArrayPre">排序前的参数组</param>
        /// <returns>排序后的参数组</returns>
        private static Dictionary<string, string> SortPara(Dictionary<string, string> dicArrayPre)
        {
            var dicTemp = new SortedDictionary<string, string>(dicArrayPre);
            var dicArray = new Dictionary<string, string>(dicTemp);

            return dicArray;
        }

        /// <summary>
        /// Creates the link string.
        /// </summary>
        /// <param name="dicArray">The dicArrayDefault documentation</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/10/2014 7:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static string CreateLinkString(Dictionary<string, string> dicArray)
        {
            var prestr = new StringBuilder();
            foreach (var temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + temp.Value + "&");
            }

            //去掉最後一個&字符
            var nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);

            return prestr.ToString();
        }

        /// <summary>
        /// 获取返回时的签名验证结果
        /// </summary>
        /// <param name="inputPara">通知返回参数数组</param>
        /// <param name="sign">对比的签名结果</param>
        /// <returns>
        /// 签名验证结果
        /// </returns>
        private static bool GetSignVeryfy(Dictionary<string, string> inputPara, string sign)
        {
            //过滤空值、sign与sign_type参数
            Dictionary<string, string> sPara = FilterPara(inputPara);

            //根据字母a到z的顺序把参数排序
            sPara = SortNotifyPara(sPara);

            //获取待签名字符串
            var preSignStr = CreateLinkString(sPara);

            //获得签名验证结果
            var isSgin = Verify(preSignStr, sign, Key, InputCharSet);

            return isSgin;
        }

        /// <summary>
        /// 异步通知时，对参数做固定排序
        /// </summary>
        /// <param name="dicArrayPre">排序前的参数组</param>
        /// <returns>排序后的参数组</returns>
        private static Dictionary<string, string> SortNotifyPara(Dictionary<string, string> dicArrayPre)
        {
            var sPara = new Dictionary<string, string>
                {
                    {"service", dicArrayPre["service"]},
                    {"v", dicArrayPre["v"]},
                    {"sec_id", dicArrayPre["sec_id"]},
                    {"notify_data", dicArrayPre["notify_data"]}
                };

            return sPara;
        }
        
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <param name="inputCharset">编码格式</param>
        /// <returns>验证结果</returns>
        private static bool Verify(string prestr, string sign, string key, string inputCharset)
        {
            var mysign = SignMd5(prestr, key, inputCharset);
            return mysign == sign;
        }

        /// <summary>
        /// 获取是否是支付宝服务器发来的请求的验证结果
        /// </summary>
        /// <param name="notifyId">通知验证ID</param>
        /// <returns>验证结果</returns>
        private static string GetResponseTxt(string notifyId)
        {
            var veryfyUrl = HttpsVeryfyUrl + "partner=" + PartnerId + "&notify_id=" + notifyId;

            //获取远程服务器ATN结果，验证是否是支付宝服务器发来的请求
            var responseTxt = Get_Http(veryfyUrl, 120000);

            return responseTxt;
        }

        /// <summary>
        /// 获取远程服务器ATN结果
        /// </summary>
        /// <param name="strUrl">指定URL路径地址</param>
        /// <param name="timeout">超时时间设置</param>
        /// <returns>服务器ATN结果</returns>
        private static string Get_Http(string strUrl, int timeout)
        {
            var myReq = (HttpWebRequest)WebRequest.Create(strUrl);
            myReq.Timeout = timeout;
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();
            if (myStream == null)
            {
                return String.Empty;
            }
            var sr = new StreamReader(myStream, Encoding.Default);
            var strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            var strResult = strBuilder.ToString();

            return strResult;
        }

        public class PaymentQr
        {
            private string _productid = "";
            private string _deviceNumber = "";
            private decimal _customerTotal = 0;
            public PaymentQr(){}
            public PaymentQr(string productid, string deviceNumber, decimal customerTotal)
            {
                _productid = productid;
                _deviceNumber = deviceNumber;
                _customerTotal = customerTotal;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string ToPaymentQr()
            {
                var code = Encoding.GetEncoding(ControllersCommon.AlipayInputCharSet);
                var sParaTemp = new Dictionary<string, string>();
                //合作者身份ID
                sParaTemp.Add("partner", ControllersCommon.AlipayPartnerId);
                //参数编码字符集
                sParaTemp.Add("_input_charset", ControllersCommon.AlipayInputCharSet);
                sParaTemp.Add("service", "alipay.acquire.precreate");
                sParaTemp.Add("out_trade_no", _productid);
                sParaTemp.Add("subject","支付订单");
                sParaTemp.Add("product_code", "QR_CODE_OFFLINE");
                sParaTemp.Add("total_fee", _customerTotal.ToString("F2"));
                //sParaTemp.Add("seller_email", "15140510108");
                sParaTemp.Add("body", "{\"DeviceNumber\":\"" + _deviceNumber + "\"}");
                sParaTemp.Add("notify_url", ControllersCommon.AlipayBackgroundNoticeUrl);
                sParaTemp = BuildRequestPara(sParaTemp);
                sParaTemp["notify_url"] = HttpUtility.UrlEncode(sParaTemp["notify_url"]);
                var uri = ControllersCommon.AlipayGatewayNew + CreateLinkString(sParaTemp);

                //把数组转换成流中所需字节数组类型
                //var bytesRequestData = code.GetBytes(strHtml);

                //设置HttpWebRequest基本信息
                var myReq = (HttpWebRequest)WebRequest.Create(uri);
                myReq.Method = "get";
                myReq.ContentType = "application/x-www-form-urlencoded";

                //填充POST数据
                //myReq.ContentLength = bytesRequestData.Length;

                //Stream requestStream = myReq.GetRequestStream();
                //requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                //requestStream.Close();

                //发送POST数据请求服务器
                var httpWResp = (HttpWebResponse)myReq.GetResponse();
                var myStream = httpWResp.GetResponseStream();

                if (myStream == null)
                {
                    return String.Empty;
                }

                //获取服务器返回信息
                var reader = new StreamReader(myStream, code);
                var responseData = new StringBuilder();
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    responseData.Append(line);
                }

                //释放
                myStream.Close();

                //请求远程HTTP
                var strRequestResult = responseData.ToString();

                var sHtmlText = HttpUtility.UrlDecode(strRequestResult, code);
                if (sHtmlText == null)
                {
                    return String.Empty;
                }
                var bigPicUrl = String.Empty;
                if (strRequestResult.Length > 0)
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(strRequestResult);
                    var selectSingleNode = xmlDoc.SelectSingleNode("/alipay/response/alipay/qr_code");
                    if (selectSingleNode == null)
                    {
                        return "返回结果解析错误";
                    }
                    bigPicUrl = selectSingleNode.InnerText;
                }
                return bigPicUrl;
            }
        }

        /// <summary>
        /// 建立请求，以表单HTML形式构造（默认）
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="strButtonValue">确认按钮显示文字</param>
        /// <returns>提交表单HTML文本</returns>
        public static string BuildRequest(Dictionary<string, string> sParaTemp, string strMethod, string strButtonValue)
        {
            //待请求参数数组
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara = BuildRequestPara(sParaTemp);

            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='alipaysubmit' name='alipaysubmit' action='" + ControllersCommon.AlipayGatewayNew + "_input_charset=" + ControllersCommon.AlipayInputCharSet + "' method='" + strMethod.ToLower().Trim() + "'>");

            foreach (KeyValuePair<string, string> temp in dicPara)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");

            return sbHtml.ToString();
        }
        /// <summary>
        /// 查询订单支付状态
        /// </summary>
        /// <param name="out_trade_no">The out_trade_no</param>
        /// <returns>
        /// 是否已经支付 True 已经支付 False 未支付
        /// </returns>
        /// 创建者：孟祺宙 创建日期：2014/3/17 18:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static PaymentResult<bool> OrderQuery(string out_trade_no)
        {
            var code = Encoding.GetEncoding(ControllersCommon.AlipayInputCharSet);
            var sParaTemp = new Dictionary<string, string>();
            //合作者身份ID
            sParaTemp.Add("partner", ControllersCommon.AlipayPartnerId);
            //参数编码字符集
            sParaTemp.Add("_input_charset", ControllersCommon.AlipayInputCharSet);
            sParaTemp.Add("service", "alipay.acquire.query");
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp = BuildRequestPara(sParaTemp);
            var uri = ControllersCommon.AlipayGatewayNew + CreateLinkString(sParaTemp);

            //设置HttpWebRequest基本信息
            var myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.Method = "get";
            myReq.ContentType = "application/x-www-form-urlencoded";

            //发送POST数据请求服务器
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();

            if (myStream == null)
            {
                return new PaymentResult<bool>
                    {
                        StatusCode = (int)StatusCode.UmPayment.InvalidPaymentNoCode,
                        Result = false
                    };
            }

            //获取服务器返回信息
            var reader = new StreamReader(myStream, code);
            var responseData = new StringBuilder();
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                responseData.Append(line);
            }

            //释放
            myStream.Close();

            //请求远程HTTP
            var strRequestResult = responseData.ToString();

            var sHtmlText = HttpUtility.UrlDecode(strRequestResult, code);
            if (sHtmlText == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.UmPayment.InvalidPaymentNoCode,
                    Result = false
                };
            }
            var tradeStatus = String.Empty;
            if (strRequestResult.Length > 0)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strRequestResult);
                var selectSingleNode = xmlDoc.SelectSingleNode("/alipay/response/alipay/trade_status");
                if (selectSingleNode == null)
                {
                    string.Format("===============================\r\n THE AlipayPaymentCommon OrderQuery not exit /alipay/response/alipay/trade_status:{0} \r\n===============================", out_trade_no).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                    return new PaymentResult<bool>
                    {
                        StatusCode = (int)StatusCode.UmPayment.InvalidPaymentNoCode,
                        Result = false
                    };
                }
                tradeStatus = selectSingleNode.InnerText;
            }
            var payCode = 0;
            var payStatus = false;
            if (tradeStatus.Equals("TRADE_SUCCESS"))
            {
                //交易成功，且可对该交易做操作，如：多级分润、退款等。
                payCode = (int) StatusCode.UmPayment.Ok;
                payStatus = true;
            }
            else if (tradeStatus.Equals("TRADE_FINISHED"))
            {
                //交易成功且结束，即不可再做任何操作 
                payCode = (int) StatusCode.UmPayment.TradeSuccessCode;
                payStatus = true;
            }
            else if (tradeStatus.Equals("TRADE_CLOSED"))
            {
                //在指定时间段内未支付时关闭的交易； 
                //在交易完成全额退款成功时关闭的交易。
                payCode = (int) StatusCode.UmPayment.TradeClosedCode;
                payStatus = false;
            }
            else if (tradeStatus.Equals("TRADE_PENDING"))
            {
                //等待卖家收款（买家付款后，如果卖家账号被冻结）。 
                payCode = (int) StatusCode.UmPayment.TradeFailCode;
                payStatus = false;
            }
            else if (tradeStatus.Equals("WAIT_BUYER_PAY"))
            {
                //交易创建，等待买家付款。 
                payCode = (int) StatusCode.UmPayment.WaitBuyerPayCode;
                payStatus = false;
            }
            return new PaymentResult<bool>
            {
                StatusCode = payCode,
                Result = payStatus
            };
        }

        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的参数数组</returns>
        private static Dictionary<string, string> BuildRequestPara(Dictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            //签名结果
            var mysign = "";

            //过滤签名参数数组
            Dictionary<string, string> sPara = FilterPara(sParaTemp);

            //获得签名结果
            mysign = BuildRequestMysign(sPara);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            sPara.Add("sign_type", "MD5");

            return sPara;
        }
        /// <summary>
        /// 生成请求时的签名
        /// </summary>
        /// <param name="sPara">请求给支付宝的参数数组</param>
        /// <returns>签名结果</returns>
        private static string BuildRequestMysign(Dictionary<string, string> sPara)
        {
            //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            var prestr = CreateLinkString(sPara);
            //把最终的字符串签名，获得签名结果
            var mysign = SignMd5(prestr, Key, ControllersCommon.AlipayInputCharSet);
            return mysign;
        }
    }
}



namespace Ets.SingleApi.Services.Payment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Xml;
    using Ets.SingleApi.Model.Services;

    public static class BaiFuBaoPaymentCommon
    {
        /// <summary>
        /// 校验百付宝回传数据与签名一直
        /// </summary>
        /// <param name="retrunData">The retrunDataDefault documentation</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/10/2014 4:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static bool VerifySignature(BaiFuBaoPaymentBackgroundNoticeData retrunData)
        {
            var dictionary = new SortedList<string, string>(StringComparer.OrdinalIgnoreCase);
            dictionary["bank_no"] = retrunData.bank_no;
            dictionary["bfb_order_no"] = retrunData.bfb_order_no;
            dictionary["bfb_order_create_time"] = retrunData.bfb_order_create_time;
            dictionary["buyer_sp_username"] = retrunData.buyer_sp_username;
            dictionary["currency"] = retrunData.currency;
            dictionary["extra"] = retrunData.extra;
            dictionary["fee_amount"] = retrunData.fee_amount;
            dictionary["input_charset"] = retrunData.input_charset;
            dictionary["order_no"] = retrunData.order_no;
            dictionary["pay_result"] = retrunData.pay_result;
            dictionary["pay_time"] = retrunData.pay_time;
            dictionary["pay_type"] = retrunData.pay_type;
            dictionary["sign_method"] = retrunData.sign_method;
            dictionary["sp_no"] = retrunData.sp_no;
            dictionary["total_amount"] = retrunData.total_amount;
            dictionary["transport_amount"] = retrunData.transport_amount;
            dictionary["unit_amount"] = retrunData.unit_amount;
            dictionary["unit_count"] = retrunData.unit_count;
            dictionary["version"] = retrunData.version;

            var signature = BuildBaiFuBaoSignature(dictionary, retrunData.sign_method);
            //var signature = BuildSignature(dictionary, retrunData.sign_method);

            return System.String.Compare(retrunData.sign, signature, System.StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        /// 百付宝查询订单支付状态
        /// </summary>
        /// <param name="_order_no">The _order_noDefault documentation</param>
        /// <param name="_verifyR">The  _verifyR indicates whether</param>
        /// <returns>
        /// OrderBDInfo
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static BaiFuBaoSearchOrderInfo SendGetInfo(string _order_no, ref  bool _verifyR)
        {
            var orderbdinfo = new BaiFuBaoSearchOrderInfo();
            var xmlDoc = new XmlDocument();
            var dictionary = new SortedList<string, string>(StringComparer.OrdinalIgnoreCase);
            dictionary["order_no"] = _order_no;
            dictionary["output_charset"] = "1";
            dictionary["output_type"] = "1";
            dictionary["service_code"] = "11";
            dictionary["sign_method"] = "1";
            dictionary["sp_no"] = Controllers.ControllersCommon.BaiFuBaoMerchantAcctId;
            dictionary["version"] = "2";
            string signature = BuildSignature(dictionary, "1");
            dictionary["sign"] = signature;
            string strUrl = Controllers.ControllersCommon.RequestForOrderUrl + "?" + BuildRequestURL(dictionary);
            var myReq = (HttpWebRequest)WebRequest.Create(strUrl);
            myReq.Method = "get";

            using (WebResponse response = myReq.GetResponse())
            {
                var HttpWResp = (HttpWebResponse)myReq.GetResponse();
                var myStream = HttpWResp.GetResponseStream();

                //获取服务器返回信息
                var Reader = new XmlTextReader(myStream);
                xmlDoc.Load(Reader);
            }

            dictionary.Clear();
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList xnodeList = xmlDoc.SelectSingleNode("response").ChildNodes;

            foreach (XmlNode node in xnodeList)
            {
                if (!string.IsNullOrEmpty(node.InnerText))
                {
                    switch (node.Name)
                    {
                        case "query_status":
                            orderbdinfo.query_status = node.InnerText;
                            break;
                        case "sp_no":
                            orderbdinfo.sp_no = node.InnerText;
                            break;
                        case "order_no":
                            orderbdinfo.order_no = node.InnerText;
                            break;
                        case "bfb_order_no":
                            orderbdinfo.bfb_order_no = node.InnerText;
                            break;
                        case "bfb_order_create_time":
                            orderbdinfo.bfb_order_create_time = node.InnerText;
                            break;
                        case "pay_time":
                            orderbdinfo.pay_time = node.InnerText;
                            break;
                        case "pay_type":
                            orderbdinfo.pay_type = node.InnerText;
                            break;
                        case "bank_no":
                            orderbdinfo.bank_no = node.InnerText;
                            break;
                        case "goods_name":
                            orderbdinfo.goods_name = node.InnerText;
                            break;
                        case "unit_amount":
                            orderbdinfo.unit_amount = Convert.ToUInt32(node.InnerText);
                            break;
                        case "unit_count":
                            orderbdinfo.unit_count = Convert.ToUInt32(node.InnerText);
                            break;
                        case "transport_amount":
                            orderbdinfo.transport_amount = Convert.ToUInt32(node.InnerText);
                            break;
                        case "total_amount":
                            orderbdinfo.total_amount = Convert.ToUInt32(node.InnerText);
                            break;
                        case "cash_amount":
                            orderbdinfo.cash_amount = Convert.ToUInt32(node.InnerText);
                            break;
                        case "fee_amount":
                            orderbdinfo.fee_amount = Convert.ToUInt32(node.InnerText);
                            break;
                        case "buyer_sp_username":
                            orderbdinfo.buyer_sp_username = node.InnerText;
                            break;
                        case "currency":
                            orderbdinfo.currency = node.InnerText;
                            break;
                        case "pay_result":
                            orderbdinfo.pay_result = node.InnerText;
                            break;
                        case "sign":
                            orderbdinfo.sign = node.InnerText;
                            break;
                        case "sign_method":
                            orderbdinfo.sign_method = node.InnerText;
                            break;
                        case "extra":
                            orderbdinfo.extra = node.InnerText;
                            break;
                        default:
                            break;
                    }
                }
                if (node.Name != "sign")
                    dictionary[node.Name] = node.InnerText;
            }
            signature = BuildSignature(dictionary, orderbdinfo.sign_method);

            _verifyR = System.String.Compare(orderbdinfo.sign, signature, System.StringComparison.OrdinalIgnoreCase) == 0;
            return orderbdinfo;
        }

        /// <summary>
        /// 生成支付签名
        /// </summary>
        /// <param name="dictionary">提交数字字典</param>
        /// <param name="sign_method">签名算法</param>
        /// <returns></returns>
        public static string BuildSignature(SortedList<string, string> dictionary, string sign_method)
        {
            var buffer = (from key in dictionary.Keys let value = dictionary[key] select string.Format("{0}={1}", key, value)).ToList();

            buffer.Add(string.Format("key={0}", Controllers.ControllersCommon.BaiFuBaoSecretKey));
            var content = string.Join("&", buffer);
            return ComputeHash(content, sign_method);
        }

        /// <summary>
        /// 计算SHA1哈希码
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sign_method">签名算法(1.MD5 2.SHA1)</param>
        /// <returns></returns>
        public static string ComputeHash(string content, string sign_method)
        {
            var encoding = Encoding.GetEncoding("gbk");

            HashAlgorithm algorithm = MD5.Create();

            if (sign_method == "2")
            {
                algorithm = SHA1.Create();
            }

            var hashData = algorithm.ComputeHash(encoding.GetBytes(content));
            var qmResult = BitConverter.ToString(hashData).Replace("-", "");

            return qmResult.ToLower();
        }

        /// <summary>
        /// Builds the request URL.
        /// </summary>
        /// <param name="dictionary">The dictionaryDefault documentation</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string BuildRequestURL(SortedList<string, string> dictionary)
        {
            var buffer = (from key in dictionary.Keys let value = dictionary[key] select string.Format("{0}={1}", key, value)).ToList();
            var content = string.Join("&", buffer);
            return content;
        }

        public static string BuildBaiFuBaoSignature(SortedList<string, string> dictionary, string sign_method)
        {
            var strList = (from key in dictionary.Keys let value = dictionary[key] select string.Format("{0}={1}", key, value)).ToList();
            var strUrl = string.Join("&", strList);

            return BuildBaiFuBaoSignature(strUrl, sign_method);
        }
        public static string BuildBaiFuBaoSignature(string url, string sign_method)
        {
            return ComputeHash(url + string.Format("&key={0}", Controllers.ControllersCommon.BaiFuBaoSecretKey), sign_method);
        }

        public static string BuildBaiFuBaoPaymentUrl(BaiFuBaoSubmitParameter baiFuBaoSubmitParameter, bool isEncode = false)
        {
            var strUrlPart = new List<string>();

            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.bank_no))
            {
                strUrlPart.Add(string.Format("bank_no={0}", baiFuBaoSubmitParameter.bank_no));
            }
            strUrlPart.Add(string.Format("buyer_sp_username={0}", baiFuBaoSubmitParameter.buyer_sp_username));
            strUrlPart.Add(string.Format("currency={0}", baiFuBaoSubmitParameter.currency));
            strUrlPart.Add(string.Format("expire_time={0}", baiFuBaoSubmitParameter.expire_time));// DateTime.Now.AddHours(1).ToString("yyyyMMddHHmmss")));
            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.extra))
            {
                strUrlPart.Add(string.Format("extra={0}", baiFuBaoSubmitParameter.extra));
            }
            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.goods_category))
            {
                strUrlPart.Add(string.Format("goods_category={0}", baiFuBaoSubmitParameter.goods_category));
            }
            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.goods_desc))
            {
                strUrlPart.Add(string.Format("goods_desc={0}", isEncode ?
                                         HttpUtility.UrlEncode(
                                         Encoding.Default.GetBytes(baiFuBaoSubmitParameter.goods_desc)) : baiFuBaoSubmitParameter.goods_desc));
            }
            strUrlPart.Add(string.Format("goods_name={0}", isEncode ?
                                         HttpUtility.UrlEncode(
                                         Encoding.Default.GetBytes(baiFuBaoSubmitParameter.goods_name)) : baiFuBaoSubmitParameter.goods_name));
            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.goods_url))
            {
                strUrlPart.Add(string.Format("goods_url={0}", baiFuBaoSubmitParameter.goods_url));
            }
            strUrlPart.Add(string.Format("input_charset={0}", baiFuBaoSubmitParameter.input_charset));
            strUrlPart.Add(string.Format("order_create_time={0}", baiFuBaoSubmitParameter.order_create_time));
            strUrlPart.Add(string.Format("order_no={0}", baiFuBaoSubmitParameter.Order_no));

            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.page_url))
            {
                var pageUrl = isEncode ? (HttpUtility.UrlEncode(baiFuBaoSubmitParameter.page_url) ?? string.Empty).Replace("(", "%28").Replace(")", "%29") : baiFuBaoSubmitParameter.page_url;
                strUrlPart.Add(string.Format("page_url={0}", pageUrl));
            }
            strUrlPart.Add(string.Format("pay_type={0}", baiFuBaoSubmitParameter.pay_type));

            var returnUrl = isEncode ? (HttpUtility.UrlEncode(baiFuBaoSubmitParameter.return_url) ?? string.Empty).Replace("(", "%28").Replace(")", "%29") : baiFuBaoSubmitParameter.return_url;
            strUrlPart.Add(string.Format("return_url={0}", returnUrl));

            strUrlPart.Add(string.Format("service_code={0}", baiFuBaoSubmitParameter.service_code));
            strUrlPart.Add(string.Format("sign_method={0}", baiFuBaoSubmitParameter.sign_method));
            strUrlPart.Add(string.Format("sp_no={0}", baiFuBaoSubmitParameter.sp_no));
            if (!string.IsNullOrEmpty(baiFuBaoSubmitParameter.sp_uno))
            {
                strUrlPart.Add(string.Format("sp_uno={0}", baiFuBaoSubmitParameter.sp_uno));
            }
            strUrlPart.Add(string.Format("total_amount={0}", baiFuBaoSubmitParameter.total_amount));
            strUrlPart.Add(string.Format("transport_amount={0}", baiFuBaoSubmitParameter.transport_amount));
            strUrlPart.Add(string.Format("unit_amount={0}", baiFuBaoSubmitParameter.unit_amount));
            strUrlPart.Add(string.Format("unit_count={0}", baiFuBaoSubmitParameter.unit_count));
            strUrlPart.Add(string.Format("version={0}", baiFuBaoSubmitParameter.version));

            return string.Join("&", strUrlPart);
        }
    }
}

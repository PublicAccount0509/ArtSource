using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;

namespace Ets.SingleApi.Pay.Umpay
{
    public class UmpayService
    {
        /// <summary>
        /// 向支付服务器下单
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <param name="merDate">下单时间</param>
        /// <param name="amount">金额</param>
        /// <returns></returns>
        public Hashtable TranUmpay(string orderID, DateTime merDate, decimal amount, string orderType = "delivery", string ret_url="")
        {
            Hashtable ht = new Hashtable();
            ht.Add("service", "pay_req"); // 接口名称 pay_req:一般支付请求 pay_req_ivr_call:IVR支付方式下单 pay_req_ivr_tcall:IVR转呼方式下单
            ht.Add("sign_type", "RSA"); // 签名方式
            ht.Add("charset", "UTF-8"); // 字符编码
            ht.Add("version", "4.0"); //版本号
            ht.Add("mer_id", "7378"); //商户号
            ht.Add("ret_url", ret_url); // Request.Params["ret_url"]; //页面返回地址
            ht.Add("notify_url", ret_url); //结果通讯地址
            //ht.Add("goods_id", goods_id); //商品号
            //ht.Add("goods_inf", goods_inf); //商品信息
            //ht.Add("media_id", media_id); //媒介标识
            //ht.Add("media_type", media_type); //媒介类型
            ht.Add("order_id", orderID);  //订单号
            ht.Add("mer_date", merDate.ToString("yyyyMMdd")); //订单日期
            ht.Add("amount", AmountToString(amount)); //金额,格式为圆角分，例如:3456表示34圆5角6分
            ht.Add("amt_type", "RMB"); //金额类型
            //ht.Add("pay_type", pay_type); //支付方式
            //ht.Add("gate_id", gate_id);  //默认银行
            ht.Add("mer_priv", orderType); //商户私有信息
            //ht.Add("expand", expand);  //商户扩展信息
            //ht.Add("user_ip", user_ip); //用户IP地址
            //ht.Add("expire_time", expire_time); //订单过期时常
            //string aaa = "";
            //foreach (DictionaryEntry  item in ht)
            //{
            //     aaa += item.Key;
            //     aaa += "|";
            //     aaa += item.Value;
            //}
            //throw new Exception(aaa);
            com.umpay.api.common.ReqData reqData = com.umpay.api.paygate.v40.Mer2Plat_v40.ReqDataByGet(ht); //标准支付下单
            string request = this.HttpGet(reqData.Url); //请求结果
            Hashtable req = com.umpay.api.paygate.v40.Plat2Mer_v40.getResData(request); //解析html
            return req;
        }

        /// <summary>
        /// 查询订单支付结果
        /// </summary>
        /// <param name="orderID">订单号</param>
        /// <param name="merDate">下单时间</param>
        /// <param name="amount">金额</param>
        /// <returns></returns>
        public bool IsPaid(string orderID, DateTime merDate, out string message)
        {
            Hashtable ht = new Hashtable();
            ht.Add("service", "query_order"); // 接口名称 pay_req:一般支付请求 pay_req_ivr_call:IVR支付方式下单 pay_req_ivr_tcall:IVR转呼方式下单
            ht.Add("sign_type", "RSA"); // 签名方式
            ht.Add("charset", "UTF-8"); // 字符编码
            //ht.Add("sign", "UTF-8"); // 字符编码
            ht.Add("version", "4.0"); //版本号
            ht.Add("mer_id", "7378"); //商户号
            //ht.Add("res_format", "");
            ht.Add("order_id", orderID);  //订单号
            ht.Add("mer_date", merDate.ToString("yyyyMMdd")); //订单日期
            com.umpay.api.common.ReqData reqData = com.umpay.api.paygate.v40.Mer2Plat_v40.ReqDataByGet(ht); //标准支付下单
            string request = this.HttpGet(reqData.Url); //请求结果
            Hashtable req = com.umpay.api.paygate.v40.Plat2Mer_v40.getResData(request); //解析html
            if (req["ret_code"].ToString() == "00060760")
            {
                message = "订单不存在";
                return false;
            }
            message = GetTradeState(req["trade_state"].ToString());
            if (req["trade_state"].ToString() == "TRADE_SUCCESS")
            {
                message = "ok";
                return true;
            }
            return false;
        }

        public string GetTradeState(string tradeState)
        {
            switch (tradeState)
            {
                case "WAIT_BUYER_PAY":
                    return "交易创建，等待买家付款。";
                case "TRADE_SUCCESS":
                    return "交易成功，不能再次进行交易";
                case "TRADE_CLOSED":
                    return "交易关闭";
                case "TRADE_CANCEL":
                    return "TRADE_CANCEL";
                case "TRADE_FAIL":
                    return "交易失败";
                default:
                    return "未知错误";
            }
        }

        /// <summary>
        /// 金钱格式转换，34.576会被转换为3457，表示34圆5角7分
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private string AmountToString(decimal amount)
        {
            string str = amount.ToString("C").TrimStart('¥');
            Console.WriteLine(str);
            int n = str.IndexOf(".");
            string pre = str.Substring(0, n);
            string end = str.Substring(n, 3).Trim('.');
            str = pre + end;
            return str;
        }

        /// <summary>
        /// 发起http get请求 取页面内容
        /// </summary>
        /// <param name="URI"></param>
        /// <returns></returns>
        public string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}

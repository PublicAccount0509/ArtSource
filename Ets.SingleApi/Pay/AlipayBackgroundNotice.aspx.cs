using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Xml;
using Ets.SingleApi.Controllers.IServices;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Pay
{
    public partial class AlipayBackgroundNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //StringWriter stringWriter = new StringWriter();
            //HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            //this.Page.RenderControl(htmlWriter);
            //string html = stringWriter.GetStringBuilder().ToString();
            Dictionary<string, string> sPara = GetRequestPost();
            var strResult = sPara.Keys.Aggregate(string.Empty, (current, key) => current + ("&" + key + "=" + sPara[key]));
            string.Format("Alipay-GetRequestPost [ {0} ]", strResult).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                var verifyResult = Ets.SingleApi.Services.AlipayPaymentCommon.VerifyNotify(sPara, Request.Form["sign"]);
                string.Format("Alipay-verifyResult [ {0} ]", verifyResult).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码

                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //解密（如果是RSA签名需要解密，如果是MD5签名则下面一行清注释掉）
                    //sPara = aliNotify.Decrypt(sPara);

                    //XML解析notify_data数据
                    try
                    {
                        /*
                        var xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(sPara["notify_data"]);

                        string.Format("Alipay-notify_data [ {0} ]", sPara["notify_data"]).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);

                        ////商户订单号
                        //var selectSingleNode = xmlDoc.SelectSingleNode("/notify/out_trade_no");
                        //if (selectSingleNode != null)
                        //{
                        //    var outTradeNo = selectSingleNode.InnerText;
                        //}
                        ////支付宝交易号
                        //var singleNode = xmlDoc.SelectSingleNode("/notify/trade_no");
                        //if (singleNode != null)
                        //{
                        //    var tradeNo = singleNode.InnerText;
                        //}
                        //交易状态
                        var xmlNode = xmlDoc.SelectSingleNode("/notify/trade_status");
                        if (xmlNode == null)
                        {
                            Response.Write("fail");
                            return;
                        }

                        var tradeStatus = xmlNode.InnerText;


                        string.Format("Alipay-tradeStatus [ {0} ]", tradeStatus).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                        if (tradeStatus == "TRADE_FINISHED")
                        {
                            
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序
                            //0 不存在 1 支付 2 未支付
                            //注意：
                            //该种交易状态只在两种情况下出现
                            //1、开通了普通即时到账，买家付款成功后。
                            //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。

                            //var payment = CastleUtility.GetInstance().Container.Resolve<IPayment>("")
                            var outTradeNo = xmlDoc.SelectSingleNode("/notify/out_trade_no ");
                            Response.Write("success");  //请不要修改或删除
                        }
                        else if (tradeStatus == "TRADE_SUCCESS")
                        {
                            //判断该笔订单是否在商户网站中已经做过处理
                            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                            //如果有做过处理，不执行商户的业务程序

                            //注意：
                            //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。

                            Response.Write("success");  //请不要修改或删除
                        }
                        else
                        {
                            Response.Write(tradeStatus);
                        }*/
                        var outTradeNo = sPara["out_trade_no"];
                        if (SaveOrderPaId(outTradeNo.ObjectToInt()))
                        {
                            var body = JsonValue.Parse(sPara["body"]);
                            var paymentServices = CastleUtility.GetInstance().Container.Resolve<IPaymentServices>();
                            if (body != null)
                            {
                                //向手机推送消息
                                var pushAppResult = paymentServices.PushApp("", new PushAppParameter { OrderId = outTradeNo, DeviceNumber = body["DeviceNumber"] });
                                string.Format("===============================\r\n THE AlipayBackgroundNotice PaymentState PushApp \r\n {0}\r\n===============================", pushAppResult.Result).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
                            }
                            Response.Write("success");
                        }
                        else
                        {
                            Response.Write("fail");
                        }
                    }
                    catch (Exception exc)
                    {
                        Response.Write(exc.ToString());
                    }
                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 修改订单支付状态
        /// </summary>
        /// <param name="outTradeNo">订单号</param>
        /// <returns>支付结果</returns>
        private bool SaveOrderPaId(int outTradeNo)
        {
            var b = false;
            var orderServices = CastleUtility.GetInstance().Container.Resolve<IOrderServices>();
            var exit = orderServices.Exist("", outTradeNo.ObjectToInt(), 1, 0);
            if (exit.StatusCode == 200)
            {
                if (exit.Result == 2)
                {
                    b = orderServices.SaveOrderPaId("", 1, 0, outTradeNo.ObjectToInt(), true).Result;
                }
            }
            return b;
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public Dictionary<string, string> GetRequestPost()
        {
            int i;
            var sArray = new Dictionary<string, string>();
            //Load Form variables into NameValueCollection variable.
            var coll = Request.Form;

            // Get names of all forms into a string array.
            var requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            string.Format("===============================\r\n THE AlipayBackgroundNotice GetRequestPost sArray \r\n {0}\r\n===============================", CreateLinkString(sArray)).WriteLog("Ets.SingleApi.Debug", Log4NetType.Info);
            return sArray;
        }
        /// <summary>
        /// 生成键对组合：key=value形式，并以 & 分割（调试用）
        /// </summary>
        /// <param name="dicArray"></param>
        /// <returns></returns>
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
    }

}
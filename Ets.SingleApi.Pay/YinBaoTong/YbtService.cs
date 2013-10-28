using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Configuration;

namespace Ets.SingleApi.Pay.YinBaoTong
{
    public class YbtService
    {
        /// <summary>
        /// 订单类型 [dingCan, dingTai]
        /// </summary>
        public string OrderType { get; set; }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="OrderNo"></param>
        /// <param name="amount"></param>
        /// <param name="returnurl"></param>
        /// <param name="cancelurl">异常url</param>
        public void YbtCard(HttpResponseBase Response, string OrderNo, string amount,string returnurl,string cancelurl)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("merchant", YbtService.YbtMerchant());
            sParaTemp.Add("amount", amount);
            sParaTemp.Add("ture_return", returnurl); //正常返回url
            sParaTemp.Add("cancel_return", cancelurl); //异常返回url
            sParaTemp.Add("order_item", OrderNo); //订单号
            sParaTemp.Add("order_name", "订单名称");//订单名称
            sParaTemp.Add("return_stat", "ok"); //返回状态
            //sParaTemp.Add("backUrl", ""); //后台返回地址
            string c = YbtVerify(OrderNo, amount);
            sParaTemp.Add("verifycode", YbtVerify(OrderNo, amount)); //交易校验码
            string sHtmlText = BuildFormHtml(sParaTemp, "https://pay.ybtcard.com/netGate/webscr.do", "post", "确认");
            Response.Write(sHtmlText);
            Response.End();
        }

        /// <summary>
        /// 生成中欣银宝通校验码
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <param name="amount">订单金额</param>
        /// <returns></returns>
        public static string YbtVerify(string OrderNo, string amount)
        {
            //*校验格式为md5加密（订单号&订单金额&商户校验码）
            return md5(OrderNo + "&" + amount + "&" + YbtVerifyCode());
        }

        /// <summary>
        /// 中欣银宝通商户校验码
        /// </summary>
        /// <returns></returns>
        public static string YbtVerifyCode()
        {
            return "801FE0EE90129DB0595C8E2F9E6738B8";
        }

        /// <summary>
        /// 中欣银宝通商户编号
        /// </summary>
        /// <returns></returns>
        public static string YbtMerchant()
        {
            return "819599900160001";
        }

        public static string md5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// 构造提交表单HTML数据
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <param name="gateway">网关地址</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="strButtonValue">确认按钮显示文字</param>
        /// <returns>提交表单HTML文本</returns>
        public string BuildFormHtml(SortedDictionary<string, string> sParaTemp, string gateway, string strMethod, string strButtonValue)
        {
            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='payform' name='mpi_form' action='" + gateway + "' method='" + strMethod.ToLower().Trim() + "'>");

            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['payform'].submit();</script>");

            return sbHtml.ToString();
        }
    }
}
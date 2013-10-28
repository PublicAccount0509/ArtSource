using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Ets.SingleApi.Pay.Allscore
{
    /// <summary>
    /// 类名：Service
    /// 功能：奥斯卡各接口构造类
    /// 详细：构造奥斯卡各接口请求参数
    /// 版本：1.0
    /// 修改日期：2011-12-20
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究奥斯卡接口使用，只是提供一个参考
    /// 
    /// 要传递的参数要么不允许为空，要么就不要出现在数组与隐藏控件或URL链接里。
    /// </summary>
    public class Service
    {
        #region 字段
        //商户ID
        private string _merchantId = "";
        //字符编码格式
        private string _input_charset = "";
        //终端号
        private string _terminalId = "";

        //奥斯卡网关地址（支付）
        private string Allscore_Gateway = "https://pay.allscore.com/serviceDirect.htm";
        //奥斯卡订单查询网关地址
        private string Allscore_query_gateway = "https://pay.allscore.com/orderQuery.htm";
        //奥斯卡订单退货网关地址
        private string Allscore_refund_geteway = "https://pay.allscore.com/returnGoods.htm";

        //奥斯卡快捷登录地址
        private string Allscore_login_geteway = "https://pay.allscore.com/login.htm";

        #endregion

        /// <summary>
        /// 构造函数
        /// 从配置文件及入口文件中初始化变量
        /// </summary>
        public Service()
        {
            _merchantId = Config.MerchantId.Trim();
            _input_charset = Config.Input_charset.Trim();
            _terminalId = Config.TerminalId.Trim();

            
        }

        /// <summary>
        /// 构造即时到帐接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string directPay(SortedDictionary<string, string> sParaTemp,string return_url,string notify_url)
        {
            //增加基本配置
            sParaTemp.Add("service", "directPay");
            sParaTemp.Add("merchantId", _merchantId);
            sParaTemp.Add("inputCharset", _input_charset);
            sParaTemp.Add("terminalId", _terminalId);
            sParaTemp.Add("returnUrl", return_url);
            sParaTemp.Add("notifyUrl", notify_url);

            //确认按钮显示文字
            string strButtonValue = "奥斯卡支付";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, Allscore_Gateway, "post", strButtonValue);

            return strHtml;
        }


        /// <summary>
        /// 构造订单查询接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string query(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "orderQuery");
            sParaTemp.Add("merchantId", _merchantId);
            sParaTemp.Add("inputCharset", _input_charset);
            sParaTemp.Add("terminalId", _terminalId);


            //确认按钮显示文字
            string strButtonValue = "订单查询";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, Allscore_query_gateway, "get", strButtonValue);

            return strHtml;
        }



        /// <summary>
        /// 构造订单退货接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string refund(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "returnGoods");
            sParaTemp.Add("merchantId", _merchantId);
            sParaTemp.Add("inputCharset", _input_charset);
            sParaTemp.Add("terminalId", _terminalId);


            //确认按钮显示文字
            string strButtonValue = "订单查询";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, Allscore_refund_geteway, "get", strButtonValue);

            return strHtml;
        }



        /// <summary>
        /// 构造提交地址
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交URL地址</returns>
        public string createUrl(SortedDictionary<string, string> sParaTemp,string return_url,string notify_url)
        {
            //增加基本配置
            sParaTemp.Add("service", "directPay");
            sParaTemp.Add("merchantId", _merchantId);
            sParaTemp.Add("inputCharset", _input_charset);
            sParaTemp.Add("terminalId", _terminalId);
            sParaTemp.Add("returnUrl", return_url);
            sParaTemp.Add("notifyUrl", notify_url);


            //表单提交地址
            string strURL = "";

            //构造表单提交HTML数据
            strURL = Submit.BuildRequestUrl(sParaTemp);

            return Allscore_Gateway+strURL;
        }



        //******************若要增加其他奥斯卡接口，可以按照下面的格式定义******************//
        /// <summary>
        /// 构造(奥斯卡接口名称)接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML文本或者奥斯卡返回XML处理结果</returns>
        public string AllscoreInterface(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置

            //表单提交HTML数据变量
            string strHtml = "";


            //构造请求参数数组


            //构造给奥斯卡处理的请求
            //请求方式有以下三种：
            //1.构造表单提交HTML数据:Submit.BuildFormHtml()
            //2.构造模拟远程HTTP的POST请求，获取奥斯卡的返回处理结果:Submit.SendPostInfo()
            //3.构造模拟远程HTTP的GET请求，获取奥斯卡的返回处理结果:Submit.SendGetInfo()
            //请根据不同的接口特性三选一


            return strHtml;
        }

        /// <summary>
        /// 构造快捷登录接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string login(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "quick.login");
            sParaTemp.Add("merchantId", _merchantId);
            sParaTemp.Add("inputCharset", _input_charset);
            sParaTemp.Add("terminalId", _terminalId);
            

            //确认按钮显示文字
            string strButtonValue = "奥斯卡快捷登录";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildFormHtml(sParaTemp, Allscore_login_geteway, "post", strButtonValue);

            return strHtml;
        }
    }
}
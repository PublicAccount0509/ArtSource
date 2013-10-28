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
    /// 类名：Submit
    /// 功能：奥斯卡各接口请求提交类
    /// 详细：构造奥斯卡各接口表单HTML文本，获取远程HTTP数据
    /// 版本：1.0
    /// 修改日期：2011-12-20
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究奥斯卡接口使用，只是提供一个参考
    /// </summary>
    public class Submit
    {
        #region 字段
        //交易安全校验码
        private static string _key = "";
        //编码格式
        private static string _input_charset = "";

        #endregion

        static Submit()
        {
            _key = Config.Key.Trim();
            _input_charset = Config.Input_charset.Trim();
        }



        /// <summary>
        /// 生成要请求给奥斯卡的参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的参数数组</returns>
        private static Dictionary<string, string> BuildRequestPara(SortedDictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            sPara = Core.FilterPara(sParaTemp);

            //获得签名结果
            mysign = Core.BuildMysign(sPara, _key, _input_charset);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            

            return sPara;
        }



        /// <summary>
        /// 生成要请求给奥斯卡的参数数组
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的参数数组字符串</returns>
        private static string BuildRequestParaToString(SortedDictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            sPara = BuildRequestPara(sParaTemp);

            //把参数组中所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string strRequestData = Core.CreateLinkString(sPara);

            return strRequestData;
        }



        /// <summary>
        /// 生成要请求给奥斯卡的URL地址
        /// </summary>
        /// <param name="sParaTemp">请求前的参数数组</param>
        /// <returns>要请求的到奥斯卡的URL地址</returns>
        public static string BuildRequestUrl(SortedDictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            sPara = BuildRequestPara(sParaTemp);

            //把参数组中所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string strRequestData = Core.CreateLinkString(sPara);

            return strRequestData;
        }




        /// <summary>
        /// 构造提交表单HTML数据
        /// </summary>
        /// <param name="sParaTemp">请求参数数组</param>
        /// <param name="gateway">网关地址</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="strButtonValue">确认按钮显示文字</param>
        /// <returns>提交表单HTML文本</returns>
        public static string BuildFormHtml(SortedDictionary<string, string> sParaTemp, string gateway, string strMethod, string strButtonValue)
        {
            //待请求参数数组
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara = BuildRequestPara(sParaTemp);

            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='allscoresubmit' name='allscoresubmit' action='" + gateway +  "' method='" + strMethod.ToLower().Trim() + "'>");

            foreach (KeyValuePair<string, string> temp in dicPara)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");

            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['allscoresubmit'].submit();</script>");

            return sbHtml.ToString();
        }




    }

}
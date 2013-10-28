using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using mpiclient;
using mpiclient.common;
using mpiclient.data;
using System.Text;
using System.Xml.Linq;

namespace Ets.SingleApi.Pay.YaGao
{
    /// <summary>
    /// 雅高支付接口服务类
    /// </summary>
    public class MpiService
    {
        protected string _basePath = System.AppDomain.CurrentDomain.BaseDirectory + "Pay\\YaGao\\";
        //转入虚拟卡号
        private string _cardNoIn = "6036818831100011277";  //可随意填写



        /// <summary>
        /// 获取支付接口地址
        /// </summary>
        /// <returns>支付接口地址</returns>
        private string GetGateWay()
        {
            XElement xelem = XElement.Load(GetMpiPropPath());
            return xelem.Element("HostPay.URL").Value;
        }

        /// <summary>
        /// 商户号
        /// </summary>
        /// <returns></returns>
        public virtual string GetMerchantID()
        {
            return "0000040781";
        }

        /// <summary>
        /// 获取mpi配置文件地址
        /// </summary>
        /// <returns></returns>
        public virtual string GetMpiPropPath()
        {
            return _basePath + "MPIProperties.xml";
        }

        public string PayTrans(string orderNo, string amount, string ip, string return_url, string cardNo = "", string cvv = "")
        {
            PathConfig.setLoggerXmlPath(_basePath + "logger.xml");
            PathConfig.setMpiPropPath(this.GetMpiPropPath());
            PathConfig.setMpiXmlPath(_basePath + "MPIReq.xml");
            OrderData inData = new OrderData();
            inData.InitOrderData();

            inData.setTranCode("8888");  //交易类型，8888表示支付
            inData.setMerchantID(GetMerchantID());
            inData.setMerOrderNum(orderNo);  //订单号
            inData.setTranAmt(amount);  //交易金额
            inData.setTranDateTime(DateTime.Now.ToString("yyyyMMddHHMMss")); //交易时间
            inData.setCurrencyType("156"); //币种，156表示人民币
            inData.setMerURL(return_url);
            inData.setVirCardNoIn(_cardNoIn);
            inData.setTranIP(ip);//交易IP
            inData.setMsgExt(string.Format("C0$ETSH${0}${1}", cardNo, cvv));

            string res = TopPayLink.InPayTrans(inData);
            return WritePost(res);

        }

        public void PayTrans(HttpResponseBase response, string orderNo, string amount, string ip, string MerUrl)
        {
            PathConfig.setLoggerXmlPath(_basePath + "logger.xml");
            PathConfig.setMpiPropPath(this.GetMpiPropPath());
            PathConfig.setMpiXmlPath(_basePath + "MPIReq.xml");

            OrderData inData = new OrderData();
            inData.InitOrderData();

            inData.setTranCode("8888");  //交易类型，8888表示支付
            inData.setMerchantID(GetMerchantID());
            inData.setMerOrderNum(orderNo);  //订单号
            inData.setTranAmt(amount);  //交易金额
            inData.setTranDateTime(DateTime.Now.ToString("yyyyMMddHHMMss")); //交易时间
            inData.setCurrencyType("156"); //币种，156表示人民币
            inData.setMerURL(MerUrl);
            inData.setVirCardNoIn(_cardNoIn);
            inData.setTranIP(ip);//交易IP

            string res = TopPayLink.InPayTrans(inData);
            WritePost(response, res);
        }

        /// <summary>
        /// 发送交易请求
        /// </summary>
        /// <param name="response">目标请求响应对象</param>
        /// <param name="transData">加密后的post交易数据</param>
        public void WritePost(HttpResponseBase response, string transData)
        {

            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("Version", "1.0.0");
            sParaTemp.Add("MPIReq", transData);

            string sHtmlText = BuildFormHtml(sParaTemp, GetGateWay(), "post", "确认");
            response.Write(sHtmlText);
            response.End();
        }


        /// <summary>
        /// 解析mpi回调传回的数据
        /// </summary>
        /// <param name="itRes"></param>
        /// <returns></returns>
        public OrderData ConvXmlToOrderData(string itRes)
        {
            PathConfig.setLoggerXmlPath(_basePath + "logger.xml");
            PathConfig.setMpiPropPath(this.GetMpiPropPath());
            PathConfig.setMpiXmlPath(_basePath + "MPIReq.xml");
            return TopPayLink.ConvXmlToOrderData(itRes);
        }

        /// <summary>
        /// 发送交易请求
        /// </summary>
        /// <param name="response">目标请求响应对象</param>
        /// <param name="transData">加密后的post交易数据</param>
        public string WritePost(string transData)
        {

            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("Version", "1.0.0");
            sParaTemp.Add("MPIReq", transData);

            string sHtmlText = BuildFormHtml(sParaTemp, GetGateWay(), "post", "确认");
            return sHtmlText;
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

            sbHtml.Append("<form id='mpi_form' name='mpi_form' action='" + gateway + "' method='" + strMethod.ToLower().Trim() + "'>");

            foreach (KeyValuePair<string, string> temp in sParaTemp)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['mpi_form'].submit();</script>");

            return sbHtml.ToString();
        }
    }
}
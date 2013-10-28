/***
 * 1.在web.config <system.serviceModel> -><bindings> -><basicHttpBinding>加入如下节点
    <binding name="ETSHServiceHttpBinding" closeTimeout="00:01:00" openTimeout="00:01:00" receiveTimeout="00:10:00" sendTimeout="00:01:00"
                    allowCookies="false" bypassProxyOnLocal="false" hostNameComparisonMode="StrongWildcard"
                    maxBufferSize="65536" maxBufferPoolSize="524288" maxReceivedMessageSize="65536"
                    messageEncoding="Text" textEncoding="utf-8" transferMode="Buffered"
                    useDefaultWebProxy="true">
                    <readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384"
                        maxBytesPerRead="4096" maxNameTableCharCount="16384" />
                    <security mode="None">
                        <transport clientCredentialType="None" proxyCredentialType="None"
                            realm="" />
                        <message clientCredentialType="UserName" algorithmSuite="Default" />
                    </security>
    </binding>
 * 
 * 2.在web.config  <system.serviceModel> -><bindings> -><client> 加入如下节点
    <endpoint address="http://218.242.136.178:19080/ivrServer/ETSHService" binding="basicHttpBinding" bindingConfiguration="ETSHServiceHttpBinding" 
    contract="IEtkYaoGao.ETSHServicePortType" name="ETSHServiceHttpPort" />
 * 
 * 3.如不明白请下载 ssh://git@10.8.8.5:8118/data/git/Ets.My.git 项目查看web.config中的配置
 * ***/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Ets.SingleApi.Pay.Etk
{
    /// <summary>
    /// 易淘卡功能处理,如查询余额等.需对web.config进行配置,具体方法进入本类查看说明.
    /// </summary>
    public class Edit
    {

        IEtkYaoGao.ETSHServicePortTypeClient ets = new IEtkYaoGao.ETSHServicePortTypeClient();
        public const string STR_AUTHCODE = "ETAOSHI_201210100117";

        /// <summary>
        /// 查询余额
        /// </summary>
        /// <param name="CardNo">卡号</param>
        public string QueryAmount(string CardNo)
        {
            string strReturn = ets.ETSH_Card_Balance_Inquery(CardNo, STR_AUTHCODE);
            return ConvertStatus(strReturn);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="CardNo">卡号</param>
        /// <param name="OldPwd">旧密码</param>
        /// <param name="NewPwd">新密码</param>
        /// <param name="Cvv">CVV</param>
        public string ModifyPassword(string CardNo, string OldPwd, string NewPwd, string Cvv)
        {
            string strReturn = ets.ETSH_Card_Change_Pin(CardNo, OldPwd, NewPwd, Cvv.ToString(), STR_AUTHCODE);
            return ConvertStatus(strReturn);
        }

        /// <summary>
        /// 转换状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ConvertStatus(string str)
        {
            switch (str)
            {
                case "0":
                    str = "成功";
                    break;
                case "-1":
                    str = "卡号错误";
                    break;
                case "-2":
                    str = "授权码或卡号不正确";
                    break;
                case "-3":
                    str = "原始密码或CVV错误";
                    break;
                case "-4":
                    str = "其他错误";
                    break;
            }
            return str;
        }
    }
}

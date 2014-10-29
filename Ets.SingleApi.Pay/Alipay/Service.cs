using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Ets.SingleApi.Pay.Alipay
{
    /// <summary>
    /// 类名：Service
    /// 功能：支付宝各接口构造类
    /// 详细：构造支付宝各接口请求参数
    /// 版本：3.2
    /// 创建日期：2014-10-27
    /// 说明：
    /// 新的支付宝接口（示例代码2012-07-05 版本3.3）里面并没有提供此Service，此Service通过提供的示例页面代码编写而成
    /// </summary>
    public class Service
    {
        public Service()
        {
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        //接口调用时间
        private string timestamp = string.Empty;
        //页面跳转同步返回页面文件路径
        private string _return_url = "";
        //服务器通知的页面文件路径
        private string _notify_url = "";
        //支付宝网关地址（新）
        private string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
        public Service(string _r_url, string _n_url)
        {
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _return_url = _r_url;
            _notify_url = _n_url;
        }

        /// <summary>
        /// 二维码管理接口请求数组
        /// </summary>
        /// <param name="biztyp">业务类型 说明：当method=add/modify时不可空，否则不需要传</param>
        /// <param name="biz_data">业务数据 格式：JSON 大字符串，详见技术文档4.2.1章节</param>
        /// <param name="method">动作 说明：商户码（友宝售货机码）目前只支持add。</param>
        /// <returns></returns>
        public SortedDictionary<string, string> GetQrcodeManageSParaTemp(AlipayMethodEnum method,AlipayBiztypEnum biztyp, string biz_data)
        {
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            //合作者身份ID
            sParaTemp.Add("partner", Config.Partner);
            //参数编码字符集
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            //签名方式(本接口只支持MD5方式。)
            //sParaTemp.Add("sign_type","MD5");
            sParaTemp.Add("service", "alipay.mobile.qrcode.manage");
            sParaTemp.Add("timestamp", timestamp);
            sParaTemp.Add("method", method.ToString().ToLower());
            sParaTemp.Add("biz_type", ((int)biztyp).ToString());
            sParaTemp.Add("biz_data", biz_data);
            sParaTemp.Add("return_url", _return_url);
            sParaTemp.Add("notify_url", _notify_url);
            return sParaTemp;
        }

        /// <summary>
        /// 构造即时到帐接口
        /// </summary>
        /// <param name="sParaTemp">请求参数集合</param>
        /// <returns>表单提交HTML信息</returns>
        public string Create_direct_pay_by_user(SortedDictionary<string, string> sParaTemp)
        {
            //增加基本配置
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("seller_email", Config.Seller_email);
            sParaTemp.Add("return_url", _return_url);
            sParaTemp.Add("notify_url", _notify_url);

            //确认按钮显示文字
            string strButtonValue = "确认";
            //表单提交HTML数据
            string strHtml = "";

            //构造表单提交HTML数据
            strHtml = Submit.BuildRequest(sParaTemp, "get", strButtonValue);

            return strHtml;
        }

        /// <summary>
        /// 创建商品二维码
        /// </summary>
        /// <param name="sParaTemp"></param>
        /// <param name="strHtml">模拟post登录的HTML</param>
        /// <returns>验证是否成功</returns>
        public bool AddMobileQrcodeManage(SortedDictionary<string, string> sParaTemp,out string strHtml)
        {
            strHtml = string.Empty;
            if (!sParaTemp.ContainsKey("biz_type"))
            {
                return false;
            }
            if (!sParaTemp.ContainsKey("biz_data"))
            {
                return false;
            }
            //合作者身份ID
            sParaTemp.Add("partner", Config.Partner);
            //参数编码字符集
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "alipay.mobile.qrcode.manage");
            sParaTemp.Add("timestamp", timestamp);
            sParaTemp.Add("method", AlipayMethodEnum.Add.ToString());
            //sParaTemp.Add("biz_type", ((int)AlipayBiztypEnum.GoodsCode).ToString());
            //sParaTemp.Add("biz_data", biz_data);
            sParaTemp.Add("return_url", _return_url);
            sParaTemp.Add("notify_url", _notify_url);
            //确认按钮显示文字
            string strButtonValue = "确认";
            //表单提交HTML数据

            //构造表单提交HTML数据
            strHtml = Submit.BuildRequest(sParaTemp, "post", strButtonValue);
            return true;
        }
    }
}
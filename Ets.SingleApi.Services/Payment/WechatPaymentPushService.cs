
namespace Ets.SingleApi.Services.Payment
{
    using Ets.MessagePlat.Services;
    using Ets.SingleApi.Utility;

    using Newtonsoft.Json;

    /// <summary>
    /// 类名称：WechatPaymentPushService
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/8 9:42
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPaymentPushService
    {
        /// <summary>
        /// Notifies the MSG.
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// String
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/8/8 14:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool NotifyMsg(int orderId)
        {
            IEtsPush push = new IEtsPush();
            //单推消息类型
            SingleMessage message = new SingleMessage();

            //发送模版      
            TransmissionTemplate template = new TransmissionTemplate();
            // token
            template.AppId = "user_wechat_huangtaiji";        //token
            template.AppKey = "36f02c9bee5412389bd701c0f500fa7";      //appkey
            template.ClientId = "user_wechat_singleapi_huangtaiji";  //clientid
            //template.PackageName = info.fromPackageName;    //packagename
            template.TransmissionContent = JsonConvert.SerializeObject(new
                                                                           {
                                                                               StatusCode = (int)StatusCode.Succeed.Ok,
                                                                               OrderId = orderId,
                                                                               IsPaid = true
                                                                           });

            //通知模板
            NotificationTemplate notify = new NotificationTemplate();
            notify.NotifyContent = JsonConvert.SerializeObject(new
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                OrderId = orderId,
                IsPaid = true
            });
            notify.NotifyVoice = "default";
            notify.NotifyTitle = "xxx";
            NotifyAction action = new NotifyAction();
            action.action_type = 1;
            action.activity = "";
            BrowserAction browser = new BrowserAction();
            browser.url = "";
            action.browser = browser;
            notify.action = action;
            //notify.NotifyStyleType = 1;   // 客户端配置
            //notify.AllowDisturb = true;   // 客户端配置
            message.setData(template);
            message.setOfflineData(notify);
            //用户当前不在线时，是否离线存储,可选
            message.setOffline(false);
            //离线有效时间，单位为毫秒，可选，老版本单位为小时，请升级至最新版本
            message.setOfflineExpireTime(72 * 3600 * 1000);
            message.isAsync = true;
            // 单条信息推送有QOS质量保证体系控制
            message.qosInfo = 1;    //1、2一样 推送并离线保存 3 务必收到
            message.pushType = 1;   //推送类型1-推送、2-通知
            Target target = new Target();
            target.AppId = "H4F6RA9322000071";
            target.ClientId = "user_0";
            //单推
            IPushResult ret = push.pushMessageToSingle(message, target);
            return ret.result;
        }
    }

}

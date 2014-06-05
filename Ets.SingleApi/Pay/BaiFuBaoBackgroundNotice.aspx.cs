namespace Ets.SingleApi.Pay
{
    using System;
    using System.Text;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.Payment;

    public partial class BaiFuBaoBackgroundNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var returnData = new BaiFuBaoPaymentBackgroundNoticeData
            {
                bank_no = Request["bank_no"],
                sp_no = Request["sp_no"],
                order_no = Request["order_no"],
                bfb_order_no = Request["bfb_order_no"],
                bfb_order_create_time = Request["bfb_order_create_time"],
                pay_time = Request["pay_time"],
                pay_type = Request["pay_type"],
                unit_amount = Request["unit_amount"],
                unit_count = Request["unit_count"],
                transport_amount = Request["transport_amount"],
                total_amount = Request["total_amount"],
                fee_amount = Request["fee_amount"],
                currency = Request["currency"],
                buyer_sp_username = Request["buyer_sp_username"],
                pay_result = Request["pay_result"],
                input_charset = Request["input_charset"],
                version = Request["version"],
                sign_method = Request["sign_method"],
                sign = Request["sign"],
                extra = Request["extra"]
            };

            if (!BaiFuBaoPaymentCommon.VerifySignature(returnData)) return;

            //
            if (returnData.pay_result != "1") return;

            var builder = new StringBuilder();

            builder.AppendFormat("<html>");
            builder.AppendFormat("   <head>");
            builder.AppendFormat("       <meta name=\"VIP_BFB_PAYMENT\" content=\"BAIFUBAO\" >");
            builder.AppendFormat("   </head>");
            builder.AppendFormat("</html>");

            Response.Write(builder.ToString());
        }
    }
}
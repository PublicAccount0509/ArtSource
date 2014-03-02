
namespace Ets.SingleApi.Services
{
    using System;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Controllers;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.Payment;

    /// <summary>
    /// 类名称：WaiMaiUmPayment
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：百付宝支付
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：02/10/2014 1:54 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WaiMaiBaiFuBaoPayment : IPayment
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiUmPayment"/> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public WaiMaiBaiFuBaoPayment(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
        }

        /// <summary>
        /// 取得支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 2:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentType PaymentType
        {
            get
            {
                return PaymentType.BaiFuBaoPayment;
            }
        }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 3:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderType OrderType
        {
            get
            {
                return OrderType.WaiMai;
            }
        }

        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="parameter">支付参数</param>
        /// <returns>
        /// 支付结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<string> Payment(IPaymentData parameter)
        {
            var baiFuBaoPaymentQueryData = parameter as BaiFuBaoPaymentData;
            if (baiFuBaoPaymentQueryData == null)
            {
                return new PaymentResult<string> { Result = string.Empty, StatusCode = (int)StatusCode.System.InvalidPaymentRequest };
            }

            var subpara = new BaiFuBaoSubmitParameter();
            var amount = AmountToString(baiFuBaoPaymentQueryData.Amount);
            subpara.goods_name = baiFuBaoPaymentQueryData.GoodsName;
            subpara.Order_no = baiFuBaoPaymentQueryData.OrderId;
            subpara.total_amount = amount;//总金额
            subpara.transport_amount = "0";//附加费用金额
            subpara.unit_amount = amount;//单价
            subpara.unit_count = "1";//数量
            subpara.page_url = baiFuBaoPaymentQueryData.PageUrl;//前台通知
            subpara.return_url = ControllersCommon.BaiFuBaoBackgroundNoticeUrl;//后台通知

            subpara.bank_no = "301";
            subpara.expire_time = DateTime.Now.AddDays(2).ToString("yyyyMMddHHmmss");
            subpara.order_create_time = DateTime.Now.ToString("yyyyMMddHHmmss");
            subpara.goods_desc = "desc";
            subpara.buyer_sp_username = "po";
            subpara.pay_type = "2";
            subpara.extra = "ext";
            subpara.sp_no = ControllersCommon.BaiFuBaoMerchantAcctId;

            const string signMethod = "1"; //加密规则 1 MID5，2 SHA1
            var result = ControllersCommon.InstantToAccountUrlWapNotBaiDuLogin + "?" + BaiFuBaoPaymentCommon.BuildBaiFuBaoPaymentUrl(subpara, true) + "&sign=" + BaiFuBaoPaymentCommon.BuildBaiFuBaoSignature(BaiFuBaoPaymentCommon.BuildBaiFuBaoPaymentUrl(subpara), signMethod);

            return new PaymentResult<string> { Result = result, StatusCode = (int)StatusCode.Succeed.Ok };
        }

        /// <summary>
        /// 查询支付状态
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：02/10/2014 1:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaymentResult<bool> QueryState(IPaymentData parameter)
        {
            var baiFuBaoPaymentQueryData = parameter as BaiFuBaoPaymentQueryData;
            if (baiFuBaoPaymentQueryData == null)
            {
                return new PaymentResult<bool>
                    {
                        StatusCode = (int)StatusCode.System.InvalidPaymentRequest
                    };
            }

            //查询订单支付状态
            var isdsd = false;
            var orderInfo = BaiFuBaoPaymentCommon.SendGetInfo(baiFuBaoPaymentQueryData.OrderId.ToString(), ref isdsd);

            if (!isdsd)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }

            //pay_result：1 支付成功，2 等待支付；3 退款成功
            if (orderInfo.pay_result != "1")
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidPaymentRequest,
                    Result = false
                };
            }

            //查询订单配送信息
            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == baiFuBaoPaymentQueryData.OrderId);
            if (deliveryEntity == null)
            {
                return new PaymentResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            //更新订单支付状态为 已支付
            deliveryEntity.IsPaId = true;
            this.deliveryEntityRepository.Save(deliveryEntity);

            return new PaymentResult<bool>
            {
                StatusCode = (int)StatusCode.UmPayment.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 金钱格式转换，34.576会被转换为3457，表示34圆5角7分
        /// </summary>
        /// <param name="amount">The amount</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string AmountToString(decimal amount)
        {
            var str = amount.ToString("C").TrimStart('¥').Replace(",", string.Empty);
            var n = str.IndexOf(".", StringComparison.Ordinal);
            var pre = str.Substring(0, n);
            var end = str.Substring(n, 3).Trim('.');
            return pre + end;
        }
    }
}
﻿namespace Ets.SingleApi.UnitTest.Utility
{
    /// <summary>
    /// 类名称：StatusCode
    /// 命名空间：Ets.SingleApi.UnitTest.Utility
    /// 类功能：状态码
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 20:23
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class StatusCode
    {
        /// <summary>
        /// 成功状态
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum Succeed
        {
            /// <summary>
            /// 操作成功
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            Ok = 200,

            /// <summary>
            /// 查询结果为空
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:39
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            Empty = 201
        }

        /// <summary>
        /// 标准OAuth错误
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum OAuth
        {
            /// <summary>
            /// 服务器错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            ServerError = 10000,

            /// <summary>
            /// 请求参数错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidRequest = 10001,

            /// <summary>
            /// 禁止访问
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            AccessDenied = 10002,

            /// <summary>
            /// 不支持的认证响应类型
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnsupportedResponseType = 10003,

            /// <summary>
            /// 权限范围无效
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidScope = 10004,

            /// <summary>
            /// 临时的服务器维护或者过载，无法处理请求
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            TemporarilyUnavailable = 10005,

            /// <summary>
            /// 未认证的客户端
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnauthorizedClient = 10006,

            /// <summary>
            /// 客户端认证失败(未知客户端、不支持的认证方法等)
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidClient = 10007,

            /// <summary>
            /// 授权无效
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidGrant = 10008,

            /// <summary>
            /// 不支持的授权类型
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnsupportedGrantType = 10009
        }

        /// <summary>
        /// 系统错误码
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum System
        {
            /// <summary>
            /// 未知错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnknowError = 1000,

            /// <summary>
            /// 签名错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidSign = 1001,

            /// <summary>
            /// 内部服务器错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InternalServerError = 1002,

            /// <summary>
            /// 请求参数错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidRequest = 1003,

            /// <summary>
            /// 请求验证失败
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            Unauthorized = 1004,

            /// <summary>
            /// 支付参数错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidPaymentRequest = 1005,
        }

        /// <summary>
        /// 一般错误
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum General
        {
            /// <summary>
            /// 未知错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnknowError = 20000,

            /// <summary>
            /// 权限错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            ErrorPermission = 20001,

            /// <summary>
            /// 资源不存在
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UriNotFound = 20002,

            /// <summary>
            /// 请求参数格式错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:25
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidRequest = 20003,

            /// <summary>
            /// 短信发送失败
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/17 21:41
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            SmsSendError = 20004,

            /// <summary>
            /// 发送短信过于频繁
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/17 21:41
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            SmsSendFrequent = 20005,

            /// <summary>
            /// 参数错误，无法找回密码
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 11:40
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidFindPasswordWay = 20006,

            /// <summary>
            /// 订单号无法找到
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/25/2013 2:19 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            OrderNumberNotFound = 20007
        }

        /// <summary>
        /// 校验错误
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum Validate
        {
            /// <summary>
            /// 您已是易淘食用户，直接登录叫外卖即可。
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:48
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            ExistUserCode = 40000,

            /// <summary>
            /// 邮箱已经被占用
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/17 16:46
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            ExistEmailCode = 40001,

            /// <summary>
            /// 手机号不能为空
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/17 16:46
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            EmptyTelephoneCode = 40002,

            /// <summary>
            /// 无效的短信发送类型（易淘食：AC001，外卖：AC002）
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/17 22:43
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidAuthCodeType = 40003,

            /// <summary>
            /// 验证码错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:45
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidAuthCode = 40004,

            /// <summary>
            /// 用户名错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:49
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidUserNameCode = 40005,

            /// <summary>
            /// 用户Id错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:49
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidUserIdCode = 40006,

            /// <summary>
            /// 密码错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/15 20:49
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidPasswordCode = 40007,

            /// <summary>
            /// 密码不能为空
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 10:00
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            EmptyPasswordCode = 40008,

            /// <summary>
            /// 无效的餐厅Id列表
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 10:00
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidSupplierIdListCode = 40009,

            /// <summary>
            /// 无效的餐厅Id
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 10:00
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidSupplierIdCode = 40010,

            /// <summary>
            /// 无效的用户地址Id列表
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 10:00
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidCustomerAddressIdListCode = 40011,

            /// <summary>
            /// 无效的用户地址Id
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/19 10:00
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidCustomerAddressIdCode = 40012,

            /// <summary>
            /// 无效的订单类型
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/21 15:29
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidOrderTypeCode = 40013,

            /// <summary>
            /// 无效的订单Id
            /// </summary>
            /// 创建者：周超
            /// 创建日期：2013/10/21 15:29
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidOrderIdCode = 40014
        }

        /// <summary>
        /// 支付状态码
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/28/2013 2:42 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public enum UmPayment
        {
            /// <summary>
            /// 交易成功
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            Ok = 200,

            /// <summary>
            /// 未知错误
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            UnknowErrorCode = 80000,

            /// <summary>
            /// 交易创建，等待买家付款。
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            WaitBuyerPayCode = 80001,

            /// <summary>
            /// 交易成功，不能再次进行交易
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            TradeSuccessCode = 80002,

            /// <summary>
            /// 交易关闭
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            TradeClosedCode = 80003,

            /// <summary>
            /// 交易取消
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            TradeCancelCode = 80004,

            /// <summary>
            /// 交易失败
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/28/2013 2:47 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            TradeFailCode = 80005,

            /// <summary>
            /// 无效交易号
            /// </summary>
            /// 创建者：周超
            /// 创建日期：10/29/2013 4:07 PM
            /// 修改者：
            /// 修改时间：
            /// ----------------------------------------------------------------------------------------
            InvalidPaymentNoCode = 80006
        }
    }
}
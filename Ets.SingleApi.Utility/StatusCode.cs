﻿﻿namespace Ets.SingleApi.Utility
 {
     /// <summary>
     /// 类名称：StatusCode
     /// 命名空间：Ets.SingleApi.Utility
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

             /// <summary>
             /// 无效的请求地址
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidRequestUrl = 1006
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
             InvalidOrderIdCode = 40014,

             /// <summary>
             /// 无效的餐厅菜单类型Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：2013/10/21 15:29
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidSupplierMenuCategoryTypeIdCode = 40015,

             /// <summary>
             /// 旧密码错误
             /// </summary>
             /// 创建者：周超
             /// 创建日期：2013/10/15 20:49
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidOldPasswordCode = 40016,

             /// <summary>
             /// 新密码不能为空
             /// </summary>
             /// 创建者：周超
             /// 创建日期：2013/10/19 10:00
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             EmptyNewPasswordCode = 40017,

             /// <summary>
             /// 无效的餐厅菜Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidSupplierDishIdCode = 40018,

             /// <summary>
             /// 无效的餐厅菜类别Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidSupplierCategoryIdCode = 40019,

             /// <summary>
             /// 无效的餐厅域名
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidSupplierDomainCode = 40020,

             /// <summary>
             /// 该时间段不提供送餐
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidDeliveryTimeCode = 40021,

             /// <summary>
             /// 该时间段不提供取餐
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidPickUpTimeCode = 40022,

             /// <summary>
             /// 购物车为空
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             EmptyShoppingCartCode = 40023,

             /// <summary>
             /// 无效的送餐方式
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidDeliveryMethodId = 40024,

             /// <summary>
             /// 无效的套餐Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidPackageId = 40025,

             /// <summary>
             /// 无效的百度轻应用程序Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidApplicationId = 40026,

             /// <summary>
             /// 未达到餐厅的最低消费，不能下单
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidShoppingPrice = 40027,

             /// <summary>
             /// 无效的支付方式
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidPaymentType = 40028,

             /// <summary>
             /// 订单已经支付成功，请勿重复支付
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             DoublePayment = 40029,

             /// <summary>
             /// 无效的购物车Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidShoppingCartIdCode = 40030,

             /// <summary>
             /// 没有找到对应的购物车
             /// </summary>
             /// 创建者：周超
             /// 创建日期：11/13/2013 3:10 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             NotFondShoppingCartCode = 40031,

             /// <summary>
             /// 该时间段不提供订台，或商户未设置台位时段
             /// </summary>
             /// 创建者：苏建峰
             /// 创建日期：3/19/2014 5:30 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidBookingTimeCode = 40032,

             /// <summary>
             /// 该台位
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             AleadyQueueCode = 40033,

             /// <summary>
             /// 该台位信息不存在
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             NotFondDeskTypeCode = 40034,

             /// <summary>
             /// 无效的排队Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidQueueIdCode = 40035,

             /// <summary>
             /// 么么哒，你的餐品尚未达到起送金额，继续加菜吧*0*
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             NotFixedDeliveryFeeCode = 40036,

             /// <summary>
             /// 订台台位已被锁定
             /// </summary>
             /// 创建者：苏建峰
             /// 创建日期：3/22/2014 8:46 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             DeskTypeIsLocked = 40037,

             /// <summary>
             /// 该桌号信息不存在
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidDeskNumCode = 40038,

             /// <summary>
             /// 该排队号已经过期或者就座，无法取消
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidCancelledQueueStateIdCode = 40039,

             /// <summary>
             /// 该排队号已经取消，无法再次取消
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             AleadyCancelledQueueCode = 40040,
             /// <summary>
             /// 该餐厅已下架
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             OffTheShelfCode = 40041,

             /// <summary>
             /// 预订时间已过，请重新选择预订时间
             /// </summary>
             /// 创建者：王巍
             /// 创建日期：3/31/2014 5:32 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             OverReservation = 40042,

             /// <summary>
             /// 无效的优惠码
             /// </summary>
             /// 创建者：单琪彬
             /// 创建日期：4/21/2014 4:43 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidCouponCode = 40043,

             /// <summary>
             /// 未查到该用户Id
             /// </summary>
             /// 创建者：单琪彬
             /// 创建日期：5/14/2014 1:32 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             NotFoundCustomerId = 40044,

             /// <summary>
             /// 无效的当面付Id
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidDirectPayIdCode = 40045,

             /// <summary>
             /// 该当面付已过期，无法取消
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidCancelledDirectPayStateIdCode = 40046,
             /// <summary>
             /// 该当面付号已经取消，无法再次取消
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             AleadyCancelledDirectPayCode = 40047,

             /// <summary>
             /// 修改新密码不能与旧密码相同
             /// </summary>
             /// 创建者：王巍
             /// 创建日期：5/23/2014 9:26 AM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             NewPasswordNotSameOldPassword = 40048
         }

         /// <summary>
         /// 定位状态码
         /// </summary>
         /// 创建者：周超
         /// 创建日期：10/28/2013 2:42 PM
         /// 修改者：
         /// 修改时间：
         /// ----------------------------------------------------------------------------------------
         public enum Location
         {
             /// <summary>
             /// 定位成功
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             Ok = 200,

             /// <summary>
             /// 无效地址
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidAddressCode = 50000,

             /// <summary>
             /// 无效城市名
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidCityCode = 50001,

             /// <summary>
             /// 无效定位类型
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             InvalidLocationTypeCode = 50002,

             /// <summary>
             /// 定位错误，请检查地址或城市名是否正确
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/28/2013 2:47 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             LocationErrorCode = 50003
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
             InvalidPaymentNoCode = 80006,

             /// <summary>
             /// 联动优势ReqDataByGet返回值为空
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             PaymentReqDataByGetErrorCode = 80007,

             /// <summary>
             /// 联动优势GetResData返回值为空
             /// </summary>
             /// 创建者：周超
             /// 创建日期：10/29/2013 4:07 PM
             /// 修改者：
             /// 修改时间：
             /// ----------------------------------------------------------------------------------------
             PaymentGetResDataErrorCode = 80008
         }
     }
 }
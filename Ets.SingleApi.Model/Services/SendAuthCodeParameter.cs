﻿namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：SendAuthCodeParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：发送短信验证码参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:52
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SendAuthCodeParameter
    {
        /// <summary>
        /// 设置或获取手机号
        /// </summary>
        /// <value>
        /// 手机号
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// 设置或获取短信验证的服务类型，服务端根据不同的服务类型发送不同的短信文字(supplier_reg:餐厅注册 user_reg:用户注册)
        /// </summary>
        /// <value>
        /// 短信验证的服务类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Type { get; set; }

        /// <summary>
        /// 设置或获取发送时间
        /// </summary>
        /// <value>
        /// 发送时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double? Second { get; set; }
    }
}
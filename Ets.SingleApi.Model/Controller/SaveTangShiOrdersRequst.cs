﻿using System.Collections.Generic;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SaveTangShiOrdersParameter
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：保存堂食订单传入参数
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：5/14/2014 9:42 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveTangShiOrdersRequst : ApiRequst
    {
        /// <summary>
        /// 订单来源
        /// </summary>
        /// <value>
        /// 订单来源
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:44 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Source { get; set; }
        /// <summary>
        /// 设置或取得订单路径信息
        /// </summary>
        /// <value>
        /// 订单路径信息
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Path { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        /// <value>
        /// 客户名称
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        /// <value>
        /// 客户性别
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:47 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CustomerSex { get; set; }
        /// <summary>
        /// 桌号
        /// </summary>
        /// <value>
        /// 桌号
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:47 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TableNo { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        /// <value>
        /// 订单备注
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:48 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Remark { get; set; }
        /// <summary>
        /// 临时订单号
        /// </summary>
        /// <value>
        /// 临时订单号
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:48 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TempOrderNumber { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <value>
        /// 支付方式
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 11:58 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PayMentMethodId { get; set; }

        /// <summary>
        /// 菜品列表
        /// </summary>
        /// <value>
        /// 菜品列表
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 9:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierDishItem> SupplierDishList { get; set; }
    }
}
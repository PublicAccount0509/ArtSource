﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：LightFeature
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅开通功能列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 11:35 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class LightFeature
    {
        /// <summary>
        /// 设置或取得餐厅功能Id
        /// </summary>
        /// <value>
        /// 餐厅功能Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierGroupFeatureId { get; set; }

        /// <summary>
        /// 设置或取得功能Id
        /// </summary>
        /// <value>
        /// 功能Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int FeatureId { get; set; }

        /// <summary>
        /// 设置或取得功能名称
        /// </summary>
        /// <value>
        /// 功能名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string FeatureName { get; set; }
    }
}
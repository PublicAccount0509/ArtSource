﻿namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierRecommendedDish
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：3/27/2014 3:30 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierRecommendedDish
    {
        /// <summary>
        /// 推荐菜品Id
        /// </summary>
        /// <value>
        /// 推荐菜品Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// 推荐菜品名称
        /// </summary>
        /// <value>
        /// 推荐菜品名称
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishName { get; set; }

        /// <summary>
        /// 菜品分类
        /// </summary>
        /// <value>
        /// 菜单分类
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/12/2014 7:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierCatogryId { get; set; }

        /// <summary>
        /// 菜单分类
        /// </summary>
        /// <value>
        /// 菜单分类
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/12/2014 7:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierMenuCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Price of SupplierDishModel
        /// </summary>
        /// <value>
        /// The Price
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 11:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the ImagePath of SupplierDishModel
        /// </summary>
        /// <value>
        /// The ImagePath
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ImagePath { get; set; }

        /// <summary>
        /// 设置或取得商品类型
        /// </summary>
        /// <value>
        /// 商品类型 0 菜 1 小料 2 锅底 3 套餐 4 专人服务
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/23/2013 6:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Type { get; set; }

        /// <summary>
        /// 食谱
        /// </summary>
        /// <value>
        /// 食谱
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Recipe { get; set; }

        /// <summary>
        /// Gets or sets the PackagingFee of SupplierDishModel
        /// </summary>
        /// <value>
        /// The PackagingFee
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? PackagingFee { get; set; }
    }
}

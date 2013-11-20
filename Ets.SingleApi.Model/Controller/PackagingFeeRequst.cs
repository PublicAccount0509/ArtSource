namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 类名称：PackagingFeeRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：打包费参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 9:35
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PackagingFeeRequst : ApiRequst
    {
        /// <summary>
        /// Gets or sets the DishList of PackagingFeeRequst
        /// </summary>
        /// <value>
        /// The DishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 23:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<PackagingFeeItem> DishList { get; set; }
    }
}
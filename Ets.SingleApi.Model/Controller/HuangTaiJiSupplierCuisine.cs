namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：HuangTaiJiSupplierCuisine
    /// 命名空间：Ets.SingleApi.Model.Cont
    /// 类功能：黄太极菜品信息
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：2013/12/25 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiSupplierCuisine
    {
        /// <summary>
        /// Gets or sets the CategoryId of HuangTaiJiSupplierCuisine
        /// </summary>
        /// <value>
        /// The CategoryId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName of HuangTaiJiSupplierCuisine
        /// </summary>
        /// <value>
        /// The CategoryName
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishList of HuangTaiJiSupplierCuisine
        /// </summary>
        /// <value>
        /// The SupplierDishList
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiSupplierDishDetail> SupplierDishList { get; set; }
    }
}
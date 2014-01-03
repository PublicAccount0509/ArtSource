using System.Collections.Generic;
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HuangTaiJiSupplierDishDetail
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：黄太极菜品明细信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiSupplierDishDetail
    {
       
        /// <summary>
        /// Gets or sets the SupplierDishId of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// Gets or sets the DishName of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The Name
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DishName { get; set; }

        /// <summary>
        /// Gets or sets the DishDescription of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The DishDescription
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DishDescription { get; set; }

        /// <summary>
        /// Gets or sets the Price of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The Price
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 11:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Recipe of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The Recipe
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Recipe { get; set; }

        /// <summary>
        /// Gets or sets the AverageRating of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The AverageRating
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the Recommended of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The Recommended
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Recommended { get; set; }

        /// <summary>
        /// Gets or sets the PackagingFee of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The PackagingFee
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? PackagingFee { get; set; }

        /// <summary>
        /// Gets or sets the IsCommission of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The IsCommission
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsCommission { get; set; }

        /// <summary>
        /// Gets or sets the IsDiscount of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The IsDiscount
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsDiscount { get; set; }

        /// <summary>
        /// Gets or sets the SupplierCategoryId of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The SupplierCategoryId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 10:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The CategoryId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 10:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName of the HuangTaiJiSupplierDishDetail.
        /// </summary>
        /// <value>
        /// The CategoryName
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 10:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the ImagePath of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The ImagePath
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ImagePath { get; set; }


        /// 增加辅菜
        /// <summary>
        /// Gets or sets the SupplierDishOptionGroups of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The SupplierDishOptionGroups
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiSupplierDishOptionGroup> SupplierDishOptionGroups { get; set; }

        /// 增加子菜单
        /// <summary>
        /// Gets or sets the SubSupplierDishDetail of HuangTaiJiSupplierDishDetail
        /// </summary>
        /// <value>
        /// The SubSupplierDishDetail
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiSupplierDishDetail> SubSupplierDishDetail { get; set; }

    }
}
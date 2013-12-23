namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：PackageDishModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：套餐菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PackageDishModel
    {
        /// <summary>
        /// Gets or sets the PackageContentId of PackageDishModel
        /// </summary>
        /// <value>
        /// The PackageContentId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PackageContentId { get; set; }

        /// <summary>
        /// Gets or sets the DefaultNum of PackageDishModel
        /// </summary>
        /// <value>
        /// The DefaultNum
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? DefaultNum { get; set; }

        /// <summary>
        /// Gets or sets the CanSelectCount of PackageDishModel
        /// </summary>
        /// <value>
        /// The CanSelectCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CanSelectCount { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishId of PackageDishModel
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishName of PackageDishModel
        /// </summary>
        /// <value>
        /// The Name
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishName { get; set; }

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
        /// Gets or sets the Price of PackageDishModel
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
        /// Gets or sets the Recipe of PackageDishModel
        /// </summary>
        /// <value>
        /// The Recipe
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Recipe { get; set; }

        /// <summary>
        /// Gets or sets the SuppllierDishDescription of SupplierDishModel
        /// </summary>
        /// <value>
        /// The SuppllierDishDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SuppllierDishDescription { get; set; }

        /// <summary>
        /// Gets or sets the AverageRating of SupplierDishModel
        /// </summary>
        /// <value>
        /// The AverageRating
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the Recommended of SupplierDishModel
        /// </summary>
        /// <value>
        /// The Recommended
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Recommended { get; set; }

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
        /// Gets or sets the IsCommission of SupplierDishModel
        /// </summary>
        /// <value>
        /// The IsCommission
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsCommission { get; set; }

        /// <summary>
        /// Gets or sets the IsDiscount of SupplierDishModel
        /// </summary>
        /// <value>
        /// The IsDiscount
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsDiscount { get; set; }

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
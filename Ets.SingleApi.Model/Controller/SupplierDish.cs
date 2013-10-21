namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SimpleSupplierDish
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDish
    {
        /// <summary>
        /// Gets or sets the SupplierDishId of SimpleSupplierDish
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
        /// Gets or sets the SupplierDishName of SimpleSupplierDish
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
        /// Gets or sets the Price of SupplierDish
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
        /// Gets or sets the Recipe of SupplierDish
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
        /// Gets or sets the SuppllierDishDescription of SupplierDish
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
        /// Gets or sets the AverageRating of SupplierDish
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
        /// Gets or sets the Recommended of SupplierDish
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
        /// Gets or sets the ImagePath of SupplierDish
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
        /// Gets or sets the IsCommission of SupplierDish
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
        /// Gets or sets the IsDiscount of SupplierDish
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
    }
}
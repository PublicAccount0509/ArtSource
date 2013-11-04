namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：SaveSupplierDishModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：餐厅菜
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/1/2013 4:22 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SaveSupplierDishModel
    {
        /// <summary>
        /// Gets or sets the CategoryId of SaveSupplierDishModel
        /// </summary>
        /// <value>
        /// The CategoryId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 5:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishId of SaveSupplierDishModel
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
        /// Gets or sets the SupplierDishName of SaveSupplierDishModel
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
        /// Gets or sets the SupplierDishNo of SaveSupplierDishModel
        /// </summary>
        /// <value>
        /// The SupplierDishNo
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierDishNo { get; set; }

        /// <summary>
        /// Gets or sets the Price of SaveSupplierDishModel
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
        /// 设置或取得打包费
        /// </summary>
        /// <value>
        /// 打包费
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 12:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// 设置或取得库存
        /// </summary>
        /// <value>
        /// 库存
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 12:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int StockLevel { get; set; }

        /// <summary>
        /// 设置或取得辣度
        /// </summary>
        /// <value>
        /// 辣度
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 12:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SpicyLevel { get; set; }

        /// <summary>
        /// 设置或取得配方
        /// </summary>
        /// <value>
        /// 配方
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Recipe { get; set; }

        /// <summary>
        /// Gets or sets the SuppllierDishDescription of SaveSupplierDishModel
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
        /// 设置或取得是否推荐
        /// </summary>
        /// <value>
        /// 是否推荐
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Recommended { get; set; }

        /// <summary>
        /// 设置或取得餐厅是否对易淘食打折
        /// </summary>
        /// <value>
        /// 餐厅是否对易淘食打折
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsCommission { get; set; }

        /// <summary>
        /// 设置或取得易淘食是否对用户打折
        /// </summary>
        /// <value>
        /// 易淘食是否对用户打折
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 12:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsDiscount { get; set; }

        /// <summary>
        /// 设置或取得是否素菜
        /// </summary>
        /// <value>
        /// 是否素菜
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/3/2013 3:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsVegetarian { get; set; }

        /// <summary>
        /// Gets or sets the ImagePath of SaveSupplierDishModel
        /// </summary>
        /// <value>
        /// The ImagePath
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 16:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ImagePath { get; set; }
    }
}
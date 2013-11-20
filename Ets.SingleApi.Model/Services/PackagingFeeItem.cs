namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：PackagingFeeItem
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：打包费
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:49 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PackagingFeeItem
    {
        /// <summary>
        /// Gets or sets the Price of PackagingFeeItem
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
        /// Gets or sets the PackagingFee of PackagingFeeItem
        /// </summary>
        /// <value>
        /// The PackagingFee
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of PackagingFeeItem
        /// </summary>
        /// <value>
        /// The Quantity
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Quantity { get; set; }
    }
}
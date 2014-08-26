
namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierDishCustomizationOptionModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：CustomizationOption
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/19 17:25
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDishCustomizationOption
    {
        /// <summary>
        /// OptionID
        /// </summary>
        /// <value>
        /// The OptionId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OptionId { get; set; }

        /// <summary>
        /// Gets or sets the OptionGroupId of SupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The OptionGroupId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OptionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the OptionTitle of SupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The OptionTitle
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:22
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OptionTitle { get; set; }

        /// <summary>
        /// Gets or sets the Price of SupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The Price
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:22
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Price { get; set; }

    }
}

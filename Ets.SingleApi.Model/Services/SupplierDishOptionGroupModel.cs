
namespace Ets.SingleApi.Model.Services
{


    /// <summary>
    /// 类名称：SupplierDishOptionGroupModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：OptionGroup
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/19 17:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDishOptionGroupModel
    {
        /// <summary>
        /// Gets or sets the SupplierDishId of SupplierDishOptionGroupModel
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 20:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// OptionGroupID
        /// </summary>
        /// <value>
        /// The OptionGroupId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:17
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OptionGroupId { get; set; }

        /// <summary>
        /// OptionGroupTitle
        /// </summary>
        /// <value>
        /// The OptionGroupTitle
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OptionGroupTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsMultiple
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsMultiple { get; set; }

        /// <summary>
        /// 免费数量
        /// </summary>
        /// <value>
        /// The FreeNum
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int FreeNum { get; set; }

        /// <summary>
        /// 是否必选
        /// </summary>
        /// <value>
        /// The IsMandatory
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsMandatory { get; set; }

        /// <summary>
        /// SupplierDishCustomization.MinValue
        /// </summary>
        /// <value>
        /// The MinValue
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal MinValue { get; set; }

        /// <summary>
        /// SupplierDishCustomization.MaxValue
        /// </summary>
        /// <value>
        /// The MaxValue
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal MaxValue { get; set; }

        /// <summary>
        /// 此分组下的详细选项
        /// </summary>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/19 17:26
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierDishCustomizationOptionModel[] SupplierDishCustomizationOption;


    }

}

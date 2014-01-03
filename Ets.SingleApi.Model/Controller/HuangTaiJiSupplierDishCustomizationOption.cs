using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HuangTaiJiSupplierDishCustomizationOption
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：黄太极菜品明细辅菜选项组明细
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：2013/12/25 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiSupplierDishCustomizationOption
    {
        /// <summary>
        /// Gets or sets the SupplierDishCustomizationOptionId of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SupplierDishCustomizationOptionId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishCustomizationOptionId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishOptionGroupId of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SupplierDishOptionGroupId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishOptionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishOptionTitle of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SupplierDishOptionTitle
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishOptionTitle { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishPrice of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SupplierDishPrice
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? SupplierDishPrice { get; set; }


        /// <summary>
        /// Gets or sets the SupplierDishQuantity of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SupplierDishQuantity
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishQuantity { get; set; }

        /// <summary>
        /// Gets or sets the SpecialInstruction of HuangTaiJiSupplierDishCustomizationOption
        /// </summary>
        /// <value>
        /// The SpecialInstruction特定备注信息
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SpecialInstruction { get; set; }
    }
}

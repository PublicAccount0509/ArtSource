using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：HuangTaiJiSupplierDishOptionGroup
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：黄太极菜品明细辅菜选项组
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：2013/12/25 14:54
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiSupplierDishOptionGroup
    {

        /// <summary>
        /// Gets or sets the SupplierDishId of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The SupplierDishId
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierDishId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDishOptionGroupIsMultiple of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The SupplierDishOptionGroupIsMultiple
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? SupplierDishOptionGroupIsMultiple { get; set;  }

        /// <summary>
        /// Gets or sets the SupplierDishOptionGroupId of HuangTaiJiSupplierDishOptionGroup
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
        /// Gets or sets the SupplierDishOptionGroupTitle of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The SupplierDishOptionGroupTitle
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishOptionGroupTitle { get; set;  }

        /// <summary>
        /// Gets or sets the IsDropDown of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The IsDropDown
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? IsDropDown { get; set;  }

        /// <summary>
        /// Gets or sets the MinValue of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The MinValue
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? MinValue { get; set;  }

        /// <summary>
        /// Gets or sets the MaxValue of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The MaxValue
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? MaxValue { get; set; }

        // 增加辅菜
        /// <summary>
        /// Gets or sets the SupplierDishCustomizationOption of HuangTaiJiSupplierDishOptionGroup
        /// </summary>
        /// <value>
        /// The SupplierDishCustomizationOption
        /// </value>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 12:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<HuangTaiJiSupplierDishCustomizationOption> SupplierDishCustomizationOption { get; set; }
    }
}

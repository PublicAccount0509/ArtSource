using System.Collections.Generic;
namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：HuangTaiJiWaiMaiOrderDishModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：黄太极外卖订单
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：2013/12/25 15:44
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiWaiMaiOrderDishModel
    {
        public int OrderId { get; set;  }

        public int? OrderParentId { get; set;  }
        /// <summary>
        /// 设置或取得菜Id
        /// </summary>
        /// <value>
        /// 菜Id
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierDishId { get; set; }

        /// <summary>
        /// 设置或取得菜名
        /// </summary>
        /// <value>
        /// 菜名
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDishName { get; set; }

        /// <summary>
        /// 设置或取得菜备注
        /// </summary>
        /// <value>
        /// 菜备注
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 9:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SpecialInstruction { get; set; }

        /// <summary>
        /// 设置或取得菜数量
        /// </summary>
        /// <value>
        /// 菜数量
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Quantity { get; set; }

        /// <summary>
        /// 设置或取得菜价格
        /// </summary>
        /// <value>
        /// 菜价格
        /// </value>
        /// 创建者：殷超
        /// 创建日期：12/25/2013 5:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? Price { get; set; }

        // 子订单
        public List<HuangTaiJiWaiMaiOrderDishModel> list { get; set;  }
    }
}
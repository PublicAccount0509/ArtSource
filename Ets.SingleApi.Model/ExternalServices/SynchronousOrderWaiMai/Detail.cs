namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：SupplierDishInfo
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：菜品信息
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：5/22/2014 3:59 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class detail
    {
        /// <summary>
        /// 菜品id supplierdishid
        /// </summary>
        /// <value>
        /// the id
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:59 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int id { get; set; }

        /// <summary>
        /// 菜品数量 quantity
        /// </summary>
        /// <value>
        /// the number
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:59 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int number { get; set; }

        /// <summary>
        /// 菜品价格 supplierprice
        /// </summary>
        /// <value>
        /// the price
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:58 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal? price { get; set; }

        /// <summary>
        /// 菜品描述 specialinstruction
        /// </summary>
        /// <value>
        /// the note
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:58 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string note { get; set; }

        /// <summary>
        /// 菜品名称 supplierdishname
        /// </summary>
        /// <value>
        /// the name
        /// </value>
        /// 创建者：王巍
        /// 创建日期：5/22/2014 3:58 pm
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string name { get; set; }
    }
}

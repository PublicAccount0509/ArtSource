namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierDish
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：桌位类型
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 5:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TableType
    {
        /// <summary>
        /// 桌位类型Id
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Id { get; set; }

        /// <summary>
        /// 桌位类型名称（大中小桌）
        /// </summary>
        /// <value>
        /// The type of the room.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TblTypeName { get; set; }
    }
}
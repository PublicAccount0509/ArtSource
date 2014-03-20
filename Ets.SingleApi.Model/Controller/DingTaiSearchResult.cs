namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：DingTaiSearchResult
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：订台检索结果
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：3/19/2014 5:19 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiSearchResult
    {
        /// <summary>
        /// 房间类型：0 散座，1 包房
        /// </summary>
        /// <value>
        /// The RoomTypeId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int RoomTypeId { get; set; }

        /// <summary>
        /// 房间类型：0 散座，1 包房
        /// </summary>
        /// <value>
        /// The name of the room type.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RoomTypeName { get; set; }

        /// <summary>
        /// 小桌，中桌，大桌
        /// </summary>
        /// <value>
        /// The name of the table type.
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TableTypeName { get; set; }

        /// <summary>
        /// 最小就餐人数
        /// </summary>
        /// <value>
        /// The MinNumber
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string MinNumber { get; set; }

        /// <summary>
        /// 最大就餐人数
        /// </summary>
        /// <value>
        /// The MaxNumber
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string MaxNumber { get; set; }

        /// <summary>
        /// 押金
        /// </summary>
        /// <value>
        /// The DepositAmount
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/19/2014 4:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DepositAmount { get; set; }
    }
}
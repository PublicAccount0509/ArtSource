namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetUserOrderParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：查询用户订单参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/12/2013 10:06 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetUserOrderParameter
    {
        /// <summary>
        /// Gets or sets the OrderStatus of GetUserOrderParameter
        /// </summary>
        /// <value>
        /// The OrderStatus
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the PaidStatus of GetUserOrderParameter
        /// </summary>
        /// <value>
        /// The PaidStatus
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? PaidStatus { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of GetUserOrderParameter
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierGroupId of GetUserOrderParameter
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierGroupId { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PageIndex { get; set; }
    }
}
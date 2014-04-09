namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：UserOrdersParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：查询用户订单参数
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/12/2013 10:06 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UserOrdersParameter
    {
        /// <summary>
        /// Gets or sets the CustomerId of UserOrdersParameter
        /// </summary>
        /// <value>
        /// The CustomerId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of UserOrdersParameter
        /// </summary>
        /// <value>
        /// The OrderStatus
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierGroupId of UserOrdersParameter
        /// </summary>
        /// <value>
        /// The OrderStatus
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierGroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsEtaoshi
        /// </value>
        /// 创建者：周超
        /// 创建日期：1/16/2014 9:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsEtaoshi { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatus of UserOrdersParameter
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
        /// Gets or sets the PaidStatus of UserOrdersParameter
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

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The Cancelled
        /// </value>
        /// 创建者：周超
        /// 创建日期：3/15/2014 4:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Cancelled { get; set; }

        /// <summary>
        /// 平台Id
        /// </summary>
        /// <value>
        /// The PlatformId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 11:57 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? PlatformId { get; set; }
    }
}
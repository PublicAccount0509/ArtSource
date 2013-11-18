namespace Ets.SingleApi.Model.Controller
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：AddWaiMaiOrderRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：添加外卖订单实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:46 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderRequst
    {
        /// <summary>
        /// Gets or sets the UserId of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryMethodId of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DeliveryMethodId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeliveryMethodId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryInstruction of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DeliveryInstruction
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 10:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryInstruction { get; set; }

        /// <summary>
        /// Gets or sets the Template of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The Template
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 10:05 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Template { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The InvoiceRequired
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? InvoiceRequired { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceTitle of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The InvoiceTitle
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string InvoiceTitle { get; set; }

        /// <summary>
        /// Gets or sets the Path of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The Path
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the OrderNotes of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The OrderNotes
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OrderNotes { get; set; }

        /// <summary>
        /// Gets or sets the AreaId of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The AreaId
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:45 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? AreaId { get; set; }

        /// <summary>
        /// Gets or sets the IpAddress of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The IpAddress
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:45 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the IsTakeInvoice of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The IsTakeInvoice
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:48 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsTakeInvoice { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryDate of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DeliveryDate
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/18/2013 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryTime of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DeliveryTime
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/18/2013 12:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryType of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DeliveryType
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/18/2013 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeliveryType { get; set; }

        /// <summary>
        /// Gets or sets the DishList of AddWaiMaiOrderRequst
        /// </summary>
        /// <value>
        /// The DishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:47 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<AddWaiMaiOrderDish> DishList { get; set; }
    }
}
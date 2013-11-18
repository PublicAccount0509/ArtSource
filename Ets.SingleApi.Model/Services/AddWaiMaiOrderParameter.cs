namespace Ets.SingleApi.Model.Services
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：AddWaiMaiOrderModel
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：添加外卖订单实体
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 5:46 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AddWaiMaiOrderParameter
    {
        /// <summary>
        /// Gets or sets the UserId of AddWaiMaiOrderModel
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
        /// Gets or sets the DeliveryMethodId of AddWaiMaiOrderModel
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
        /// Gets or sets the SupplierId of AddWaiMaiOrderModel
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
        /// Gets or sets the DeliveryInstruction of AddWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The DeliveryInstruction
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 10:05 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryInstruction { get; set; }

        /// <summary>
        /// Gets or sets the Template of AddWaiMaiOrderParameter
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
        /// Gets or sets the InvoiceTitle of AddWaiMaiOrderParameter
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
        /// Gets or sets the Path of AddWaiMaiOrderParameter
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
        /// Gets or sets the OrderNotes of AddWaiMaiOrderParameter
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
        /// Gets or sets the AreaId of AddWaiMaiOrderParameter
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
        /// Gets or sets the IpAddress of AddWaiMaiOrderParameter
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
        /// Gets or sets the IsTakeInvoice of AddWaiMaiOrderParameter
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
        /// Gets or sets the DeliveryTime of AddWaiMaiOrderParameter
        /// </summary>
        /// <value>
        /// The DeliveryTime
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/18/2013 11:27 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryType of AddWaiMaiOrderParameter
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
        /// Gets or sets the DishList of AddWaiMaiOrderModel
        /// </summary>
        /// <value>
        /// The DishList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 5:47 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<AddWaiMaiOrderDishModel> DishList { get; set; }
    }
}
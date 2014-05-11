using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class AddOrderModel
    {
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public int ArtworkId { get; set; }
        public PayMode PayMode { get; set; }
        public DeliveryMode DeliveryMode { get; set; }

        public InvoiceType InvoiceType { get; set; }
        public string InvoiceCustomerName { get; set; }
    }

    public class AddOrderModelTranslator : TranslatorBase<Order, AddOrderModel>
    {
        public static readonly AddOrderModelTranslator Instance = new AddOrderModelTranslator();

        public override AddOrderModel Translate(Order from)
        {
            throw new NotImplementedException();
        }

        public override Order Translate(AddOrderModel from)
        {
            var to = new Order();
            to.CustomerId = from.CustomerId;
            to.CustumerMessage = from.Message;
            to.PayMode = from.PayMode;
            to.DeliveryMode = from.DeliveryMode;
            to.InvoiceInfo = new OrderInvoiceInfo()
            {
                InvoiceType = InvoiceType.单位,
                CustomerName = from.InvoiceCustomerName
            };


            to.OrderItem = new OrderItem
            {
                ArtworkId = from.ArtworkId
            };
            return to;
        }
    }

}
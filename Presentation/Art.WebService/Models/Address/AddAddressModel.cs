
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Art.Data.Domain;
using System.Web.Http;
using Art.BussinessLogic;

namespace Art.WebService.Models
{ 
    public class AddAddressModel
    {
        public int UserId { get; set; }
        public string ReceiptName { get; set; }
        public string PhoneNumber { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
    }

    public enum AddAddressStatus
    {
        Success,

        [DisplayText("地址不能为空")]
        DetailEmpty,

        [DisplayText("手机号不能为空")]
        PhoneNumberEmpty,

        [DisplayText("收货人不能为空")]
        ReceiptNameEmpty,

        [DisplayText("用户不存在")]
        UserNotExist
    }

    public class AddAddressModelTranslator : TranslatorBase<Address, AddAddressModel>
    {
        public static readonly AddAddressModelTranslator Instance = new AddAddressModelTranslator();

        public override AddAddressModel Translate(Address from)
        {
            throw new NotImplementedException();
        }

        public override Address Translate(AddAddressModel from)
        { 
            var logic = GlobalConfiguration.Configuration.DependencyResolver.BeginScope().GetService(typeof(ICustomerBussinessLogic)) as ICustomerBussinessLogic;
            
            var to = new Address();
            to.Name = from.ReceiptName;
            to.Detail = from.Detail;
            to.Telephone = from.PhoneNumber;
            to.Customer = logic.Get(from.UserId);
            if (from.IsDefault)
            {
                to.Customer.DefaultAddress = to;
            }
            return to;
        }
    }
}
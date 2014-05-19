using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;
using System.Web.Http;
using Art.BussinessLogic;

namespace Art.WebService.Models
{
    public class UpdateAddressModel
    {
        public int Id { get; set; }
        public string ReceiptName { get; set; }
        public string PhoneNumber { get; set; }
        public string Detail { get; set; }
        public bool IsDefault { get; set; }
    }
      
    public enum UpdateAddressStatus
    {
        Success,

        [DisplayText("地址不能为空")]
        DetailEmpty,

        [DisplayText("手机号不能为空")]
        PhoneNumberEmpty,

        [DisplayText("收货人不能为空")]
        ReceiptNameEmpty,

        [DisplayText("您想要修改的地址不存在")]
        AddressIdNotExist
    }
     
    public enum DeleteAddressStatus
    {
        Success,

        [DisplayText("您想要删除的地址不存在")]
        AddressIdNotExist
    }

    public enum GetMyAddressesStatus
    {
        Success
    }
      
    public class UpdateAddressModelTranslator : TranslatorBase<Address, UpdateAddressModel>
    {
        public static readonly UpdateAddressModelTranslator Instance = new UpdateAddressModelTranslator();

        public override UpdateAddressModel Translate(Address from)
        {
            throw new NotImplementedException();
        }

        public override Address Translate(UpdateAddressModel from)
        {
            var logic = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerBussinessLogic)) as ICustomerBussinessLogic;

            var to = logic.GetAddressById(from.Id);
            to.Name = from.ReceiptName;
            to.Detail = from.Detail;
            to.Telephone = from.PhoneNumber; 
            if (from.IsDefault)
            {
                to.Customer.DefaultAddress = to;
            }
            return to;
        }
    } 
}
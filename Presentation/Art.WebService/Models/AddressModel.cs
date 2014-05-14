using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ReceiptName { get; set; }
        public string PhoneNumber { get; set; }
        public string Detail { get; set; }
        public bool? IsDefault { get; set; }
    }
    
    public enum SaveAddressStatus
    { 
        Success,
        DetailEmpty,
        PhoneNumberEmpty,
        ReceiptNameEmpty,
        UserNotExist,
        AddressIdNotExist
    }

    public enum DeleteAddressStatus
    {
        Success,
        AddressIdNotExist
    }


    public class AddressModelTranslator : TranslatorBase<Address, AddressModel>
    {
        public static readonly AddressModelTranslator Instance = new AddressModelTranslator();

        public override AddressModel Translate(Address from)
        {
            //var to = new CustomerRegisterModel();
            //to.Id = from.Id;
            //to.Name = from.Name;
            //return to;
            throw new NotImplementedException();
        }

        public override Address Translate(AddressModel from)
        {
            var to = new Address();
            to.Id = from.Id;
            to.Name = from.ReceiptName;
            to.Detail = from.Detail;
            to.Telephone = from.PhoneNumber;
            return to;
        }
    }


}
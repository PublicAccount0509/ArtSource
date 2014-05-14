using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class CustomerRegisterModel
    {
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string CheckCode { get; set; }
        public DeviceType DeviceType { get; set; }
    }

    public class CustomerRegisterModelTranslator : TranslatorBase<Customer, CustomerRegisterModel>
    {
        public static readonly CustomerRegisterModelTranslator Instance = new CustomerRegisterModelTranslator();

        public override CustomerRegisterModel Translate(Customer from)
        {
            //var to = new CustomerRegisterModel();
            //to.Id = from.Id;
            //to.Name = from.Name;
            //return to;
            throw new NotImplementedException();
        }

        public override Customer Translate(CustomerRegisterModel from)
        {
            var to = new Customer();
            to.NickName = from.NickName;
            to.Password = from.Password;
            to.PhoneNumber = from.PhoneNumber;
            return to;
        }
    }


    public enum CustomerRegisterStatus:int
    { 
        Success = 0,
        NickNameEmpty,
        PhoneNumberEmpty,
        PasswordEmpty,
        NickNameAlreadyRegistered,
        PhoneNumberRegistered
    }
}
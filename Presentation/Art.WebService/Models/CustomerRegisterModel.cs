
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class CustomerRegisterModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    //public class CustomerRegisterModelTranslator : TranslatorBase<Customer, CustomerRegisterModel>
    //{
    //    public static readonly CustomerRegisterModelTranslator Instance = new CustomerRegisterModelTranslator();

    //    public override CustomerRegisterModel Translate(Customer from)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Customer Translate(CustomerRegisterModel from)
    //    {
    //        var to = new Customer(); 
    //        to.LoginName = from.Name;
    //        to.Password = from.Password;
    //        return to;
    //    }
    //}
}
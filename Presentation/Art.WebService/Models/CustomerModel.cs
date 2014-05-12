//using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string  Contact { get; set; }
    }

    //public class CustomerModelTranslator : TranslatorBase<Customer, CustomerModel>
    //{
    //    public static readonly CustomerModelTranslator Instance = new CustomerModelTranslator();

    //    public override CustomerModel Translate(Customer from)
    //    {
    //        var to = new CustomerModel();
    //        to.Id = from.Id;
    //        to.LoginName = from.LoginName;
    //        return to;
    //    }

    //    public override Customer Translate(CustomerModel from)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

}
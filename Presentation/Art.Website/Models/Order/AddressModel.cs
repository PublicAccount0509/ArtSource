using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class AddressModel
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string DetailAddress { get; set; }
    }

    public class AddressModelTranslator : TranslatorBase<Address, AddressModel>
    {
        public static readonly AddressModelTranslator Instance = new AddressModelTranslator();

        public override AddressModel Translate(Address from)
        {
            var to = new AddressModel();
            to.DetailAddress = from.Detail;
            to.Name = from.Name;
            to.Telephone = from.Telephone;
            return to;
        }

        public override Address Translate(AddressModel from)
        {
            throw new NotImplementedException();
        }
    }
}
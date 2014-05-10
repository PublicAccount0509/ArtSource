using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{ 
    //public class ValueTextEntry
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


    public class IdNameModelTranslator<TDomain> : TranslatorBase<TDomain, ValueTextEntry> where TDomain : IIdNameEntry, new()
    {
        public static readonly IdNameModelTranslator<TDomain> Instance = new IdNameModelTranslator<TDomain>();

        public override ValueTextEntry Translate(TDomain from)
        {
            var to = new ValueTextEntry();
            to.Value = from.Id;
            to.Text = from.Name;
            return to;
        }

        public override TDomain Translate(ValueTextEntry from)
        {
            var to = new TDomain();
            to.Id = from.Value;
            to.Name = from.Text;
            return to;
        }
    }
}
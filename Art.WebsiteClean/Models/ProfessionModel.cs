using Art.BussinessLogic;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ProfessionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProfessionTranslator : TranslatorBase<Profession, ProfessionModel>
    {
        public static readonly ProfessionTranslator Instance = new ProfessionTranslator();

        public override ProfessionModel Translate(Profession from)
        {
            var to = new ProfessionModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override Profession Translate(ProfessionModel from)
        {
            Profession to;
            if (from.Id > 0)
            {
                to = ArtistBussinessLogic.Instance.GetProfession(from.Id);
            }
            else
            {
                to = new Profession();
            }
            to.Name = from.Name;
            return to;
        }
    }
}
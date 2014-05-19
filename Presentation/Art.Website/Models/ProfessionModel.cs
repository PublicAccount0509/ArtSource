using Art.BussinessLogic;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Autofac;
using System.Web.Mvc;

namespace Art.Website.Models
{
    public class ArtistTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ArtistTypeTranslator : TranslatorBase<ArtistType, ArtistTypeModel>
    {
        public static readonly ArtistTypeTranslator Instance = new ArtistTypeTranslator();

        public override ArtistTypeModel Translate(ArtistType from)
        {
            var to = new ArtistTypeModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override ArtistType Translate(ArtistTypeModel from)
        {
            ArtistType to;
            if (from.Id > 0)
            {
                var logic = DependencyResolver.Current.GetService<IArtistBussinessLogic>();
                to = logic.GetArtistType(from.Id);
            }
            else
            {
                to = new ArtistType();
            }
            to.Name = from.Name;
            return to;
        }
    }
}
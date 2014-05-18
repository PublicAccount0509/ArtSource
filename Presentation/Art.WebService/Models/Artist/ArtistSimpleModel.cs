using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ArtistSimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }

    public class ArtistSimpleModelTranslator : TranslatorBase<Artist, ArtistSimpleModel>
    {
        public static readonly ArtistSimpleModelTranslator Instance = new ArtistSimpleModelTranslator();

        public override ArtistSimpleModel Translate(Artist from)
        {
            var to = new ArtistSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            //to.IconPath = from.Artist;

            return to;
        }

        public override Artist Translate(ArtistSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
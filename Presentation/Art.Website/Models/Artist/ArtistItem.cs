using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtistItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public bool CanUnPublish { get; set; }
        public IList<string> ArtistTypeNames { get; set; }
    }
     

    public class ArtistItemTranslator : TranslatorBase<Artist, ArtistItem>
    {
        public static readonly ArtistItemTranslator Instance = new ArtistItemTranslator();

        public override ArtistItem Translate(Artist from)
        {
            var to = new ArtistItem();
            to.Id = from.Id;
            to.Name = from.Name;
            to.IsPublic = from.IsPublic;
            to.ArtistTypeNames = from.ArtistTypes.Select(i => i.Name).ToList();

            return to;
        }

        public override Artist Translate(ArtistItem from)
        {
            throw new NotImplementedException();
        }
    }
}
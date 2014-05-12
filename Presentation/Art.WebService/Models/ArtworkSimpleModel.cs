using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ArtworkSimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShareCount { get; set; }
        public int CollectAccount { get; set; }
        public int PraiseCount { get; set; }

        public int CommentUserId { get; set; }
        public int CommentUserIconPath { get; set; }
        public int CommentContent { get; set; }

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string ImagePath { get; set; }
    }

    public class ArtworkSimpleModel : TranslatorBase<Artwork, ArtworkSimpleModel>
    {
        public static readonly ArtworkSimpleModel Instance = new ArtworkSimpleModel();

        public override ArtworkSimpleModel Translate(Artwork from)
        {
            var to = new ArtworkSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            //to.ShareCount = to.ShareCount;
            return to;
        }

        public override Artwork Translate(ArtworkSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
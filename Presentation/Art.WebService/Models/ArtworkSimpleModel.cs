using Art.Common;
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
        public string ImagePath { get; set; }
        public string ArtistName { get; set; }

        public int ShareCount { get; set; }
        public int CollectAccount { get; set; }
        public int PraiseCount { get; set; }

        public int CommentUserId { get; set; }
        public string CommentUserIconPath { get; set; }
        public string CommentContent { get; set; }

    }

    public class ArtworkSimpleModelTranslator : TranslatorBase<Artwork, ArtworkSimpleModel>
    {
        public static readonly ArtworkSimpleModelTranslator Instance = new ArtworkSimpleModelTranslator
            ();

        public override ArtworkSimpleModel Translate(Artwork from)
        {
            var to = new ArtworkSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ArtistName = from.Artist.Name;

            var image = from.Images.FirstOrDefault(i => i.ImageType == Data.Common.ArtworkImageResizeType.Size_W290_MinH240);
            if (image != null)
            {
                to.ImagePath = CommonHelper.GetUploadFileRelativePath_SlantStyle(image.ImagePath);
            }

            if (from.DefaultComment != null)
            {
                to.CommentUserId = from.DefaultComment.Id;
                to.CommentUserIconPath = CommonHelper.GetUploadFileRelativePath(from.DefaultComment.Customer.AvatarPath);
                to.CommentContent = from.DefaultComment.Text;
            }

            return to;
        }

        public override Artwork Translate(ArtworkSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
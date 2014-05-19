using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class CommentedArtworkModel
    {
        public string ArtworkImagePath { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Content { get; set; }
    }

    public class CommentedArtworkModelTranslator : TranslatorBase<Comment, CommentedArtworkModel>
    {
        public static readonly CommentedArtworkModelTranslator Instance = new CommentedArtworkModelTranslator();

        public override CommentedArtworkModel Translate(Comment from)
        {
            var to = new CommentedArtworkModel();
            to.Content = from.Text;
            to.CommentDateTime = from.FADateTime;
            var image = from.Artwork.Images.Where(i => i.ImageType == Data.Common.ArtworkImageResizeType.Size_W180_H140).FirstOrDefault();
            if (image != null)
            {
                to.ArtworkImagePath = Path.Combine(ConfigSettings.Instance.FileUploadPath, image.ImagePath);                
            }
            return to;
        }

        public override Comment Translate(CommentedArtworkModel from)
        {
            throw new NotImplementedException();
        }
    }
}
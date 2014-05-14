using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;
using Art.Common;

namespace Art.WebService.Models
{
    public class ArtworkDetailModel
    {
        public string ImagePath { get; set; }
        public bool HasPraised { get; set; }

        public int AuctionType { get; set; }
        public int AuctionCount { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string Size { get; set; }
        public int CreationYear { get; set; }
        public string ArtworkType { get; set; }
        public string Material { get; set; }
        public string Technique { get; set; }
        public string FitPlaces { get; set; }
        public string Inspiration { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public decimal Price { get; set; }
    }

    public enum ArtworkDetailModelStatus
    {
        Success,
        ArtworkNotFound,
        UserNotFound
    }

    public class ArtworkDetailModelTranslator : TranslatorBase<Artwork, ArtworkDetailModel>
    {
        public static readonly ArtworkDetailModelTranslator Instance = new ArtworkDetailModelTranslator();

        public override ArtworkDetailModel Translate(Artwork from)
        {
            var to = new ArtworkDetailModel();
            var image = from.Images.FirstOrDefault(i => i.ImageType == ArtworkImageResizeType.Size_W600_H420);
            if (image != null)
            {
                to.ImagePath = CommonHelper.GetUploadFileRelativePath_SlantStyle(image.ImagePath);
            }
            to.AuctionType = (int)from.AuctionType;
            to.StartDateTime = from.StartDateTime;
            to.EndDateTime = from.EndDateTime;
            to.Size = from.Size;
            to.CreationYear = from.ArtYear;
            to.ArtworkType = from.ArtworkType.Name;
            to.Material = from.ArtMaterial.Name;
            to.Technique = from.ArtTechnique == null ? string.Empty : from.ArtTechnique.Name;
            to.FitPlaces = string.Join(",", from.SuitableArtPlaces.Select(i => i.Name));
            to.Inspiration = from.CreationInspiration;
            to.ArtistId = from.Artist.Id;
            to.ArtistName = from.Artist.Name;
            to.Price = from.AuctionPrice;
            return to;
        }

        public override Artwork Translate(ArtworkDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
using Art.BussinessLogic;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Common.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtworkDetailModel
    {
        public string ImageFileName { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Institution { get; set; }
        public string Size { get; set; }
        public string ArtMaterial { get; set; }
        public string Period { get; set; }
        public string ArtworkType { get; set; }
        public string Genre { get; set; }
        public string ArtShape { get; set; }
        public string ArtTechnique { get; set; }
        public string CreationInspiration { get; set; }
        public string[] SuitablePlaces { get; set; }
        public AuctionType AuctionType { get; set; }
        public decimal AuctionPrice { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }

    public class ArtworkDetailModelTranslator : TranslatorBase<Artwork, ArtworkDetailModel>
    {
        public static readonly ArtworkDetailModelTranslator Instance = new ArtworkDetailModelTranslator();

        public override ArtworkDetailModel Translate(Artwork from)
        {
            var to = new ArtworkDetailModel();
            if (!string.IsNullOrEmpty(from.ImageFileName))
            {
                to.ImageFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.ImageFileName);
            }

            to.Name = from.Name;
            to.ArtistName = from.Artist.Name;
            to.Institution = from.Institution;
            to.Size = from.Size;
            to.ArtMaterial = from.ArtMaterial.Name;
            to.Period = from.ArtYear.ToString();
            to.ArtworkType = from.ArtworkType.Name;
            to.Genre = from.Genre.Name;
            to.ArtShape = from.ArtShape == null ? null : from.ArtShape.Name;
            to.ArtTechnique = from.ArtTechnique == null ? null : from.ArtTechnique.Name;
            to.CreationInspiration = from.CreationInspiration;
            to.SuitablePlaces = from.SuitableArtPlaces.Select(i => i.Name).ToArray();
            to.AuctionType = from.AuctionType;
            to.AuctionPrice = from.AuctionPrice;
            to.StartDateTime = from.StartDateTime;
            to.EndDateTime = from.EndDateTime;
            return to;
        }

        public override Artwork Translate(ArtworkDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
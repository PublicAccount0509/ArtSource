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
    public class ArtworkModel
    {
        public ArtworkModel()
        {
            SuitablePlaceIds = new List<int>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public string Institution { get; set; }
        public string Size { get; set; }

        public int ArtworkTypeId { get; set; }
        public int ArtMaterialId { get; set; }
        public int? ArtShapeId { get; set; }
        public int? ArtTechniqueId { get; set; }

        public int ArtYear { get; set; }
        public int GenreId { get; set; }
        public string CreationInspiration { get; set; }
        public List<int> SuitablePlaceIds { get; set; }
        public string ImageFileName { get; set; }

        public AuctionType AuctionType { get; set; }
        public decimal AuctionPrice { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public bool FeePackageGeneralEnabled { get; set; }
        public decimal? FeePackageGeneral { get; set; }

        public bool FeePackageFineEnabled { get; set; }
        public decimal? FeePackageFine { get; set; }

        public bool FeeDeliveryLocalEnabled { get; set; }
        public decimal? FeeDeliveryLocal { get; set; }

        public bool FeeDeliveryNonlocalEnabled { get; set; }
        public decimal? FeeDeliveryNonlocal { get; set; }
    }

    public class ArtworkModelTranslator : TranslatorBase<Artwork, ArtworkModel>
    {
        public static readonly ArtworkModelTranslator Instance = new ArtworkModelTranslator();

        public override ArtworkModel Translate(Artwork from)
        {
            var to = new ArtworkModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.ArtistId = from.Artist.Id;
            to.Institution = from.Institution;
            to.Size = from.Size;
            to.ArtworkTypeId = from.ArtworkType.Id;
            to.ArtMaterialId = from.ArtMaterial.Id;
            to.ArtShapeId = from.ArtShape == null ? (int?)null : from.ArtShape.Id;
            to.ArtTechniqueId = from.ArtTechnique == null ? (int?)null : from.ArtTechnique.Id;

            to.ArtYear = from.ArtYear;
            to.GenreId = from.Genre.Id;
            to.CreationInspiration = from.CreationInspiration;
            to.SuitablePlaceIds = from.SuitableArtPlaces.Select(i => i.Id).ToList();
            if (!string.IsNullOrEmpty(from.ImageFileName))
            {
                to.ImageFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.ImageFileName);
            }

            to.AuctionType = from.AuctionType;
            to.AuctionPrice = from.AuctionPrice;

            to.StartDateTime = from.StartDateTime;
            to.EndDateTime = from.EndDateTime;

            to.FeePackageGeneral = from.FeePackageGeneral;
            to.FeePackageFine = from.FeePackageFine;
            to.FeeDeliveryLocal = from.FeeDeliveryLocal;
            to.FeeDeliveryNonlocal = from.FeeDeliveryNonlocal;

            to.FeePackageFineEnabled = from.FeePackageFine.HasValue;
            to.FeePackageGeneralEnabled = from.FeePackageGeneral.HasValue;
            to.FeeDeliveryLocalEnabled = from.FeeDeliveryLocal.HasValue;
            to.FeeDeliveryNonlocalEnabled = from.FeeDeliveryNonlocal.HasValue;

            return to;
        }

        public override Artwork Translate(ArtworkModel from)
        {
            Artwork to = from.Id > 0 ? ArtworkBussinessLogic.Instance.GetArtwork(from.Id) : new Artwork();
            to.Id = from.Id;
            to.Name = from.Name;
            to.Artist = ArtistBussinessLogic.Instance.GetArtist(from.ArtistId);
            to.Institution = from.Institution;
            to.Size = from.Size;
            to.ArtworkType = ArtworkBussinessLogic.Instance.GetArtworkType(from.ArtworkTypeId);
            to.ArtMaterial = ArtworkBussinessLogic.Instance.GetArtMaterial(from.ArtMaterialId);
            to.ArtShape = from.ArtShapeId == null ? null : ArtworkBussinessLogic.Instance.GetArtShape(from.ArtShapeId.Value);
            to.ArtTechnique = from.ArtTechniqueId == null ? null : ArtworkBussinessLogic.Instance.GetArtTechnique(from.ArtTechniqueId.Value);

            to.ArtYear = from.ArtYear;// ArtworkBussinessLogic.Instance.GetPeriod(from.ArtYear);
            to.Genre = ArtistBussinessLogic.Instance.GetGenre(from.GenreId);
            to.CreationInspiration = from.CreationInspiration;
            to.SuitableArtPlaces = ArtworkBussinessLogic.Instance.GetArtPlaces(from.SuitablePlaceIds);
            if (!string.IsNullOrEmpty(from.ImageFileName))
            {
                //to.ImageFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.ImageFileName);
                to.ImageFileName = new Uri(from.ImageFileName).Segments.Last();
            }

            to.AuctionType = from.AuctionType;
            to.AuctionPrice = from.AuctionPrice;
            to.StartDateTime = from.StartDateTime;
            to.EndDateTime = from.EndDateTime;

            to.FeePackageGeneral = from.FeePackageGeneralEnabled ? from.FeePackageGeneral : null;
            to.FeePackageFine = from.FeePackageFineEnabled ? from.FeePackageFine : null;
            to.FeeDeliveryLocal = from.FeeDeliveryLocalEnabled ? from.FeeDeliveryLocal : null;
            to.FeeDeliveryNonlocal = from.FeeDeliveryNonlocalEnabled ? from.FeeDeliveryNonlocal : null;

            return to;
        }
    }
}
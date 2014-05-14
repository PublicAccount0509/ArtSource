using Art.Data.Common;
using Art.Data.Domain;
using Art.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtistModel
    {
        public ArtistModel()
        {
            ArtistTypeIds = new List<int>();
            SkilledGenreIds = new List<int>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? Deathday { get; set; }

        public string School { get; set; }

        public string AvatarFileName { get; set; }

        public bool IsPublic { get; set; }

        public string Masterpiece { get; set; }

        public int MasterpieceTypeId { get; set; }

        public string PrizeItems { get; set; }

        public Genders Gender { get; set; }

        public Degree? Degree { get; set; }

        public List<int> ArtistTypeIds { get; set; }

        public List<int> SkilledGenreIds { get; set; }
    }

    public class ArtistTranslator : TranslatorBase<Artist, ArtistModel>
    {
        public static readonly ArtistTranslator Instance = new ArtistTranslator();

        public override ArtistModel Translate(Artist from)
        {
            var to = new ArtistModel();
            to.Id = from.Id;
            to.Gender = from.Gender;
            to.Name = from.Name;
            to.Birthday = from.Birthday;
            to.Deathday = from.Deathday;
            to.Degree = from.Degree;
            to.School = from.School;
            to.PrizeItems = from.PrizeItems;
            to.Masterpiece = from.Masterpiece;
            to.MasterpieceTypeId = from.MasterpieceTypeId;

            if (!string.IsNullOrEmpty(from.AvatarFileName))
            {
                to.AvatarFileName = Path.Combine(ConfigSettings.Instance.FileUploadPath, from.AvatarFileName);
            }

            to.ArtistTypeIds = from.ArtistTypes.Select(i => i.Id).ToList();
            to.SkilledGenreIds = from.SkilledGenres.Select(i => i.Id).ToList();

            return to;
        }

        public override Artist Translate(ArtistModel from)
        {
            Artist to = from.Id > 0 ? Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(from.Id) : new Artist();
            to.Gender = from.Gender;
            to.Name = from.Name;
            to.Birthday = from.Birthday;
            to.Deathday = from.Deathday;
            to.Degree = from.Degree;
            to.School = from.School;
            to.PrizeItems = from.PrizeItems;
            to.Masterpiece = from.Masterpiece;
            to.MasterpieceTypeId = from.MasterpieceTypeId;
            if (!string.IsNullOrEmpty(from.AvatarFileName))
            {
                to.AvatarFileName = Path.GetFileName(from.AvatarFileName);
            }

            to.ArtistTypes = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtistTypes(from.ArtistTypeIds);
            to.SkilledGenres = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetSkilledGenres(from.SkilledGenreIds);
            return to;
        }
    }
}
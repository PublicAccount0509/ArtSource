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
    public class ArtistModel
    {
        public ArtistModel()
        {
            ProfessionIds = new List<int>();
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

        public List<int> ProfessionIds { get; set; }

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
                to.AvatarFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.AvatarFileName);
            }

            to.ProfessionIds = from.Professions.Select(i => i.Id).ToList();
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

            to.Professions = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetProfessions(from.ProfessionIds);// null;// from.Professions.Select(i => i.Id).ToArray();
            to.SkilledGenres = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetSkilledGenres(from.SkilledGenreIds);// = from.SkilledGenres.Select(i => i.Id).ToArray();
            return to;
        }
    }
}
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Common.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtistDetailModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string School { get; set; }
        public string[] Prizes { get; set; }
        public string[] ArtistTypeNames { get; set; }
        public string[] SkilledGenres { get; set; }
        public string Masterpiece { get; set; }
        public string MasterpieceType { get; set; }
        public string AvatarFileName { get; set; }
    }

    public class ArtistDetailModelTranslator : TranslatorBase<Artist, ArtistDetailModel>
    {
        public static readonly ArtistDetailModelTranslator Instance = new ArtistDetailModelTranslator();

        public override ArtistDetailModel Translate(Artist from)
        {
            var to = new ArtistDetailModel();
            to.Name = from.Name;
            to.Gender = from.Gender == Genders.Male ? "男" : "女";
            to.Birthday = from.Birthday;
            to.School = from.School;
            to.Prizes = from.PrizeItems.Split(',');
            to.ArtistTypeNames = from.ArtistTypes.Select(i => i.Name).ToArray();
            to.SkilledGenres = from.SkilledGenres.Select(i => i.Name).ToArray() ;
            to.Masterpiece = from.Masterpiece;
            to.MasterpieceType = from.MasterpieceType.Name;
            if (!string.IsNullOrEmpty(from.AvatarFileName))
            {
                to.AvatarFileName = Path.Combine(ConfigSettings.Instance.UploadedFileFolder, from.AvatarFileName);
            }
            return to;
        }

        public override Artist Translate(ArtistDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
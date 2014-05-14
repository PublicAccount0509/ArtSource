using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ArtistDetailModel
    {
        public bool HasFollowed { get; set; }
        public string IconPath { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Honur { get; set; }
        public ArtworkSimpleModel[] Artworks { get; set; }
    }

    public enum ArtistDetailModelStatus
    {
        Success,
        ArtistNotExist
    }
    public class ArtistDetailModelTranslator : TranslatorBase<Artist, ArtistDetailModel>
    {
        public static readonly ArtistDetailModelTranslator Instance = new ArtistDetailModelTranslator();

        public override ArtistDetailModel Translate(Artist from)
        {
            var to = new ArtistDetailModel
                {
                    Honur = from.PrizeItems,
                    Experience = from.School,
                    IconPath = from.AvatarFileName,
                    Name = from.Name
                };
            return to;
        }

        public override Artist Translate(ArtistDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
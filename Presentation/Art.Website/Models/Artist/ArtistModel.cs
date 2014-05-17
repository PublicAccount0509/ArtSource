using Art.Data.Common;
using Art.Data.Domain;
using Art.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;
using Art.BussinessLogic;
using Autofac;
using System.Web.Mvc;
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
            var logic = DependencyResolver.Current.GetService<IArtistBussinessLogic>();

            Artist to = from.Id > 0 ? logic.GetArtist(from.Id) : new Artist();
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

            var allArtistTypes = logic.GetArtistTypes();
            ParseItems(to.ArtistTypes, from.ArtistTypeIds, allArtistTypes); 

            var allGenres = logic.GetGenres();
            ParseItems(to.SkilledGenres, from.SkilledGenreIds, allGenres);
            return to;
        }

        private void ParseItems<T>(ICollection<T> correntItems, IList<int> finalItemIds, ICollection<T> all) where T : BaseEntity
        {
            foreach (var item in all)
            {
                if (finalItemIds.Contains(item.Id))
                {
                    if (!correntItems.Any(i => i.Id == item.Id))
                    {
                        correntItems.Add(item);
                    }
                }
                else
                {
                    if (correntItems.Any(i => i.Id == item.Id))
                    {
                        correntItems.Remove(item);
                    }
                }
            }
        }
    }
}
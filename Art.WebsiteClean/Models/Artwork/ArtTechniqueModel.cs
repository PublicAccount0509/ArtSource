using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class ArtTechniqueModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsUsed { get; set; }
    }

    public class ArtTechniqueModelTranslator : TranslatorBase<ArtTechnique, ArtTechniqueModel>
    {
        public static readonly ArtTechniqueModelTranslator Instance = new ArtTechniqueModelTranslator();

        public override ArtTechniqueModel Translate(ArtTechnique from)
        {
            var to = new ArtTechniqueModel();
            to.Id = from.Id;
            to.Text = from.Name;
            to.IsUsed = from.Artworks.Any();
            return to;
        }

        public override ArtTechnique Translate(ArtTechniqueModel from)
        {
            var to = new ArtTechnique();
            to.Id = from.Id;
            to.Name = from.Text;
            return to;
        }
    }
}
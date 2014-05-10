using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreTranslator : TranslatorBase<Genre,GenreModel>
    {
        public static readonly GenreTranslator Instance = new GenreTranslator();
          
        public override GenreModel Translate(Genre from)
        {
            var to = new GenreModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override Genre Translate(GenreModel from)
        {
            var to = new Genre();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }
    }
}
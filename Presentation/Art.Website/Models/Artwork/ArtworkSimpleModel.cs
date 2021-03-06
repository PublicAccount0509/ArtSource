﻿using Art.BussinessLogic;
using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class ArtworkSimpleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdentityNumber { get; set; }
        public string ImageFileName { get; set; }
        public string ArtistName { get; set; }
        public string ArtworkType { get; set; }
        public string ArtMaterial { get; set; }
        public string Genre { get; set; }
        public string AuctionType { get; set; }
        public bool IsPublic { get; set; }
    }

    public class ArtworkSimpleModelTranslator : TranslatorBase<Artwork, ArtworkSimpleModel>
    {
        public static readonly ArtworkSimpleModelTranslator Instance = new ArtworkSimpleModelTranslator();

        public override ArtworkSimpleModel Translate(Artwork from)
        {
            var to = new ArtworkSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.IdentityNumber = from.IdentityNumber;
            to.ArtistName = from.Artist.Name;
            to.ArtworkType = from.ArtworkType.Name;
            to.ArtMaterial = from.ArtMaterial.Name;
            to.Genre = from.Genre.Name;

            if (!string.IsNullOrEmpty(from.ImageFileName))
            {
                to.ImageFileName = Path.Combine(ConfigSettings.Instance.FileUploadPath, from.ImageFileName);
            }
            to.AuctionType = from.AuctionType.ToString();
            to.IsPublic = from.IsPublic;
            return to;
        }

        public override Artwork Translate(ArtworkSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
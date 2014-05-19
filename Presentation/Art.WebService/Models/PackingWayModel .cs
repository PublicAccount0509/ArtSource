﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class ArtworkPackingWayModel 
    {
        public int ArtworkId { get; set; }
        public string ArtworkName { get; set; }
        public PackingWay[] Ways { get; set; }
    }

    public class PackingWay
    {
        public PackingType PackingType { get; set; }
        public string Name { get; set; }
        public decimal? Fee { get; set; }
    }

    public class ArtworkPackingWayModelTranslator : TranslatorBase<Artwork, ArtworkPackingWayModel>
    {
        public static readonly ArtworkPackingWayModelTranslator Instance = new ArtworkPackingWayModelTranslator();

        public override ArtworkPackingWayModel Translate(Artwork from)
        {
            var ways = new List<PackingWay>();

            if (from.FeePackageGeneral.HasValue)
            {
                ways.Add(new PackingWay
                    {
                        PackingType = PackingType.一般包装,
                        Name = PackingType.一般包装.ToString(),
                        Fee = from.FeePackageGeneral.Value
                    });
            }

            if (from.FeePackageFine.HasValue)
            {
                ways.Add(new PackingWay
                    {
                        PackingType = PackingType.精包装,
                        Name = PackingType.精包装.ToString(),
                        Fee = from.FeePackageFine.Value
                    });
            }

            var to = new ArtworkPackingWayModel
                {
                    ArtworkId = from.Id,
                    ArtworkName = from.Name,
                    Ways = ways.ToArray()
                };
            return to;
        }

        public override Artwork Translate(ArtworkPackingWayModel from)
        {
            throw new NotImplementedException();
        }
    }
}
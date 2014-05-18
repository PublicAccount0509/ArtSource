using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    public class DeveryWaysModel
    {
        public int ArtworkId { get; set; }
        public string ArtworkName { get; set; }
        public WaysModel[] Ways { get; set; }
    }

    public class WaysModel
    {
        public DeliveryType DeliveryType { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
    }

    public enum DeveryWaysStatus
    {
        Success,

        [DisplayText("无效的请求参数")]
        InvalidArtworkIds
    }

    public class DeveryWaysModelTranslator : TranslatorBase<Artwork, DeveryWaysModel>
    {
        public static readonly DeveryWaysModelTranslator Instance = new DeveryWaysModelTranslator();

        public override DeveryWaysModel Translate(Artwork from)
        {
            var ways = new List<WaysModel>();
            if (from.FeeDeliveryLocal != null)
            {
                ways.Add(new WaysModel
                    {
                        DeliveryType = DeliveryType.市内,
                        Name = "室内",
                        Fee = Convert.ToDecimal(from.FeeDeliveryLocal)
                    });
            }
            if (from.FeeDeliveryNonlocal != null)
            {
                ways.Add(new WaysModel
                    {
                        DeliveryType = DeliveryType.外地,
                        Name = "外地",
                        Fee = Convert.ToDecimal(from.FeeDeliveryNonlocal)
                    });
            }
            ways.Add(new WaysModel
                {
                    DeliveryType = DeliveryType.自提,
                    Name = "自提",
                    Fee = 0
                });
            var to = new DeveryWaysModel
                {
                    ArtworkId = from.Id,
                    ArtworkName = from.Name,
                    Ways = ways.ToArray()
                };
            return to;
        }

        public override Artwork Translate(DeveryWaysModel from)
        {
            throw new NotImplementedException();
        }
    }
}
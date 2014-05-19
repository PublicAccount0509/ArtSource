using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Common;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 配送方式数据
    /// </summary>
    public class DeveryWaysModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string ArtworkName { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        public WaysModel[] Ways { get; set; }
    }

    public class WaysModel
    {
        public DeliveryType DeliveryType { get; set; }
        public string Name { get; set; }
        public decimal? Fee { get; set; }
    }

    public class DeveryWaysModelTranslator : TranslatorBase<Artwork, DeveryWaysModel>
    {
        public static readonly DeveryWaysModelTranslator Instance = new DeveryWaysModelTranslator();

        public override DeveryWaysModel Translate(Artwork from)
        {
            var ways = new List<WaysModel>();

            if (from.FeeDeliveryLocal.HasValue)
            {
                ways.Add(new WaysModel
                    {
                        DeliveryType = DeliveryType.市内,
                        Name = DeliveryType.市内.ToString(),
                        Fee = from.FeeDeliveryLocal.Value
                    });
            }

            if (from.FeeDeliveryNonlocal.HasValue)
            {
                ways.Add(new WaysModel
                    {
                        DeliveryType = DeliveryType.外地,
                        Name = DeliveryType.外地.ToString(),
                        Fee = from.FeeDeliveryNonlocal.Value
                    });
            }

            ways.Add(new WaysModel
                {
                    DeliveryType = DeliveryType.自提,
                    Name = DeliveryType.自提.ToString(),
                    Fee = null
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
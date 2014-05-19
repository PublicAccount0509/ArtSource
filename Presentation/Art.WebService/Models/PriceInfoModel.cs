using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 艺术品价格数据
    /// </summary>
    public class PriceInfoModel
    {
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal FeePackageGeneral { get; set; }
        public decimal FeepackageFine { get; set; }
        public decimal FeeDeliveryLocal { get; set; }
        public decimal FeeDeliveryNonlocal { get; set; }
    }

    public enum PriceInfoStatus
    {
        Success,
        ArtworkNotExist
    }

    public class PriceInfoModelTranslator : TranslatorBase<Artwork, PriceInfoModel>
    {
        public static readonly PriceInfoModelTranslator Instance = new PriceInfoModelTranslator();

        public override PriceInfoModel Translate(Artwork from)
        {
            var to = new PriceInfoModel
                {
                    Price = from.AuctionPrice,
                    FeePackageGeneral = from.FeePackageGeneral ?? 0,
                    FeepackageFine = from.FeePackageFine ?? 0,
                    FeeDeliveryLocal = from.FeeDeliveryLocal ?? 0,
                    FeeDeliveryNonlocal = from.FeeDeliveryNonlocal ?? 0
                };
            return to;
        }

        public override Artwork Translate(PriceInfoModel from)
        {
            throw new NotImplementedException();
        }
    }
}
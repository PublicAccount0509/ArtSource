using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 作品分类信息
    /// </summary>
    public class ArtworkTypeSimpleModel
    {
        /// <summary>
        /// 作品分类Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 作品分类名字
        /// </summary>
        public string Name { get; set; }
    }

    public class ArtworkTypeSimpleModelTranslator : TranslatorBase<ArtworkType, ArtworkTypeSimpleModel>
    {
        public static readonly ArtworkTypeSimpleModelTranslator Instance = new ArtworkTypeSimpleModelTranslator();

        public override ArtworkTypeSimpleModel Translate(ArtworkType from)
        {
            var to = new ArtworkTypeSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            return to;
        }

        public override ArtworkType Translate(ArtworkTypeSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
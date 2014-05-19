using Art.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取所有艺术家列表数据
    /// </summary>
    public class ArtistSimpleModel
    {
        /// <summary>
        /// 艺术家Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 艺术家名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string IconPath { get; set; }
    }

    public class ArtistSimpleModelTranslator : TranslatorBase<Artist, ArtistSimpleModel>
    {
        public static readonly ArtistSimpleModelTranslator Instance = new ArtistSimpleModelTranslator();

        public override ArtistSimpleModel Translate(Artist from)
        {
            var to = new ArtistSimpleModel();
            to.Id = from.Id;
            to.Name = from.Name;
            //to.IconPath = from.Artist;

            return to;
        }

        public override Artist Translate(ArtistSimpleModel from)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using Art.Data.Domain;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取艺术家数据
    /// </summary>
    public class ArtistDetailModel
    {
        /// <summary>
        /// 是否已关注
        /// </summary>
        public bool HasFollowed { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 经历
        /// </summary>
        public string Experience { get; set; }
        /// <summary>
        /// 所获荣誉
        /// </summary>
        public string Honur { get; set; }
        /// <summary>
        /// 该艺术家的所有作品
        /// </summary>
        public ArtworkSimpleModel[] Artworks { get; set; }
    }

    public enum ArtistDetailModelStatus
    {
        Success,

        [DisplayText("艺术家不存在")]
        ArtistNotExist
    }
    public class ArtistDetailModelTranslator : TranslatorBase<Artist, ArtistDetailModel>
    {
        public static readonly ArtistDetailModelTranslator Instance = new ArtistDetailModelTranslator();

        public override ArtistDetailModel Translate(Artist from)
        {
            var to = new ArtistDetailModel
                {
                    Honur = from.PrizeItems,
                    Experience = from.School222,
                    IconPath = from.AvatarFileName,
                    Name = from.Name
                };
            return to;
        }

        public override Artist Translate(ArtistDetailModel from)
        {
            throw new NotImplementedException();
        }
    }
}
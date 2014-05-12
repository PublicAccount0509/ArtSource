using System;

namespace Art.Website.Models.MvcModels
{
    /// <summary>
    /// 类名称：AuctionSearchCriteria
    /// 命名空间：Art.Website.Models
    /// 类功能：
    /// </summary>
    /// 创建者：黄磊
    /// 创建日期：5/12/2014 10:58 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuctionSearchCriteria
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? ArtworkId { get; set; }
        public int? ArtistsId { get; set; }
    }
}
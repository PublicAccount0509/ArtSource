using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public enum OrderByField
    {
        Hot = 1,
        New = 2,
        Price = 3
    }
    public class ArtworkSearchCriteriaModel
    {
        public string ArtworkNamePart { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ArtworkTypeId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public int ItemsCount { get; set; }
        public int PageIndex { get; set; }
        public OrderByField? OrderByField { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.WebService.Models
{
    public class ArtworkSearchCriteriaModel
    {
        public string ArtworkNamePart { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ArtworkTypeId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Website.Models
{
    public class SummaryModel
    {
        public int ArtistCount { get; set; }

        public int ArtistCountOnline { get; set; }

        public int ArtistCountOffline { get; set; }

        public int ArtworkCount { get; set; }

        public int ArtworkCountOnline { get; set; }

        public int ArtworkCountNewWeek { get; set; }

        public int ArtworkCountOffline { get; set; }

        public int TransactionCountToday { get; set; }

        public int TransactionCountTotal { get; set; }
    }
}
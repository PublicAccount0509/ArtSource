using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Art.WebService
{
    public class ArtCaching
    {
        public static readonly ArtCaching Instance = new ArtCaching();

        private Cache _artCaching = new Cache();

        public void Add(string key, string value)
        {
            if (_artCaching[key] != null)
            {
                _artCaching.Remove(key);
            }
            _artCaching.Add(key, value, null, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }
    }
}
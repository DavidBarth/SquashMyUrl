using SquashMyUrlApp.Models;
using System.Collections.Generic;

namespace SquashMyUrl.DAL.Caching
{
    /// <summary>
    /// in memory object to store URLs
    /// purpose is improve performance in querying URLs
    /// considerations
    /// 1. how many URLs do we want to store here at a time?
    /// 2. bootstrapping cache on service restart
    /// </summary>
    class SquashModelCache : ISquashModelCache
    {
        List<UrlModel> cache = new List<UrlModel>();
        public SquashModelCache()
        {
            var model = new UrlModel() { ShortenedUrl = "O9Oz9L1" };
            cache.Add(model);
        }

        public void AddShortenedUrl(string encodedUrl)
        {
            throw new System.NotImplementedException();
        }

        public string GetShortenedUrl(string encodedUrl)
        {
            return cache.Find(x=> x.ShortenedUrl == encodedUrl)?.ShortenedUrl;
        }
    }
}

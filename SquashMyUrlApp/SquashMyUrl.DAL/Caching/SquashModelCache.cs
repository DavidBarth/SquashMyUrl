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
    internal class SquashModelCache : ISquashModelCache
    {
        Dictionary<string, UrlModel> _cache = new Dictionary<string, UrlModel>();
        public SquashModelCache()
        {
            var model = new UrlModel() { ShortenedUrl = "O9Oz9L1" };
            _cache.Add("https://www.kerstner.at/2012/07/shortening-strings-using-base-62-encoding/", model);
        }

        public void AddShortenedUrl(string encodedUrl)
        {
            throw new System.NotImplementedException();
        }

        public string GetShortenedUrl(string originalUrl)
        {
            UrlModel model;
            _cache.TryGetValue("https://www.kerstner.at/2012/07/shortening-strings-using-base-62-encoding/", out model);
            if (!string.IsNullOrWhiteSpace(model.ShortenedUrl))
            {
                return model.ShortenedUrl;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

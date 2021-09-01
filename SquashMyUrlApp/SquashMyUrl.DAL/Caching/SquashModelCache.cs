using SquashMyUrl.DAL.Utility;
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
        private static readonly List<UrlModel> _cache = new List<UrlModel>();

        /// <summary>
        /// add shorted url to cache
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <param name="shortUrlCode"></param>
        public void AddShortenedUrl(UrlModel urlModel)
        {
            _cache.Add(urlModel);
        }

        /// <summary>
        /// return shorted url from cache
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns></returns>
        public string GetShortenedUrl(string originalUrl)
        {
            UrlModel model = _cache.Find(m => m.OriginalUrl == originalUrl);
            if (!string.IsNullOrWhiteSpace(model?.ID))
            {
                return model.ID;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

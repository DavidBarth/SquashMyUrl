using SquashMyUrlApp.Models;
using System;
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
        private static readonly Dictionary<string, UrlModel> _cache = new Dictionary<string, UrlModel>();

        public void AddShortenedUrl(string originalUrl, string encodedUrl)
        {
            UrlModel urlModel = new UrlModel
            {
                ShortenedUrl = encodedUrl,
                CreatedDate = DateTime.UtcNow
            };
            _cache.Add(originalUrl, urlModel);
        }

        public string GetShortenedUrl(string originalUrl)
        {
            UrlModel model;
            _cache.TryGetValue(originalUrl, out model);
            if (!string.IsNullOrWhiteSpace(model?.ShortenedUrl))
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

using SquashMyUrl.DAL.Caching;
using SquashMyUrl.DAL.Interfaces;

namespace SquashMyUrl.DAL
{
    /// <summary>
    /// repository that checks for instance in cache
    /// if not in cache then store in DB and cache
    /// if in cache return straight away
    /// </summary>
    public class SquashModelRepository : ISquashModelRepository
    {
        private readonly ISquashModelCache _cache;

        //just newing a cache up here for now
        //would use IOC container later to resolve
        public SquashModelRepository(ISquashModelCache cache = null)
        {
            if (cache == null)
            {
                _cache = new SquashModelCache();
            }
            else
            {
                _cache = cache;
            }
        }
        public string GetShortenedUrl(string encodedUrl)
        {
            string cachedUrl = _cache.GetShortenedUrl(encodedUrl);
            if (!string.IsNullOrWhiteSpace(cachedUrl))
            {
                return cachedUrl;
            }
            else
            {
                _cache.AddShortenedUrl(encodedUrl);
            }
            return cachedUrl;
        }
    }
}

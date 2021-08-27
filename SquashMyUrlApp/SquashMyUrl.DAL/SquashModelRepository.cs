using SquashMyUrl.DAL.Caching;
using SquashMyUrl.DAL.Interfaces;

namespace SquashMyUrl.DAL
{
    /// <summary>
    /// repository that checks for instance in cache
    /// if not in cache then store in DB and cache if DB successfully stored input
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

        public void AddShortenedUrl(string original, string encodedUrl)
        {
            //hard coding succesful commit to DB for now
            bool dbTransactionSuccessful = true;
            if (dbTransactionSuccessful)
            {
                _cache.AddShortenedUrl(original, encodedUrl);
            }
        }

        public string GetShortenedUrl(string input)
        {
            return _cache.GetShortenedUrl(input);
        }
    }
}

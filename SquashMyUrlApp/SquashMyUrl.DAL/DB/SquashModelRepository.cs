using SquashMyUrl.DAL.Caching;
using SquashMyUrl.DAL.Interfaces;
using SquashMyUrl.DAL.DB;

namespace SquashMyUrl.DAL
{
    /// <summary>
    /// repository class that checks for instance in cache
    /// if not in cache then store in DB and cache if DB successfully stored input
    /// if in cache return found item straight away
    /// </summary>
    public class SquashModelRepository : ISquashModelRepository
    {
        private readonly ISquashModelCache _cache;
        private readonly ISquashDB _fakeDB;

        //just newing a cache up here for now
        //would use IOC container later to resolve
        public SquashModelRepository(ISquashModelCache cache = null)
        {
            if (cache == null)
            {
                _cache = new SquashModelCache();
                _fakeDB = new SquashDB();
            }
            else
            {
                _cache = cache;
            }
        }

        public void AddShortenedUrl(string original, string encodedUrl)
        {
            bool dbTransactionSuccessful = _fakeDB.TryAddShortenedUrl(original, encodedUrl);
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

using SquashMyUrl.DAL.Caching;
using SquashMyUrl.DAL.DB;
using SquashMyUrl.DAL.Interfaces;
using SquashMyUrl.DAL.Utility;
using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL
{
    /// <summary>
    /// repository class that checks for instance in cache
    /// if not in cache then store in DB and cache if DB successfully stored input
    /// if in cache return found item straight away
    /// </summary>
    public class SquashModelRepository : ISquashModelRepository
    {
        private static ISquashModelCache _cache = new SquashModelCache();
        private static ISquashDB _fakeDB = new SquashDB();

        public SquashModelRepository()
        {
        }
        
        public void AddShortenedUrl(string original, string shortUrlCode)
        {
            UrlModel model = ModelBuilder.BuildModel(original, shortUrlCode);
            bool dbTransactionSuccessful = _fakeDB.TryAddShortenedUrl(model);
            if (dbTransactionSuccessful)
            {
                _cache.Add(model);
            }
        }

        public UrlModel GetUrl(string input)
        {
            return _cache.Get(input);
        }
    }
}

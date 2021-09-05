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

        public void Add(UrlModel urlModel)
        {
            _cache.Add(urlModel);
        }

        public UrlModel Get(string urlCode)
        {
            UrlModel model = _cache.Find(m => m.ID == urlCode);
            if (!string.IsNullOrWhiteSpace(model?.ID))
            {
                return model;
            }
            else
            {
                return new UrlModel();
            }
        }
    }
}

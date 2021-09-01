using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL.DB
{
    internal interface ISquashDB
    {
        //this is for when bootstrapping into the cache
        string GetShortenedUrl(string originalUrl);
        bool TryAddShortenedUrl(UrlModel urlModel);
    }
}
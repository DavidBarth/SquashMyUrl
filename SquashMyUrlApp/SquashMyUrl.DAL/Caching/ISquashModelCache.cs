using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL
{
    //this cache is specific to DAL so leaving in .DAL
    public interface ISquashModelCache
    {
        string GetShortenedUrl(string originalUrl);
        void AddShortenedUrl(UrlModel model);
    }
}